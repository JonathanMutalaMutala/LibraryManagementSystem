using LibraryManagementSystem.Application.Exceptions;
using LibraryManagementSystem.Application.Identity;
using LibraryManagementSystem.Application.Models.Jwt;
using LibraryManagementSystem.Application.Models.Login;
using LibraryManagementSystem.Application.Models.Register;
using LibraryManagementSystem.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Identity.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager; 
        private readonly SignInManager<ApplicationUser> _signInManager;  
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        #region Methode pour Login 
        /// <summary>
        /// Mise en place de Login 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException">Si L'email n'est pas valide</exception>
        /// <exception cref="BadRequestException">Si les credentials sont invalide </exception>
        public async Task<AuthResponse> Login(AuthRequest request)
        {
            // Recuperer le user Courant 
            var user = await _userManager.FindByEmailAsync(request.Email);

            //Si aucun utilisateur trouvé
            if(user is null)
            {
                throw new NotFoundException($"User with {request.Email} not found", request.Email); 
            }

            
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false); 
            
            // Si le mot de passe ne pas correct 
            if(!result.Succeeded)
            {
                throw new BadRequestException($"Credentials for {request.Email} aren't valid .");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var authResponse = new AuthResponse()
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            }; 

            return authResponse;


        }
        #endregion

        #region Register Methode 
        /// <summary>
        /// Methode permettant d'enregistrer 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var user = new ApplicationUser
            {
                Email = request.EmailAddress,
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Employee");
                return new RegistrationResponse { UserId = user.Id }; 
            }else
            {
                StringBuilder str = new StringBuilder();

                foreach (var item in result.Errors)
                {
                    str.AppendFormat("{0}\n", item.Description);
                }

                throw new BadRequestException($"{str}");
            }

        }
        #endregion

        #region GenerateToken

        /// <summary>
        /// Cette methode permet de crée un Jwt d'une durée de 15 min
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            //Recuperations des claims de L'utilisateur 
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user); // Recuperation des roles de l'utilisateur 

            var rolesClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();

            // Creation d'un tableau des revendications 

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid",user.Id)
            }.Union(userClaims)
             .Union(rolesClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)); 

            var signingCredentials = new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256);


            var jwtSecurityToken = new JwtSecurityToken(issuer: _jwtSettings.Issuer,
                                                        audience: _jwtSettings.Audience,
                                                        claims: claims,
                                                        expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                                                        signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        #endregion
    }
}

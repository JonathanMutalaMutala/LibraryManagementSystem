using LibraryManagementSystem.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public static PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

        List<ApplicationUser> lstApplicationUsers = new List<ApplicationUser>()
        {
            new ApplicationUser
            {
                Id = "ff2c1a69-9968-430f-9909-aee7d7baf13d",
                Email = "admin@localhost.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM",
                FirstName = "System",
                LastName = "Admin",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"), //HasherAPassWord(),
                EmailConfirmed = true,
                OrgId = 1,
                IsActive = true
            },
            new ApplicationUser
            {
                Id = "7a2e247f-bfb8-4e92-9afa-ff725155ca84",
                Email = "employee1@localhost.com",
                NormalizedEmail = "EMPLOYEE1@LOCALHOST.COM",
                FirstName = "System",
                LastName = "USER",
                UserName = "SysUser",
                NormalizedUserName = "SYSUSER",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                EmailConfirmed = true,
                OrgId = 1,
                IsActive = true
            },
            new ApplicationUser
            {
                Id = "678d9751-64df-458f-a48d-19cbc9a0ad84",
                Email = "client1@localhost.com",
                NormalizedEmail = "CLIENT1@LOCALHOST.COM",
                FirstName = "System",
                LastName = "Client",
                UserName = "SysClient",
                NormalizedUserName = "SYSCLIENT",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                EmailConfirmed = true,
                OrgId = 1,
                IsActive = true
            }

        };

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(lstApplicationUsers);
        }
    }
}

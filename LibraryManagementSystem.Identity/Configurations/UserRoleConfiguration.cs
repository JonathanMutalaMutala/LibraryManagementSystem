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
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        List<IdentityUserRole<string>> roles = new List<IdentityUserRole<string>>()
        {
            new IdentityUserRole<string>
            {
                //Admin
                RoleId= "a5d2fbee-ca8b-4c2f-9a65-a280099fec25",
                UserId = "ff2c1a69-9968-430f-9909-aee7d7baf13d"
            },
            new IdentityUserRole<string>
            {
                //Client
                RoleId = "ec122476-c367-4026-85ab-7ffd2413b660",
                UserId = "678d9751-64df-458f-a48d-19cbc9a0ad84"
            },
            new IdentityUserRole<string>
            {
                //Employee
                RoleId = "612c8e52-3bf9-4588-841d-fd6642fa11e7",
                UserId = "7a2e247f-bfb8-4e92-9afa-ff725155ca84"
            }
        };

        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(roles); 
        }
    }
}

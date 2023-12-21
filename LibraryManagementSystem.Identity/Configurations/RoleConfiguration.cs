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
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        List<IdentityRole> roles = new List<IdentityRole>()
        {
            new IdentityRole
            {
                Id= "a5d2fbee-ca8b-4c2f-9a65-a280099fec25",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "ec122476-c367-4026-85ab-7ffd2413b660",
                Name = "Client",
                NormalizedName = "CLIENT"
            },
            new IdentityRole
            {
                Id = "612c8e52-3bf9-4588-841d-fd6642fa11e7",
                Name = "Employee",
                NormalizedName= "EMPLOYEE"
            }
        };
 
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(roles); 
        }
    }
}

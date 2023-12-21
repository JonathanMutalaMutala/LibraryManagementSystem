using LibraryManagementSystem.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Identity.DbContext
{
    public  class LibraryManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public LibraryManagementIdentityDbContext(DbContextOptions<LibraryManagementIdentityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(LibraryManagementIdentityDbContext).Assembly);
        }

    }
}

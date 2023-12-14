using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Persistence.DatabaseContext
{
    public  class LibraryManagementSystemDbContext : DbContext
    {
        private readonly DbContextOptions<LibraryManagementSystemDbContext> options;

        public LibraryManagementSystemDbContext(DbContextOptions<LibraryManagementSystemDbContext> options) : base(options)
        {
            this.options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryManagementSystemDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}

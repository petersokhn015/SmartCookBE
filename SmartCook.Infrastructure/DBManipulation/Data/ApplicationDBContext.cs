using Microsoft.EntityFrameworkCore;
using SmartCook.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Infrastructure.DBManipulation.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Preferences> Preferences { get; set; }
        public DbSet<DBRecipe> Recipes { get; set; }
    }
}

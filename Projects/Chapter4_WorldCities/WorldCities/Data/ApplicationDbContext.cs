using Microsoft.EntityFrameworkCore;
using WorldCities.Data.Models;

namespace WorldCities.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region  Constructor
        public ApplicationDbContext() : base()
        {

        }

        public ApplicationDbContext(DbContextOptions option) : base(option)
        {

        }
        #endregion Constructor

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Map Entity Name to DB ttable names
            modelBuilder.Entity<City>().ToTable("Cites");
            modelBuilder.Entity<Country>().ToTable("Countries");

        }
        #endregion Methods

        #region Properties
        public DbSet<City> Cities {get; set;}
        public DbSet<Country> Countries {get; set;}
        #endregion Properties

    }


}


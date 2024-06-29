using Microsoft.EntityFrameworkCore;
using VolviendoACasita.Domain.Entity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace VolviendoACasita.DataAccess.Data
{
    //DbContext es una clase que nos da el entity para interacturar con la bd,
    //ApplicationDbContext hereda todas las funcionalidad de la clase
    public class ApplicationDbContext : DbContext 
    {
        //: base(options) se utiliza para pasar las opciones de configuración al constructor
        //de DbContext, asegurando que ApplicationDbContext
        //se inicialice correctamente con las configuraciones necesarias
        //para interactuar con la base de datos.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        //mapea una tabla MyEntity a la base de datos.
        public DbSet<User> User { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<LostFoundForm> LostFoundForm { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Archive> Archive { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Breed> Breed { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Request> Request { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Species>().HasData(
                new Species { Id = 1, Description = "Perro" },
                new Species { Id = 2, Description = "Gato" }
            );

            modelBuilder.Entity<Breed>().HasData(
                // Razas de gato
                new Breed { Id = 1, Description = "Siamés", SpeciesId = 2 },
                new Breed { Id = 2, Description = "Persa", SpeciesId = 2 },
                new Breed { Id = 3, Description = "Maine Coon", SpeciesId = 2 },
                new Breed { Id = 4, Description = "Bengala", SpeciesId = 2 },
                new Breed { Id = 5, Description = "Ragdoll", SpeciesId = 2 },

                // Razas de perro
                new Breed { Id = 6, Description = "Labrador Retriever", SpeciesId = 1 },
                new Breed { Id = 7, Description = "Pastor Alemán", SpeciesId = 1 },
                new Breed { Id = 8, Description = "Golden Retriever", SpeciesId = 1 },
                new Breed { Id = 9, Description = "Bulldog", SpeciesId = 1 },
                new Breed { Id = 10, Description = "Beagle", SpeciesId = 1 }
            );

            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, Description = "Palermo" },
                new Location { Id = 2, Description = "Recoleta" },
                new Location { Id = 3, Description = "San Telmo" },
                new Location { Id = 4, Description = "La Boca" },
                new Location { Id = 5, Description = "Belgrano" },
                new Location { Id = 6, Description = "Caballito" },
                new Location { Id = 7, Description = "Villa Crespo" },
                new Location { Id = 8, Description = "Almagro" },
                new Location { Id = 9, Description = "Flores" },
                new Location { Id = 10, Description = "Boedo" }
            );

            modelBuilder.Entity<Province>().HasData(
                new Province { Id = 1, Description = "Ciudad Autónoma de Buenos Aires" }
            );
        }
    }
}

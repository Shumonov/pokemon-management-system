using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PokemonEH.Models;

namespace PokemonEH.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PokemonElementType> Types { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed PokemonElementTypes
            modelBuilder.Entity<PokemonElementType>().HasData(
                new PokemonElementType { Id = 1, Name = "Normal" },
                new PokemonElementType { Id = 2, Name = "Fire" },
                new PokemonElementType { Id = 3, Name = "Water" },
                new PokemonElementType { Id = 4, Name = "Grass" },
                new PokemonElementType { Id = 5, Name = "Flying" },
                new PokemonElementType { Id = 6, Name = "Fighting" },
                new PokemonElementType { Id = 7, Name = "Poison" },
                new PokemonElementType { Id = 8, Name = "Electric" },
                new PokemonElementType { Id = 9, Name = "Ground" },
                new PokemonElementType { Id = 10, Name = "Rock" },
                new PokemonElementType { Id = 11, Name = "Psychic" },
                new PokemonElementType { Id = 12, Name = "Ice" },
                new PokemonElementType { Id = 13, Name = "Bug" },
                new PokemonElementType { Id = 14, Name = "Ghost" },
                new PokemonElementType { Id = 15, Name = "Steel" },
                new PokemonElementType { Id = 16, Name = "Dragon" },
                new PokemonElementType { Id = 17, Name = "Dark" },
                new PokemonElementType { Id = 18, Name = "Fairy" }
            );

            modelBuilder.Entity<PokemonType>()
                .HasKey(pt => new { pt.PokemonId, pt.TypeId });
        }

        public DbSet<PokemonEH.Models.Pokemon>? Pokemon { get; set; }
    }
}

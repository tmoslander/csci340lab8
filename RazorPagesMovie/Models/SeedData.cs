using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;

namespace RazorPagesMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesMovieContext>>()))
        {
            if (context == null || context.Card == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Card.Any())
            {
                return;   // DB has been seeded
            }

            context.Card.AddRange(
                new Card
                {
                    Id = 1,
                    Name = "Umbreon VMax",
                    PokemonType = "Dark",
                    ExpansionSet = "Evolving Skies",
                    Price = 541.57M
                },

                new Card
                {
                    Id = 2,
                    Name = "Charizard",
                    PokemonType = "Fire",
                    ExpansionSet = "Base Set 2",
                    Price = 237.43M
                },

                new Card
                {
                    Id = 3,
                    Name = "Lugia",
                    PokemonType = "Colorless",
                    ExpansionSet = "Neo Genesis",
                    Price = 529.17M
                },

                new Card
                {
                    Id = 4,
                    Name = "Suicune Star",
                    PokemonType = "Water",
                    ExpansionSet = "Unseen Forces",
                    Price = 303.03M
                },

                new Card
                {
                    Id = 5,
                    Name = "Gengar",
                    PokemonType = "Psychic",
                    ExpansionSet = "Skyridge",
                    Price = 332.66M
                }
            );
            context.SaveChanges();
        }
    }
}
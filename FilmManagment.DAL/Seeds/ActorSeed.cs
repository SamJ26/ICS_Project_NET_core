
using FilmManagment.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace FilmManagment.DAL.Seeds
{
    // TODO: remake this class to universal class which will contain seeds for all entities.
    //       modelBuilder.Entity<ActorEntity>().HasData(Actor_1);
    //       modelBuilder.Entity<ActorEntity>().HasData(Film_1);
    //       modelBuilder.Entity<ActorEntity>().HasData(Director_1);

    public class ActorSeed
    {
        // Vytvorime noveho herca a dame mu nejake informacie
        public static ActorEntity Actor_1 { get; } = new ActorEntity()
        {
            Id = Guid.Parse("818f1def-204e-44da-b764-ca28c75e2acc"),
            FirstName = "John",
            SecondName = "Stone",
            WikiUrl = "wikiurl",
            PhotoFilePath = @"c:/blabla/nic/bla"

            // TODO: add generic lists and other properties

        };

        // Touto metodou vytvorime model Entity ActorEntity, ktory potom realne zapiseme do databazy pomocou DbContext.OnModelCreating() metody
        // Metodu OnModelCreating() musime najskor overridenut v AppDbContext, pricom jej nadefinujeme vztahy medzi tabulkami v DB
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorEntity>().HasData(Actor_1);
        }
    }
}


using FilmManagment.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace FilmManagment.DAL.Seeds
{
    // TODO: ked budeme seedovat info napr. pre film ... musi byt nova classa FilmSeed a jej vlastny Seed alebo
    //       len premenujem tuto classu napr. na SeedInfo a v nej budu dalsie fieldy napr. Film_1, Director_1 atd a vsetkych
    //       potom dame do jednej spolocnej metody seed() na konci nejako takto:
    //        modelBuilder.Entity<ActorEntity>().HasData(Actor_1);
    //        modelBuilder.Entity<ActorEntity>().HasData(Film_1);
    //        modelBuilder.Entity<ActorEntity>().HasData(Director_1);

    // TODO: ako naseedovat generic listy ?

    public class ActorSeed
    {
        // Vytvorime noveho herca a dame mu nejake informacie
        public static readonly ActorEntity Actor_1 = new ActorEntity()
        {
            Id = Guid.Parse("818f1def-204e-44da-b764-ca28c75e2acc"),
            FirstName = "John",
            SecondName = "Stone",
            WikiUrl = "wikiurl",
            PhotoFilePath = @"c:/blabla/nic/bla"
        };

        // Touto metodou vytvorime model Entity ActorEntity, ktory potom realne zapiseme do databazy pomocou DbContext.OnModelCreating() metody
        // Metodu OnModelCreating() musime najskor overridenut v AppDbContext, pricom jej nadefinujeme vztahy medzi tabulkami v DB
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorEntity>().HasData(Actor_1);
        }
    }
}

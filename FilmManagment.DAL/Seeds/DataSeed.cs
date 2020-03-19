
using FilmManagment.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace FilmManagment.DAL.Seeds
{
    public class DataSeed
    {
        public static ActorEntity Actor_1 { get; } = new ActorEntity()
        {
            Id = Guid.Parse("818f1def-204e-44da-b764-ca28c75e2acc"),
            FirstName = "John",
            SecondName = "Stone",
            WikiUrl = "wikiurl",
            PhotoFilePath = @"c:/blabla/nic/bla"

            // TODO: add generic lists and other properties

        };

        public static DirectorEntity Director_1 { get; } = new DirectorEntity()
        {      
            // TODO: add informations
        };

        public static RatingEntity Rating_1 { get; } = new RatingEntity()
        {
            // TODO: add informations
        };

        public static FilmEntity Film_1 { get; } = new FilmEntity()
        {
            // TODO: add informations
        };

        // Touto metodou vytvorime model danych entit, ktory potom realne zapiseme do databazy pomocou DbContext.OnModelCreating() metody
        // Metodu OnModelCreating() musime najskor overridenut v AppDbContext, pricom jej nadefinujeme vztahy medzi tabulkami v DB
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorEntity>().HasData(Actor_1);
            modelBuilder.Entity<ActorEntity>().HasData(Director_1);
            modelBuilder.Entity<ActorEntity>().HasData(Rating_1);
            modelBuilder.Entity<ActorEntity>().HasData(Film_1);
        }
    }
}

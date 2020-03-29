
using FilmManagment.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace FilmManagment.DAL.Seeds
{
    public class DataSeed
    {
        public static ActorEntity Actor_1 { get; } = new ActorEntity()
        {
            Id = Guid.Parse("63156919-53f4-4a7a-b099-1c57bace2307"),
            FirstName = "John",
            SecondName = "Stone",
            Age = 40,
            WikiUrl = "wikiurl",
            PhotoFilePath = @"c:/blabla/nic/bla"
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

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorEntity>().HasData(Actor_1);
            //modelBuilder.Entity<ActorEntity>().HasData(Director_1);
            //modelBuilder.Entity<ActorEntity>().HasData(Rating_1);
            //modelBuilder.Entity<ActorEntity>().HasData(Film_1);
        }
    }
}


using System;
using System.Linq;
using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Enums;
using FilmManagment.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FilmManagment.DAL.Tests
{
    public class AppDbContextTests : IDisposable
    {
        private readonly DbContextInMemoryFactory dbContextFactory;
        private readonly AppDbContext appDbContextTestUnit;                     // TODO: Is it a good name ??

        public AppDbContextTests()                                              // TODO: pre istotu vysvetlit tento kus kodu
        {
            dbContextFactory = new DbContextInMemoryFactory(nameof(AppDbContext));
            appDbContextTestUnit = dbContextFactory.CreateDbContext();
            appDbContextTestUnit.Database.EnsureCreated();
        }

        // Attribute which indicates that it is a fact that should be run by the test runner
        [Fact]
        public void AddNewActor()
        {
            // Creating new entity for testing called myActor
            var myActor = new ActorEntity()
            {
                FirstName = "John",
                SecondName = "Stone",
                Age = 43,
                WikiUrl = "Wikipedia",
                PhotoFilePath = "Some_path",
                ActedMovies =
                {
                    new FilmEntity
                    {
                        CzechName = "Mackopes",
                        OriginalName = "Catdog",
                        CountryOfOrigin = "Canada",
                        Description = "Film about strange animal",
                        ImageFilePath = "filePath",
                        GenreOfFilm = Genre.ComedyFilm,
                        LengthInMinutes = new TimeSpan(1, 20, 5),
                        // TODO: add director
                        // TODO: add actors
                        // TODO: add directors
                    }
                }
            };

            // Adding myActor to database
            appDbContextTestUnit.Actors.Add(myActor);
            appDbContextTestUnit.SaveChanges();

            // Tasting of content ( myActor ) which was saved to database
            
            using ( var tempDbCOntext = dbContextFactory.CreateDbContext())
            {
                var retrievedActor = tempDbCOntext.Actors.Single(entity => entity.Id == myActor.Id);
                Assert.Equal(myActor, retrievedActor, ActorEntity.ActorEqualityComparer);
                
            }

        }

        public void Dispose()
        {
            appDbContextTestUnit?.Dispose();
        }
    }
}

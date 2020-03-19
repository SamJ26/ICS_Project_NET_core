
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
        private readonly AppDbContext appDbContextTestUnit;

        public AppDbContextTests()
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
                
                // TODO: add all properties

            };

            // Adding myActor to database
            appDbContextTestUnit.Actors.Add(myActor);
            appDbContextTestUnit.SaveChanges();

            // Tasting of content ( myActor ) which was saved to database           
            using ( var tempDbCOntext = dbContextFactory.CreateDbContext())
            {
                var retrievedActor = tempDbCOntext.Actors.Single(entity => entity.Id == myActor.Id);

                // TODO: add proper EC in Assert func.

                //Assert.Equal(myActor, retrievedActor, ActorEntity.ActorEqualityComparer);        
            }
        }

        public void Dispose()
        {
            appDbContextTestUnit?.Dispose();
        }
    }
}

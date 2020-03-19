
using System;
using System.Linq;
using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Enums;
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

        [Fact]
        public void AddNewFilm()
        {
            var myNewFilm = new FilmEntity()
            {
                OriginalName = "Iron Man",
                CzechName = "Zelezny muz",
                CountryOfOrigin = "Canada",
                GenreOfFilm = Genre.ActionFilm,
                Directors =
                {
                    new FilmDirectorEntity
                    {
                        Director = new DirectorEntity
                        {
                            FirstName = "John",
                            SecondName = "Mayer",
                            Age = 55
                        }
                    }
                },
                Actors =
                {
                    new FilmActorEntity
                    {
                        Actor = new ActorEntity
                        {
                            FirstName = "Jacob",
                            SecondName = "King",
                            Age = 18
                        }
                    }
                },
                Ratings =
                {
                    new RatingEntity
                    {
                        RatingInPercents = 90,
                        TextRating = "Very good film"
                    }

                }
            };

            // Adding myNewFilm to database
            appDbContextTestUnit.Films.Add(myNewFilm);
            appDbContextTestUnit.SaveChanges();

            // Tasting of content ( myNewFilm ) which was saved to database           
            using (var tempDbCOntext = dbContextFactory.CreateDbContext())
            {
                var retrievedFilm = tempDbCOntext.Films
                    .Include(entity => entity.Directors)
                        .ThenInclude(connectionTable => connectionTable.Director)
                    .Include(entity => entity.Actors)
                        .ThenInclude(connectionTable => connectionTable.Actor)
                    .Include(entity => entity.Ratings)
                    .Single(entity => entity.Id == myNewFilm.Id);                    // ako mozu byt tieto dve IDcka porovnavane ??

                Assert.Equal(myNewFilm,retrievedFilm, FilmEntity.FilmEntityComparer);
            }
        }

        public void Dispose()
        {
            appDbContextTestUnit?.Dispose();
        }
    }
}

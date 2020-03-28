
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

            // Assert         
            using (var tempDbContext = dbContextFactory.CreateDbContext())
            {
                var retrievedFilm = tempDbContext.Films
                    .Include(entity => entity.Directors)
                        .ThenInclude(connectionTable => connectionTable.Director)
                    .Include(entity => entity.Actors)
                        .ThenInclude(connectionTable => connectionTable.Actor)
                    .Include(entity => entity.Ratings)
                    .Single(entity => entity.Id == myNewFilm.Id);

                Assert.Equal(myNewFilm,retrievedFilm, FilmEntity.FilmEntityComparer);
            }
        }

        [Fact]
        public void AddNewDirector()
        {
            var myNewDirector = new DirectorEntity
            {
                Id = new Guid("7B682BDD-7FC6-406C-93EE-BAD769201516"),
                Age = 55,
                FirstName = "Jožko",
                SecondName = "Podržho",
                PhotoFilePath = @":C\Windows\fotka.jpg",
                WikiUrl = @"www.wikipedia.com/jozkoPodrzho",
                DirectedMovies =
                {
                    new FilmDirectorEntity
                    {
                        Film = new FilmEntity
                        {
                            OriginalName = "Iron Man",
                            CzechName = "Zelezny muz",
                            CountryOfOrigin = "Canada",
                            GenreOfFilm = Genre.ActionFilm,
                            Description = "Film o zeleznem muzi",
                            ImageFilePath = @":C\Windows\filmFotka.jpg",
                            LengthInMinutes = new TimeSpan(1,30,0)
                        }
                    },
                    new FilmDirectorEntity
                    {
                        Film = new FilmEntity
                        {
                        OriginalName = "Spiderman",
                        CzechName = "Pavouci muz",
                        CountryOfOrigin = "Canada",
                        GenreOfFilm = Genre.ActionFilm,
                        Description = "Film o pavoucim muzi",
                        ImageFilePath = @":C\Windows\filmFotkaSpider.jpg",
                        LengthInMinutes = new TimeSpan(1,30,0)
                        }
                    }
                }
            };
            appDbContextTestUnit.Directors.Add(myNewDirector);
            appDbContextTestUnit.SaveChanges();

            using (var tempDbContext = dbContextFactory.CreateDbContext())
            {
                var retrievedDirector = tempDbContext.Directors
                    .Include(entity => entity.DirectedMovies)
                        .ThenInclude(connectionTable => connectionTable.Film)
                    .Single(entity => entity.Id == myNewDirector.Id);

                Assert.Equal(myNewDirector, retrievedDirector, DirectorEntity.DirectorEntityComparer);
            }
        }

        [Fact]
        public void AddNewActor()
        {
            var myNewActor = new ActorEntity
            {
                Id = new Guid("591C6ACC-191B-4539-A4B9-42C5C280E4B5"),
                Age = 55,
                FirstName = "Jožko",
                SecondName = "Podržho",
                PhotoFilePath = @":C\Windows\fotka.jpg",
                WikiUrl = @"www.wikipedia.com/jozkoPodrzho",
                ActedMovies =
                {
                    new FilmActorEntity()
                    {
                        Film = new FilmEntity
                        {
                            OriginalName = "Iron Man",
                            CzechName = "Zelezny muz",
                            CountryOfOrigin = "Canada",
                            GenreOfFilm = Genre.ActionFilm,
                            Description = "Film o zeleznem muzi",
                            ImageFilePath = @":C\Windows\filmFotka.jpg",
                            LengthInMinutes = new TimeSpan(1,30,0)
                        }
                    },

                    new FilmActorEntity()
                    {
                        Film = new FilmEntity
                        {
                        OriginalName = "Spiderman",
                        CzechName = "Pavouci muz",
                        CountryOfOrigin = "Canada",
                        GenreOfFilm = Genre.ActionFilm,
                        Description = "Film o pavoucim muzi",
                        ImageFilePath = @":C\Windows\filmFotkaSpider.jpg",
                        LengthInMinutes = new TimeSpan(1,30,0)
                        }
                    }
                }
            };
            appDbContextTestUnit.Actors.Add(myNewActor);
            appDbContextTestUnit.SaveChanges();

            using (var tempDbContext = dbContextFactory.CreateDbContext())
            {
                var retrievedActor = tempDbContext.Actors
                    .Include(entity => entity.ActedMovies)
                        .ThenInclude(connectionTable => connectionTable.Film)
                    .Single(entity => entity.Id == myNewActor.Id);

                Assert.Equal(myNewActor, retrievedActor, ActorEntity.ActorEntityComparer);
            }
        }

        [Fact]
        public void AddNewRating()
        {
            var myNewRate = new RatingEntity()
            {
                Id = new Guid("591C6ACC-191B-4539-A4B9-42C5C280E4B5"),
                Film = new FilmEntity
                {
                    OriginalName = "Guns Akimbo",
                    CzechName = "Guns Akimbo",
                    CountryOfOrigin = "Canada",
                    GenreOfFilm = Genre.ActionFilm,
                    Description = "Nebudu spoilovat, ale je tam ten týpek z Harry Pottera ;)",
                    ImageFilePath = @":C\Windows\filmFotka.jpg",
                    LengthInMinutes = new TimeSpan(1, 35, 0)
                },
                RatingInPercents = 75,
                TextRating = "Hodně dobrej film, #ZrovnaJsemZkouklJedenPo3Pivách, Doporučuji potomhle psát kód (y)"
            };

            appDbContextTestUnit.Ratings.Add(myNewRate);
            appDbContextTestUnit.SaveChanges();

            using (var tempDbContext = dbContextFactory.CreateDbContext())
            {
                var retrievedRate = tempDbContext.Ratings
                    .Include(i => i.Film)
                    .Single(entity => entity.Id == myNewRate.Id);

                Assert.Equal(myNewRate, retrievedRate, RatingEntity.RatingEntityComparer);
            }
        }

        public void Dispose()
        {
            appDbContextTestUnit?.Dispose();
        }
    }
}

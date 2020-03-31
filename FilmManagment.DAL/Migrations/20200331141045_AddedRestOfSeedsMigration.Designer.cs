﻿// <auto-generated />
using System;
using FilmManagment.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FilmManagment.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200331141045_AddedRestOfSeedsMigration")]
    partial class AddedRestOfSeedsMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FilmManagment.DAL.Entities.ActorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("FirstName");

                    b.Property<string>("PhotoFilePath");

                    b.Property<string>("SecondName");

                    b.Property<string>("WikiUrl");

                    b.HasKey("Id");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("63156915-53f4-4a7a-b099-1c57bace2307"),
                            Age = 59,
                            FirstName = "John",
                            PhotoFilePath = "c:/blabla/nic/bla/JohnStone",
                            SecondName = "Stone",
                            WikiUrl = "wikiurlJS"
                        },
                        new
                        {
                            Id = new Guid("562ed03a-dc26-41cf-8a01-ee78afd22541"),
                            Age = 50,
                            FirstName = "Axel",
                            PhotoFilePath = "c:/blabla/nic/bla/AxelBrown",
                            SecondName = "Brown",
                            WikiUrl = "wikiurlAB"
                        },
                        new
                        {
                            Id = new Guid("5aae9cc3-b880-441c-b88e-ca00242db99f"),
                            Age = 21,
                            FirstName = "Mical",
                            PhotoFilePath = "c:/blabla/nic/bla/MicalMorris",
                            SecondName = "Morris",
                            WikiUrl = "wikiurlMM"
                        },
                        new
                        {
                            Id = new Guid("7793e739-6940-4c51-9f37-340be6e613a9"),
                            Age = 23,
                            FirstName = "Garreth",
                            PhotoFilePath = "c:/blabla/nic/bla/GarrethClark",
                            SecondName = "Clark",
                            WikiUrl = "wikiurlGC"
                        });
                });

            modelBuilder.Entity("FilmManagment.DAL.Entities.DirectorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("FirstName");

                    b.Property<string>("PhotoFilePath");

                    b.Property<string>("SecondName");

                    b.Property<string>("WikiUrl");

                    b.HasKey("Id");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("880c8cf4-21cd-4c7a-a4a9-917502bd7db4"),
                            Age = 56,
                            FirstName = "Adam",
                            PhotoFilePath = "c:/blabla/nic/bla/AdamSilver",
                            SecondName = "Silver",
                            WikiUrl = "wikiurlAS"
                        },
                        new
                        {
                            Id = new Guid("d4a48f01-c183-4b22-a4a7-5fdf1fa2634f"),
                            Age = 60,
                            FirstName = "George",
                            PhotoFilePath = "c:/blabla/nic/bla/GeorgeBlack",
                            SecondName = "Black",
                            WikiUrl = "wikiurlGB"
                        },
                        new
                        {
                            Id = new Guid("011a72e9-827c-48e4-ac61-da46ab5756e3"),
                            Age = 35,
                            FirstName = "Rory",
                            PhotoFilePath = "c:/blabla/nic/bla/RorySabatini",
                            SecondName = "Sabatini",
                            WikiUrl = "wikiurlRS"
                        },
                        new
                        {
                            Id = new Guid("9033b72b-6340-4667-8a14-b6aed51697b6"),
                            Age = 42,
                            FirstName = "Paul",
                            PhotoFilePath = "c:/blabla/nic/bla/PaulGasol",
                            SecondName = "Gasol",
                            WikiUrl = "wikiurlPG"
                        });
                });

            modelBuilder.Entity("FilmManagment.DAL.Entities.FilmActorEntity", b =>
                {
                    b.Property<Guid>("FilmId");

                    b.Property<Guid>("ActorId");

                    b.Property<Guid>("Id");

                    b.HasKey("FilmId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("FilmsActorsEntity");

                    b.HasData(
                        new
                        {
                            FilmId = new Guid("07cab248-0bcf-4e36-a954-b4f8f619579e"),
                            ActorId = new Guid("63156915-53f4-4a7a-b099-1c57bace2307"),
                            Id = new Guid("5c0154f3-6f6a-473c-8904-1a56dc39eb96")
                        },
                        new
                        {
                            FilmId = new Guid("5729a349-b4ec-4c7e-ab3b-86ae981003d9"),
                            ActorId = new Guid("562ed03a-dc26-41cf-8a01-ee78afd22541"),
                            Id = new Guid("4117bfcc-b81f-4e73-b8cc-af8a14135621")
                        });
                });

            modelBuilder.Entity("FilmManagment.DAL.Entities.FilmDirectorEntity", b =>
                {
                    b.Property<Guid>("FilmId");

                    b.Property<Guid>("DirectorId");

                    b.Property<Guid>("Id");

                    b.HasKey("FilmId", "DirectorId");

                    b.HasIndex("DirectorId");

                    b.ToTable("FilmsDirectorsEntity");

                    b.HasData(
                        new
                        {
                            FilmId = new Guid("07cab248-0bcf-4e36-a954-b4f8f619579e"),
                            DirectorId = new Guid("880c8cf4-21cd-4c7a-a4a9-917502bd7db4"),
                            Id = new Guid("8805e086-0206-4b9e-8fba-031a2f04092a")
                        },
                        new
                        {
                            FilmId = new Guid("5729a349-b4ec-4c7e-ab3b-86ae981003d9"),
                            DirectorId = new Guid("d4a48f01-c183-4b22-a4a7-5fdf1fa2634f"),
                            Id = new Guid("9e00af51-7eba-496a-9e72-254eaa9b674d")
                        });
                });

            modelBuilder.Entity("FilmManagment.DAL.Entities.FilmEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryOfOrigin");

                    b.Property<string>("CzechName");

                    b.Property<string>("Description");

                    b.Property<int>("GenreOfFilm");

                    b.Property<string>("ImageFilePath");

                    b.Property<TimeSpan>("LengthInMinutes");

                    b.Property<string>("OriginalName");

                    b.HasKey("Id");

                    b.ToTable("Films");

                    b.HasData(
                        new
                        {
                            Id = new Guid("07cab248-0bcf-4e36-a954-b4f8f619579e"),
                            CountryOfOrigin = "USA",
                            CzechName = "White house",
                            Description = "Movie about white house",
                            GenreOfFilm = 1,
                            ImageFilePath = "c:/blabla/nic/bla/WhiteHouse",
                            LengthInMinutes = new TimeSpan(0, 2, 56, 30, 0),
                            OriginalName = "Bily dum"
                        },
                        new
                        {
                            Id = new Guid("5729a349-b4ec-4c7e-ab3b-86ae981003d9"),
                            CountryOfOrigin = "Denmark",
                            CzechName = "Dansky hrdina",
                            Description = "Film about Danish Hero",
                            GenreOfFilm = 2,
                            ImageFilePath = "c:/blabla/nic/bla/DanishHero",
                            LengthInMinutes = new TimeSpan(0, 2, 56, 30, 0),
                            OriginalName = "Danish Hero"
                        },
                        new
                        {
                            Id = new Guid("03b8ccb9-c1c2-4251-b86e-4a2a0baccfc7"),
                            CountryOfOrigin = "England",
                            CzechName = "Velký návrat",
                            Description = "Movie about one of the best sport comeback",
                            GenreOfFilm = 7,
                            ImageFilePath = "c:/blabla/nic/bla/BigComeback",
                            LengthInMinutes = new TimeSpan(0, 2, 56, 30, 0),
                            OriginalName = "Big Comeback"
                        });
                });

            modelBuilder.Entity("FilmManagment.DAL.Entities.RatingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("FilmId");

                    b.Property<int>("RatingInPercents");

                    b.Property<string>("TextRating");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aa835099-587e-4dbb-b48e-f9c402f978a4"),
                            FilmId = new Guid("07cab248-0bcf-4e36-a954-b4f8f619579e"),
                            RatingInPercents = 87,
                            TextRating = "Best movie I have seen so far"
                        },
                        new
                        {
                            Id = new Guid("2ed269bc-2c39-457e-bf7c-96258b3d247a"),
                            FilmId = new Guid("5729a349-b4ec-4c7e-ab3b-86ae981003d9"),
                            RatingInPercents = 50,
                            TextRating = "Pretty average"
                        });
                });

            modelBuilder.Entity("FilmManagment.DAL.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("FirstName");

                    b.Property<string>("NickName");

                    b.Property<string>("Password");

                    b.Property<string>("SecondName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FilmManagment.DAL.Entities.FilmActorEntity", b =>
                {
                    b.HasOne("FilmManagment.DAL.Entities.ActorEntity", "Actor")
                        .WithMany("ActedMovies")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FilmManagment.DAL.Entities.FilmEntity", "Film")
                        .WithMany("Actors")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FilmManagment.DAL.Entities.FilmDirectorEntity", b =>
                {
                    b.HasOne("FilmManagment.DAL.Entities.DirectorEntity", "Director")
                        .WithMany("DirectedMovies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FilmManagment.DAL.Entities.FilmEntity", "Film")
                        .WithMany("Directors")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FilmManagment.DAL.Entities.RatingEntity", b =>
                {
                    b.HasOne("FilmManagment.DAL.Entities.FilmEntity", "Film")
                        .WithMany("Ratings")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

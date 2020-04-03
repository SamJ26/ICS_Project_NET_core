using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace FilmManagment.DAL.Migrations
{
	public partial class InitialCreate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Actors",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					FirstName = table.Column<string>(nullable: true),
					SecondName = table.Column<string>(nullable: true),
					Age = table.Column<int>(nullable: false),
					WikiUrl = table.Column<string>(nullable: true),
					PhotoFilePath = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Actors", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Directors",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					FirstName = table.Column<string>(nullable: true),
					SecondName = table.Column<string>(nullable: true),
					Age = table.Column<int>(nullable: false),
					WikiUrl = table.Column<string>(nullable: true),
					PhotoFilePath = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Directors", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Films",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					OriginalName = table.Column<string>(nullable: true),
					CzechName = table.Column<string>(nullable: true),
					CountryOfOrigin = table.Column<string>(nullable: true),
					Description = table.Column<string>(nullable: true),
					ImageFilePath = table.Column<string>(nullable: true),
					GenreOfFilm = table.Column<int>(nullable: false),
					LengthInMinutes = table.Column<TimeSpan>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Films", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					FirstName = table.Column<string>(nullable: true),
					SecondName = table.Column<string>(nullable: true),
					Age = table.Column<int>(nullable: false),
					NickName = table.Column<string>(nullable: true),
					Password = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "FilmActorEntity",
				columns: table => new
				{
					FilmId = table.Column<Guid>(nullable: false),
					ActorId = table.Column<Guid>(nullable: false),
					Id = table.Column<Guid>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_FilmActorEntity", x => new { x.FilmId, x.ActorId });
					table.ForeignKey(
						name: "FK_FilmActorEntity_Actors_ActorId",
						column: x => x.ActorId,
						principalTable: "Actors",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_FilmActorEntity_Films_FilmId",
						column: x => x.FilmId,
						principalTable: "Films",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "FilmDirectorEntity",
				columns: table => new
				{
					FilmId = table.Column<Guid>(nullable: false),
					DirectorId = table.Column<Guid>(nullable: false),
					Id = table.Column<Guid>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_FilmDirectorEntity", x => new { x.FilmId, x.DirectorId });
					table.ForeignKey(
						name: "FK_FilmDirectorEntity_Directors_DirectorId",
						column: x => x.DirectorId,
						principalTable: "Directors",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_FilmDirectorEntity_Films_FilmId",
						column: x => x.FilmId,
						principalTable: "Films",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Ratings",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					RatingInPercents = table.Column<int>(nullable: false),
					TextRating = table.Column<string>(nullable: true),
					FilmId = table.Column<Guid>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Ratings", x => x.Id);
					table.ForeignKey(
						name: "FK_Ratings_Films_FilmId",
						column: x => x.FilmId,
						principalTable: "Films",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.InsertData(
				table: "Actors",
				columns: new[] { "Id", "Age", "FirstName", "PhotoFilePath", "SecondName", "WikiUrl" },
				values: new object[] { new Guid("63156919-53f4-4a7a-b099-1c57bace2307"), 40, "John", "c:/blabla/nic/bla", "Stone", "wikiurl" });

			migrationBuilder.CreateIndex(
				name: "IX_FilmActorEntity_ActorId",
				table: "FilmActorEntity",
				column: "ActorId");

			migrationBuilder.CreateIndex(
				name: "IX_FilmDirectorEntity_DirectorId",
				table: "FilmDirectorEntity",
				column: "DirectorId");

			migrationBuilder.CreateIndex(
				name: "IX_Ratings_FilmId",
				table: "Ratings",
				column: "FilmId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "FilmActorEntity");

			migrationBuilder.DropTable(
				name: "FilmDirectorEntity");

			migrationBuilder.DropTable(
				name: "Ratings");

			migrationBuilder.DropTable(
				name: "Users");

			migrationBuilder.DropTable(
				name: "Actors");

			migrationBuilder.DropTable(
				name: "Directors");

			migrationBuilder.DropTable(
				name: "Films");
		}
	}
}

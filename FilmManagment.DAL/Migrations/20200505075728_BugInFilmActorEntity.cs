using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmManagment.DAL.Migrations
{
	public partial class BugInFilmActorEntity : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
				name: "PK_FilmsDirectorsEntity",
				table: "FilmsDirectorsEntity");

			migrationBuilder.DropPrimaryKey(
				name: "PK_FilmsActorsEntity",
				table: "FilmsActorsEntity");

			migrationBuilder.AddPrimaryKey(
				name: "PK_FilmsDirectorsEntity",
				table: "FilmsDirectorsEntity",
				column: "Id");

			migrationBuilder.AddPrimaryKey(
				name: "PK_FilmsActorsEntity",
				table: "FilmsActorsEntity",
				column: "Id");

			migrationBuilder.CreateIndex(
				name: "IX_FilmsDirectorsEntity_FilmId",
				table: "FilmsDirectorsEntity",
				column: "FilmId");

			migrationBuilder.CreateIndex(
				name: "IX_FilmsActorsEntity_FilmId",
				table: "FilmsActorsEntity",
				column: "FilmId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
				name: "PK_FilmsDirectorsEntity",
				table: "FilmsDirectorsEntity");

			migrationBuilder.DropIndex(
				name: "IX_FilmsDirectorsEntity_FilmId",
				table: "FilmsDirectorsEntity");

			migrationBuilder.DropPrimaryKey(
				name: "PK_FilmsActorsEntity",
				table: "FilmsActorsEntity");

			migrationBuilder.DropIndex(
				name: "IX_FilmsActorsEntity_FilmId",
				table: "FilmsActorsEntity");

			migrationBuilder.AddPrimaryKey(
				name: "PK_FilmsDirectorsEntity",
				table: "FilmsDirectorsEntity",
				columns: new[] { "FilmId", "DirectorId" });

			migrationBuilder.AddPrimaryKey(
				name: "PK_FilmsActorsEntity",
				table: "FilmsActorsEntity",
				columns: new[] { "FilmId", "ActorId" });
		}
	}
}

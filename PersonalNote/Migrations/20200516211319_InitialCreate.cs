using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalNote.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JournalReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalReport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemName = table.Column<string>(nullable: false),
                    WorkoutDate = table.Column<DateTime>(nullable: false),
                    Calories = table.Column<float>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutReport", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JournalReport");

            migrationBuilder.DropTable(
                name: "WorkoutReport");
        }
    }
}

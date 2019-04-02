using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalNote.Migrations
{
    public partial class AddedFields1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Calories",
                table: "WorkoutReport",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "WorkoutReport",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "WorkoutReport",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "WorkoutReport");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "WorkoutReport");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "WorkoutReport");
        }
    }
}

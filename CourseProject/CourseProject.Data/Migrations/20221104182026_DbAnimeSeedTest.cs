using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseProject.Data.Migrations
{
    public partial class DbAnimeSeedTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Animes",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "EpisodeCount",
                table: "Animes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "Animes",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Synopsis",
                table: "Animes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EpisodeCount",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "Synopsis",
                table: "Animes");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Animes",
                newName: "Name");
        }
    }
}

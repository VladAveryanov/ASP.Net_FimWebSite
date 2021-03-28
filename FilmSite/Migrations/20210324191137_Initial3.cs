using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmSite.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "currentFilm",
                table: "Films");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Films",
                newName: "ShortDescription");

            migrationBuilder.AddColumn<int>(
                name: "Dislikes",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Films",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Films",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Dislikes = table.Column<int>(type: "int", nullable: false),
                    FilmID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropColumn(
                name: "Dislikes",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Films");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Films",
                newName: "Description");

            migrationBuilder.AddColumn<bool>(
                name: "currentFilm",
                table: "Films",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

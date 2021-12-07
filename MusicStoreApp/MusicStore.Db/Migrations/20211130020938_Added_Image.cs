using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStore.Db.Migrations
{
    public partial class Added_Image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Artists");

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Artists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Artists");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

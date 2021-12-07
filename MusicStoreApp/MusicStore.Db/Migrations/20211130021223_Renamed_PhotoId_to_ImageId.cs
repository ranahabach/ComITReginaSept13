using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStore.Db.Migrations
{
    public partial class Renamed_PhotoId_to_ImageId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoId",
                table: "Artists",
                newName: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Artists",
                newName: "PhotoId");
        }
    }
}

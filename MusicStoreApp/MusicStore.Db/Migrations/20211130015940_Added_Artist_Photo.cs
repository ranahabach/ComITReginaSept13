using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStore.Db.Migrations
{
    public partial class Added_Artist_Photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Artists");
        }
    }
}

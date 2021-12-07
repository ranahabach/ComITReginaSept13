using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStore.Db.Migrations
{
    public partial class Added_Artist_Album_Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Albums",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Albums");
        }
    }
}

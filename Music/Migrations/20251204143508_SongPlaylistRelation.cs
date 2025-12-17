using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Music.Migrations
{
    /// <inheritdoc />
    public partial class SongPlaylistRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "Playlist",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_SongId",
                table: "Playlist",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlist_Songs_SongId",
                table: "Playlist",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlist_Songs_SongId",
                table: "Playlist");

            migrationBuilder.DropIndex(
                name: "IX_Playlist_SongId",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "Playlist");
        }
    }
}

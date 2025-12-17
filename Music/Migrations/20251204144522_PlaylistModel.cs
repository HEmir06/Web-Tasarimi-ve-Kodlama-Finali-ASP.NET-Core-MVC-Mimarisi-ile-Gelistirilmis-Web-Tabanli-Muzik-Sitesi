using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Music.Migrations
{
    /// <inheritdoc />
    public partial class PlaylistModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlist_AspNetUsers_AppUserId1",
                table: "Playlist");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlist_Songs_SongId",
                table: "Playlist");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSong_Playlist_PlaylistId",
                table: "PlaylistSong");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSong_Songs_SongId",
                table: "PlaylistSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaylistSong",
                table: "PlaylistSong");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistSong_PlaylistId",
                table: "PlaylistSong");

            migrationBuilder.DropIndex(
                name: "IX_Playlist_AppUserId1",
                table: "Playlist");

            migrationBuilder.DropIndex(
                name: "IX_Playlist_SongId",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlaylistSong");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "Playlist");

            migrationBuilder.RenameColumn(
                name: "SongId",
                table: "PlaylistSong",
                newName: "SongsId");

            migrationBuilder.RenameColumn(
                name: "PlaylistId",
                table: "PlaylistSong",
                newName: "PlaylistsId");

            migrationBuilder.RenameIndex(
                name: "IX_PlaylistSong_SongId",
                table: "PlaylistSong",
                newName: "IX_PlaylistSong_SongsId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Playlist",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Playlist",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaylistSong",
                table: "PlaylistSong",
                columns: new[] { "PlaylistsId", "SongsId" });

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_AppUserId",
                table: "Playlist",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlist_AspNetUsers_AppUserId",
                table: "Playlist",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSong_Playlist_PlaylistsId",
                table: "PlaylistSong",
                column: "PlaylistsId",
                principalTable: "Playlist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSong_Songs_SongsId",
                table: "PlaylistSong",
                column: "SongsId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlist_AspNetUsers_AppUserId",
                table: "Playlist");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSong_Playlist_PlaylistsId",
                table: "PlaylistSong");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSong_Songs_SongsId",
                table: "PlaylistSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaylistSong",
                table: "PlaylistSong");

            migrationBuilder.DropIndex(
                name: "IX_Playlist_AppUserId",
                table: "Playlist");

            migrationBuilder.RenameColumn(
                name: "SongsId",
                table: "PlaylistSong",
                newName: "SongId");

            migrationBuilder.RenameColumn(
                name: "PlaylistsId",
                table: "PlaylistSong",
                newName: "PlaylistId");

            migrationBuilder.RenameIndex(
                name: "IX_PlaylistSong_SongsId",
                table: "PlaylistSong",
                newName: "IX_PlaylistSong_SongId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Playlist",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PlaylistSong",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Playlist",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Playlist",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "Playlist",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaylistSong",
                table: "PlaylistSong",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSong_PlaylistId",
                table: "PlaylistSong",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_AppUserId1",
                table: "Playlist",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_SongId",
                table: "Playlist",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlist_AspNetUsers_AppUserId1",
                table: "Playlist",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Playlist_Songs_SongId",
                table: "Playlist",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSong_Playlist_PlaylistId",
                table: "PlaylistSong",
                column: "PlaylistId",
                principalTable: "Playlist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSong_Songs_SongId",
                table: "PlaylistSong",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

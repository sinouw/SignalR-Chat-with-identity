using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class jusa3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatBoxModel",
                columns: table => new
                {
                    IDChatBox = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ToUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatBoxModel", x => x.IDChatBox);
                    table.ForeignKey(
                        name: "FK_ChatBoxModel_AspNetUsers_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(nullable: false),
                    ChatBoxModelIDChatBox = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Messages_ChatBoxModel_ChatBoxModelIDChatBox",
                        column: x => x.ChatBoxModelIDChatBox,
                        principalTable: "ChatBoxModel",
                        principalColumn: "IDChatBox",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatBoxModel_ToUserId",
                table: "ChatBoxModel",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatBoxModelIDChatBox",
                table: "Messages",
                column: "ChatBoxModelIDChatBox");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "ChatBoxModel");
        }
    }
}

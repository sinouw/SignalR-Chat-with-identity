using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class chaty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "ChatBoxModel");

            migrationBuilder.CreateTable(
                name: "MessageChat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FromUser = table.Column<string>(nullable: true),
                    ToUser = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    User1Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageChat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageChat_AspNetUsers_User1Id",
                        column: x => x.User1Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageChat_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserConnections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ConnectionId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConnections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserConnections_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageChat_User1Id",
                table: "MessageChat",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_MessageChat_UserId",
                table: "MessageChat",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserConnections_ApplicationUserId",
                table: "UserConnections",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageChat");

            migrationBuilder.DropTable(
                name: "UserConnections");

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
                    ChatBoxModelIDChatBox = table.Column<int>(nullable: true),
                    Message = table.Column<string>(nullable: false)
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
    }
}

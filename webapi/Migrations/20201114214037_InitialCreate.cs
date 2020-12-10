using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userId = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    dateCreated = table.Column<DateTime>(nullable: false),
                    active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    userRoleId = table.Column<Guid>(nullable: false),
                    role = table.Column<string>(nullable: true),
                    userId = table.Column<Guid>(nullable: false),
                    active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.userRoleId);
                    table.ForeignKey(
                        name: "FK_UserRole_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "userId", "active", "dateCreated", "lastName", "name" },
                values: new object[] { new Guid("3f80c97d-74da-4b1e-8d3f-1a98f562434f"), true, new DateTime(2020, 11, 14, 16, 40, 36, 687, DateTimeKind.Local).AddTicks(236), "last name 1", "User 1" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "userId", "active", "dateCreated", "lastName", "name" },
                values: new object[] { new Guid("635b96f4-5ae3-4d21-8da2-268f97127c34"), true, new DateTime(2020, 11, 14, 16, 40, 36, 688, DateTimeKind.Local).AddTicks(5190), "last name 2", "User 2" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "userId", "active", "dateCreated", "lastName", "name" },
                values: new object[] { new Guid("d3e2a40d-70cb-4b42-b9a5-e1976dc393d9"), true, new DateTime(2020, 11, 14, 16, 40, 36, 688, DateTimeKind.Local).AddTicks(5239), "last name 3", "User 3" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "userRoleId", "active", "role", "userId" },
                values: new object[] { new Guid("c464eb6b-e42d-41ea-a2a0-da281921fadb"), true, "Admin", new Guid("3f80c97d-74da-4b1e-8d3f-1a98f562434f") });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "userRoleId", "active", "role", "userId" },
                values: new object[] { new Guid("94b8dee4-2dbb-49b3-af20-39140fd04881"), true, "User", new Guid("635b96f4-5ae3-4d21-8da2-268f97127c34") });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "userRoleId", "active", "role", "userId" },
                values: new object[] { new Guid("14cb2cb5-caa9-4076-bd6e-91ecfc560a3d"), true, "Suport", new Guid("d3e2a40d-70cb-4b42-b9a5-e1976dc393d9") });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_userId",
                table: "UserRole",
                column: "userId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

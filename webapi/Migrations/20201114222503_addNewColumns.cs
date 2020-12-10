using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class addNewColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "userRoleId",
                keyValue: new Guid("14cb2cb5-caa9-4076-bd6e-91ecfc560a3d"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "userRoleId",
                keyValue: new Guid("94b8dee4-2dbb-49b3-af20-39140fd04881"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "userRoleId",
                keyValue: new Guid("c464eb6b-e42d-41ea-a2a0-da281921fadb"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "userId",
                keyValue: new Guid("3f80c97d-74da-4b1e-8d3f-1a98f562434f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "userId",
                keyValue: new Guid("635b96f4-5ae3-4d21-8da2-268f97127c34"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "userId",
                keyValue: new Guid("d3e2a40d-70cb-4b42-b9a5-e1976dc393d9"));

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "UserRole",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "User",
                nullable: true);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "userId", "active", "dateCreated", "lastName", "name", "phone" },
                values: new object[] { new Guid("858d3854-62ad-49dc-a8ab-2680130c5aef"), true, new DateTime(2020, 11, 14, 17, 25, 2, 719, DateTimeKind.Local).AddTicks(7008), "last name 1", "User 1", null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "userId", "active", "dateCreated", "lastName", "name", "phone" },
                values: new object[] { new Guid("47e8eee4-c58c-464b-9bb3-4f1d967a962a"), true, new DateTime(2020, 11, 14, 17, 25, 2, 720, DateTimeKind.Local).AddTicks(8886), "last name 2", "User 2", null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "userId", "active", "dateCreated", "lastName", "name", "phone" },
                values: new object[] { new Guid("94b56db9-0d25-4efd-9f7a-8e5af20a9b41"), true, new DateTime(2020, 11, 14, 17, 25, 2, 720, DateTimeKind.Local).AddTicks(8926), "last name 3", "User 3", null });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "userRoleId", "active", "description", "role", "userId" },
                values: new object[] { new Guid("abb3743e-3408-447f-85df-09895f6bfc42"), true, null, "Admin", new Guid("858d3854-62ad-49dc-a8ab-2680130c5aef") });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "userRoleId", "active", "description", "role", "userId" },
                values: new object[] { new Guid("a5625ff5-f379-4413-bcef-625dc9fa43ea"), true, null, "User", new Guid("47e8eee4-c58c-464b-9bb3-4f1d967a962a") });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "userRoleId", "active", "description", "role", "userId" },
                values: new object[] { new Guid("9203bc79-4d90-4bc2-9e1b-af0d24f0b416"), true, null, "Suport", new Guid("94b56db9-0d25-4efd-9f7a-8e5af20a9b41") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "userRoleId",
                keyValue: new Guid("9203bc79-4d90-4bc2-9e1b-af0d24f0b416"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "userRoleId",
                keyValue: new Guid("a5625ff5-f379-4413-bcef-625dc9fa43ea"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "userRoleId",
                keyValue: new Guid("abb3743e-3408-447f-85df-09895f6bfc42"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "userId",
                keyValue: new Guid("47e8eee4-c58c-464b-9bb3-4f1d967a962a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "userId",
                keyValue: new Guid("858d3854-62ad-49dc-a8ab-2680130c5aef"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "userId",
                keyValue: new Guid("94b56db9-0d25-4efd-9f7a-8e5af20a9b41"));

            migrationBuilder.DropColumn(
                name: "description",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "User");

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
        }
    }
}

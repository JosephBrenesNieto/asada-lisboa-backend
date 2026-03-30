using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AsadaLisboaBackend.Models.Migrations
{
    /// <inheritdoc />
    public partial class DocumentUpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("219d007a-7678-4d0e-87d1-ecfa4ef0402a"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("2797641b-3f01-4fc7-bc88-96a4fbf20db7"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("ba3b8826-24b2-44d8-8e1e-7af7202c125d"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("c6ea3e4f-ed3f-4cad-9697-bff213b8e5dd"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("cbec9bae-c444-4234-a851-1a2d9f544192"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("cc1ad219-1f4b-47bc-a3d6-8723e8250375"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("e0bfd8c2-0151-4de8-99b3-ac2b99800eb9"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("f10c568a-e590-4402-88ac-8467cb6d8a9b"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("171b840d-48b0-4f83-81dd-1921215898ac"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("7c3d1291-f268-4938-872e-d3f62ca8ab68"));

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Charges",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3d201bf6-aa3c-4d0f-a73e-5f87c23cdedc"), "Presidente" },
                    { new Guid("49f65ca6-49b7-468c-b8e7-34e094332635"), "Vicepresidente" },
                    { new Guid("4c2901ba-8efa-4fa8-8a67-7c297a77ea13"), "Vocal 3" },
                    { new Guid("79fa6018-6b32-4554-ab54-26d65fb4fb17"), "Vocal 2" },
                    { new Guid("8442d375-f380-4433-97a5-51ea5020337a"), "Tesorero" },
                    { new Guid("8ad77ce4-ed2e-4dc7-8e18-4b2d2fbb67f4"), "Fiscal" },
                    { new Guid("eec5664f-e08e-4e64-ad37-6952bd5ba715"), "Vocal 1" },
                    { new Guid("f1404010-e8a1-4140-814b-988663808a10"), "Secretario" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("16153600-e030-44e0-ac7e-1018a27d5d98"), "Draft" },
                    { new Guid("8269e96f-dc94-4e47-95c6-c7e73e41b8e5"), "Active" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("3d201bf6-aa3c-4d0f-a73e-5f87c23cdedc"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("49f65ca6-49b7-468c-b8e7-34e094332635"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("4c2901ba-8efa-4fa8-8a67-7c297a77ea13"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("79fa6018-6b32-4554-ab54-26d65fb4fb17"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("8442d375-f380-4433-97a5-51ea5020337a"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("8ad77ce4-ed2e-4dc7-8e18-4b2d2fbb67f4"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("eec5664f-e08e-4e64-ad37-6952bd5ba715"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("f1404010-e8a1-4140-814b-988663808a10"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("16153600-e030-44e0-ac7e-1018a27d5d98"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("8269e96f-dc94-4e47-95c6-c7e73e41b8e5"));

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Documents");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Charges",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("219d007a-7678-4d0e-87d1-ecfa4ef0402a"), "Fiscal" },
                    { new Guid("2797641b-3f01-4fc7-bc88-96a4fbf20db7"), "Presidente" },
                    { new Guid("ba3b8826-24b2-44d8-8e1e-7af7202c125d"), "Vicepresidente" },
                    { new Guid("c6ea3e4f-ed3f-4cad-9697-bff213b8e5dd"), "Tesorero" },
                    { new Guid("cbec9bae-c444-4234-a851-1a2d9f544192"), "Secretario" },
                    { new Guid("cc1ad219-1f4b-47bc-a3d6-8723e8250375"), "Vocal 3" },
                    { new Guid("e0bfd8c2-0151-4de8-99b3-ac2b99800eb9"), "Vocal 2" },
                    { new Guid("f10c568a-e590-4402-88ac-8467cb6d8a9b"), "Vocal 1" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("171b840d-48b0-4f83-81dd-1921215898ac"), "Draft" },
                    { new Guid("7c3d1291-f268-4938-872e-d3f62ca8ab68"), "Active" }
                });
        }
    }
}

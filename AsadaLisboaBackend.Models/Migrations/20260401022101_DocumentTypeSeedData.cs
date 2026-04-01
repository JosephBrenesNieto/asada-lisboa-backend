using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AsadaLisboaBackend.Models.Migrations
{
    /// <inheritdoc />
    public partial class DocumentTypeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("027e163d-a39d-4958-9eba-9ae027384c0e"), "Estados Financieros" },
                    { new Guid("10b26421-51ff-4ac1-8bda-e678d00fa713"), "Hidrantes" },
                    { new Guid("19eb7b82-bbf8-4ebe-88df-79609f537098"), "Solicitudes" },
                    { new Guid("1ee2c5c1-e81b-4980-9a67-3c0acedec6e3"), "Lineamientos" },
                    { new Guid("2b88dbbc-af80-4f61-a606-88db3dfd4b47"), "Exámenes" },
                    { new Guid("31d41a1e-95d8-44d1-93c2-c596dfa0fede"), "Sugerencias" },
                    { new Guid("39aa8592-a311-4d87-a497-dfdbd1a518aa"), "Dudas" },
                    { new Guid("3c2d9994-4ded-46a1-942d-747d7b39cd35"), "Colindancia" },
                    { new Guid("96e21897-a0f1-4c8d-a65b-ba2861ecf536"), "Informes" },
                    { new Guid("a06064d1-7407-4867-833e-ba4babb11eb8"), "Reglamentos" },
                    { new Guid("ad8ef572-67c3-4df2-8a8b-f40c6c8bcb6d"), "Pozo Principal" },
                    { new Guid("b034226c-c3a2-4477-81df-9f75ff1c541d"), "Tanque Principal" },
                    { new Guid("bf0f12b0-e642-4206-b9b5-322d8ed96d44"), "Proyectos Ejecutados" },
                    { new Guid("e9d011c4-cc7b-4a81-9323-0bf518f06eed"), "Estudios" },
                    { new Guid("fef785d8-43d8-4e7e-9f0c-82f1999b8b99"), "Convenios" }
                });

            migrationBuilder.InsertData(
                table: "Charges",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0bbcd6bf-ed4e-4a86-8a5c-3117729885f1"), "Vocal 3" },
                    { new Guid("2dc2f27e-5626-4a96-a753-6f097c430756"), "Presidente" },
                    { new Guid("48a43a7b-a558-42dd-addb-14f00738d2eb"), "Secretario" },
                    { new Guid("59b4bd4f-b2b7-4e2b-b6dc-64ea4cc26c0c"), "Vicepresidente" },
                    { new Guid("6c2bfd25-5b05-46d1-81e2-95a067790221"), "Fiscal" },
                    { new Guid("96eb9b33-30a3-45a4-8abc-ec3bd42e66be"), "Vocal 1" },
                    { new Guid("d9eb8280-f2bc-4839-9dca-65d0199eebc5"), "Vocal 2" },
                    { new Guid("ec687d2a-106d-44bd-9470-242e04fc35e8"), "Tesorero" }
                });

            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "Id", "Extension", "MimeType", "Name" },
                values: new object[,]
                {
                    { new Guid("168228f9-a198-4962-a8d5-90895764cce9"), ".csv", "text/csv", "CSV" },
                    { new Guid("7f58246c-f23c-4f09-85a9-1c4630e83dfe"), ".txt", "text/plain", "Texto" },
                    { new Guid("8b800c34-7e1c-40d4-a283-bf2e613b459d"), ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Excel" },
                    { new Guid("8f96303d-83f6-4b6d-b95b-b0b99539c39e"), ".zip", "application/octet-stream", "ZIP" },
                    { new Guid("98763e28-b273-4b82-8e6c-cc794adc7554"), ".pdf", "application/pdf", "PDF" },
                    { new Guid("b17f8674-cd04-4b03-9102-70c68acab183"), ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Word" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("070f50d8-20d3-4d49-bf5a-a8b61aaa9d4f"), "Borrador" },
                    { new Guid("61acfdd5-eef2-42c9-86a4-4999d0e88058"), "Publicado" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("027e163d-a39d-4958-9eba-9ae027384c0e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10b26421-51ff-4ac1-8bda-e678d00fa713"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("19eb7b82-bbf8-4ebe-88df-79609f537098"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1ee2c5c1-e81b-4980-9a67-3c0acedec6e3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2b88dbbc-af80-4f61-a606-88db3dfd4b47"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("31d41a1e-95d8-44d1-93c2-c596dfa0fede"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("39aa8592-a311-4d87-a497-dfdbd1a518aa"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3c2d9994-4ded-46a1-942d-747d7b39cd35"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("96e21897-a0f1-4c8d-a65b-ba2861ecf536"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a06064d1-7407-4867-833e-ba4babb11eb8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ad8ef572-67c3-4df2-8a8b-f40c6c8bcb6d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b034226c-c3a2-4477-81df-9f75ff1c541d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bf0f12b0-e642-4206-b9b5-322d8ed96d44"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e9d011c4-cc7b-4a81-9323-0bf518f06eed"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fef785d8-43d8-4e7e-9f0c-82f1999b8b99"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("0bbcd6bf-ed4e-4a86-8a5c-3117729885f1"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("2dc2f27e-5626-4a96-a753-6f097c430756"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("48a43a7b-a558-42dd-addb-14f00738d2eb"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("59b4bd4f-b2b7-4e2b-b6dc-64ea4cc26c0c"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("6c2bfd25-5b05-46d1-81e2-95a067790221"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("96eb9b33-30a3-45a4-8abc-ec3bd42e66be"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("d9eb8280-f2bc-4839-9dca-65d0199eebc5"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("ec687d2a-106d-44bd-9470-242e04fc35e8"));

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("168228f9-a198-4962-a8d5-90895764cce9"));

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("7f58246c-f23c-4f09-85a9-1c4630e83dfe"));

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("8b800c34-7e1c-40d4-a283-bf2e613b459d"));

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("8f96303d-83f6-4b6d-b95b-b0b99539c39e"));

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("98763e28-b273-4b82-8e6c-cc794adc7554"));

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("b17f8674-cd04-4b03-9102-70c68acab183"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("070f50d8-20d3-4d49-bf5a-a8b61aaa9d4f"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("61acfdd5-eef2-42c9-86a4-4999d0e88058"));

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AsadaLisboaBackend.Models.Migrations
{
    /// <inheritdoc />
    public partial class NewDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("6fcf3478-3ced-400b-92a6-dbe6a9d37446"), "6FCF3478-3CED-400B-92A6-DBE6A9D37446", "Escritor", "ESCRITOR" },
                    { new Guid("864c6f86-5fdf-4279-857b-d7b8d99170b2"), "864C6F86-5FDF-4279-857B-D7B8D99170B2", "Administrador", "ADMINISTRADOR" },
                    { new Guid("caa2cbcd-3a76-4ed0-ab4f-7d07034692eb"), "CAA2CBCD-3A76-4ED0-AB4F-7D07034692EB", "Lector", "LECTOR" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("03e622ec-438b-49f3-8c53-3a3873651c16"), "Proyectos Ejecutados" },
                    { new Guid("2b3b492d-e243-4fc8-8217-03ea9998a201"), "Sugerencias" },
                    { new Guid("3643cd9f-99fe-4873-85f9-2a7b6b4dac28"), "Tanque Principal" },
                    { new Guid("560841fb-884b-45f6-9a09-18d4641b7af5"), "Hidrantes" },
                    { new Guid("5aa04636-cd02-4184-bbe0-603a2e785988"), "Convenios" },
                    { new Guid("6da5cf2d-e946-43ed-a092-d5b4c9282ffa"), "Estados Financieros" },
                    { new Guid("71b9c756-b148-4e0f-a5c7-09a8a7aa209e"), "Dudas" },
                    { new Guid("77607c99-2ed1-4b8e-89cc-ccc7c6344e53"), "Lineamientos" },
                    { new Guid("783e94bc-4748-4223-a150-8892354b865b"), "Colindancia" },
                    { new Guid("81f11c15-3556-40be-8074-a6be7a5d5ab4"), "Informes" },
                    { new Guid("93ca9020-78fd-4080-8d57-469eb05d9dc3"), "Reglamentos" },
                    { new Guid("b2dbcf36-fddf-4752-b39d-b31f61e704a3"), "Estudios" },
                    { new Guid("ba84f8ac-ead7-4cb3-83b4-77238df95884"), "Solicitudes" },
                    { new Guid("ceb0bb8a-0414-474c-b378-46491b4c08e8"), "Exámenes" },
                    { new Guid("f62ed863-70d4-446b-9088-10efd6cb6c77"), "Pozo Principal" }
                });

            migrationBuilder.InsertData(
                table: "Charges",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0feb0b33-cf81-4973-9754-e45de997069d"), "Administrador" },
                    { new Guid("1bce957a-451a-425a-b438-58c0227ff9fc"), "Secretario" },
                    { new Guid("28524859-89fd-4f06-a39c-c62150c1284c"), "Vocal 3" },
                    { new Guid("56f6b0c4-9e67-4cb6-ac31-d95ac0d10271"), "Presidente" },
                    { new Guid("64849ca6-6daa-4174-a240-a640cd09509f"), "Vocal 2" },
                    { new Guid("7d591140-46fa-47a3-9875-d450896c8b14"), "Vicepresidente" },
                    { new Guid("9db79916-bac2-479a-84a1-dfb13c83dda8"), "Vocal 1" },
                    { new Guid("bee47254-066c-414b-a872-3cc72d708a67"), "Fiscal" },
                    { new Guid("c8fcb329-dcaf-4352-80fc-5cc7730482e7"), "Tesorero" }
                });

            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "Id", "Extension", "MimeType", "Name" },
                values: new object[,]
                {
                    { new Guid("1e42a6e9-0baa-4c51-8812-e459e0678130"), ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Excel" },
                    { new Guid("55931b3a-ae2b-4aec-8625-7c9adbdfab5f"), ".csv", "text/csv", "CSV" },
                    { new Guid("9029eb69-0e77-4cf6-8622-c7902d565745"), ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Word" },
                    { new Guid("d8fbe9b6-1a5e-41ea-98ea-e6641a6047c8"), ".pdf", "application/pdf", "PDF" },
                    { new Guid("d9ec3706-86f8-4c3d-a770-e3e38221a7e8"), ".txt", "text/plain", "Texto" },
                    { new Guid("f4365613-d7e7-488e-b24e-4834645408d6"), ".zip", "application/octet-stream", "ZIP" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2c36a4b8-de3e-4607-9b7b-dbe0f0e00390"), "Borrador" },
                    { new Guid("5c1cebda-fc8c-44ac-997c-aaf015572d46"), "Publicado" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6fcf3478-3ced-400b-92a6-dbe6a9d37446"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("864c6f86-5fdf-4279-857b-d7b8d99170b2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("caa2cbcd-3a76-4ed0-ab4f-7d07034692eb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("03e622ec-438b-49f3-8c53-3a3873651c16"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2b3b492d-e243-4fc8-8217-03ea9998a201"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3643cd9f-99fe-4873-85f9-2a7b6b4dac28"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("560841fb-884b-45f6-9a09-18d4641b7af5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5aa04636-cd02-4184-bbe0-603a2e785988"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6da5cf2d-e946-43ed-a092-d5b4c9282ffa"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("71b9c756-b148-4e0f-a5c7-09a8a7aa209e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("77607c99-2ed1-4b8e-89cc-ccc7c6344e53"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("783e94bc-4748-4223-a150-8892354b865b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("81f11c15-3556-40be-8074-a6be7a5d5ab4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("93ca9020-78fd-4080-8d57-469eb05d9dc3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b2dbcf36-fddf-4752-b39d-b31f61e704a3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ba84f8ac-ead7-4cb3-83b4-77238df95884"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ceb0bb8a-0414-474c-b378-46491b4c08e8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f62ed863-70d4-446b-9088-10efd6cb6c77"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("0feb0b33-cf81-4973-9754-e45de997069d"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("1bce957a-451a-425a-b438-58c0227ff9fc"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("28524859-89fd-4f06-a39c-c62150c1284c"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("56f6b0c4-9e67-4cb6-ac31-d95ac0d10271"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("64849ca6-6daa-4174-a240-a640cd09509f"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("7d591140-46fa-47a3-9875-d450896c8b14"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("9db79916-bac2-479a-84a1-dfb13c83dda8"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("bee47254-066c-414b-a872-3cc72d708a67"));

            migrationBuilder.DeleteData(
                table: "Charges",
                keyColumn: "Id",
                keyValue: new Guid("c8fcb329-dcaf-4352-80fc-5cc7730482e7"));

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("1e42a6e9-0baa-4c51-8812-e459e0678130"));

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("55931b3a-ae2b-4aec-8625-7c9adbdfab5f"));

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("9029eb69-0e77-4cf6-8622-c7902d565745"));

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("d8fbe9b6-1a5e-41ea-98ea-e6641a6047c8"));

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("d9ec3706-86f8-4c3d-a770-e3e38221a7e8"));

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("f4365613-d7e7-488e-b24e-4834645408d6"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("2c36a4b8-de3e-4607-9b7b-dbe0f0e00390"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("5c1cebda-fc8c-44ac-997c-aaf015572d46"));

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
    }
}

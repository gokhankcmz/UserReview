using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserReview.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("35d174b7-57b9-44bd-842a-4ee070b786bb"),
                columns: new[] { "CreatedAt", "content", "title" },
                values: new object[] { new DateTime(2021, 5, 9, 19, 57, 29, 902, DateTimeKind.Local).AddTicks(475), "Another content", "Another Title" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("41332237-ffc1-4c63-8edf-1fd1ec602473"),
                columns: new[] { "CreatedAt", "content", "title" },
                values: new object[] { new DateTime(2021, 5, 9, 19, 57, 29, 901, DateTimeKind.Local).AddTicks(8101), "A content", "A title" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5198f585-2ec1-4a97-ab57-ed2ea6c69353"),
                column: "CreatedAt",
                value: new DateTime(2021, 5, 9, 19, 57, 29, 908, DateTimeKind.Local).AddTicks(609));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("90bcc60a-34e0-49f0-a10f-13222c9fc6f2"),
                column: "CreatedAt",
                value: new DateTime(2021, 5, 9, 19, 57, 29, 908, DateTimeKind.Local).AddTicks(2689));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a86611d5-6f64-4951-859e-7249b3ef26e9"),
                column: "CreatedAt",
                value: new DateTime(2021, 5, 9, 19, 57, 29, 908, DateTimeKind.Local).AddTicks(2684));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f27f1c31-9b90-4406-8e7a-6dd1e6a7535c"),
                column: "CreatedAt",
                value: new DateTime(2021, 5, 9, 19, 57, 29, 908, DateTimeKind.Local).AddTicks(2674));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("35d174b7-57b9-44bd-842a-4ee070b786bb"),
                columns: new[] { "CreatedAt", "content", "title" },
                values: new object[] { new DateTime(2021, 5, 9, 14, 55, 42, 7, DateTimeKind.Local).AddTicks(2247), "Yemekler çok kötüydü ama kuryeniz çok nazik bir beyefendiydisırf onun için 5 yıldız veriyorum bence kendisi iyi bir zammı hak ediyor.", "Kurye çok iyi." });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("41332237-ffc1-4c63-8edf-1fd1ec602473"),
                columns: new[] { "CreatedAt", "content", "title" },
                values: new object[] { new DateTime(2021, 5, 9, 14, 55, 42, 7, DateTimeKind.Local).AddTicks(141), "Çamaşır makinesi aldım ama içinden çamaşır çıkmadı.", "Aldatıcı satıcı." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5198f585-2ec1-4a97-ab57-ed2ea6c69353"),
                column: "CreatedAt",
                value: new DateTime(2021, 5, 9, 14, 55, 42, 12, DateTimeKind.Local).AddTicks(4892));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("90bcc60a-34e0-49f0-a10f-13222c9fc6f2"),
                column: "CreatedAt",
                value: new DateTime(2021, 5, 9, 14, 55, 42, 12, DateTimeKind.Local).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a86611d5-6f64-4951-859e-7249b3ef26e9"),
                column: "CreatedAt",
                value: new DateTime(2021, 5, 9, 14, 55, 42, 12, DateTimeKind.Local).AddTicks(7003));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f27f1c31-9b90-4406-8e7a-6dd1e6a7535c"),
                column: "CreatedAt",
                value: new DateTime(2021, 5, 9, 14, 55, 42, 12, DateTimeKind.Local).AddTicks(6993));
        }
    }
}

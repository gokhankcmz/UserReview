using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserReview.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    userType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    star = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    rejectReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    operatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "UpdatedAt", "email", "firstName", "lastName", "password", "userType", "username" },
                values: new object[,]
                {
                    { new Guid("5198f585-2ec1-4a97-ab57-ed2ea6c69353"), new DateTime(2021, 5, 9, 14, 55, 42, 12, DateTimeKind.Local).AddTicks(4892), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FirstUser@email.com", "First User Firstname", "First User Lastname", "123456", 1, "FirstUser" },
                    { new Guid("f27f1c31-9b90-4406-8e7a-6dd1e6a7535c"), new DateTime(2021, 5, 9, 14, 55, 42, 12, DateTimeKind.Local).AddTicks(6993), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SecondUser@email.com", "Second User Firstname", "Second User Lastname", "1.23456", 1, "SecondUser" },
                    { new Guid("a86611d5-6f64-4951-859e-7249b3ef26e9"), new DateTime(2021, 5, 9, 14, 55, 42, 12, DateTimeKind.Local).AddTicks(7003), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin1@email.com", "Admin1 Firstname", "Admin1 Lastname", "123456", 0, "VeryCoolAdmin" },
                    { new Guid("90bcc60a-34e0-49f0-a10f-13222c9fc6f2"), new DateTime(2021, 5, 9, 14, 55, 42, 12, DateTimeKind.Local).AddTicks(7006), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin2@email.com", "Admin2 Firstname", "Admin2 Lastname", "123456", 0, "VeryNiceAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CreatedAt", "UpdatedAt", "content", "operatedBy", "rejectReason", "star", "status", "title", "userId" },
                values: new object[] { new Guid("41332237-ffc1-4c63-8edf-1fd1ec602473"), new DateTime(2021, 5, 9, 14, 55, 42, 7, DateTimeKind.Local).AddTicks(141), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çamaşır makinesi aldım ama içinden çamaşır çıkmadı.", new Guid("00000000-0000-0000-0000-000000000000"), null, 1, 1, "Aldatıcı satıcı.", new Guid("f27f1c31-9b90-4406-8e7a-6dd1e6a7535c") });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CreatedAt", "UpdatedAt", "content", "operatedBy", "rejectReason", "star", "status", "title", "userId" },
                values: new object[] { new Guid("35d174b7-57b9-44bd-842a-4ee070b786bb"), new DateTime(2021, 5, 9, 14, 55, 42, 7, DateTimeKind.Local).AddTicks(2247), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yemekler çok kötüydü ama kuryeniz çok nazik bir beyefendiydisırf onun için 5 yıldız veriyorum bence kendisi iyi bir zammı hak ediyor.", new Guid("00000000-0000-0000-0000-000000000000"), null, 5, 0, "Kurye çok iyi.", new Guid("f27f1c31-9b90-4406-8e7a-6dd1e6a7535c") });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_Id",
                table: "Reviews",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_userId",
                table: "Reviews",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_username_email_Id",
                table: "Users",
                columns: new[] { "username", "email", "Id" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

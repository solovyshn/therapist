using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class InitMigartion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Psycotherapists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psycotherapists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstMeeting = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FrequencyTime = table.Column<int>(type: "int", nullable: false),
                    PsycotherapistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meetings_Psycotherapists_PsycotherapistId",
                        column: x => x.PsycotherapistId,
                        principalTable: "Psycotherapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Psycotherapists",
                columns: new[] { "Id", "Address", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "Herentalsebaan 335, 2100 Antwerpen", "Zach Curtis", "1ps" },
                    { 2, "Eyendijkstraat 22, 2100 Antwerpen", "Max Thomson", "2ps" },
                    { 3, "Apollostraat 31, 2140 Antwerpen", "Eva Reyes", "3ps" },
                    { 4, "Lange Beeldekensstraat 267, 2060 Antwerpen", "Farhan Greene", "4ps" },
                    { 5, "Arenaplein 62 A, 2100 Antwerpen", "Lorna Carpenter", "5ps" }
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "Description", "FirstMeeting", "FrequencyTime", "Name", "PsycotherapistId" },
                values: new object[,]
                {
                    { 1, "Nulla sed neque malesuada, faucibus est non, luctus elit. Sed ultrices sem justo, convallis convallis ex sagittis sit amet. Cras at mauris in lectus semper placerat sit amet nec metus.", new DateTime(2022, 12, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), 0, "Ronald E. Tinsley depression", 1 },
                    { 2, "Mauris ac odio dui. ", new DateTime(2022, 12, 13, 16, 0, 0, 0, DateTimeKind.Unspecified), 0, "Edward J. Reynolds post-traumatic syndrome", 2 },
                    { 3, "Duis non tellus sed velit imperdiet lacinia. ", new DateTime(2022, 12, 15, 13, 20, 0, 0, DateTimeKind.Unspecified), 0, "Lloyd D. Smith amnesia", 3 },
                    { 4, "Cras varius tortor a diam pulvinar tempor. Aliquam vel bibendum turpis. ", new DateTime(2022, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), 0, "Corine W. Daniels paranoia", 4 },
                    { 5, "Quisque nunc quam, lacinia ut efficitur et, dictum eu dui. Aliquam dapibus sem eget nisi pellentesque, non eleifend ipsum bibendum.", new DateTime(2022, 12, 16, 14, 30, 0, 0, DateTimeKind.Unspecified), 0, "Christine R. Carlson addiction", 5 },
                    { 6, "Nulla ut finibus tellus. Donec ultrices sem eros, tincidunt ultrices leo malesuada ut. Vivamus ultricies eros eget enim lobortis eleifend. Mauris consectetur, ipsum at condimentum semper, elit elit egestas nibh, id suscipit sem diam sed neque. ", new DateTime(2022, 12, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "Tricia C. Kirkpatrick depression", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_PsycotherapistId",
                table: "Meetings",
                column: "PsycotherapistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Psycotherapists");
        }
    }
}

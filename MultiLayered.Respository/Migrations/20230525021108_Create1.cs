using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiLayered.Respository.Migrations
{
    public partial class Create1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TeamPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeagueCup = table.Column<int>(type: "int", nullable: false),
                    EuropeanCup = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamFeatures_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turkey", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "England", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain", null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Italy", null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Germany", null }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CountryId", "CreatedDate", "Name", "TeamPrice", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 5, 25, 5, 11, 7, 964, DateTimeKind.Local).AddTicks(4882), "Galatasaray SK", 500000m, null },
                    { 2, 1, new DateTime(2023, 5, 25, 5, 11, 7, 964, DateTimeKind.Local).AddTicks(4893), "Fenerbahce SK", 400000m, null },
                    { 3, 1, new DateTime(2023, 5, 25, 5, 11, 7, 964, DateTimeKind.Local).AddTicks(4894), "Besiktas JK", 300000m, null },
                    { 4, 1, new DateTime(2023, 5, 25, 5, 11, 7, 964, DateTimeKind.Local).AddTicks(4895), "Trabzonspor SK", 200000m, null },
                    { 5, 1, new DateTime(2023, 5, 25, 5, 11, 7, 964, DateTimeKind.Local).AddTicks(4895), "Basaksehir FC", 100000m, null },
                    { 6, 2, new DateTime(2023, 5, 25, 5, 11, 7, 964, DateTimeKind.Local).AddTicks(4896), "Manchester City", 15000000m, null },
                    { 7, 2, new DateTime(2023, 5, 25, 5, 11, 7, 964, DateTimeKind.Local).AddTicks(4897), "Manchester UTD", 14000000m, null },
                    { 8, 2, new DateTime(2023, 5, 25, 5, 11, 7, 964, DateTimeKind.Local).AddTicks(4898), "Chesea FC", 12000000m, null },
                    { 9, 3, new DateTime(2023, 5, 25, 5, 11, 7, 964, DateTimeKind.Local).AddTicks(4899), "Barcelona FC", 11480000m, null },
                    { 10, 3, new DateTime(2023, 5, 25, 5, 11, 7, 964, DateTimeKind.Local).AddTicks(4900), "Real Madrid FC", 14000000m, null },
                    { 11, 3, new DateTime(2023, 5, 25, 5, 11, 7, 964, DateTimeKind.Local).AddTicks(4901), "Atetico Madrid FC", 12220000m, null },
                    { 12, 4, new DateTime(2023, 5, 25, 5, 11, 7, 964, DateTimeKind.Local).AddTicks(4902), "Juventus FC", 15420000m, null },
                    { 13, 4, new DateTime(2023, 5, 25, 5, 11, 7, 964, DateTimeKind.Local).AddTicks(4903), "Internazional FC", 12670000m, null },
                    { 14, 4, new DateTime(2023, 5, 25, 5, 11, 7, 964, DateTimeKind.Local).AddTicks(4904), "Inter Milan FC", 14790000m, null },
                    { 15, 4, new DateTime(2023, 5, 25, 5, 11, 7, 964, DateTimeKind.Local).AddTicks(4904), "Napoli FC", 155500000m, null },
                    { 16, 4, new DateTime(2023, 5, 25, 5, 11, 7, 964, DateTimeKind.Local).AddTicks(4905), "Roma FC", 13330000m, null },
                    { 17, 5, new DateTime(2023, 5, 25, 5, 11, 7, 964, DateTimeKind.Local).AddTicks(4906), "Bayern Munch", 12550000m, null },
                    { 18, 5, new DateTime(2023, 5, 25, 5, 11, 7, 964, DateTimeKind.Local).AddTicks(4907), "Borusia Dortmund", 11000000m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamFeatures_TeamId",
                table: "TeamFeatures",
                column: "TeamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CountryId",
                table: "Teams",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamFeatures");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace _25.Data.Migrations
{
    public partial class AddCentreEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CentreId",
                table: "Psychologists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Psychologists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TitleId",
                table: "Psychologists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CentreId",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Centres",
                columns: table => new
                {
                    CentreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centres", x => x.CentreId);
                });

            migrationBuilder.CreateTable(
                name: "CentreAddresses",
                columns: table => new
                {
                    CentreId = table.Column<int>(nullable: false),
                    Line1 = table.Column<string>(nullable: false),
                    Line2 = table.Column<string>(nullable: true),
                    CityOrTown = table.Column<string>(nullable: false),
                    Province = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentreAddresses", x => x.CentreId);
                    table.ForeignKey(
                        name: "FK_CentreAddresses_Centres_CentreId",
                        column: x => x.CentreId,
                        principalTable: "Centres",
                        principalColumn: "CentreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Psychologists_CentreId",
                table: "Psychologists",
                column: "CentreId");

            migrationBuilder.CreateIndex(
                name: "IX_Psychologists_GenderId",
                table: "Psychologists",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Psychologists_TitleId",
                table: "Psychologists",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CentreId",
                table: "Employees",
                column: "CentreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Centres_CentreId",
                table: "Employees",
                column: "CentreId",
                principalTable: "Centres",
                principalColumn: "CentreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Psychologists_Centres_CentreId",
                table: "Psychologists",
                column: "CentreId",
                principalTable: "Centres",
                principalColumn: "CentreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Psychologists_Genders_GenderId",
                table: "Psychologists",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Psychologists_Titles_TitleId",
                table: "Psychologists",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "TitleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Centres_CentreId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Psychologists_Centres_CentreId",
                table: "Psychologists");

            migrationBuilder.DropForeignKey(
                name: "FK_Psychologists_Genders_GenderId",
                table: "Psychologists");

            migrationBuilder.DropForeignKey(
                name: "FK_Psychologists_Titles_TitleId",
                table: "Psychologists");

            migrationBuilder.DropTable(
                name: "CentreAddresses");

            migrationBuilder.DropTable(
                name: "Centres");

            migrationBuilder.DropIndex(
                name: "IX_Psychologists_CentreId",
                table: "Psychologists");

            migrationBuilder.DropIndex(
                name: "IX_Psychologists_GenderId",
                table: "Psychologists");

            migrationBuilder.DropIndex(
                name: "IX_Psychologists_TitleId",
                table: "Psychologists");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CentreId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CentreId",
                table: "Psychologists");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Psychologists");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "Psychologists");

            migrationBuilder.DropColumn(
                name: "CentreId",
                table: "Employees");
        }
    }
}

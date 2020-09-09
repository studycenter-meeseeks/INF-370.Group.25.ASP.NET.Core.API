using Microsoft.EntityFrameworkCore.Migrations;

namespace _25.Data.Migrations
{
    public partial class AddPsychologistCentre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Psychologists_Centres_CentreId",
                table: "Psychologists");

            migrationBuilder.DropIndex(
                name: "IX_Psychologists_CentreId",
                table: "Psychologists");

            migrationBuilder.DropColumn(
                name: "CentreId",
                table: "Psychologists");

            migrationBuilder.CreateTable(
                name: "PsychologistCentres",
                columns: table => new
                {
                    CentreId = table.Column<int>(nullable: false),
                    PsychologistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychologistCentres", x => new { x.CentreId, x.PsychologistId });
                    table.ForeignKey(
                        name: "FK_PsychologistCentres_Centres_CentreId",
                        column: x => x.CentreId,
                        principalTable: "Centres",
                        principalColumn: "CentreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PsychologistCentres_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologists",
                        principalColumn: "PsychologistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PsychologistCentres_PsychologistId",
                table: "PsychologistCentres",
                column: "PsychologistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PsychologistCentres");

            migrationBuilder.AddColumn<int>(
                name: "CentreId",
                table: "Psychologists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Psychologists_CentreId",
                table: "Psychologists",
                column: "CentreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Psychologists_Centres_CentreId",
                table: "Psychologists",
                column: "CentreId",
                principalTable: "Centres",
                principalColumn: "CentreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

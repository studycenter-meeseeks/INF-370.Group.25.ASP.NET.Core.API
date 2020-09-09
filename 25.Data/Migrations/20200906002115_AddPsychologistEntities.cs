using Microsoft.EntityFrameworkCore.Migrations;

namespace _25.Data.Migrations
{
    public partial class AddPsychologistEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Psychologists",
                columns: table => new
                {
                    PsychologistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PracticeNo = table.Column<string>(nullable: false),
                    HPCSANo = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    About = table.Column<string>(nullable: true),
                    PracticeTitle = table.Column<string>(nullable: false),
                    WorkContactNumber = table.Column<string>(nullable: false),
                    CellContactNumber = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psychologists", x => x.PsychologistId);
                });

            migrationBuilder.CreateTable(
                name: "PsychologistQualifications",
                columns: table => new
                {
                    PsychologistQualificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    PsychologistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychologistQualifications", x => x.PsychologistQualificationId);
                    table.ForeignKey(
                        name: "FK_PsychologistQualifications_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologists",
                        principalColumn: "PsychologistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PsychologistServices",
                columns: table => new
                {
                    PsychologistServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    PsychologistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychologistServices", x => x.PsychologistServiceId);
                    table.ForeignKey(
                        name: "FK_PsychologistServices_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologists",
                        principalColumn: "PsychologistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PsychologistQualifications_PsychologistId",
                table: "PsychologistQualifications",
                column: "PsychologistId");

            migrationBuilder.CreateIndex(
                name: "IX_PsychologistServices_PsychologistId",
                table: "PsychologistServices",
                column: "PsychologistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PsychologistQualifications");

            migrationBuilder.DropTable(
                name: "PsychologistServices");

            migrationBuilder.DropTable(
                name: "Psychologists");
        }
    }
}

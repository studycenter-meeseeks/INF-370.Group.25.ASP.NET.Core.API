using Microsoft.EntityFrameworkCore.Migrations;

namespace _25.Data.Migrations
{
    public partial class addPatientMedicalAidModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalAid",
                columns: table => new
                {
                    MedicalAidId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Option = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    MainMember_Name = table.Column<string>(nullable: true),
                    MainMember_Surname = table.Column<string>(nullable: true),
                    MainMember_IdNumber = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAid", x => x.MedicalAidId);
                    table.ForeignKey(
                        name: "FK_MedicalAid_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalAidDependentMember",
                columns: table => new
                {
                    MedicalAidDependentMemberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    IdNumber = table.Column<string>(nullable: false),
                    MedicalAidId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAidDependentMember", x => x.MedicalAidDependentMemberId);
                    table.ForeignKey(
                        name: "FK_MedicalAidDependentMember_MedicalAid_MedicalAidId",
                        column: x => x.MedicalAidId,
                        principalTable: "MedicalAid",
                        principalColumn: "MedicalAidId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAid_PatientId",
                table: "MedicalAid",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAidDependentMember_MedicalAidId",
                table: "MedicalAidDependentMember",
                column: "MedicalAidId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalAidDependentMember");

            migrationBuilder.DropTable(
                name: "MedicalAid");
        }
    }
}

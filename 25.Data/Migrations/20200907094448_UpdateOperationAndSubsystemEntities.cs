using Microsoft.EntityFrameworkCore.Migrations;

namespace _25.Data.Migrations
{
    public partial class UpdateOperationAndSubsystemEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_SubSystems_SubSystemId",
                table: "Operations");

            migrationBuilder.DropForeignKey(
                name: "FK_SubSystems_Systems_SystemId",
                table: "SubSystems");

            migrationBuilder.DropIndex(
                name: "IX_SubSystems_SystemId",
                table: "SubSystems");

            migrationBuilder.DropIndex(
                name: "IX_Operations_SubSystemId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "SystemId",
                table: "SubSystems");

            migrationBuilder.DropColumn(
                name: "HasPermission",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "SubSystemId",
                table: "Operations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SystemId",
                table: "SubSystems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasPermission",
                table: "Operations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SubSystemId",
                table: "Operations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubSystems_SystemId",
                table: "SubSystems",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_SubSystemId",
                table: "Operations",
                column: "SubSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_SubSystems_SubSystemId",
                table: "Operations",
                column: "SubSystemId",
                principalTable: "SubSystems",
                principalColumn: "SubSystemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubSystems_Systems_SystemId",
                table: "SubSystems",
                column: "SystemId",
                principalTable: "Systems",
                principalColumn: "SystemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

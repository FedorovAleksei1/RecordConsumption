using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class AddPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorPolyclinic");

            migrationBuilder.AddColumn<int>(
                name: "PolyclinicId",
                table: "Practices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolyclinicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Polyclinics_PolyclinicId",
                        column: x => x.PolyclinicId,
                        principalTable: "Polyclinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Practices_PolyclinicId",
                table: "Practices",
                column: "PolyclinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PhotoId",
                table: "Doctors",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PolyclinicId",
                table: "Photos",
                column: "PolyclinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Photos_PhotoId",
                table: "Doctors",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Practices_Polyclinics_PolyclinicId",
                table: "Practices",
                column: "PolyclinicId",
                principalTable: "Polyclinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Photos_PhotoId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Practices_Polyclinics_PolyclinicId",
                table: "Practices");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Practices_PolyclinicId",
                table: "Practices");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_PhotoId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PolyclinicId",
                table: "Practices");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Doctors");

            migrationBuilder.CreateTable(
                name: "DoctorPolyclinic",
                columns: table => new
                {
                    DoctorsId = table.Column<int>(type: "int", nullable: false),
                    PolyclinicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPolyclinic", x => new { x.DoctorsId, x.PolyclinicsId });
                    table.ForeignKey(
                        name: "FK_DoctorPolyclinic_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorPolyclinic_Polyclinics_PolyclinicsId",
                        column: x => x.PolyclinicsId,
                        principalTable: "Polyclinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPolyclinic_PolyclinicsId",
                table: "DoctorPolyclinic",
                column: "PolyclinicsId");
        }
    }
}

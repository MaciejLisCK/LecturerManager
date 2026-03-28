using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LecturerManager.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courx_course",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courx_course", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "assix_assignment",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    course_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assix_assignment", x => x.id);
                    table.ForeignKey(
                        name: "FK_assix_assignment_courx_course_course_id",
                        column: x => x.course_id,
                        principalTable: "courx_course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assii_assignment_item",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    assignment_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    item_type = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assii_assignment_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_assii_assignment_item_assix_assignment_assignment_id",
                        column: x => x.assignment_id,
                        principalTable: "assix_assignment",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_assii_assignment_item_assignment_id",
                table: "assii_assignment_item",
                column: "assignment_id");

            migrationBuilder.CreateIndex(
                name: "IX_assix_assignment_course_id",
                table: "assix_assignment",
                column: "course_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assii_assignment_item");

            migrationBuilder.DropTable(
                name: "assix_assignment");

            migrationBuilder.DropTable(
                name: "courx_course");
        }
    }
}

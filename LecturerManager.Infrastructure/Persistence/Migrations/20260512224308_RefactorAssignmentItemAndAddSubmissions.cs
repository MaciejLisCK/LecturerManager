using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LecturerManager.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RefactorAssignmentItemAndAddSubmissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "assii_assignment_item");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "assii_assignment_item");

            migrationBuilder.AlterColumn<string>(
                name: "item_type",
                table: "assii_assignment_item",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(21)",
                oldMaxLength: 21);

            migrationBuilder.CreateTable(
                name: "asisu_assignment_item_submission",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    assignment_item_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    submission_type = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asisu_assignment_item_submission", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asisu_assignment_item_submission");

            migrationBuilder.AlterColumn<string>(
                name: "item_type",
                table: "assii_assignment_item",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "assii_assignment_item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "assii_assignment_item",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

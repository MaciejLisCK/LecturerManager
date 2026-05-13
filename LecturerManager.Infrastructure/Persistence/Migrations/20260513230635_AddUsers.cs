using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LecturerManager.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userx_user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    login = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    student_index = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    email = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userx_user", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "userx_user",
                columns: new[] { "id", "email", "first_name", "last_name", "login", "password_hash", "role", "student_index" },
                values: new object[] { new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), null, null, null, "admin", "$2a$11$LnKL1uRSBuPJFSywy.UX0.JmKM63Qjo3z7flsUvx/Hw33eLt7PnJK", 0, null });

            migrationBuilder.CreateIndex(
                name: "IX_userx_user_login",
                table: "userx_user",
                column: "login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userx_user");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LecturerManager.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTeacherPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "userx_user",
                keyColumn: "id",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"),
                column: "password_hash",
                value: "$2a$11$8MqFe/099pa66yV3/J021eAcc6e1BI/spqZ.8UbzxPFeNC2iEFjzm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "userx_user",
                keyColumn: "id",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"),
                column: "password_hash",
                value: "$2a$11$LnKL1uRSBuPJFSywy.UX0.JmKM63Qjo3z7flsUvx/Hw33eLt7PnJK");
        }
    }
}

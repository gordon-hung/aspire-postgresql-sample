using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aspire.PostgreSQLSample.MigrationEntry.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "users",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "識別碼"),
                    username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, comment: "用戶名"),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "密碼"),
                    state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "狀態"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "更新時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_users_username",
                schema: "dbo",
                table: "users",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users",
                schema: "dbo");
        }
    }
}

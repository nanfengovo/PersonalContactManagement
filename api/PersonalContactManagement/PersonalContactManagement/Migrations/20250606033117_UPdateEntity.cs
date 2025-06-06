using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalContactManagement.Migrations
{
    /// <inheritdoc />
    public partial class UPdateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "T_Contact",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelted",
                table: "T_Contact",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "T_Contact",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "T_Contact");

            migrationBuilder.DropColumn(
                name: "IsDelted",
                table: "T_Contact");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "T_Contact");
        }
    }
}

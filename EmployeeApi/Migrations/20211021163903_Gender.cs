﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeApi.Migrations
{
    public partial class Gender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "GenderType",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenderType",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

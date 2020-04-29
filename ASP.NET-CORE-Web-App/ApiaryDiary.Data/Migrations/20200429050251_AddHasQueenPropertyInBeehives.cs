﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiaryDiary.Data.Migrations
{
    public partial class AddHasQueenPropertyInBeehives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasQueen",
                table: "Beehives",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasQueen",
                table: "Beehives");
        }
    }
}

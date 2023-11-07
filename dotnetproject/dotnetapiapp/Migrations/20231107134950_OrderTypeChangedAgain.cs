using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetapiapp.Migrations
{
    public partial class OrderTypeChangedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EstablishmentDate",
                table: "Orders",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstablishmentDate",
                table: "Orders");
        }
    }
}

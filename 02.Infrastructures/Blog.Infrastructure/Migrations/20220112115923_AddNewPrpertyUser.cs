using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Infrastructure.Migrations
{
    public partial class AddNewPrpertyUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 12, 15, 29, 22, 603, DateTimeKind.Local).AddTicks(8531),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 12, 13, 38, 1, 242, DateTimeKind.Local).AddTicks(6699));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 12, 13, 38, 1, 242, DateTimeKind.Local).AddTicks(6699),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 12, 15, 29, 22, 603, DateTimeKind.Local).AddTicks(8531));
        }
    }
}

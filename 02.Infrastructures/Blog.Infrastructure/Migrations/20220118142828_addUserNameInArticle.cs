using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Infrastructure.Migrations
{
    public partial class addUserNameInArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 18, 17, 58, 27, 490, DateTimeKind.Local).AddTicks(5896),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 16, 20, 14, 46, 996, DateTimeKind.Local).AddTicks(532));

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Articles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 16, 20, 14, 46, 996, DateTimeKind.Local).AddTicks(532),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 18, 17, 58, 27, 490, DateTimeKind.Local).AddTicks(5896));
        }
    }
}

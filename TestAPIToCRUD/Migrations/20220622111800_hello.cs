using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAPIToCRUD.Migrations
{
    public partial class hello : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LogIn",
                table: "LogIn");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LogIn");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "LogIn");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "LogIn");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "LogIn",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogIn",
                table: "LogIn",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LogIn",
                table: "LogIn");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "LogIn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "LogIn",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "LogIn",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LogIn",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogIn",
                table: "LogIn",
                column: "Id");
        }
    }
}

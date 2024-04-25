using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIMaster.Migrations
{
    public partial class migrations003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarefas",
                table: "Tarefas");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "tb_Usuarios");

            migrationBuilder.RenameTable(
                name: "Tarefas",
                newName: "tb_Tarefas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_Usuarios",
                table: "tb_Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_Tarefas",
                table: "tb_Tarefas",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_Usuarios",
                table: "tb_Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_Tarefas",
                table: "tb_Tarefas");

            migrationBuilder.RenameTable(
                name: "tb_Usuarios",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "tb_Tarefas",
                newName: "Tarefas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tarefas",
                table: "Tarefas",
                column: "Id");
        }
    }
}

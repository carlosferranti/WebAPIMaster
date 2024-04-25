using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIMaster.Migrations
{
    public partial class migrations001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioModel",
                table: "UsuarioModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TarefaModel",
                table: "TarefaModel");

            migrationBuilder.RenameTable(
                name: "UsuarioModel",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "TarefaModel",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarefas",
                table: "Tarefas");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "UsuarioModel");

            migrationBuilder.RenameTable(
                name: "Tarefas",
                newName: "TarefaModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioModel",
                table: "UsuarioModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TarefaModel",
                table: "TarefaModel",
                column: "Id");
        }
    }
}

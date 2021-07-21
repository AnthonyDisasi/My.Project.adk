using Microsoft.EntityFrameworkCore.Migrations;

namespace My.Project.adk.Migrations
{
    public partial class init_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Eleves");

            migrationBuilder.RenameColumn(
                name: "Sexe",
                table: "Classes",
                newName: "Section");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Section",
                table: "Classes",
                newName: "Sexe");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Eleves",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

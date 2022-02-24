using Microsoft.EntityFrameworkCore.Migrations;

namespace HappyBday.Persistence.Migrations
{
    public partial class parentesconull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aniversarios_Parentescos_ParentescoId",
                table: "Aniversarios");

            migrationBuilder.AlterColumn<int>(
                name: "ParentescoId",
                table: "Aniversarios",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Aniversarios_Parentescos_ParentescoId",
                table: "Aniversarios",
                column: "ParentescoId",
                principalTable: "Parentescos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aniversarios_Parentescos_ParentescoId",
                table: "Aniversarios");

            migrationBuilder.AlterColumn<int>(
                name: "ParentescoId",
                table: "Aniversarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Aniversarios_Parentescos_ParentescoId",
                table: "Aniversarios",
                column: "ParentescoId",
                principalTable: "Parentescos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

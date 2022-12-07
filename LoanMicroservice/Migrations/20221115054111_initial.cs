using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanMicroservice.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "loan",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lnum = table.Column<int>(type: "int", nullable: false),
                    paddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lamount = table.Column<long>(type: "bigint", nullable: false),
                    ltype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lterm = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loan", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "loan");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace CrediAPI.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardOwnerFirstname = table.Column<string>(maxLength: 50, nullable: false),
                    CardOwnerLastname = table.Column<string>(maxLength: 50, nullable: false),
                    CardNumber = table.Column<string>(maxLength: 16, nullable: false),
                    ExpirationDate = table.Column<string>(maxLength: 5, nullable: false),
                    CVV = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCards");
        }
    }
}

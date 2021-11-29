using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthTestApp.Migrations
{
    public partial class addHardwareToDatabase3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Hardware",
                columns: table => new
                {
                    SN = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Model_Number = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    MAC_Address = table.Column<float>(type: "nvarchar(150)", nullable: false),
                    In_Use = table.Column<string>(type: "nchar(10)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hardware", x => x.SN);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hardware");

        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Flight.AirService.AccessData.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transport",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightCarrier = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    FlightNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transport", x => x.ID);
                });


            migrationBuilder.CreateTable(
                name: "Journey",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    TotalPrice = table.Column<int>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journey", x => x.ID); 
                }); 


            migrationBuilder.CreateTable(
                name: "FlightDTL",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDTransport = table.Column<int>(type: "int", nullable: false),
                    IDJourney = table.Column<int>(type: "int", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Price = table.Column<int>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightDTL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FlightDTL_Transport",
                        column: x => x.IDTransport,
                        principalTable: "Transport",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightDTL_Journey",
                        column: x => x.IDJourney,
                        principalTable: "Journey",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IXFlightDTL_IDTransport",
                table: "FlightDTL",
                column: "IDTransport");

            migrationBuilder.CreateIndex(
                name: "IXFlightDTL_IDJourney",
                table: "FlightDTL",
                column: "IDJourney");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightDTL");

            migrationBuilder.DropTable(
                name: "Journey");

            migrationBuilder.DropTable(
                name: "Transport");
        }
    }
}

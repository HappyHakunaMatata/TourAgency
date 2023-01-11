using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourAgency.Migrations
{
    /// <inheritdoc />
    public partial class initial001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "abouts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    info = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abouts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    flag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "HolidayTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    adress = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Qualities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<int>(type: "int", nullable: false),
                    super = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    room = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roomServices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomServices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ticketTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticketTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    countryid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.id);
                    table.ForeignKey(
                        name: "FK_cities_Countries_countryid",
                        column: x => x.countryid,
                        principalTable: "Countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    countryid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Regions_Countries_countryid",
                        column: x => x.countryid,
                        principalTable: "Countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cityid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.id);
                    table.ForeignKey(
                        name: "FK_Airports_cities_cityid",
                        column: x => x.cityid,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    recomended = table.Column<bool>(type: "bit", nullable: false),
                    regionid = table.Column<int>(type: "int", nullable: false),
                    qualityid = table.Column<int>(type: "int", nullable: false),
                    roomid = table.Column<int>(type: "int", nullable: true),
                    roomServiceid = table.Column<int>(type: "int", nullable: true),
                    transferid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.id);
                    table.ForeignKey(
                        name: "FK_Hotels_Qualities_qualityid",
                        column: x => x.qualityid,
                        principalTable: "Qualities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hotels_Regions_regionid",
                        column: x => x.regionid,
                        principalTable: "Regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hotels_Rooms_roomid",
                        column: x => x.roomid,
                        principalTable: "Rooms",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Hotels_Transfers_transferid",
                        column: x => x.transferid,
                        principalTable: "Transfers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Hotels_roomServices_roomServiceid",
                        column: x => x.roomServiceid,
                        principalTable: "roomServices",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "aircompanies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ticketTypeid = table.Column<int>(type: "int", nullable: true),
                    airportid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aircompanies", x => x.id);
                    table.ForeignKey(
                        name: "FK_aircompanies_Airports_airportid",
                        column: x => x.airportid,
                        principalTable: "Airports",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_aircompanies_ticketTypes_ticketTypeid",
                        column: x => x.ticketTypeid,
                        principalTable: "ticketTypes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "trips",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aircompanyid = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trips", x => x.id);
                    table.ForeignKey(
                        name: "FK_trips_aircompanies_aircompanyid",
                        column: x => x.aircompanyid,
                        principalTable: "aircompanies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    duration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    price = table.Column<long>(type: "bigint", nullable: false),
                    tripid = table.Column<int>(type: "int", nullable: false),
                    hotelid = table.Column<int>(type: "int", nullable: false),
                    holidayTypeid = table.Column<int>(type: "int", nullable: false),
                    aboutid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_HolidayTypes_holidayTypeid",
                        column: x => x.holidayTypeid,
                        principalTable: "HolidayTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Hotels_hotelid",
                        column: x => x.hotelid,
                        principalTable: "Hotels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_abouts_aboutid",
                        column: x => x.aboutid,
                        principalTable: "abouts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_trips_tripid",
                        column: x => x.tripid,
                        principalTable: "trips",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_orderDetails_Orders_orderID",
                        column: x => x.orderID,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shopCartItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productid = table.Column<int>(type: "int", nullable: false),
                    ShopCartId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopCartItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_shopCartItems_Products_productid",
                        column: x => x.productid,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aircompanies_airportid",
                table: "aircompanies",
                column: "airportid");

            migrationBuilder.CreateIndex(
                name: "IX_aircompanies_ticketTypeid",
                table: "aircompanies",
                column: "ticketTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_cityid",
                table: "Airports",
                column: "cityid");

            migrationBuilder.CreateIndex(
                name: "IX_cities_countryid",
                table: "cities",
                column: "countryid");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_qualityid",
                table: "Hotels",
                column: "qualityid");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_regionid",
                table: "Hotels",
                column: "regionid");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_roomid",
                table: "Hotels",
                column: "roomid");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_roomServiceid",
                table: "Hotels",
                column: "roomServiceid");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_transferid",
                table: "Hotels",
                column: "transferid");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_orderID",
                table: "orderDetails",
                column: "orderID");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_ProductID",
                table: "orderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_aboutid",
                table: "Products",
                column: "aboutid");

            migrationBuilder.CreateIndex(
                name: "IX_Products_holidayTypeid",
                table: "Products",
                column: "holidayTypeid");

            migrationBuilder.CreateIndex(
                name: "IX_Products_hotelid",
                table: "Products",
                column: "hotelid");

            migrationBuilder.CreateIndex(
                name: "IX_Products_tripid",
                table: "Products",
                column: "tripid");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_countryid",
                table: "Regions",
                column: "countryid");

            migrationBuilder.CreateIndex(
                name: "IX_shopCartItems_productid",
                table: "shopCartItems",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_trips_aircompanyid",
                table: "trips",
                column: "aircompanyid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderDetails");

            migrationBuilder.DropTable(
                name: "shopCartItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "HolidayTypes");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "abouts");

            migrationBuilder.DropTable(
                name: "trips");

            migrationBuilder.DropTable(
                name: "Qualities");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "roomServices");

            migrationBuilder.DropTable(
                name: "aircompanies");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "ticketTypes");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}

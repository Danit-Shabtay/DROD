using Microsoft.EntityFrameworkCore.Migrations;

namespace DROD.Migrations
{
    public partial class updateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemName", "Price", "Gender", "Path" },
                values: new object[,]
                {
                    {"DROD DESIGN", 120, 1, "../images/W1.JPEG" },
                    {"DROD DESIGN", 130, 1, "../images/W2.JPEG" },
                    {"DROD DESIGN", 150, 1, "../images/W3.JPEG" },
                    {"DROD DESIGN", 300, 1, "../images/W4.JPEG" },
                    {"DROD DESIGN", 119, 1, "../images/W5.JPEG" },
                    {"DROD DESIGN", 109, 1, "../images/W6.JPEG" },
                    {"DROD DESIGN", 89, 1, "../images/W7.JPEG" },
                    {"DROD DESIGN", 99, 1, "../images/W8.JPEG" },
                    {"DROD DESIGN", 79, 1, "../images/W9.JPEG" },
                    {"DROD DESIGN", 129, 1, "../images/W10.JPEG" },
                    {"DROD DESIGN", 109, 1, "../images/W11.JPEG" },
                    {"DROD DESIGN", 149, 1, "../images/W12.JPEG" },
                    {"DROD DESIGN", 179, 1, "../images/W13.JPEG" },
                    {"DROD DESIGN", 359, 1, "../images/W14.JPEG" },
                    {"DROD DESIGN", 359, 1,  "../images/W15.JPEG" },
                    {"DROD DESIGN", 99, 1, "../images/W16.JPEG" },
                    {"DROD DESIGN", 109, 0,  "../images/M1.JPEG" },
                    {"DROD DESIGN", 89, 0, "../images/M2.JPEG" },
                    {"DROD DESIGN", 79, 0, "../images/M3.JPEG" },
                    {"DROD DESIGN", 129, 0, "../images/M4.JPEG" },
                    {"DROD DESIGN", 119, 0, "../images/M5.JPEG" },
                    {"DROD DESIGN", 99, 0, "../images/M6.JPEG" },
                    {"DROD DESIGN", 89, 0, "../images/M7.JPEG" },
                    {"DROD DESIGN", 149, 0, "../images/M8.JPEG" },
                    {"DROD DESIGN", 69, 0, "../images/M9.JPEG" },
                    {"DROD DESIGN", 79, 0, "../images/M10.JPEG" },
                    {"DROD DESIGN", 99, 0, "../images/M11.JPEG" },
                    {"DROD DESIGN", 119, 0, "../images/M12.JPEG" },
                    {"DROD DESIGN", 89, 0,  "../images/M13.JPEG" },
                    {"DROD DESIGN", 99, 0, "../images/M14.JPEG" },
                    {"DROD DESIGN", 79, 0, "../images/M15.JPEG" },
                    {"DROD DESIGN", 89, 0, "../images/M16.JPEG" },
                    {"DROD DESIGN", 89, 2,  "../images/S1.JPEG" },
                    {"DROD DESIGN", 99, 2, "../images/S2.JPEG" },
                    {"DROD DESIGN", 79, 2, "../images/S3.JPEG" },
                    {"DROD DESIGN", 99, 2, "../images/S4.JPEG" },
                    {"DROD DESIGN", 109, 2, "../images/S5.JPEG "},
                    {"DROD DESIGN", 69, 2, "../images/S6.JPEG "},
                    {"DROD DESIGN", 89, 2, "../images/S7.JPEG" },
                    {"DROD DESIGN", 99, 2, "../images/S8.JPEG "},
                    {"DROD DESIGN", 69, 2, "../images/S9.JPEG" },
                    {"DROD DESIGN", 99, 2, "../images/S10.JPEG" },
                    {"DROD DESIGN", 79, 2, "../images/S11.JPEG" },
                    {"DROD DESIGN", 69, 2, "../images/S12.JPEG "},
                    {"DROD DESIGN", 59, 2, "../images/S13.JPEG" },
                    {"DROD DESIGN", 79, 2, "../images/S14.JPEG "},
                    {"DROD DESIGN", 49, 2, "../images/S15.JPEG "},
                    {"DROD DESIGN", 59, 2, "../images/S16.JPEG "},
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

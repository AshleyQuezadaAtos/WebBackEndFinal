using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBackEndRepo.Migrations
{
    public partial class newDefaultValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TopicTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Video" },
                    { 2, null, "Audio" },
                    { 3, null, "HTML" },
                    { 4, null, "PDF" },
                    { 5, null, "Test" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TopicTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TopicTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TopicTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TopicTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TopicTypes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}

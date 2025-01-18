using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProje2.Migrations
{
    /// <inheritdoc />
    public partial class CreateDurumColumnInKategorilerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Durum",
                table: "Kategoriler",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Durum",
                table: "Kategoriler");
        }
    }
}

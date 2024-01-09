using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ThumnailImageId",
                table: "Properties",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PropertyImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PropertyId = table.Column<int>(type: "integer", nullable: false),
                    Extension = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyImages_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ThumnailImageId",
                table: "Properties",
                column: "ThumnailImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImages_PropertyId",
                table: "PropertyImages",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PropertyImages_ThumnailImageId",
                table: "Properties",
                column: "ThumnailImageId",
                principalTable: "PropertyImages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_PropertyImages_ThumnailImageId",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "PropertyImages");

            migrationBuilder.DropIndex(
                name: "IX_Properties_ThumnailImageId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ThumnailImageId",
                table: "Properties");
        }
    }
}

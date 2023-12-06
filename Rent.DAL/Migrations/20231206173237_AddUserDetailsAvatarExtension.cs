﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUserDetailsAvatarExtension : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarExtension",
                table: "UserDetails",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarExtension",
                table: "UserDetails");
        }
    }
}

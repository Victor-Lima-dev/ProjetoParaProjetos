﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoParaProjetos.Migrations
{
    /// <inheritdoc />
    public partial class categorianotas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Notas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Notas");
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SemaFlags.Migrations
{
    public partial class FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Groups_BoardId",
                table: "Groups",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Boards_BoardId",
                table: "Groups",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Boards_BoardId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_BoardId",
                table: "Groups");
        }
    }
}

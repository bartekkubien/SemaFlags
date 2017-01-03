using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SemaFlags.Migrations
{
    public partial class Uba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "BoardOwnerId",
                table: "Boards");

            migrationBuilder.AddColumn<int>(
                name: "UserKeyId",
                table: "Boards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Boards_UserKeyId",
                table: "Boards",
                column: "UserKeyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_AspNetUsers_UserKeyId",
                table: "Boards",
                column: "UserKeyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_AspNetUsers_UserKeyId",
                table: "Boards");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_Boards_UserKeyId",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "UserKeyId",
                table: "Boards");

            migrationBuilder.AddColumn<int>(
                name: "BoardOwnerId",
                table: "Boards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");
        }
    }
}

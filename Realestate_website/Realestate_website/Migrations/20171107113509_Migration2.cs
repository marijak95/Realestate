using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Realestate_website.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_UploadImage_Imageid",
                table: "Advertisement");

            migrationBuilder.DropTable(
                name: "UploadImage");

            migrationBuilder.DropIndex(
                name: "IX_Advertisement_Imageid",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "Imageid",
                table: "Advertisement");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Advertisement",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Advertisement");

            migrationBuilder.AddColumn<int>(
                name: "Imageid",
                table: "Advertisement",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UploadImage",
                columns: table => new
                {
                    Imageid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdID = table.Column<int>(nullable: false),
                    Content = table.Column<byte[]>(nullable: true),
                    ContentType = table.Column<string>(maxLength: 100, nullable: true),
                    Imagename = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadImage", x => x.Imageid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_Imageid",
                table: "Advertisement",
                column: "Imageid");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_UploadImage_Imageid",
                table: "Advertisement",
                column: "Imageid",
                principalTable: "UploadImage",
                principalColumn: "Imageid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

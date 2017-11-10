using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Realestate_website.Migrations
{
    public partial class MigrationImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Advertisement_AdvertisementID",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_AdvertisementID",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AdvertisementID",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "UploadImage");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Advertisement",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "Advertisement",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Advertisement",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Area",
                table: "Advertisement",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Advertisement",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Imageid",
                table: "Advertisement",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UploadImage",
                table: "UploadImage",
                column: "Imageid");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_UploadImage_Imageid",
                table: "Advertisement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UploadImage",
                table: "UploadImage");

            migrationBuilder.DropIndex(
                name: "IX_Advertisement_Imageid",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "Imageid",
                table: "Advertisement");

            migrationBuilder.RenameTable(
                name: "UploadImage",
                newName: "Images");

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementID",
                table: "Images",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Advertisement",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "Advertisement",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Advertisement",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Area",
                table: "Advertisement",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Advertisement",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Imageid");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AdvertisementID",
                table: "Images",
                column: "AdvertisementID");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Advertisement_AdvertisementID",
                table: "Images",
                column: "AdvertisementID",
                principalTable: "Advertisement",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

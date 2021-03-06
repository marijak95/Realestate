﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Realestate_website.Data;

namespace Realestate_website.Migrations
{
    [DbContext(typeof(AdContext))]
    [Migration("20171107074002_MigrationImages")]
    partial class MigrationImages
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Realestate_website.Data.EfModels.Advertisement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Area")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Contact")
                        .IsRequired();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int?>("Imageid");

                    b.Property<bool>("OneRoom");

                    b.Property<int>("Price");

                    b.Property<bool>("Studio");

                    b.Property<bool>("ThreeRooms");

                    b.Property<bool>("TwoRooms");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("Imageid");

                    b.ToTable("Advertisement");
                });

            modelBuilder.Entity("Realestate_website.Data.EfModels.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdvertisementID");

                    b.Property<int?>("CommentID1");

                    b.Property<DateTime>("DateOfComent");

                    b.Property<int>("Dislike");

                    b.Property<int>("Like");

                    b.Property<string>("Text");

                    b.Property<string>("UserId");

                    b.HasKey("CommentID");

                    b.HasIndex("AdvertisementID");

                    b.HasIndex("CommentID1");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Realestate_website.Data.EfModels.UploadImage", b =>
                {
                    b.Property<int>("Imageid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdID");

                    b.Property<byte[]>("Content");

                    b.Property<string>("ContentType")
                        .HasMaxLength(100);

                    b.Property<string>("Imagename")
                        .HasMaxLength(255);

                    b.HasKey("Imageid");

                    b.ToTable("UploadImage");
                });

            modelBuilder.Entity("Realestate_website.Data.EfModels.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Realestate_website.Data.EfModels.Advertisement", b =>
                {
                    b.HasOne("Realestate_website.Data.EfModels.UploadImage", "Image")
                        .WithMany()
                        .HasForeignKey("Imageid");
                });

            modelBuilder.Entity("Realestate_website.Data.EfModels.Comment", b =>
                {
                    b.HasOne("Realestate_website.Data.EfModels.Advertisement")
                        .WithMany("Comments")
                        .HasForeignKey("AdvertisementID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Realestate_website.Data.EfModels.Comment")
                        .WithMany("Comments")
                        .HasForeignKey("CommentID1");
                });
        }
    }
}

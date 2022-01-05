﻿// <auto-generated />
using EFGetStarted;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFGetStarted.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20220105133741_IndexTuto")]
    partial class IndexTuto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("EFGetStarted.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("EFGetStarted.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BlogId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PostId");

                    b.HasIndex("BlogId");

                    b.HasIndex(new[] { "Title" }, "TituloPost")
                        .IsUnique();

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("EFGetStarted.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.Property<int>("postsPostId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("tagsTagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("postsPostId", "tagsTagId");

                    b.HasIndex("tagsTagId");

                    b.ToTable("PostTag");
                });

            modelBuilder.Entity("EFGetStarted.Post", b =>
                {
                    b.HasOne("EFGetStarted.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.HasOne("EFGetStarted.Post", null)
                        .WithMany()
                        .HasForeignKey("postsPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFGetStarted.Tag", null)
                        .WithMany()
                        .HasForeignKey("tagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFGetStarted.Blog", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Practicum_berezin_2;

#nullable disable

namespace Practicumberezin2.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Practicum_berezin_2.Emotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ImageId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("emotion_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("emotion_val")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("Image_emotions");
                });

            modelBuilder.Entity("Practicum_berezin_2.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Practicum_berezin_2.Image_directly", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ImageId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Raw_data")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("ImageId")
                        .IsUnique();

                    b.ToTable("Blobs");
                });

            modelBuilder.Entity("Practicum_berezin_2.Emotion", b =>
                {
                    b.HasOne("Practicum_berezin_2.Image", "image")
                        .WithMany("Emotions")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("image");
                });

            modelBuilder.Entity("Practicum_berezin_2.Image_directly", b =>
                {
                    b.HasOne("Practicum_berezin_2.Image", "image")
                        .WithOne("Blob")
                        .HasForeignKey("Practicum_berezin_2.Image_directly", "ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("image");
                });

            modelBuilder.Entity("Practicum_berezin_2.Image", b =>
                {
                    b.Navigation("Blob")
                        .IsRequired();

                    b.Navigation("Emotions");
                });
#pragma warning restore 612, 618
        }
    }
}

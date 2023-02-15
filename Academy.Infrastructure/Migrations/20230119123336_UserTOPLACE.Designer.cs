﻿// <auto-generated />
using System;
using Academy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Academy.Infrastructure.Migrations
{
    [DbContext(typeof(AcademyDataContext))]
    [Migration("20230119123336_UserTOPLACE")]
    partial class UserTOPLACE
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.12");

            modelBuilder.Entity("Academy.Domain.Entities.Place", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("DATE('now')");

                    b.Property<double>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<double>("Longtitude")
                        .HasColumnType("REAL");

                    b.Property<DateTimeOffset>("ModificationDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("DATE('now')");

                    b.Property<int>("PeopleAmountFrom")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PeopleAmountTo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlaceName")
                        .HasColumnType("TEXT");

                    b.Property<double>("PriceFrom")
                        .HasColumnType("REAL");

                    b.Property<double>("PriceTo")
                        .HasColumnType("REAL");

                    b.Property<double>("Rating")
                        .HasColumnType("REAL");

                    b.Property<int>("RatingAmount")
                        .HasColumnType("INTEGER");

                    b.Property<double>("VisitDurationFrom")
                        .HasColumnType("REAL");

                    b.Property<double>("VisitDurationTo")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Academy.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("DATE('now')");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("ModificationDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("DATE('now')");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Academy.Domain.Entities.UserPlace", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("DATE('now')");

                    b.Property<DateTimeOffset>("ModificationDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("DATE('now')");

                    b.Property<Guid>("PlaceId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPlaces");
                });

            modelBuilder.Entity("Academy.Domain.Entities.UserPlace", b =>
                {
                    b.HasOne("Academy.Domain.Entities.Place", "Place")
                        .WithMany("UserPlaces")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Academy.Domain.Entities.User", "User")
                        .WithMany("UserPlaces")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Academy.Domain.Entities.Place", b =>
                {
                    b.Navigation("UserPlaces");
                });

            modelBuilder.Entity("Academy.Domain.Entities.User", b =>
                {
                    b.Navigation("UserPlaces");
                });
#pragma warning restore 612, 618
        }
    }
}

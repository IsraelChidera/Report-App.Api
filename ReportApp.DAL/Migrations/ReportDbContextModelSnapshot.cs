﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReportApp.DAL;

#nullable disable

namespace ReportApp.DAL.Migrations
{
    [DbContext(typeof(ReportDbContext))]
    partial class ReportDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "6504efdc-d3de-4201-bc57-844a5780bfe6",
                            ConcurrencyStamp = "24de958c-d646-4bb9-8d14-deee994b4e80",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        },
                        new
                        {
                            Id = "a6208081-1c3a-4b90-8d91-fb4ef9980849",
                            ConcurrencyStamp = "dda41085-08bd-4aa0-be0c-f8bd23d2beaf",
                            Name = "Organization",
                            NormalizedName = "ORGANIZATION"
                        },
                        new
                        {
                            Id = "ba41b6de-9b12-45ef-9db7-fc6e336e5926",
                            ConcurrencyStamp = "0a812506-5cd2-494a-b18f-44410a99f902",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ReportApp.BLL.Entities.AppUsers", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ReportApp.DAL.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EmployeeId");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppUsersId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUsersId");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("ReportApp.DAL.Entities.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OrganizationId");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations", (string)null);
                });

            modelBuilder.Entity("ReportApp.DAL.Entities.Report", b =>
                {
                    b.Property<Guid>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HazardDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HazardRating")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreventiveMeasure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResourceAtRisk")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RiskImpact")
                        .HasColumnType("int");

                    b.Property<int>("RiskProbability")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ReportId");

                    b.HasIndex("UserId1");

                    b.ToTable("Reports", (string)null);

                    b.HasData(
                        new
                        {
                            ReportId = new Guid("d4d1554e-4a96-4a34-bc71-c1f9b3ceba06"),
                            AdditionalInfo = "Jo ..",
                            HazardDescription = "Environment is ...",
                            HazardRating = 0,
                            Location = "Ikeja, Lagos",
                            PreventiveMeasure = "To ... ...",
                            ResourceAtRisk = "Environment",
                            RiskImpact = 1,
                            RiskProbability = 1,
                            UserId = new Guid("19f907bf-4633-4b75-8f53-35ce78eb97f2")
                        },
                        new
                        {
                            ReportId = new Guid("8c90bb06-13e5-4d8f-a14f-5461b9d2703a"),
                            AdditionalInfo = "Jo ..",
                            HazardDescription = "Environment is ...",
                            HazardRating = 0,
                            Location = "Enugu, Enugu",
                            PreventiveMeasure = "Eradixcated the use of pumps",
                            ResourceAtRisk = "Environment",
                            RiskImpact = 1,
                            RiskProbability = 1,
                            UserId = new Guid("9a6a288c-df87-476d-8c13-15e008c84d71")
                        },
                        new
                        {
                            ReportId = new Guid("a99b6593-2497-4baf-8568-15aa1c2f2e22"),
                            AdditionalInfo = "Jo ..",
                            HazardDescription = "Environment is ...",
                            HazardRating = 0,
                            Location = "Enugu, Enugu",
                            PreventiveMeasure = "Eradixcated the use of pumps",
                            ResourceAtRisk = "Environment",
                            RiskImpact = 1,
                            RiskProbability = 1,
                            UserId = new Guid("a8b6c9d0-22e5-45f1-a3c5-6e5b46d201c6")
                        },
                        new
                        {
                            ReportId = new Guid("5f5ca5c5-3b5e-40a3-9a9e-9fa9b7d04d51"),
                            AdditionalInfo = "Jo ..",
                            HazardDescription = "Fashion world is ...",
                            HazardRating = 0,
                            Location = "Agbelekale, Laos",
                            PreventiveMeasure = "Remains of clothes ...",
                            ResourceAtRisk = "Environment",
                            RiskImpact = 1,
                            RiskProbability = 1,
                            UserId = new Guid("d0b8c61b-7720-49f1-95c8-42e2b98d67e9")
                        },
                        new
                        {
                            ReportId = new Guid("10bc62a1-e8a6-476f-8fc2-743c1f46b8d8"),
                            AdditionalInfo = "Jo ..",
                            HazardDescription = "Baking is ...",
                            HazardRating = 0,
                            Location = "Nsukka, Enugu",
                            PreventiveMeasure = "Cakes and cakes materials ...",
                            ResourceAtRisk = "Environment",
                            RiskImpact = 1,
                            RiskProbability = 1,
                            UserId = new Guid("6c8a9db9-93a4-4d7b-8b8f-7e41aa1d52a7")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ReportApp.BLL.Entities.AppUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ReportApp.BLL.Entities.AppUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReportApp.BLL.Entities.AppUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ReportApp.BLL.Entities.AppUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReportApp.DAL.Entities.Employee", b =>
                {
                    b.HasOne("ReportApp.BLL.Entities.AppUsers", null)
                        .WithMany("Employees")
                        .HasForeignKey("AppUsersId");
                });

            modelBuilder.Entity("ReportApp.DAL.Entities.Report", b =>
                {
                    b.HasOne("ReportApp.BLL.Entities.AppUsers", "User")
                        .WithMany("Reports")
                        .HasForeignKey("UserId1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReportApp.BLL.Entities.AppUsers", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}

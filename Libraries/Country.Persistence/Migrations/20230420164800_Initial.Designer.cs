﻿// <auto-generated />
using System;
using Country.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Country.Persistence.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20230420164800_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Country.Domain.Entities.EF.Main.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasDefaultValueSql("NULL");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Latitude")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Longitude")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("StateCode")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<int>("StateId")
                        .HasColumnType("integer");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("WikiDataId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.HasIndex("CountryId", "StateId", "Name");

                    b.ToTable("Cities", (string)null);
                });

            modelBuilder.Entity("Country.Domain.Entities.EF.Main.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Capital")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Currency")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2500)
                        .HasColumnType("character varying(2500)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("CurrencyName")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("CurrencySymbol")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Emoji")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(191)
                        .HasColumnType("character varying(191)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("EmojiU")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(191)
                        .HasColumnType("character varying(191)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Iso2")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Iso3")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Latitude")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Longitude")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Native")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("NumericCode")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("PhoneCode")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Region")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("SubRegion")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Tld")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("Id");

                    b.ToTable("Countries", (string)null);
                });

            modelBuilder.Entity("Country.Domain.Entities.EF.Main.Language", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("Id");

                    b.HasIndex("Id", "Description");

                    b.ToTable("Languages", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "kr",
                            Description = "Korean"
                        },
                        new
                        {
                            Id = "pt-BR",
                            Description = "Portuguese (Brazil)"
                        },
                        new
                        {
                            Id = "pt",
                            Description = "Portuguese (Portugal)"
                        },
                        new
                        {
                            Id = "nl",
                            Description = "Dutch"
                        },
                        new
                        {
                            Id = "hr",
                            Description = "Croatian"
                        },
                        new
                        {
                            Id = "fa",
                            Description = "Farsi"
                        },
                        new
                        {
                            Id = "de",
                            Description = "German"
                        },
                        new
                        {
                            Id = "es",
                            Description = "Spanish"
                        },
                        new
                        {
                            Id = "fr",
                            Description = "French"
                        },
                        new
                        {
                            Id = "ja",
                            Description = "Japanese"
                        },
                        new
                        {
                            Id = "it",
                            Description = "Italian"
                        },
                        new
                        {
                            Id = "cn",
                            Description = "Chinese (S)"
                        },
                        new
                        {
                            Id = "tr",
                            Description = "Turkish"
                        });
                });

            modelBuilder.Entity("Country.Domain.Entities.EF.Main.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasDefaultValueSql("NULL");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Latitude")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Longitude")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("StateCode")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Type")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(191)
                        .HasColumnType("character varying(191)")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("Id");

                    b.HasIndex("CountryId", "Name");

                    b.ToTable("States", (string)null);
                });

            modelBuilder.Entity("Country.Domain.Entities.EF.Main.Timezone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasDefaultValueSql("NULL");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<int?>("GmtOffset")
                        .HasColumnType("integer");

                    b.Property<string>("GmtOffsetName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("TzName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("ZoneName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Timezones", (string)null);
                });

            modelBuilder.Entity("Country.Domain.Entities.EF.Main.Translation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("LanguageId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("character varying(10)")
                        .HasDefaultValueSql("NULL");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("LanguageId", "CountryId");

                    b.ToTable("Translations", (string)null);
                });

            modelBuilder.Entity("Country.Domain.Entities.EF.Main.City", b =>
                {
                    b.HasOne("Country.Domain.Entities.EF.Main.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Country.Domain.Entities.EF.Main.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Country.Domain.Entities.EF.Main.State", b =>
                {
                    b.HasOne("Country.Domain.Entities.EF.Main.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Country.Domain.Entities.EF.Main.Timezone", b =>
                {
                    b.HasOne("Country.Domain.Entities.EF.Main.Country", "Country")
                        .WithMany("Timezones")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Country.Domain.Entities.EF.Main.Translation", b =>
                {
                    b.HasOne("Country.Domain.Entities.EF.Main.Country", "Country")
                        .WithMany("Translations")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Country.Domain.Entities.EF.Main.Language", "Language")
                        .WithMany("Translations")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Country.Domain.Entities.EF.Main.Country", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("States");

                    b.Navigation("Timezones");

                    b.Navigation("Translations");
                });

            modelBuilder.Entity("Country.Domain.Entities.EF.Main.Language", b =>
                {
                    b.Navigation("Translations");
                });

            modelBuilder.Entity("Country.Domain.Entities.EF.Main.State", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}

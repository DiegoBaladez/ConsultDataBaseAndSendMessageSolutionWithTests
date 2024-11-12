﻿// <auto-generated />
using System;
using DatabaseApi.Infrastructure.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatabaseApi.Migrations
{
    [DbContext(typeof(TransactionsContext))]
    [Migration("20241109221443_PopulatingDatabase")]
    partial class PopulatingDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DatabaseApi.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountDigit")
                        .HasColumnType("int");

                    b.Property<long>("AccountNumber")
                        .HasColumnType("bigint");

                    b.Property<int>("CustomerNumber")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerNumber");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("DatabaseApi.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("CEP")
                        .HasColumnType("bigint");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Floor")
                        .HasColumnType("int");

                    b.Property<int?>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("OfficeNumber")
                        .HasColumnType("int");

                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Uf")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PeopleId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("DatabaseApi.Models.Entry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("CustomerNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DebitCreditIndicator")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerNumber");

                    b.ToTable("Entrys");
                });

            modelBuilder.Entity("DatabaseApi.Models.People", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeopleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasDiscriminator<string>("PeopleType").HasValue("People");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DatabaseApi.Models.Telephone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DDD")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PeopleId");

                    b.ToTable("Telephone");
                });

            modelBuilder.Entity("DatabaseApi.Models.Customer", b =>
                {
                    b.HasBaseType("DatabaseApi.Models.People");

                    b.Property<int>("CustomerNumber")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("DatabaseApi.Models.Account", b =>
                {
                    b.HasOne("DatabaseApi.Models.Customer", "Holder")
                        .WithMany("Account")
                        .HasForeignKey("CustomerNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Holder");
                });

            modelBuilder.Entity("DatabaseApi.Models.Address", b =>
                {
                    b.HasOne("DatabaseApi.Models.People", "People")
                        .WithMany("Address")
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("People");
                });

            modelBuilder.Entity("DatabaseApi.Models.Entry", b =>
                {
                    b.HasOne("DatabaseApi.Models.Account", "Account")
                        .WithMany("Entrys")
                        .HasForeignKey("CustomerNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DatabaseApi.Models.Telephone", b =>
                {
                    b.HasOne("DatabaseApi.Models.People", "People")
                        .WithMany("Telephone")
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("People");
                });

            modelBuilder.Entity("DatabaseApi.Models.Account", b =>
                {
                    b.Navigation("Entrys");
                });

            modelBuilder.Entity("DatabaseApi.Models.People", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Telephone");
                });

            modelBuilder.Entity("DatabaseApi.Models.Customer", b =>
                {
                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
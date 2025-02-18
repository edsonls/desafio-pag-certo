﻿// <auto-generated />
using System;
using DesafioPagCerto.Repository.EntityFramework.Drive;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesafioPagCerto.Repository.Migrations
{
    [DbContext(typeof(Drive))]
    partial class DriveModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DesafioPagCerto.Repository.EntityFramework.Models.Anticipation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AnalysisEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("AnalysisStartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("AnticipatedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RequestedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ResultAnalysis")
                        .HasColumnType("int");

                    b.Property<DateTime>("SolicitationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusAnticipation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Anticipation");
                });

            modelBuilder.Entity("DesafioPagCerto.Repository.EntityFramework.Models.Installment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("AnticipationValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ExpectedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("GrossValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NumberParcel")
                        .HasColumnType("int");

                    b.Property<Guid?>("TransactionNSU")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("TransferDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TransactionNSU");

                    b.ToTable("Installment");
                });

            modelBuilder.Entity("DesafioPagCerto.Repository.EntityFramework.Models.Transaction", b =>
                {
                    b.Property<Guid>("NSU")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AnticipationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ApprovedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Confirmation")
                        .HasColumnType("bit");

                    b.Property<string>("CreditCardSuffix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("FixedTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("GrossValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NumberParcel")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReprovedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("StatusAnticipation")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("NSU");

                    b.HasIndex("AnticipationId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("DesafioPagCerto.Repository.EntityFramework.Models.Installment", b =>
                {
                    b.HasOne("DesafioPagCerto.Repository.EntityFramework.Models.Transaction", "Transaction")
                        .WithMany("Installments")
                        .HasForeignKey("TransactionNSU");
                });

            modelBuilder.Entity("DesafioPagCerto.Repository.EntityFramework.Models.Transaction", b =>
                {
                    b.HasOne("DesafioPagCerto.Repository.EntityFramework.Models.Anticipation", "Anticipation")
                        .WithMany("Transactions")
                        .HasForeignKey("AnticipationId");
                });
#pragma warning restore 612, 618
        }
    }
}

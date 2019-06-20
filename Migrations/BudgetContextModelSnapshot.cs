﻿// <auto-generated />
using System;
using Budget.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Budget.Migrations
{
    [DbContext(typeof(BudgetContext))]
    partial class BudgetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("Budget.Models.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountNumber");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Budget.Models.Payee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Payee");
                });

            modelBuilder.Entity("Budget.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountID");

                    b.Property<int>("Amount");

                    b.Property<int?>("PayeeID");

                    b.Property<DateTime>("TransactionDate");

                    b.HasKey("TransactionID");

                    b.HasIndex("AccountID");

                    b.HasIndex("PayeeID");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("Budget.Models.Transaction", b =>
                {
                    b.HasOne("Budget.Models.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Budget.Models.Payee", "Payee")
                        .WithMany("Transactions")
                        .HasForeignKey("PayeeID");
                });
#pragma warning restore 612, 618
        }
    }
}
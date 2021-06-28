﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoUCDB.Infrastructure.Context;

namespace ProjetoUCDB.Infrastructure.Migrations
{
    [DbContext(typeof(ProjetoUCDBContext))]
    partial class ProjetoUCDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetoUCDB.Core.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("data_vencimento")
                        .HasColumnType("DATE")
                        .HasColumnName("data_vencimento");

                    b.Property<decimal>("desconto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DECIMAL(9,2)")
                        .HasDefaultValue(0m)
                        .HasColumnName("desconto");

                    b.Property<string>("nome_produto")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("nome_produto");

                    b.Property<string>("situacao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("situacao");

                    b.Property<decimal>("valor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DECIMAL(9,2)")
                        .HasDefaultValue(0m)
                        .HasColumnName("valor");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });
#pragma warning restore 612, 618
        }
    }
}

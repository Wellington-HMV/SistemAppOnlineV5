﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sistemav5.Models;

namespace sistemav5.Migrations
{
    [DbContext(typeof(sistemav5Context))]
    partial class sistemav5ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("sistemav5.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<int>("Telefone");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("sistemav5.Models.ItensPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProdutoId");

                    b.Property<int>("Quantidade");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItensPedido");
                });

            modelBuilder.Entity("sistemav5.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<int>("ItensPedidoId");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.HasIndex("ItensPedidoId")
                        .IsUnique();

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("sistemav5.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ItensPedidoId");

                    b.Property<string>("Nome");

                    b.Property<double>("Preco");

                    b.Property<int>("Quantidade");

                    b.HasKey("Id");

                    b.HasIndex("ItensPedidoId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("sistemav5.Models.ItensPedido", b =>
                {
                    b.HasOne("sistemav5.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("sistemav5.Models.Pedido", b =>
                {
                    b.HasOne("sistemav5.Models.Cliente", "Cliente")
                        .WithOne("Pedido")
                        .HasForeignKey("sistemav5.Models.Pedido", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("sistemav5.Models.ItensPedido", "ItensPedido")
                        .WithOne("Pedido")
                        .HasForeignKey("sistemav5.Models.Pedido", "ItensPedidoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("sistemav5.Models.Produto", b =>
                {
                    b.HasOne("sistemav5.Models.ItensPedido")
                        .WithMany("Produtos")
                        .HasForeignKey("ItensPedidoId");
                });
#pragma warning restore 612, 618
        }
    }
}

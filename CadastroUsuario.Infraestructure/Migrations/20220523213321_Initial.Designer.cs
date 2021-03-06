// <auto-generated />
using System;
using CadastroUsuario.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CadastroUsuario.Infraestructure.Migrations
{
    [DbContext(typeof(ParametrosDeAcessoContext))]
    [Migration("20220523213321_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("CadastroUsuario.Domain.Entities.UsuarioEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("Token")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UsuarioEntity");
                });
#pragma warning restore 612, 618
        }
    }
}

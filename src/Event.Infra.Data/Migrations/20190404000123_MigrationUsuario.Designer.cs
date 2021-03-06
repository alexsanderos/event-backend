﻿// <auto-generated />
using System;
using Event.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Event.Infra.Data.Migrations
{
    [DbContext(typeof(EventContext))]
    [Migration("20190404000123_MigrationUsuario")]
    partial class MigrationUsuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Event.Domain.Entities.Evento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UK_ID");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("TXT_DESCRICAO");

                    b.Property<string>("Subtitulo")
                        .IsRequired()
                        .HasColumnName("TXT_SUBTITULO");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnName("TXT_TITULO");

                    b.HasKey("Id");

                    b.ToTable("EV_EVENTO");
                });

            modelBuilder.Entity("Event.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UK_ID");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnName("TXT_CPF");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("DT_NASCIMENTO")
                        .HasColumnType("datetime");

                    b.Property<string>("EmpresaInstituicao")
                        .HasColumnName("TXT_EMPRESA_INSTITUICAO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("TXT_NOME");

                    b.HasKey("Id");

                    b.ToTable("EV_USUARIO");
                });
#pragma warning restore 612, 618
        }
    }
}

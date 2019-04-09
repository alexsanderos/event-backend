﻿// <auto-generated />
using System;
using Event.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Event.Infra.Data.Migrations
{
    [DbContext(typeof(EventContext))]
    partial class EventContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Event.Domain.Entities.Agenda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UK_ID");

                    b.Property<DateTime>("DataFim")
                        .HasColumnName("DT_FIM")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnName("DT_INICIO")
                        .HasColumnType("datetime");

                    b.Property<Guid>("EventoId")
                        .HasColumnName("UK_ID_EVENTO");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.ToTable("EV_AGENDA");
                });

            modelBuilder.Entity("Event.Domain.Entities.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UK_ID");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("TXT_NOME");

                    b.HasKey("Id");

                    b.ToTable("EV_CATEGORIA");
                });

            modelBuilder.Entity("Event.Domain.Entities.CategoriaEvento", b =>
                {
                    b.Property<Guid>("IdEvento")
                        .HasColumnName("UK_EVENTO");

                    b.Property<Guid>("IdCategoria")
                        .HasColumnName("UK_CATEGORIA");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnName("DT_ATUALIZACAO")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnName("DT_CRIACAO")
                        .HasColumnType("datetime");

                    b.HasKey("IdEvento", "IdCategoria");

                    b.HasIndex("IdCategoria");

                    b.ToTable("EV_CATEGORIA_EVENTO");
                });

            modelBuilder.Entity("Event.Domain.Entities.Evento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UK_ID");

                    b.Property<string>("DescricaoCurta")
                        .IsRequired()
                        .HasColumnName("TXT_DESCRICAO_CURTA");

                    b.Property<string>("DescricaoLonga")
                        .IsRequired()
                        .HasColumnName("TXT_DESCRICAO_LONGA");

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

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("TXT_EMAIL");

                    b.Property<string>("EmpresaInstituicao")
                        .HasColumnName("TXT_EMPRESA_INSTITUICAO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("TXT_NOME");

                    b.HasKey("Id");

                    b.ToTable("EV_USUARIO");
                });

            modelBuilder.Entity("Event.Domain.Entities.UsuarioEvento", b =>
                {
                    b.Property<Guid>("IdEvento")
                        .HasColumnName("UK_EVENTO");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnName("UK_USUARIO");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnName("DT_ATUALIZACAO")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnName("DT_CRIACAO")
                        .HasColumnType("datetime");

                    b.HasKey("IdEvento", "IdUsuario");

                    b.HasIndex("IdUsuario");

                    b.ToTable("EV_USUARIO_EVENTO");
                });

            modelBuilder.Entity("Event.Domain.Entities.Agenda", b =>
                {
                    b.HasOne("Event.Domain.Entities.Evento", "Evento")
                        .WithMany("Agendamentos")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Event.Domain.Entities.CategoriaEvento", b =>
                {
                    b.HasOne("Event.Domain.Entities.Categoria", "Categoria")
                        .WithMany("CategoriaEventos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Event.Domain.Entities.Evento", "Evento")
                        .WithMany("CategoriaEventos")
                        .HasForeignKey("IdEvento")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Event.Domain.Entities.UsuarioEvento", b =>
                {
                    b.HasOne("Event.Domain.Entities.Evento", "Evento")
                        .WithMany("UsuarioEventos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Event.Domain.Entities.Usuario", "Usuario")
                        .WithMany("UsuarioEventos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

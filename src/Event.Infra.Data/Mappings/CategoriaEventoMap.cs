using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Event.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Event.Infra.Data.Mappings
{
    public class CategoriaEventoMap : IEntityTypeConfiguration<CategoriaEvento>
    {
        public void Configure(EntityTypeBuilder<CategoriaEvento> builder)
        {
            builder.ToTable("EV_CATEGORIA_EVENTO");

            builder.HasKey(bc => new { bc.IdEvento, bc.IdCategoria });

            builder.Property(x => x.IdEvento).HasColumnName("UK_EVENTO").IsRequired();
            builder.Property(x => x.IdCategoria).HasColumnName("UK_CATEGORIA").IsRequired();

            builder.Property(e => e.DataCriacao)
                .HasColumnName("DT_CRIACAO")
                .HasColumnType("datetime");

            builder.Property(e => e.DataAtualizacao)
                .HasColumnName("DT_ATUALIZACAO")
                .HasColumnType("datetime");

            // Foreign keys
            builder.HasOne(bc => bc.Categoria)
                .WithMany(b => b.CategoriaEventos)
                .HasForeignKey(bc => bc.IdCategoria);

            builder.HasOne(bc => bc.Evento)
                .WithMany(c => c.CategoriaEventos)
                .HasForeignKey(bc => bc.IdEvento);
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Event.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Event.Infra.Data.Mappings
{
    public class EventoMap : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("EV_EVENTO");

            builder.Property(e => e.Id)
                .HasColumnName("UK_ID")
                .IsRequired();

            builder.Property(e => e.Titulo)
                .HasColumnName("TXT_TITULO")
                .IsRequired();

            builder.Property(e => e.Subtitulo)
                .HasColumnName("TXT_SUBTITULO")
                .IsRequired();

            builder.Property(e => e.DescricaoCurta)
                .HasColumnName("TXT_DESCRICAO_CURTA")
                .IsRequired();

            builder.Property(e => e.DescricaoLonga)
                .HasColumnName("TXT_DESCRICAO_LONGA")
                .IsRequired();

            builder.HasMany(c => c.Agendamentos)
                .WithOne(e => e.Evento);

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

        }
    }
}

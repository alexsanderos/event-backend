using System;
using System.Collections.Generic;
using System.Text;
using Event.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Event.Infra.Data.Mappings
{
    public class AgendaMap : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.ToTable("EV_AGENDA");
            
            builder.Property(e => e.Id)
                .HasColumnName("UK_ID")
                .IsRequired();

            builder.Property(e => e.EventoId)
                .HasColumnName("UK_ID_EVENTO")
                .IsRequired();

            builder.Property(e => e.DataInicio)
                .HasColumnName("DT_INICIO")
                .HasColumnType("datetime");

            builder.Property(e => e.DataFim)
                .HasColumnName("DT_FIM")
                .HasColumnType("datetime");

            builder.HasOne(e => e.Evento)
                .WithMany(c => c.Agendamentos)
                .HasForeignKey(x => x.EventoId);

            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);
        }
    }
}

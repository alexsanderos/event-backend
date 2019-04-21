using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Event.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Event.Infra.Data.Mappings
{
    public class UsuarioEventoMap : IEntityTypeConfiguration<UsuarioEvento>
    {
        public void Configure(EntityTypeBuilder<UsuarioEvento> builder)
        {
            builder.ToTable("EV_USUARIO_EVENTO");

            builder.HasKey(bc => new { bc.IdEvento, bc.IdUsuario });

            builder.Property(x => x.IdEvento).HasColumnName("UK_EVENTO").IsRequired();
            builder.Property(x => x.IdUsuario).HasColumnName("UK_USUARIO").IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("FL_STATUS").IsRequired();

            // Foreign keys
            builder.HasOne(bc => bc.Usuario)
                .WithMany(b => b.UsuarioEventos)
                .HasForeignKey(bc => bc.IdUsuario);

            builder.HasOne(bc => bc.Evento)
                .WithMany(c => c.UsuarioEventos)
                .HasForeignKey(bc => bc.IdEvento);
            
        }
    }
}

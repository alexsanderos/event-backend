using System;
using System.Collections.Generic;
using System.Text;
using Event.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Event.Infra.Data.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("EV_CATEGORIA");

            builder.Property(e => e.Id)
                .HasColumnName("UK_ID")
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnName("TXT_NOME")
                .IsRequired();

            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);
        }
    }
}

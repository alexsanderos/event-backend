using System;
using System.Collections.Generic;
using System.Text;
using Event.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Event.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("EV_USUARIO");

            builder.Property(e => e.Id)
                .HasColumnName("UK_ID")
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnName("TXT_NOME")
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnName("TXT_EMAIL")
                .IsRequired();

            builder.Property(e => e.CPF)
                .HasColumnName("TXT_CPF")
                .IsRequired();

            builder.Property(e => e.DataNascimento)
                .HasColumnName("DT_NASCIMENTO")
                .HasColumnType("datetime");

            builder.Property(e => e.EmpresaInstituicao)
                .HasColumnName("TXT_EMPRESA_INSTITUICAO");
            
            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);

        }
    }
}

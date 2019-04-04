using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Event.Domain.Entities;
using Event.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Event.Infra.Data.Context
{
    public class EventContext : DbContext
    {
        public DbSet<Evento> Evento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region FluentAPI

            modelBuilder.ApplyConfiguration(new EventoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new UsuarioEventoMap());
            modelBuilder.ApplyConfiguration(new CategoriaEventoMap());
            modelBuilder.ApplyConfiguration(new AgendaMap());


            #endregion

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            base.OnConfiguring(optionsBuilder);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using copaHAS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace copaHAS.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Estadio> Estadios {get; set;}
       
        public DataContext(DbContextOptions<DataContext>options) : base(options)
        {
            
        }
        public DbSet<Jogador> TB_JOGADORES{get;set;}
        public DbSet<Estadio> TB_ESTADIOS{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jogador>().ToTable("TB_JOGADORES");

            modelBuilder.Entity<Jogador>().HasData
            (
                new Jogador(){Nome="Tevez", Id=1, NumeroCamisa=10, Posicao="Meio-Campo", Status=Models.Enums.StatusJogador.TITULAR},
                new Jogador(){Nome="Cassio", Id=2, NumeroCamisa=12, Posicao="Goleiro", Status=Models.Enums.StatusJogador.TITULAR},
                new Jogador(){Nome="Ronaldo", Id=3, NumeroCamisa=9, Posicao="Atacante", Status=Models.Enums.StatusJogador.TITULAR},
                new Jogador(){Nome="Fagner", Id=4, NumeroCamisa=23, Posicao="Lateral Direito", Status=Models.Enums.StatusJogador.TITULAR},
                new Jogador(){Nome="Gil", Id=5, NumeroCamisa=4, Posicao="Zagueiro", Status=Models.Enums.StatusJogador.TITULAR},
                new Jogador(){Nome="Renato Augusto", Id=6, NumeroCamisa=8, Posicao="Meio-Campo", Status=Models.Enums.StatusJogador.TITULAR},
                new Jogador(){Nome="Paulinho", Id=7, NumeroCamisa=15, Posicao="Meio-Campo", Status=Models.Enums.StatusJogador.TITULAR},
                new Jogador(){Nome="Yuri Alberto", Id=8, NumeroCamisa=9, Posicao="Atacante", Status=Models.Enums.StatusJogador.TITULAR},
                new Jogador(){Nome="Roger Guedes", Id=9, NumeroCamisa=10, Posicao="Atacante", Status=Models.Enums.StatusJogador.TITULAR},
                new Jogador(){Nome="Fabio Santos", Id=10, NumeroCamisa=6, Posicao="Lateral Esquerdo", Status=Models.Enums.StatusJogador.TITULAR}
            );

            modelBuilder.Entity<Jogador>().ToTable("TB_ESTADIOS");
            
             modelBuilder.Entity<Estadio>().HasData
            (
                
                new Estadio(){Nome="NeoQuímica Arena", Id=1, Cidade="São Paulo", Capacidade=46000},
                new Estadio(){Nome="Allianz Parque", Id=2, Cidade="São Paulo", Capacidade=45000},
                new Estadio(){Nome="Maracanã", Id=3, Cidade="Rio de Janeiro", Capacidade=75000},
                new Estadio(){Nome="Morumbi", Id=4, Cidade="São Paulo", Capacidade=47000},
                new Estadio(){Nome="Castelão", Id=5, Cidade="São Paulo", Capacidade=30000},
                new Estadio(){Nome="Brinco de Ouro", Id=6, Cidade="São Paulo", Capacidade=20000},
                new Estadio(){Nome="Camp Nou", Id=7, Cidade="São Paulo", Capacidade=50000},
                new Estadio(){Nome="Allianz Arena", Id=8, Cidade="São Paulo", Capacidade=60000},
                new Estadio(){Nome="Vila Belmiro", Id=9, Cidade="São Paulo", Capacidade=20000},
                new Estadio(){Nome="Arena Barueri", Id=10, Cidade="São Paulo", Capacidade=20000}
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

    }
}
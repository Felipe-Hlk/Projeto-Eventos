using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Entity.FrameworkCore;//adicionar using Microsoft.Entity.FrameworkCore para ser utilizado
using ProEventos.API.Models; //adicionar ao inserir conteudo q veio da pasta Model (Evento.cs)

namespace ProEventos.API.Data
{
    public class DataContext : DbContext // função q recebe o Evento.cs...
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){  }
        public DbSet<Evento> Eventos { get; set; } //adicionando o conteudo do Model-Evento.cs    
    }
}
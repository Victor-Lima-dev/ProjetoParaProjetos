using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjetoParaProjetos.context
{
    public class AppDbContext : DbContext
    {
        //construtor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ProjetoParaProjetos.Models.Tarefa> Tarefas { get; set; }
        
    }
}
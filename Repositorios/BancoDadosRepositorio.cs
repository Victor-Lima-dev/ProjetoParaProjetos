using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoParaProjetos.context;
using ProjetoParaProjetos.Interfaces;
using ProjetoParaProjetos.Models;

namespace ProjetoParaProjetos.Repositorios
{
    public class BancoDadosRepositorio : IBancoDados
    {
 
       private readonly AppDbContext _appDbContext;

        public BancoDadosRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Tarefa> Tarefas => _appDbContext.Tarefas;

        public List<Tarefa> GetTarefas()
        {
            return _appDbContext.Tarefas.ToList();
        }

        public Tarefa GetTarefa(int id)
        {
            return _appDbContext.Tarefas.FirstOrDefault(t => t.TarefaId == id);
        }

        public void AddTarefa(Tarefa tarefa)
        {
            _appDbContext.Tarefas.Add(tarefa);
            _appDbContext.SaveChanges();
        }

        public void UpdateTarefa(Tarefa tarefa)
        {
            

            var tarefaEdit = tarefa;


            _appDbContext.Tarefas.Update(tarefaEdit);
            _appDbContext.SaveChanges();
        }

        public void DeleteTarefa(Tarefa tarefa)
        {
            _appDbContext.Tarefas.Remove(tarefa);
            _appDbContext.SaveChanges();
        }

    }
    
}
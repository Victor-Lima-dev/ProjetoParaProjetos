using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoParaProjetos.Models;

namespace ProjetoParaProjetos.Interfaces
{
    public interface IBancoDados
    {
        public IEnumerable<Tarefa> Tarefas { get;}


        public List<Tarefa> GetTarefas();
        public Tarefa GetTarefa(int id);
        public void AddTarefa(Tarefa tarefa);
        public void UpdateTarefa(Tarefa tarefa);
        public void DeleteTarefa(Tarefa tarefa);
        
    }
}
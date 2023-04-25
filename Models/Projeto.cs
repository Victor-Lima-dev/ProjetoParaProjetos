using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoParaProjetos.Models
{
    public class Projeto
    {
        public int ProjetoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Status { get; set; }
        public string Objetivo { get; set; }
        public DateTime Atualiacao { get; set; }
        public string Selos { get; set; }
    }
}
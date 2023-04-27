using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoParaProjetos.Models
{
    public class Nota
    {
        public int NotaId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        
    }
}
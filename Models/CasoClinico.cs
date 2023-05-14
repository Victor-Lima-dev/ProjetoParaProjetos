using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoParaProjetos.Models
{
    public class CasoClinico
    {
        public int CasoClinicoId { get; set; }

        public string Caso { get; set; }

        public List<Questao> Questoes { get; set; } = new List<Questao>();

    }
}
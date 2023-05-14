using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoParaProjetos.Models.ViewModels
{
    public class QuizViewModel
    {
        public Questao Questao { get; set; }

       public  List<Alternativa> Alternativas { get; set; }

       public string CasoClinico { get; set; }
    }
}
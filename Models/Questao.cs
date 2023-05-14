using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoParaProjetos.Models
{
    public class Questao
    {
        public int QuestaoId { get; set; }

        [Display(Name = "Enunciado da questão")]
        // define o nome que será exibido na view
        public string Enunciado { get; set; }


        [Display(Name = "Resposta correta")] 
        // define o nome que será exibido na view
        public string RespostaCorreta { get; set; }

        [Display(Name = "Alternativas")] 
        // define o nome que será exibido na view
        public List<Alternativa> Alternativas { get; set; } = new List<Alternativa>();

        public int CasoClinicoId { get; set; }

        public CasoClinico CasoClinico { get; set; }

        

    }


}
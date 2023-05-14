using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoParaProjetos.Models
{
      public class Alternativa
    {
        public int AlternativaId { get; set; }

        [Display(Name = "Texto da alternativa")] 
        // define o nome que será exibido na view
        public string Texto { get; set; }

        public int QuestaoId { get; set; } // chave estrangeira

        public Questao Questao { get; set; } // propriedade de navegação
    }
}
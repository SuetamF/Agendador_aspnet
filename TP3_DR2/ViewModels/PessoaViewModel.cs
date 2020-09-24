using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TP3_DR2.Models;

namespace TP3_DR2.ViewModels
{
    public class PessoaViewModel
    {
        public int IDPessoa { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Aniversario { get; set; }

        public Pessoa pessoa { get; set; }
    }
}

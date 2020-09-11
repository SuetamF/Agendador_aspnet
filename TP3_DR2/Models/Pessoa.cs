using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP3_DR2.Models
{
    public class Pessoa
    {
        public int IDPessoa { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Aniverssario { get; set; }
    }
}

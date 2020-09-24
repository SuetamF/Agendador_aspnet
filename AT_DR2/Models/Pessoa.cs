using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AT_DR2.Models
{
    public class Pessoa
    {
        [Key]
        public int IDPessoa { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        [DataType(DataType.Date)]
        public DateTime Aniversario { get; set; }
    }
}


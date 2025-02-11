using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace web_app_sistemainfo.Models
{
    public class Usuario
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório.")]
        public string cpf { get; set; }

        public string endereco { get; set; }
        public string telefone { get; set; }
    }
}
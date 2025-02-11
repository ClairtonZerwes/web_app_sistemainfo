using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace web_app_sistemainfo.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório.")]
        public string Cpf { get; set; }

        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }
}
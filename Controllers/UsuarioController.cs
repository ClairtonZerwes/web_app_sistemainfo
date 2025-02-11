using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Services.Description;
using web_app_sistemainfo.Models;

namespace web_app_sistemainfo.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        private static List<Usuario> usuarios = new List<Usuario>();

        [HttpPost]
        [Route("salvar")]
        public IHttpActionResult SalvarUsuario([FromBody] Usuario usuario)
        {
            /*
            if (usuario.Cpf.Length != 11)
            {
                return Content(HttpStatusCode.BadRequest, new RespostaApi
                {
                    Mensagem = $"O CPF informado ({usuario.Cpf}) contém {usuario.Cpf.Length} dígitos, mas deve conter exatamente 11!"
                });
            }
            */

            if (usuario == null)
            {
                return Content(HttpStatusCode.BadRequest, new RespostaApi { Mensagem = "Dados inválidos. O usuário não pode ser nulo." });
            }

            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, new RespostaApi { Mensagem = "Nome e CPF são obrigatórios." });
            }

            if (!SomenteDigitosNumericos(usuario.Cpf))
            {
                return Content(HttpStatusCode.BadRequest, new RespostaApi { Mensagem = "Informar somente dígitos numéricos!" });
            }

            if (!ValidarQuantidadeDigitos(usuario.Cpf))
            {
                return Content(HttpStatusCode.BadRequest, new RespostaApi { Mensagem = "O CPF deve conter exatamente 11 dígitos!" });
            }

            usuario.Id = usuarios.Count + 1;
            usuarios.Add(usuario);

            string cpfDigitosInicial = usuario.Cpf.Length >= 4 ? usuario.Cpf.Substring(0, 4) : "0000";
            return Ok(new RespostaApi { Mensagem = $"Último usuário cadastrado com sucesso! Código: [{usuario.Id}] - CPF Dígitos Inicial: [{cpfDigitosInicial}]" });
        }

        private bool ValidarQuantidadeDigitos(string cpf)
        {
            int quantidadeDigitosCorreto = 11;

            return cpf.Length == quantidadeDigitosCorreto;
        }

        private bool SomenteDigitosNumericos(string cpf)
        {
            return Regex.IsMatch(cpf, @"^\d+$");
        }
    }
}
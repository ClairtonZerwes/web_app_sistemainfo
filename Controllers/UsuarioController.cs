using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
            if (!ModelState.IsValid)
            {
                return BadRequest("Nome e CPF são obrigatórios.");
            }

            usuario.id = usuarios.Count + 1;
            usuarios.Add(usuario);

            string cpfDigitosInicial = usuario.cpf.Length >= 4 ? usuario.cpf.Substring(0, 4) : "0000";
            return Ok($"Pessoa cadastrada com sucesso! Código: [{usuario.id}] - CPF Dígitos Inicial: [{cpfDigitosInicial}]");
        }
    }
}
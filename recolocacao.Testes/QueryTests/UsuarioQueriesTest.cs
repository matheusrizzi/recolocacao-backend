using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using recolocacao.Dominio.Entidades;
using recolocacao.Dominio.Queries;

namespace recolocacao.Testes.QueryTests
{
    [TestClass]
    public class UsuarioQueriesTest
    {
        [TestMethod]
        public void Sucesso_ao_buscar_usuario_por_email()
        {
            var users = new List<Usuario>()
            {
                CreateUser("Matheus", "matheus@xpto.com.br"),
                CreateUser("Joao", "xpto@foo.com.br"),
                CreateUser("Batman", "batman@gotham.com.br")
            };

            var user = users.AsQueryable()
                            .FirstOrDefault(UsuarioQueries.BuscarPorEmail("xpto@foo.com.br"));

            Assert.IsTrue(user != null);
            Assert.IsTrue(user.NomeCompleto == "Joao");
        }

        private Usuario CreateUser(string nome, string email)
        {
            return new Usuario(nome,
                               email,
                               "2342432",
                               "programador",
                               true);
        }
    }
}
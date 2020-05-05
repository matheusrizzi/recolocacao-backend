using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using recolocacao.Dominio.Entidades;
using recolocacao.Dominio.Queries;

namespace recolocacao.Testes.QueryTests
{
    [TestClass]
    public class CandidatoQueriesTest
    {
        [TestMethod]
        public void Sucesso_ao_buscar_por_usuarioid()
        {
            var candidates = new List<Candidato>()
            {
                CreateCandidate("Programador", 1),
                CreateCandidate("Programador", 2),
                CreateCandidate("Analista Full Stack", 3)
            };

            var candidate = candidates.AsQueryable()
                                      .FirstOrDefault(CandidatoQueries.BuscarPorUsuarioId(3));

            Assert.IsTrue(candidate != null);
            Assert.IsTrue(candidate.Cargo == "Analista Full Stack");
        }

        private Candidato CreateCandidate(string cargo, int usuarioId)
        {
            return new Candidato(
                                "meuCv.pdf", 
                                cargo, 
                                "53 999999999", 
                                "Pelotas", 
                                DateTime.Now,
                                usuarioId);
        }
    }
}
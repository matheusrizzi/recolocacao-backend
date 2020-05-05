using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using recolocacao.Dominio.Commands;
using recolocacao.Dominio.Commands.Candidato;
using recolocacao.Dominio.Handlers.Candidato;
using recolocacao.Dominio.Repositories;

namespace recolocacao.Testes.handler.Candidato
{
    [TestClass]
    public class CriarCandidatoHandlerTeste
    {
        private Mock<IRepository<Dominio.Entidades.Candidato>> _repositorio;

        public CriarCandidatoHandlerTeste()
        {
            _repositorio = new Mock<IRepository<Dominio.Entidades.Candidato>>();
        }

        [TestMethod]
        public void Sucesso_ao_criar_um_candidato()
        {
            var cmd = new CriarCandidatoCommand("aheiuaheiauhea",
                                                "Desenvolvedor FullStack",
                                                "99 99999999",
                                                "Blumenau",
                                                DateTime.Now,
                                                1);

            var hdl = new CriarCandidatoHandler(_repositorio.Object);
            var res = (ResponseCommandResult)hdl.Handle(cmd);

            Assert.IsTrue(res.Valid, res.Message);
        }

        [TestMethod]
        public void Erro_ao_criar_um_candidato_com_email_ja_existente()
        {
            var cmd = new CriarCandidatoCommand("aheiuaheiauhea",
                                                "Desenvolvedor FullStack",
                                                "99 99999999",
                                                "Blumenau",
                                                DateTime.Now,
                                                1);
            _repositorio
                .Setup(x => x.ObterEntidade(It.IsAny<Expression<Func<Dominio.Entidades.Candidato, bool>>>()))
                .Returns(
                        new Dominio.Entidades.Candidato(cmd.Curriculum,
                                                        cmd.Cargo,
                                                        cmd.Telefone,
                                                        cmd.Cidade,
                                                        cmd.DataNascimento,
                                                        cmd.UsuarioId));

            var hdl = new CriarCandidatoHandler(_repositorio.Object);
            var res = (ResponseCommandResult)hdl.Handle(cmd);

            Assert.IsTrue(res.Invalid, res.Message);
        }

    }

    public class Venda()
    {
        IObjetoCliente _cliente;

        public Venda(IObjetoCliente cliente){

            _cliente = cliente;
        }

        public void Vender()
        {
            
        }
    }
}
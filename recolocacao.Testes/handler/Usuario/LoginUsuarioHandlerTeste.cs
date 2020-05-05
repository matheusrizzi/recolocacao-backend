using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using recolocacao.Dominio.Commands;
using recolocacao.Dominio.Commands.Usuario;
using recolocacao.Dominio.Handlers.Usuario;
using recolocacao.Dominio.Repositories;

namespace recolocacao.Testes.handler.Usuario
{
    [TestClass]
    public class LoginUsuarioHandlerTeste
    {
        private Mock<IRepository<Dominio.Entidades.Usuario>> _repositorio;

        public LoginUsuarioHandlerTeste()
        {
            _repositorio = new Mock<IRepository<Dominio.Entidades.Usuario>>();
        }

        [TestMethod]
        public void Sucesso_ao_efetuar_login()
        {
            var cmd = new LoginUsuarioCommand("fulano@xpto.com.br", "123456");

            _repositorio.Setup(x =>x.ObterEntidade(It.IsAny<Expression<Func<Dominio.Entidades.Usuario, bool>>>()))
            .Returns(new Dominio.Entidades.Usuario("fulano xpto", cmd.Email, cmd.Senha, "candidato", true));

            var hdl = new LoginUsuarioHandler(_repositorio.Object);
            var result = (ResponseCommandResult)hdl.Handle(cmd);

            Assert.IsTrue(result.Valid, result.Message);
        }

        [TestMethod]
        public void Erro_ao_efetuar_login_com_email_nao_verificado()
        {
            var cmd = new LoginUsuarioCommand("fulano@xpto.com.br", "123456");

            _repositorio.Setup(x =>x.ObterEntidade(It.IsAny<Expression<Func<Dominio.Entidades.Usuario, bool>>>()))
            .Returns(new Dominio.Entidades.Usuario("fulano xpto", cmd.Email, cmd.Senha, "candidato", false));

            var hdl = new LoginUsuarioHandler(_repositorio.Object);
            var result = (ResponseCommandResult)hdl.Handle(cmd);

            Assert.IsTrue(!result.Valid, result.Message);
        }

        [TestMethod]
        public void Erro_ao_efetuar_login_com_email_nao_cadastrado()
        {
            var cmd = new LoginUsuarioCommand("fulano@xpto.com.br", "123456");
            var hdl = new LoginUsuarioHandler(_repositorio.Object);
            var result = (ResponseCommandResult)hdl.Handle(cmd);

            Assert.IsTrue(!result.Valid, result.Message);
        }

        [TestMethod]
        public void Erro_ao_efetuar_login_com_senha_invalida()
        {
            var cmd = new LoginUsuarioCommand("fulano@xpto.com.br", "123456");

            _repositorio.Setup(x =>x.ObterEntidade(It.IsAny<Expression<Func<Dominio.Entidades.Usuario, bool>>>()))
            .Returns(new Dominio.Entidades.Usuario("fulano xpto", cmd.Email, "5684582", "candidato", false));

            var hdl = new LoginUsuarioHandler(_repositorio.Object);
            var result = (ResponseCommandResult)hdl.Handle(cmd);

            Assert.IsTrue(!result.Valid, result.Message);
        }
    }
}
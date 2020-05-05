using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using recolocacao.Dominio.Commands;
using recolocacao.Dominio.Commands.Usuario;
using recolocacao.Dominio.Handlers.Usuario;
using recolocacao.Dominio.Queries;
using recolocacao.Dominio.Repositories;

namespace recolocacao.Testes.handler.Usuario
{
    [TestClass]
    public class CriarUsuarioHandlerTeste
    {
        private readonly Mock<IRepository<Dominio.Entidades.Usuario>> _repositorio;

        public CriarUsuarioHandlerTeste()
        {
            _repositorio = new Mock<IRepository<Dominio.Entidades.Usuario>>();
        }

        [TestMethod]
        public void Criar_um_usuario_com_sucesso()
        {
            var cmd = new CriarUsuarioCommand("Fulano de tal",
                                              "fulano@xpto.com.br",
                                              "123456",
                                              "candidato"
            );

            var hdl = new CriarUsuarioHandler(_repositorio.Object);
            var result = (ResponseCommandResult)hdl.Handle(cmd);

            Assert.IsTrue(result.Valid, result.Message);
        }

        [TestMethod]
        public void Erro_ao_tentar_criar_um_usuario_com_email_ja_cadastrado()
        {
            var cmd = new CriarUsuarioCommand("Fulano de tal",
                                              "fulano@xpto.com.br",
                                              "123456",
                                              "candidato"
            );

            var repositorio = new Mock<IRepository<Dominio.Entidades.Usuario>>();
            repositorio
                .Setup(x =>x.ObterEntidade(It.IsAny<Expression<Func<Dominio.Entidades.Usuario, bool>>>()))
                .Returns(
                        new Dominio.Entidades.Usuario(cmd.NomeCompleto, 
                                                      cmd.Email, 
                                                      cmd.Senha, 
                                                      cmd.Role, 
                                                      false));

            var hdl = new CriarUsuarioHandler(repositorio.Object);
            var result = (ResponseCommandResult)hdl.Handle(cmd);

            Assert.IsTrue(!result.Valid, result.Message);
        }
    }
}
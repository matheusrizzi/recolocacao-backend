using Microsoft.VisualStudio.TestTools.UnitTesting;
using recolocacao.Dominio.Commands.Usuario;

namespace recolocacao.Testes.CommandTestes.Usuario
{
    [TestClass]
    public class CriarUsuarioCommandTeste
    {
        [TestMethod]
        public void Dado_um_usuario_com_nome_invalido()
        {
            var command = new CriarUsuarioCommand("Ful",
                                                  "fulano@hotmail.com",
                                                  "123456",
                                                  "candidato");

            command.Validate();

            Assert.IsTrue(command.Invalid);
        }

        [TestMethod]
        public void Dado_um_usuario_com_email_invalido()
        {
            var command = new CriarUsuarioCommand("Fulano de tal",
                                                  "fula",
                                                  "123456",
                                                  "candidato");

            command.Validate();

            Assert.IsTrue(command.Invalid);
        }

        [TestMethod]
        public void Dado_um_usuario_com_senha_invalida()
        {
            var command = new CriarUsuarioCommand("Fulano de tal",
                                                  "fulano@xpto.com.br",
                                                  "123",
                                                  "candidato");

            command.Validate();

            Assert.IsTrue(command.Invalid);
        }

        [TestMethod]
        public void Dado_um_usuario_com_role_invalido()
        {
            var command = new CriarUsuarioCommand("Fulano de tal",
                                                  "fulano@xpto.com.br",
                                                  "123456",
                                                  "gerente");

            command.Validate();

            Assert.IsTrue(command.Invalid);
        }        

        [TestMethod]
        public void Dado_um_comando_valido()
        {
            var command = new CriarUsuarioCommand("Fulano de tal",
                                                  "fulano@hotmail.com",
                                                  "123456",
                                                  "candidato");
            command.Validate();

            Assert.IsTrue(command.Valid);
        }        
    }
}
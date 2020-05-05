using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using recolocacao.Dominio.Commands.Candidato;

namespace recolocacao.Testes.Command.Candidato
{
    [TestClass]
    public class CriarCandidatoCommandTeste
    {
        [TestMethod]
        public void Sucesso_ao_criar_candidato()
        {
            var cmd = new CriarCandidatoCommand("afdlsjkfas",
                                                "programador",
                                                "1238128372189",
                                                "Blumenau",
                                                DateTime.Now,
                                                1
                                                );

            cmd.Validate();

            Assert.IsTrue(cmd.Valid, cmd.ToString());
        }

        [TestMethod]
        public void Erro_ao_criar_candidato_sem_cargo()
        {
            var cmd = new CriarCandidatoCommand("afdlsjkfas",
                                                "",
                                                "1238128372189",
                                                "Blumenau",
                                                DateTime.Now,
                                                1
                                                );

            cmd.Validate();

            Assert.IsTrue(cmd.Invalid, cmd.ToString());
        }

        [TestMethod]
        public void Erro_ao_criar_candidato_sem_curriculum()
        {
            var cmd = new CriarCandidatoCommand("",
                                                "programador",
                                                "1238128372189",
                                                "Blumenau",
                                                DateTime.Now,
                                                1
                                                );

            cmd.Validate();

            Assert.IsTrue(cmd.Invalid, cmd.ToString());
        }

        [TestMethod]
        public void Erro_ao_criar_candidato_com_telefone()
        {
            var cmd = new CriarCandidatoCommand("afdlsjkfas",
                                    "programador",
                                    "12",
                                    "Blumenau",
                                    DateTime.Now,
                                    1
                                    );

            cmd.Validate();

            Assert.IsTrue(cmd.Invalid, cmd.ToString());
        }

        [TestMethod]
        public void Sucesso_ao_criar_candidato_sem_telefone()
        {
            var cmd = new CriarCandidatoCommand("afdlsjkfas",
                                    "programador",
                                    "",
                                    "Blumenau",
                                    DateTime.Now,
                                    1
                                    );

            cmd.Validate();

            Assert.IsTrue(cmd.Valid, cmd.ToString());
        }

        [TestMethod]
        public void Sucesso_ao_criar_candidato_sem_cidade()
        {
            var cmd = new CriarCandidatoCommand("afdlsjkfas",
                                                "programador", 
                                                "1238128372189", 
                                                "",
                                                DateTime.Now,
                                                1
                                                );
            
            cmd.Validate();

            Assert.IsTrue(cmd.Valid, cmd.ToString());
        }

    }
}
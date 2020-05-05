

using System;
using Flunt.Notifications;
using recolocacao.Dominio.Commands.Contracts;
using recolocacao.Dominio.Validations;

namespace recolocacao.Dominio.Commands.Candidato
{
    public class CriarCandidatoCommand : Notifiable, ICommand
    {
        public CriarCandidatoCommand()
        {
        }
        
        public CriarCandidatoCommand(string curriculum, string cargo, string telefone, string cidade, DateTime dataNascimento, int usuarioId)
        {
            Curriculum = curriculum;
            Cargo = cargo;
            Telefone = telefone;
            Cidade = cidade;
            DataNascimento = dataNascimento;
            UsuarioId = usuarioId;
        }

        public string Curriculum { get; set; }
        public string Cargo { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public DateTime DataNascimento { get; set; }
        public int UsuarioId { get; set; }
        
        public void Validate()
        {
            AddNotifications(
                new CandidatoValidation()
                    .ValidarCargo(this.Cargo)
                    .ValidarCurriculum(this.Curriculum)
                    .ValidarTelefone(this.Telefone, false)
                    .ValidarCidade(this.Cidade, false)
                    .ValidarUsuarioId(this.UsuarioId)
                    .Notifications
            );
        }
    }
}
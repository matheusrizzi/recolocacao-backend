using Flunt.Notifications;
using recolocacao.Dominio.Commands.Contracts;
using recolocacao.Dominio.Validations;

namespace recolocacao.Dominio.Commands.Usuario
{
    public class CriarUsuarioCommand : Notifiable, ICommand
    {
        public CriarUsuarioCommand()
        {
        }

        public CriarUsuarioCommand(string nomeCompleto, string email, string senha, string role)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            Senha = senha;
            Role = role;
        }

        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }

        public void Validate()
        {
            AddNotifications(
                new UsuarioValidation()
                        .ValidarNomeCompleto(this.NomeCompleto)
                        .ValidarRole(this.Role)
                        .ValidarSenha(this.Senha)
                        .ValidarEmail(this.Email)
                        .Notifications
            );
        }
    }
}
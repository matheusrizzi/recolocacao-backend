using Flunt.Notifications;
using recolocacao.Dominio.Commands.Contracts;
using recolocacao.Dominio.Validations;

namespace recolocacao.Dominio.Commands.Usuario
{
    public class LoginUsuarioCommand : Notifiable, ICommand
    {
        public LoginUsuarioCommand()
        {
        }

        public LoginUsuarioCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; set; }
        public string Senha { get; set; }

        public void Validate()
        {
            AddNotifications(new UsuarioValidation()
                                .ValidarEmail(this.Email)
                                .ValidarSenha(this.Senha)
                                .Notifications
            );
        }
    }
}
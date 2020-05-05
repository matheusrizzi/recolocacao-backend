using Flunt.Notifications;
using Flunt.Validations;

namespace recolocacao.Dominio.Validations
{
    public class UsuarioValidation : Notifiable
    {
        public UsuarioValidation ValidarNomeCompleto(string nomeCompleto)
        {
            AddNotifications(new Contract()
                            .Requires()
                            .HasMinLen(nomeCompleto, 6, "UsuarioValidation.NomeCompleto", "Seu nome não pode ser inferior a 6 caracteres.")
                            .HasMaxLen(nomeCompleto, 60, "UsuarioValidation.NomeCompleto", "Seu nome nao pode ultrapassar 60 caracteres.")
            );
            return this;
        }

        public UsuarioValidation ValidarRole(string role)
        {
            AddNotifications(new Contract()
                             .Requires()
                             .IsTrue(role == "candidato" || role == "recrutador", "UsuarioValidation.Role", "Perfil do usuario inválido.")
            );
            return this;
        }

        public UsuarioValidation ValidarSenha(string senha)
        {

            AddNotifications(new Contract()
                             .Requires()
                             .HasMinLen(senha, 6, "UsuarioValidation.Senha",  "Sua senha deve conter no mínimo 6 caracteres.")
                             .HasMaxLen(senha, 20, "UsuarioValidation.Senha", "Sua senha deve conter no máximo 20 caracteres.")
            );

            return this;
        }

        public UsuarioValidation ValidarEmail(string email)
        {
            AddNotifications(new Contract()
                             .Requires()
                             .IsEmail(email, "UsuarioValidation.Email", "Informe um e-mail válido.")
            );

            return this;
        }
    }
}
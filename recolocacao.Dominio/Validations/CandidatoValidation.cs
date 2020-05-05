using Flunt.Notifications;
using Flunt.Validations;

namespace recolocacao.Dominio.Validations
{
    public class CandidatoValidation:Notifiable
    {
        public CandidatoValidation ValidarCargo(string cargo, bool obrigatorio = true)
        {
            if(string.IsNullOrEmpty(cargo) && !obrigatorio)
                return this;

            AddNotifications(new Contract()
                                .Requires()
                                .HasMinLen(cargo, 2,"CandidatoValidation.cargo", "O cargo devera ter entre 2 e 60 caracteres.")
                                .HasMaxLen(cargo, 60,"CandidatoValidation.cargo", "O cargo devera ter entre 2 e 60 caracteres.")
                            );

            return this;
        }

        public CandidatoValidation ValidarCurriculum(string curriculum, bool obrigatorio=true)
        {
            if(string.IsNullOrEmpty(curriculum))
            {
                if(!obrigatorio)
                    return this;

                AddNotification("CandidatoValidation.Curriculum", "Obrigatório informar o curriculum.");
            }

            return this;
        }

        public CandidatoValidation ValidarTelefone(string telefone, bool obrigatorio = true)
        {
            if(string.IsNullOrEmpty(telefone) && !obrigatorio)
                return this;

            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(telefone, 8, "CandidatoValidation.Telefone", "O numero do telefone deve conter entre 8 e 15 caracteres.")
                    .HasMaxLen(telefone, 15, "Candidato.Validation", "O numero do telefone deve conter entre 8 e 15 caracteres.")
            );

            return this;
        }

        public CandidatoValidation ValidarCidade(string cidade, bool obrigatorio=true)
        {
            if(string.IsNullOrEmpty(cidade) && !obrigatorio)
                return this;

            AddNotifications(
                new Contract()
                    .HasMinLen(cidade, 4, "CandidatoValidation.Cidade", "O nome da cidade deve conter entre 4 e 60 caracteres.")
                    .HasMaxLen(cidade, 60, "CandidatoValidation.Cidade", "O nome da cidade deve conter entre 4 e 60 caracteres.")
            );

            return this;
        }

        public CandidatoValidation ValidarUsuarioId(int id, bool obrigatorio = true)
        {
            if(id == 0 && !obrigatorio)
                return this;
                
            AddNotifications(new Contract()
                             .Requires()
                             .IsGreaterThan(id, 0, "CandidatoValidation.UsuarioId", "Obrigatório informar o id do usuario.")
            );
            return this;
        }
    }
}

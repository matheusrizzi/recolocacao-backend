using recolocacao.Dominio.Commands;
using recolocacao.Dominio.Commands.Candidato;
using recolocacao.Dominio.Commands.Contracts;
using recolocacao.Dominio.Handlers.Contracts;
using recolocacao.Dominio.Queries;
using recolocacao.Dominio.Repositories;

namespace recolocacao.Dominio.Handlers.Candidato
{
    public class CriarCandidatoHandler : IHandler<CriarCandidatoCommand>
    {
        private readonly IRepository<Entidades.Candidato> _repositorio;

        public CriarCandidatoHandler(IRepository<Entidades.Candidato> repositorio)
        {
            _repositorio = repositorio;
        }

        public ICommandResult Handle(CriarCandidatoCommand command)
        {
            command.Validate();

            if(command.Invalid)
                return Response(false,
                                "Não foi possível salvar as informações do candidato.",
                                command.Notifications);
            
            var candidato = _repositorio
                                .ObterEntidade(CandidatoQueries.BuscarPorUsuarioId(command.UsuarioId));

            if(candidato != null)
                return Response(false, "Já existe um candidato cadastrado para este usuario.", null);

            candidato = new Entidades
                            .Candidato(command.Curriculum,
                                       command.Cargo,
                                       command.Telefone, 
                                       command.Cidade,
                                       command.DataNascimento,
                                       command.UsuarioId
                            );
            
            _repositorio.Adicionar(candidato);
            _repositorio.SalvarTodos();
            
            return Response(true, "Informações do candidato salvas com sucesso.", candidato);
        }

        private ResponseCommandResult Response(bool success, string mensagem, object valor)
        {
            return new ResponseCommandResult(success,
                                            mensagem,
                                            valor);
        }
    }
}
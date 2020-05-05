using recolocacao.Dominio.Commands;
using recolocacao.Dominio.Commands.Contracts;
using recolocacao.Dominio.Commands.Usuario;
using recolocacao.Dominio.Handlers.Contracts;
using recolocacao.Dominio.Queries;
using recolocacao.Dominio.Repositories;

namespace recolocacao.Dominio.Handlers.Usuario
{
    public class CriarUsuarioHandler : IHandler<CriarUsuarioCommand>
    {
        private readonly IRepository<Entidades.Usuario> _repositorio;

        public CriarUsuarioHandler(IRepository<Entidades.Usuario> repositorio) => this._repositorio = repositorio;
        
        public ICommandResult Handle(CriarUsuarioCommand command)
        {
            command.Validate();

            if(command.Invalid)
                return Response(false, 
                               "Não foi possível criar o usuário!", 
                               command.Notifications);

            var usuario = new Entidades.Usuario(command.NomeCompleto,
                                                command.Email,
                                                command.Senha,
                                                command.Role,
                                                false);

             var usuarioExistente = _repositorio
                                     .ObterEntidade(UsuarioQueries.BuscarPorEmail(command.Email));

            if(usuarioExistente != null)
                return Response(false,
                                "Já existe um usuário com este e-mail!",
                                command.Notifications);

            _repositorio.Adicionar(usuario);
            _repositorio.SalvarTodos();

            return Response(true, 
                            "Usuário adicionado com sucesso!", 
                            usuario);            
        }

        private ResponseCommandResult Response(bool success, string mensagem, object valor)
        {
            return new ResponseCommandResult(success, 
                                            mensagem, 
                                            valor);            
        }
    }
}
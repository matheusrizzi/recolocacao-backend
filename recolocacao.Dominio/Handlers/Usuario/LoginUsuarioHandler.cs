using recolocacao.Dominio.Commands;
using recolocacao.Dominio.Commands.Contracts;
using recolocacao.Dominio.Commands.Usuario;
using recolocacao.Dominio.Handlers.Contracts;
using recolocacao.Dominio.Queries;
using recolocacao.Dominio.Repositories;

namespace recolocacao.Dominio.Handlers.Usuario
{
    public class LoginUsuarioHandler : IHandler<LoginUsuarioCommand>
    {
        private readonly IRepository<Entidades.Usuario> _repositorio;

        public LoginUsuarioHandler(IRepository<Entidades.Usuario> repositorio)
        {
            _repositorio = repositorio;
        }

        public ICommandResult Handle(LoginUsuarioCommand command)
        {
            command.Validate();

            if(command.Invalid)
                return Response(false,
                                "Não foi possível efetuar o login.",
                                command.Notifications);

            var usuario = _repositorio
                                .ObterEntidade(UsuarioQueries.BuscarPorEmail(command.Email));

            if(usuario == null)
                return Response(false, "Não existe esse email cadastrado.", null);

            if(usuario.Senha != command.Senha)
                return Response(false, "Informações de usuário e senha inválidas.", null);

            if(!usuario.Verificado)
                return Response(false, "Aguardando verificação do e-mail do usuário.", null);

            return Response(true, "Login realizado com sucesso.", usuario);
        }

        private ResponseCommandResult Response(bool success, string mensagem, object valor)
        {
            return new ResponseCommandResult(success, 
                                            mensagem, 
                                            valor);            
        }
    }
}
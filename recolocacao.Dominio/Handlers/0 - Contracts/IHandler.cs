using recolocacao.Dominio.Commands.Contracts;

namespace recolocacao.Dominio.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
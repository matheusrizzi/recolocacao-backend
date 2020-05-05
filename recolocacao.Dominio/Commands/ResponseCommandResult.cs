using recolocacao.Dominio.Commands.Contracts;

namespace recolocacao.Dominio.Commands
{
    public class ResponseCommandResult : ICommandResult
    {
        public ResponseCommandResult(bool success, string message, object data)
        {
            Valid = success;
            Message = message;
            Data = data;
        }

        public bool Valid { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public bool Invalid { get{return !Valid;}}
    }
}
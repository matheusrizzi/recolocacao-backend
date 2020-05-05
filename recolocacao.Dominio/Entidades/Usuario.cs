
namespace recolocacao.Dominio.Entidades
{
    public class Usuario : Entidade
    {

        public Usuario(string nomeCompleto, string email, string senha, string role, bool verificado)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            Senha = senha;
            Role = role;
            Verificado = verificado;
        }

        public string NomeCompleto { get; private set; }
        public string Email { get; private set; }     
        public string Senha { get; private set; }
        public string Role { get; private set; }
        public bool Verificado { get; private set; }
    }
}
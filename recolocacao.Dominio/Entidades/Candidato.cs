using System;

namespace recolocacao.Dominio.Entidades
{
    public class Candidato:Entidade
    {
        public Candidato(string curriculum, string cargo, string telefone, string cidade, DateTime dataNascimento, int usuarioId)
        {
            Curriculum = curriculum;
            Cargo = cargo;
            Telefone = telefone;
            Cidade = cidade;
            DataNascimento = dataNascimento;
            UsuarioId = usuarioId;
        }

        public string Curriculum { get; private set; }
        public string Cargo { get; private set; }
        public string Telefone { get; private set; }
        public string Cidade { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public int UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }
    }
}
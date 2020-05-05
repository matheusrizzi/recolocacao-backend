using System;
using System.Linq.Expressions;
using recolocacao.Dominio.Entidades;

namespace recolocacao.Dominio.Queries
{
    public static class CandidatoQueries
    {
        public static Expression<Func<Candidato, bool>> BuscarPorUsuarioId(int usuarioId)
        {
            return x => x.UsuarioId == usuarioId;
        }
    }
}
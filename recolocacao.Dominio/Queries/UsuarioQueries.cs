using System;
using System.Linq.Expressions;
using recolocacao.Dominio.Entidades;

namespace recolocacao.Dominio.Queries
{
    public static class UsuarioQueries
    {
        public static Expression<Func<Usuario, bool>> BuscarPorEmail(string email)
        {
            return x => x.Email.ToLower() == email.ToLower();
        }
    }
}
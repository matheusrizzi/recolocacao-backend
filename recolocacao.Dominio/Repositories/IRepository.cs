using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace recolocacao.Dominio.Repositories
{
    public interface IRepository<Entidade> where Entidade : class
    {
        void Atualizar(Entidade obj);
        void SalvarTodos();
        void Adicionar(Entidade obj);
        void Excluir(Entidade obj);
        Entidade ObterEntidade(Expression<Func<Entidade, bool>> predicate);
        IList<Entidade> ObterLista(Expression<Func<Entidade, bool>> predicate);
    }
}
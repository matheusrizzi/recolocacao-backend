using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using recolocacao.Dominio.Entidades;
using recolocacao.Dominio.Repositories;
using recolocacao.Infra.Context;

namespace recolocacao.Infra.Repositories
{
    public class Repository<Entidade> : IRepository<Entidade> where Entidade : class
    {
        private readonly DataContext _context;
        
        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Adicionar(Entidade obj)
        {
            _context.Add(obj);
        }

        public void Atualizar(Entidade obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Excluir(Entidade obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
        }

        public Entidade ObterEntidade(Expression<Func<Entidade, bool>> predicate)
        {
            return _context.Set<Entidade>().AsQueryable().FirstOrDefault(predicate);
        }

        public IList<Entidade> ObterLista(Expression<Func<Entidade, bool>> predicate)
        {
            return (IList<Entidade>)_context.Set<Entidade>().AsQueryable().Where(predicate);
        }

        public void SalvarTodos()
        {
            _context.SaveChanges();
        }
    }
}
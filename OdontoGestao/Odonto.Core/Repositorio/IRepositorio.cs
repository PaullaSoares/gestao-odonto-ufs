using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Odonto.Core.Repositorio
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);

        void AdicionarConjunto(IEnumerable<TEntity> listaDeEntidades);

        void Atualizar(TEntity obj);

        IQueryable<TEntity> SqlQuery(string sql);

        IQueryable<TEntity> Buscar(Expression<Func<TEntity, bool>> clasulaWhere);

        IQueryable<TEntity> Buscar(Expression<Func<TEntity, bool>> clasulaWhere, Expression<Func<TEntity, object>> @orderby);

        Task<ICollection<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> clasulaWhere, int limit = 0);

        Task<ICollection<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> clasulaWhere, Expression<Func<TEntity, object>> @orderby, int limit = 0);

        IQueryable<TEntity> BuscarTodos();

        void Excluir(Expression<Func<TEntity, bool>> clasulaWhere);

        void ExcluirConjunto(IEnumerable<TEntity> listaDeEntidades);
    }
}
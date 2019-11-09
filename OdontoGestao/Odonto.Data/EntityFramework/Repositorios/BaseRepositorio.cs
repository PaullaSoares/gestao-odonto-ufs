using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Odonto.Core.Repositorio;

namespace Odonto.Data.EntityFramework.Repositorios
{
    public abstract class BaseRepositorio<TEntity> : IDisposable, IRepositorio<TEntity> where TEntity : class
    {
        private readonly DbContext _contexto;

        public BaseRepositorio(DbContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(TEntity obj)
        {
            _contexto.Set<TEntity>().Add(obj);
        }

        public void AdicionarConjunto(IEnumerable<TEntity> listaDeEntidades)
        {
            _contexto.Set<TEntity>().AddRange(listaDeEntidades);
        }

        public void Atualizar(TEntity obj)
        {
            _contexto.Set<TEntity>().Update(obj);
        }

        public IQueryable<TEntity> SqlQuery(string sql)
        {
            return _contexto.Set<TEntity>().FromSql(sql).AsQueryable();
        }

        public IQueryable<TEntity> Buscar(Expression<Func<TEntity, bool>> clasulaWhere)
        {
            return BuscarTodos().Where(clasulaWhere).AsQueryable();
        }

        public IQueryable<TEntity> Buscar(Expression<Func<TEntity, bool>> clasulaWhere, Expression<Func<TEntity, object>> @orderby)
        {
            return BuscarTodos().Where(clasulaWhere).OrderBy(orderby).AsQueryable();
        }

        public async Task<ICollection<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> clasulaWhere, int limit = 0)
        {
            if (limit == 0)
                return await BuscarTodos().Where(clasulaWhere).ToListAsync();
            return await BuscarTodos().Where(clasulaWhere).Take(limit).ToListAsync();
        }

        public async Task<ICollection<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> clasulaWhere, Expression<Func<TEntity, object>> @orderby, int limit = 0)
        {
            if (limit == 0)
                return await BuscarTodos().Where(clasulaWhere).OrderBy(orderby).ToListAsync();
            return await BuscarTodos().Where(clasulaWhere).OrderBy(orderby).Take(limit).ToListAsync();
        }

        public IQueryable<TEntity> BuscarTodos()
        {
            return _contexto.Set<TEntity>().AsQueryable();
        }

        public void Excluir(Expression<Func<TEntity, bool>> clasulaWhere)
        {
            _contexto.Set<TEntity>()
                .Where(clasulaWhere).ToList()
                .ForEach(del => _contexto.Set<TEntity>().Remove(del));
        }

        public void ExcluirConjunto(IEnumerable<TEntity> listaDeEntidades)
        {
            _contexto.Set<TEntity>().RemoveRange(listaDeEntidades);
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        /// <summary>
        /// Devolve a primeira parte de uma string delimitada entre as "\" ou "%" informados, ou o próprio valor se "\" ou "%" não for informado
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static string TratarValorOrderBy(string valor)
        {
            var str = valor.Trim().Replace(@"\", "%"); // Isso irá permitir usar '%' ou '\'

            while (str.StartsWith("%"))
            {
                str = str.Substring(1);
            }

            var aux = str.Split('%');

            return aux.Length > 0 ? aux.FirstOrDefault() : valor;
        }
    }
}

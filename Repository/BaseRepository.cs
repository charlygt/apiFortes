using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        private readonly Context _context;

        /// <summary>
        /// Construtor recebe um contexto
        /// </summary>
        /// <param name="context">Classe de contexto que herda da classe DbContext do Entity Framework COre</param>
        public BaseRepository(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Método para adicionar dados no banco via Entity Framework
        /// </summary>
        /// <param name="obj">Objeto generico definido na herança da classe filha</param>
        public void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            try
            {
                _context.SaveChanges();

            }
            catch (Exception ex)
            {


                throw ex;
            }
        }

        /// <summary>
        /// Método para adicionar uma lista de objetos de dados no banco via Entity Framework
        /// </summary>
        /// <param name="obj">Lista do Objeto generico definido na herança da classe filha</param>
        public void AddRange(IEnumerable<TEntity> obj)
        {
            _context.Set<TEntity>().AddRange(obj);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método para adicionar uma lista de objetos de dados no banco via Entity Framework
        /// </summary>
        /// <param name="obj">Lista do Objeto generico definido na herança da classe filha</param>
        public TEntity GetById(object id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Método para obter uma lista de objetos de dados do banco via Entity Framework
        /// </summary>
        /// <returns>Retorna a tabela inteira do banco sem nenhuma condição</returns>
        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Método para obter uma lista de objetos de dados do banco via Entity Framework
        /// </summary>
        /// <param name="condicao">Expressão lambida para condicionar os dados que serão trazidos do banc com condiçãoo</param>
        /// <returns>Retorna dados do banco de acordo com a condição</returns>
        public List<TEntity> GetAll(Func<TEntity, bool> condicao)
        {
            return _context.Set<TEntity>().AsQueryable()
                .Where(condicao).ToList();
        }
        
        /// <summary>
        /// Método para alterar dados do banco via Entity Framework
        /// </summary>
        /// <param name="obj">Objeto generico definido na herança da classe filha</param>
        public void Update(TEntity obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para remover dados do banco via Entity Framework
        /// </summary>
        /// <param name="obj">Objeto generico definido na herança da classe filha</param>
        public void Remove(object ID)
        {
            TEntity obj = GetById(ID);
            _context.Set<TEntity>().Remove(obj);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método para remover dados do banco via Entity Framework - Remove vários objetos
        /// </summary>
        /// <param name="obj">Lista do Objeto generico definido na herança da classe filha</param>
        public void RemoveRange(IEnumerable<TEntity> obj)
        {
            _context.Set<TEntity>().RemoveRange(obj);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método para verificar se existe uma determinada entidade no banco
        /// </summary>
        /// <param name="obj">Id da entidade</param>
        public bool Existe(object obj)
        {
            return _context.Set<TEntity>().Find(obj) != null;
        }

    }
}


using Microsoft.EntityFrameworkCore;
using PruebaTecnicaVivianaLargo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaVivianaLargo.Repositorios
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly pruebaTecnicaContext _context;
        public GenericRepository(pruebaTecnicaContext context)
        {
            _context = context;
        }

        /*public  List<T> Get(int id)
        {
            return  _context.Set<T>().Find(id);
        }

        public  List<IEnumerable<T>> GetAll()
        {
            return  _context.Set<T>().ToList();
        }*/

        public void Add(T entity)
        {
             _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}

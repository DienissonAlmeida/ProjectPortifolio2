using ProjectsPortifolio.Data.Context;
using ProjectsPortifolio.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ProjectsPortifolio.Infra.Data.Features
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ProjectsPortifolioDbContext _context;

        public RepositoryBase(ProjectsPortifolioDbContext ProjectsPortifolioDbContext)
        {
            _context = ProjectsPortifolioDbContext;
        }
        public async Task<T> Add(T entity)
        {
            var dbEntity = _context.Set<T>().Add(entity).Entity;
            _context.SaveChanges();
            return dbEntity;
        }

        public async Task DeleteById(int id)
        {
            var entity = _context.Set<T>().Find(id);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                var db =   _context.Set<T>().AsNoTracking();
                return await db.ToListAsync();
            }
            catch(Exception ex) { return null; }
        }

        public async Task<T> GetById(int? id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
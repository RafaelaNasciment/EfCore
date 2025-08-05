﻿using Core.Entity;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infraestruture.Repository
{
    public class EfRepository<T> : IRepository<T> where T : EntityBase
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;

        public EfRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            entity.DataCriacao = DateTime.Now;
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(GetById(id));
            _context.SaveChanges();
        }

        public IList<T> GetAll()
            => _dbSet.ToList();


        public T GetById(int id)
            => _dbSet.FirstOrDefault(x => x.Id == id);
        

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
    }
}

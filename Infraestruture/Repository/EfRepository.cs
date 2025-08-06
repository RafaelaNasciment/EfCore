using Core.Entity;
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

        public void AddList(IEnumerable<T> entity)
        {
            var tempo1 =  System.Diagnostics.Stopwatch.StartNew();
            _dbSet.AddRange(entity);
            _context.SaveChanges();

            tempo1.Stop();
            var tempo1EmMilisegundos = tempo1.ElapsedMilliseconds;

            var tempo2 = System.Diagnostics.Stopwatch.StartNew();

            _dbSet.BulkInsert(entity);

            tempo2.Stop();
            var tempo2EmMilisegundos = tempo2.ElapsedMilliseconds;

            System.Diagnostics.Debug.WriteLine($"Tempo 1:{tempo1EmMilisegundos} - Tempo 2: {tempo2EmMilisegundos}");
        }
    }
}

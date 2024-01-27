using Flight.AirService.AccessData.Data;
using Flight.AirService.AccessData.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Flight.AirService.AccessData.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _dbcontext;
        public DbSet<T> dbSet;

        public Repository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            this.dbSet = _dbcontext.Set<T>();
        }

        public async Task<IQueryable<T>> AsQueryable()
        {
            return dbSet.AsQueryable();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var ip in includeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(ip);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetOne(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var ip in includeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(ip);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public int InsertSink(T entity, Func<T, int> getId)
        {
            dbSet.Add(entity);
            _dbcontext.SaveChanges();
            return getId(entity);
        }

        public int InsertIfNotExistSink(T entity, Func<T, int> getId)
        {
            var flightCarrier = GetPropertyValue(entity, "FlightCarrier") as string;
            var flightNumber = GetPropertyValue(entity, "FlightNumber") as string;

            var existingEntity = dbSet
                .Where(e => GetPropertyValue(e, "FlightCarrier") as string == flightCarrier &&
                            GetPropertyValue(e, "FlightNumber") as string == flightNumber)
                .FirstOrDefault();

            if (existingEntity != null)
            {
                return getId(existingEntity);
            }

            dbSet.Add(entity);
            _dbcontext.SaveChanges();

            return getId(entity);
        }

        public async Task Insert(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public bool Remove(T entity)
        {
            dbSet.Remove(entity);
            return _dbcontext.SaveChanges() > 0;
        }

        public bool Update(T entity)
        {
            _dbcontext.Entry(entity).State = EntityState.Modified;
            return _dbcontext.SaveChanges() > 0;
        }
        public async Task SaveChanges()
        {
            await _dbcontext.SaveChangesAsync();
        }
        private object GetPropertyValue(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName)?.GetValue(obj, null);
        }
    }
}

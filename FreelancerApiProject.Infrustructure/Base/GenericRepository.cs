using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using FreelancerApiProject.Infrustructure.Context;

namespace FreelancerApiProject.Infrustructure.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext Context;

        protected readonly DbSet<T> DbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            Context = context;

            DbSet = Context.Set<T>();
        }

        //*********************************************************

        public T? GetById(int id)
        {
            return DbSet.Find(id);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        //----------------------------------------------------------

        public T? Find(Expression<Func<T, bool>>? criteria, string[]? includes = null)
        {
            IQueryable<T> query = DbSet;

            if (criteria is not null)
            {
                query = query.Where(criteria);
            }

            if (includes != null)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            }

            return query.FirstOrDefault();
        }

        public async Task<T?> FindAsync(Expression<Func<T, bool>>? criteria, string[]? includes = null)
        {
            IQueryable<T> query = DbSet;

            if (criteria is not null)
            {
                query = query.Where(criteria);
            }

            if (includes != null)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            }


            return await query.FirstOrDefaultAsync();
        }

        //----------------------------------------------------------

        public IEnumerable<T> FindAll(string[]? includes = null, Expression<Func<T, bool>>? criteria = null)
        {
            IQueryable<T> query = DbSet;

            if (criteria is not null)
            {
                query = query.Where(criteria);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(string[]? includes = null, Expression<Func<T, bool>>? criteria = null)
        {
            IQueryable<T> query = DbSet;

            if (criteria is not null)
            {
                query = query.Where(criteria);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync(); 
        }

        public int GetCount()
        {
            return DbSet.Count();
        }

        //----------------------------------------------------------

        public PaginatedListModel<T> FindPaginated(int page, int pageSize, string[]? includes = null, Expression<Func<T, bool>>? criteria = null)
        {
            IQueryable<T> query = DbSet;

            if (criteria != null)
            {
                query = query.Where(criteria);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            int totalFilteredItems = query.Count();

            if (page < 1)
            {
                page = 1;
            }

            int totalPages = (int)Math.Ceiling(totalFilteredItems / (double)pageSize);

            if (page > totalPages)
            {
                page = totalPages;
            }

            List<T> items = query.Skip((page - 1) * pageSize)
                             .Take(pageSize)
                             .ToList();

            return new PaginatedListModel<T>
            {
                TotalItems = totalFilteredItems,
                TotalPages = totalPages,
                CurrentPage = page,
                Items = items
            };
        }

        public async Task<PaginatedListModel<T>> FindAllPaginatedAsync(int page, int pageSize, string[]? includes = null, Expression<Func<T, bool>>? criteria = null)
        {
            IQueryable<T> query = DbSet;

            if (criteria != null)
            {
                query = query.Where(criteria);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            int totalFilteredItems = await query.CountAsync();

            int totalPages = (int)Math.Ceiling(totalFilteredItems / (double)pageSize);

            // Add a check to ensure the page number is within a valid range
            if (page < 1)
            {
                page = 1;
            }

            if (page > totalPages)
            {
                page = totalPages;
            }

            var items = await query.Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();

            return new PaginatedListModel<T>
            {
                TotalItems = totalFilteredItems,
                TotalPages = totalPages,
                CurrentPage = page,
                Items = items
            };
        }

        //----------------------------------------------------------

        public T Add(T entity)
        {
            DbSet.Add(entity);

            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);

            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
            return entities;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await DbSet.AddRangeAsync(entities);
            return entities;
        }

        //----------------------------------------------------------

        public T Update(T entity)
        {
            DbSet.Update(entity);
            return entity;
        }
      

        //----------------------------------------------------------

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }
        

        public void DeleteRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public bool IsExist(Expression<Func<T, bool>> criteria)
        {
            return DbSet.Any(criteria);
        }
    }
}
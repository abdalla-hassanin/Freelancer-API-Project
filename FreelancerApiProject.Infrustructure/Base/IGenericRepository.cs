using System.Linq.Expressions;

namespace FreelancerApiProject.Infrustructure.Base 
{
    public interface IGenericRepository<T> where T : class
    {
        public T? GetById(int id);

        public Task<T?> GetByIdAsync(int id);

        //-------------------------------------------------------------------------

        public T? Find(Expression<Func<T, bool>> criteria, string[]? includes = null);

        public Task<T?> FindAsync(Expression<Func<T, bool>> criteria, string[]? includes = null);

        //-------------------------------------------------------------------------

        public IEnumerable<T> FindAll(string[]? includes = null, Expression<Func<T, bool>>? criteria = null);

        public Task<IEnumerable<T>> FindAllAsync(string[]? includes = null, Expression<Func<T, bool>>? criteria = null);

        public int GetCount();

        //-------------------------------------------------------------------------

        public PaginatedListModel<T> FindPaginated(int page , int pageSize ,string[]? includes = null, Expression<Func<T, bool>>? criteria = null);

        public Task<PaginatedListModel<T>> FindAllPaginatedAsync(int pageNumber, int pageSize,string[]? includes = null, Expression<Func<T, bool>>? criteria = null);

        //-------------------------------------------------------------------------

        public T Add(T entity);

        public Task<T> AddAsync(T entity);

        //-------------------------------------------------------------------------

        public IEnumerable<T> AddRange(IEnumerable<T> entities);

        public Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        //-------------------------------------------------------------------------

        public T Update(T entity);


        //-------------------------------------------------------------------------

        public void Delete(T entity);

        public void DeleteRange(IEnumerable<T> entities);

        public bool IsExist(Expression<Func<T, bool>> criteria);
        
    }
}
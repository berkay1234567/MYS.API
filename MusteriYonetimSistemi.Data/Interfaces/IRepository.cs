

namespace MusteriYonetimSistemi.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<bool> AddAsync(T obj);
        public Task<bool> UpdateAsync(T obj);
        public Task<bool> DeleteAsync(int id);
        public Task<T> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetByAllAsync();

        public Task<T> FindAsync(int id);
    }
}

namespace DAL.Repositories
{
    public interface IRepository<T>
    {
        public T? GetById(int id);
        public List<T?> Get();
        public int Add(T item);
        public void Update(int id, T item);
    }

    public abstract class Repository<T>
    {
        public abstract T? GetById(int id);
        public abstract List<T?> Get();
        public abstract int Add(T item);
        public abstract void Update(int id, T item);
    }
}

namespace DAL.Repositories
{
    public abstract class Repository<T>
    {
        public abstract T? GetById(int id);
        public abstract List<T?> Get();
        public abstract int Add(T item);
        public abstract void Update(int id, T item);
    }
}

namespace WebApplication1.repository
{
    public interface IGenericRepository<T, ID>
    {
        T? FindById(ID id);
        List<T> FindAll();
        T? Update(ID id, T entity);
        T Save(T entity);
        T? DeleteById(ID id);
    }
}

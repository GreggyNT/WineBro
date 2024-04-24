namespace api.Services;

public interface IService<T,TV>
{
    public T? Create(T dto);

    T? Read(long? id);

    public T? Update(T dto);

    public bool Delete(long? id);

    public IEnumerable<T> GetAll(int count);
    
}
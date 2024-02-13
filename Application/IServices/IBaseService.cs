namespace ApplicationLayer.IServices;

public interface IBaseService<T>
{
    List<T> GetAll();
    T GetById(int id);
    T Create(T model);
    T Update(T model);
    T Delete(int id);
}
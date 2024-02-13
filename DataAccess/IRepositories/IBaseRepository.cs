namespace DataAccess.IRepositories;

public interface IBaseRepository<TEntity>
{
    List<TEntity> FindAll();
    TEntity? FindById(int id);
    TEntity? Create(TEntity? entity);
    TEntity? Update(TEntity entity);
    TEntity? Delete(int id);
}
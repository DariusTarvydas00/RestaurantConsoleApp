using DataAccess.Entities;
using DataAccess.IRepositories;
using Newtonsoft.Json;

namespace DataAccess.Repositories;

/// <summary>
/// Generic base repository class providing basic CRUD operations for entities.
/// </summary>
/// <typeparam name="TEntity">The type of entity.</typeparam>
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : IEntity
{
    private readonly string _filePath;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class with the specified file path.
    /// </summary>
    /// <param name="filePath">The file path where data will be stored.</param>
    protected BaseRepository(string filePath)
    {
        _filePath = filePath;
    }

    /// <summary>
    /// Retrieves all entities from the data source.
    /// </summary>
    /// <returns>The list of entities.</returns>
    public List<TEntity> FindAll()
    {
        return ReadFromFile() ?? new List<TEntity>();
    }

    /// <summary>
    /// Retrieves an entity by its ID from the data source.
    /// </summary>
    /// <param name="id">The ID of the entity to retrieve.</param>
    /// <returns>The entity if found; otherwise, null.</returns>
    public TEntity? FindById(int id)
    {
        var entities = FindAll();
        return entities.FirstOrDefault(item => item.Id == id);
    }

    /// <summary>
    /// Creates a new entity in the data source.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    /// <returns>The created entity.</returns>
    public TEntity? Create(TEntity? entity)
    {
        var entities = FindAll();
        if (entity != null)
        {
            entity.Id = entities.Any() ? entities.Max(e => e.Id) + 1 : 1;
            entities.Add(entity);
            WriteToFile(entities);
            return entity;
        }

        return entity;
    }

    /// <summary>
    /// Updates an existing entity in the data source.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>The updated entity.</returns>
    public TEntity? Update(TEntity entity)
    {
        var entities = FindAll();
        var entityToUpdate = entities.FirstOrDefault(item => item.Id == entity.Id);
        if (entityToUpdate != null)
        {
            entities.Remove(entityToUpdate);
            entities.Add(entity);
            WriteToFile(entities);
        }
        return entityToUpdate;
    }

    /// <summary>
    /// Deletes an entity from the data source by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    /// <returns>The deleted entity.</returns>
    public TEntity? Delete(int id)
    {
        var entities = FindAll();
        var entityToRemove = entities.FirstOrDefault(item => item.Id == id);
        if (entityToRemove != null)
        {
            entities.Remove(entityToRemove);
            WriteToFile(entities);
        }
        return entityToRemove;
    }

    // Reads data from the file and deserializes it to a list of entities
    private List<TEntity>? ReadFromFile()
    {
        if (!File.Exists(_filePath))
            return null;

        var json = File.ReadAllText(_filePath);
        return JsonConvert.DeserializeObject<List<TEntity>>(json);
    }

    // Writes a list of entities to the file after sorting them by ID
    private void WriteToFile(List<TEntity> items)
    {
        var jsonSettings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        };
        var json = JsonConvert.SerializeObject(items.OrderBy(entity => entity.Id), jsonSettings);
        File.WriteAllText(_filePath, json);
    }
}
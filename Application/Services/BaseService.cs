using ApplicationLayer.IServices;
using AutoMapper;
using DataAccess.IRepositories;

namespace ApplicationLayer.Services;

    // Generic base service class providing CRUD operations for a given entity and model types
    public class BaseService<TEntity, TModel> : IBaseService<TModel> where TEntity : class
    {
        // Private fields to hold the repository and mapper instances
        private readonly IBaseRepository<TEntity?> _repository;
        private readonly IMapper _mapper;

        // Constructor to initialize the repository and mapper instances
        protected BaseService(IBaseRepository<TEntity?> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Method to retrieve all instances of the model
        public List<TModel> GetAll()
        {
            // Retrieve all entities from the repository
            var entities = _repository.FindAll();
            // Map the entities to model objects using AutoMapper
            return _mapper.Map<List<TModel>>(entities);
        }

        // Method to retrieve a single instance of the model by its ID
        public TModel GetById(int id)
        {
            // Retrieve the entity from the repository by its ID
            var entity = _repository.FindById(id);
            // Map the entity to a model object using AutoMapper
            return _mapper.Map<TModel>(entity);
        }

        // Method to create a new instance of the model
        public TModel Create(TModel model)
        {
            // Map the model object to an entity using AutoMapper
            var entity = _mapper.Map<TEntity>(model);
            // Create the entity in the repository
            var createdEntity = _repository.Create(entity);
            // Map the created entity back to a model object using AutoMapper
            return _mapper.Map<TModel>(createdEntity);
        }

        // Method to update an existing instance of the model
        public TModel Update(TModel model)
        {
            // Map the model object to an entity using AutoMapper
            var entity = _mapper.Map<TEntity>(model);
            // Update the entity in the repository
            var updatedEntity = _repository.Update(entity);
            // Map the updated entity back to a model object using AutoMapper
            return _mapper.Map<TModel>(updatedEntity);
        }

        // Method to delete an instance of the model by its ID
        public TModel Delete(int id)
        {
            // Delete the entity from the repository by its ID
            var deletedEntity = _repository.Delete(id);
            // Map the deleted entity to a model object using AutoMapper
            return _mapper.Map<TModel>(deletedEntity);
        }
    }
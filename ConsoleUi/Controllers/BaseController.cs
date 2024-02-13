using ApplicationLayer.IServices;

namespace ConsoleUi.Controllers;

// Generic base controller class providing CRUD operations for a given model type
public class BaseController<TService, TModel> where TService : IBaseService<TModel>
{
    // Private field to hold the service instance
    private readonly TService _service;

    // Constructor to initialize the service instance
    protected BaseController(TService service)
    {
        _service = service;
    }

    // Method to retrieve all instances of the model
    public List<TModel> GetAll()
    {
        return _service.GetAll();
    }

    // Method to retrieve a single instance of the model by its ID
    public TModel GetById(int id)
    {
        return _service.GetById(id);
    }

    // Method to create a new instance of the model
    public TModel Create(TModel model)
    {
        return _service.Create(model);
    }

    // Method to update an existing instance of the model
    public TModel Update(TModel model)
    {
        return _service.Update(model);
    }

    // Method to delete an instance of the model by its ID
    public TModel Delete(int id)
    {
        return _service.Delete(id);
    }
}
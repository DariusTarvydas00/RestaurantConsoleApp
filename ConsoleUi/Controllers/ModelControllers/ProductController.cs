using ApplicationLayer.IServices.ISpecServices;
using ApplicationLayer.Models.SpecModels;

namespace ConsoleUi.Controllers.ModelControllers;

public class ProductController(IProductService service) : BaseController<IProductService, ProductModel>(service)
{
    private readonly IProductService _service1 = service;

    public void PrintAllProducts()
    {
        foreach (var productModel in _service1.GetAll())
        {
            // Print product details
            Console.WriteLine($"Product Id:{productModel.Id} " +
                              $"Product:{productModel.Name} - {productModel.Description} " +
                              $"Price:{productModel.Price}");
        }
        Console.WriteLine();
    }

    // Method to create a new product
    public void CreateProduct()
    {
        Console.WriteLine("Please enter the following information to create a new product:");
        Console.Write("Name: ");
        var productName = Console.ReadLine();

        Console.Write("Description (optional): ");
        var productDescription = Console.ReadLine();

        Console.Write("Price: ");
        double.TryParse(Console.ReadLine(), out double productPrice);

        // Create a new product model
        var newProduct = new ProductModel()
        {
            Name = productName ?? throw new InvalidOperationException(),
            Description = productDescription ?? throw new InvalidOperationException(),
            Price = productPrice
        };
        _service1.Create(newProduct);
    }

    // Method to update a product
    public void UpdateProduct()
    {
        Console.WriteLine("Please enter the following information to update a product:");
        Console.Write("Product Id: ");
        int.TryParse(Console.ReadLine(), out int id);

        Console.Write("Name: ");
        var productName = Console.ReadLine();

        Console.Write("Description (optional): ");
        var productDescription = Console.ReadLine();

        Console.Write("Price: ");
        double.TryParse(Console.ReadLine(), out double productPrice);

        // Create a product model to update
        var productToUpdate = new ProductModel()
        {
            Id = id,
            Name = productName ?? throw new InvalidOperationException(),
            Description = productDescription ?? throw new InvalidOperationException(),
            Price = productPrice
        };
        _service1.Update(productToUpdate);
    }

    // Method to delete a product
    public void DeleteProduct()
    {
        Console.WriteLine("Please enter the following information to delete a product:");
        Console.Write("Product Id: ");
        int.TryParse(Console.ReadLine(), out int id);
        _service1.Delete(id);
    }
}
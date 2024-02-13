using ApplicationLayer.IServices.ISpecServices;
using ApplicationLayer.Models.SpecModels;

namespace ConsoleUi.Controllers.ModelControllers;

public class OrderController(IOrderService service) : BaseController<IOrderService, OrderModel>(service)
{
    private readonly IOrderService _service1 = service;

    // Method to print all orders
    public void PrintAllOrders()
    {
        foreach (var orderModel in _service1.GetAll())
        {
            // Print order details including its associated table ID and occupation status
            Console.Write($"Order Id:{orderModel.Id} " +
                              $"Table Id:{orderModel.TableModel.Id} " +
                              $"Table occupation:{orderModel.TableModel.IsTaken} " +
                              $"Table Seat amount:{orderModel.TableModel.SeatAmount}");
            if (orderModel.TableModel.IsTaken)
            {
                Console.WriteLine($"Reserved by:{orderModel.TableModel.CustomerName}");
                Console.WriteLine($"This table already ordered:");
                foreach (var products in orderModel.ProductModels)
                {
                    Console.WriteLine($"Product:{products.Name} - {products.Description} " +
                                      $"Price:{products.Price}");
                }
            }
        }
        Console.WriteLine();
    }

    // Method to create a new order
    public void CreateOrder(ProductController productController, TableController tableController)
    {
        Console.WriteLine("Please enter the following information to create a new order:");

        // Prompt user for table number
        Console.WriteLine("Please Enter Table Number:");
        int.TryParse(Console.ReadLine(), out var tableNumber);
        var tableSelected = tableController.GetById(tableNumber);
        if (tableSelected.IsTaken)
        {
            throw new InvalidDataException("Table is already taken");
        }
        tableSelected.IsTaken = true;
        var productList = new List<ProductModel>();
        var selectingProducts = true;
        do
        {
            if (selectingProducts)
            {
                Console.WriteLine("Please enter product id or -1 to exit)");
                int.TryParse(Console.ReadLine(), out var productId);
                if (productId == -1)
                {
                    selectingProducts = false;
                }
                else
                {
                    var product = productController.GetById(productId);
                    productList.Add(product);
                }
            }
        } while (selectingProducts);

        // Check if the product list is empty
        if (productList.Count == 0)
        {
            Console.WriteLine("Product list cannot be empty.");
            return;
        }

        var newOrder = new OrderModel()
        {
            TableModel = tableSelected,
            ProductModels = productList
        };
        _service1.Create(newOrder);
    }

    // Method to update an order
    public void UpdateOrder(ProductController productController, TableController tableController)
    {
        Console.WriteLine("Please enter the following information to update an order:");
        Console.WriteLine("Please Enter Order Id:");
        int.TryParse(Console.ReadLine(), out var orderId);
        var orderToUpdate = _service1.GetById(orderId);

        var updatingOrder = true;
        do
        {
            if (updatingOrder)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Update Table occupation:");
                Console.WriteLine("2. Update Products:");
                Console.WriteLine("3. Finish Order Update:");
                int.TryParse(Console.ReadLine(), out int selection);
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Enter true or false if table occupied:");
                        bool.TryParse(Console.ReadLine(), out bool isOccupied);
                        if (isOccupied)
                        {
                            Console.WriteLine("Please enter new Customer Name");
                            orderToUpdate.TableModel.CustomerName =
                                Console.ReadLine() ?? throw new InvalidOperationException();
                            orderToUpdate.TableModel.IsTaken = true;
                        }
                        else
                        {
                            orderToUpdate.TableModel.CustomerName = "";
                            orderToUpdate.TableModel.IsTaken = false;
                        }

                        break;
                    case 2:
                        var updatingProducts = true;
                        do
                        {
                            if (updatingProducts)
                            {
                                Console.WriteLine("Please select an option:");
                                Console.WriteLine("1. Add product");
                                Console.WriteLine("2. Remove product");
                                Console.WriteLine("3. Done");
                                int.TryParse(Console.ReadLine(), out int productSelection);
                                switch (productSelection)
                                {
                                    case 1:
                                        Console.WriteLine("Enter product id to add:");
                                        int.TryParse(Console.ReadLine(), out int productIdToAdd);
                                        orderToUpdate.ProductModels.Add(productController.GetById(productIdToAdd));
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter product id to remove:");
                                        int.TryParse(Console.ReadLine(), out int productIdToRemove);
                                        orderToUpdate.ProductModels.Remove(
                                            productController.GetById(productIdToRemove));
                                        break;
                                    case 3:
                                        updatingProducts = false;
                                        break;
                                    default:
                                        Console.WriteLine("Wrong selection!!!");
                                        break;
                                }
                            }
                        } while (updatingProducts);

                        break;
                    case 3:
                        updatingOrder = false;
                        break;
                    default:
                        Console.WriteLine("Wrong selection!!!");
                        break;
                }
            }
        } while (updatingOrder);

        _service1.Update(orderToUpdate);
    }

    // Method to delete an order
    public void DeleteOrder()
    {
        Console.WriteLine("Please enter the following information to delete an order:");
        Console.Write("Order Id: ");
        int.TryParse(Console.ReadLine(), out var id);
        _service1.Delete(id);
    }
}
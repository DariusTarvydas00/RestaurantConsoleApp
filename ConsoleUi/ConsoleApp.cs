using ApplicationLayer.Models.SpecModels;
using ConsoleUi.Controllers.ModelControllers;

namespace ConsoleUi;

public class ConsoleApp
{
    private readonly ProductController _productController;
    private readonly TableController _tableController;
    private readonly OrderController _orderController;
    private readonly VoucherController _voucherController;

    public ConsoleApp(ProductController productController, TableController tableController,
        OrderController orderController, VoucherController voucherController)
    {
        _productController = productController;
        _tableController = tableController;
        _orderController = orderController;
        _voucherController = voucherController;
    }

    public void Run()
    {
        if (!File.Exists("C:\\Restaurant\\products.json"))
        {
            InitializeProducts();
        }
        if (!File.Exists("C:\\Restaurant\\tables.json"))
        {
            InitializeTables();
        }

        var applicationRunning = true;
        PrintLogo();
        do
        {
            PrintMainMenu();
            var option = Console.ReadLine();
            int.TryParse(option, out int selection);
            switch (selection)
            {
                case 1:
                    RestaurantManagement();
                    break;
                case 2:
                    applicationRunning = false;
                    break;
                default:
                    Console.WriteLine("Wrong selection!!!");
                    break;
            }
        } while (applicationRunning);
    }

    private void PrintLogo()
    {
        Console.WriteLine($"--------------------------------------------");
        Console.WriteLine($"--------------------------------------------");
        Console.WriteLine($"--------------------------------------------");
        Console.WriteLine($"--------------------------------------------");
        Console.WriteLine($"--------------- Restaurant App -------------");
        Console.WriteLine($"--------------------------------------------");
        Console.WriteLine($"--------------------------------------------");
        Console.WriteLine($"--------------------------------------------");
        Console.WriteLine($"--------------------------------------------");
    }

    private void PrintMainMenu()
    {
        Console.WriteLine($"Please, choose one of the options: ");
        Console.WriteLine($"1. Restaurant Management System");
        Console.WriteLine($"2. Exit");
    }

    private void RestaurantManagement()
    {
        var managingRestaurant = true;
        do
        {
            if (managingRestaurant)
            {
                Console.WriteLine($"Please Select from available Options:");
                Console.WriteLine($"1. Product management");
                Console.WriteLine($"2. Table management");
                Console.WriteLine($"3. Order management");
                Console.WriteLine($"4. Voucher management");
                Console.WriteLine($"5. Go back");
                int.TryParse(Console.ReadLine(), out int selection);
                switch (selection)
                {
                    case 1:
                        ProductManagement();
                        break;
                    case 2:
                        TableManagement();
                        break;
                    case 3:
                        OrderManagement();
                        break;
                    case 4:
                        VoucherManagement();
                        break;
                    case 5:
                        break;
                    case 6:
                        managingRestaurant = false;
                        break;
                    default:
                        Console.WriteLine("Wrong selection");
                        break;
                }
            }
        } while (managingRestaurant);
    }

    private void ProductManagement()
    {
        var managingProduct = true;
        do
        {
            if (managingProduct)
            {
                Console.WriteLine($"Please Select from available Options:");
                Console.WriteLine($"1. Show all products");
                Console.WriteLine($"2. Create product");
                Console.WriteLine($"3. Update product");
                Console.WriteLine($"4. Delete product");
                Console.WriteLine($"5. Go back");
                int.TryParse(Console.ReadLine(), out int selection);
                switch (selection)
                {
                    case 1:
                        _productController.PrintAllProducts();
                        break;
                    case 2:
                        _productController.CreateProduct();
                        break;
                    case 3:
                        _productController.UpdateProduct();
                        break;
                    case 4:
                        _productController.DeleteProduct();
                        break;
                    case 5:
                        managingProduct = false;
                        break;
                    default:
                        Console.WriteLine("Wrong selection");
                        break;
                }
            }
        } while (managingProduct);
    }

    private void TableManagement()
    {
        var managingTable = true;
        do
        {
            if (managingTable)
            {
                Console.WriteLine($"Please Select from available Options:");
                Console.WriteLine($"1. Show all tables");
                Console.WriteLine($"2. Create table");
                Console.WriteLine($"3. Update table");
                Console.WriteLine($"4. Delete table");
                Console.WriteLine($"5. Go back");
                int.TryParse(Console.ReadLine(), out int selection);
                switch (selection)
                {
                    case 1:
                        _tableController.PrintAllTables();
                        break;
                    case 2:
                        _tableController.CreateTable();
                        break;
                    case 3:
                        _tableController.UpdateTable();
                        break;
                    case 4:
                        _tableController.DeleteTable();
                        break;
                    case 5:
                        managingTable = false;
                        break;
                    default:
                        Console.WriteLine("Wrong selection");
                        break;
                }
            }
        } while (managingTable);
    }

    private void OrderManagement()
    {
        var managingOrder = true;
        do
        {
            if (managingOrder)
            {
                Console.WriteLine($"Please Select from available Options:");
                Console.WriteLine($"1. Show all orders");
                Console.WriteLine($"2. Create order");
                Console.WriteLine($"3. Update order");
                Console.WriteLine($"4. Delete order");
                Console.WriteLine($"5. Go back");
                int.TryParse(Console.ReadLine(), out int selection);
                switch (selection)
                {
                    case 1:
                        _orderController.PrintAllOrders();
                        break;
                    case 2:

                        _orderController.CreateOrder(_productController, _tableController);
                        break;
                    case 3:
                        _orderController.UpdateOrder(_productController, _tableController);
                        break;
                    case 4:
                        _orderController.DeleteOrder();
                        break;
                    case 5:
                        managingOrder = false;
                        break;
                    default:
                        Console.WriteLine("Wrong selection");
                        break;
                }
            }
        } while (managingOrder);
    }

    private void VoucherManagement()
    {
        var managingVoucher = true;
        do
        {
            if (managingVoucher)
            {
                Console.WriteLine($"Please Select from available Options:");
                Console.WriteLine($"1. Show all vouchers");
                Console.WriteLine($"2. Create voucher");
                Console.WriteLine($"3. Delete voucher");
                Console.WriteLine($"4. Go back");
                int.TryParse(Console.ReadLine(), out int selection);
                switch (selection)
                {
                    case 1:
                        _voucherController.PrintAllVouchers();
                        break;
                    case 2:
                        _voucherController.CreateVoucher(_orderController, _tableController);
                        break;
                    case 3:
                        _voucherController.DeleteVoucher();
                        break;
                    case 4:
                        managingVoucher = false;
                        break;
                    default:
                        Console.WriteLine("Wrong selection");
                        break;
                }
            }
        } while (managingVoucher);
    }

    private void InitializeProducts()
    {
        string[] mealNames =
        {
            "Spaghetti Carbonara", "Chicken Alfredo", "Beef Stir Fry", "Vegetable Lasagna", "Grilled Salmon",
            "Roast Chicken", "Caesar Salad", "Margherita Pizza", "Hamburger", "Pad Thai", "Sushi", "Chicken Parmesan",
            "Mushroom Risotto", "Eggplant Parmesan", "Tacos", "Burritos", "Pasta Primavera", "BBQ Ribs",
            "Shrimp Scampi", "Fish and Chips", "Steak Frites", "Pho", "Lasagna", "Tom Yum Soup"
        };
        string[] drinkNames =
        {
            "Orange Juice", "Mojito", "Margarita", "Strawberry Smoothie", "Cappuccino", "Espresso", "Hot Chocolate",
            "Iced Tea", "Milkshake", "Pina Colada", "Ginger Beer", "Green Tea", "Lemonade", "Peach Iced Tea",
            "Apple Cider", "Coconut Water", "Sangria", "Lemon Water", "Arnold Palmer", "Red Bull", "Milk", "Chai Tea",
            "Cranberry Juice", "Grapefruit Juice", "Tomato Juice"
        };

        // Creating 25 meals
        for (int i = 1; i <= 25; i++)
        {
            var meal = new ProductModel()
            {
                Id = i,
                Name = GetRandomMealName(mealNames),
                Description = $"Description for {mealNames[i % mealNames.Length]}",
                Price = GenerateRandomPrice()
            };
            _productController.Create(meal);
        }

        // Creating 25 drinks
        for (var i = 26; i <= 50; i++)
        {
            var drink = new ProductModel
            {
                Id = i,
                Name = GetRandomDrinkName(drinkNames),
                Description = $"Description for {drinkNames[(i - 25) % drinkNames.Length]}",
                Price = GenerateRandomPrice()
            };

            _productController.Create(drink);
        }
    }

    // Method to get a random meal name from the predefined list
    private string GetRandomMealName(string[] mealNames)
    {
        var rand = new Random();
        return mealNames[rand.Next(mealNames.Length)];
    }

    // Method to get a random drink name from the predefined list
    private string GetRandomDrinkName(string[] drinkNames)
    {
        var rand = new Random();
        return drinkNames[rand.Next(drinkNames.Length)];
    }

    // Generating a random price for the products
    private double GenerateRandomPrice()
    {
        var rand = new Random();
        return Math.Round(rand.NextDouble() * 20 + 5, 2); // Generating a price between 5 and 25 with two decimal places
    }

    private void InitializeTables()
    {
        // Creating 20 tables
        for (var i = 1; i <= 20; i++)
        {
            var table = new TableModel
            {
                Id = i,
                IsTaken = false, // Assuming initially all tables are not taken
                SeatAmount = GetRandomSeatAmount(),
                CustomerName = string.Empty // Assuming initially there's no customer
            };

            _tableController.Create(table);
        }
    }

    // Generating a random seat amount for the tables
    private int GetRandomSeatAmount()
    {
        var rand = new Random();
        return rand.Next(2, 10); // Assuming tables can have 2 to 9 seats
    }
}
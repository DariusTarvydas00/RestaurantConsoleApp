using ApplicationLayer.IServices.ISpecServices;
using ApplicationLayer.Models.SpecModels;

namespace ConsoleUi.Controllers.ModelControllers;

public class VoucherController(IVoucherService service) : BaseController<IVoucherService, VoucherModel>(service)
{
    private readonly IVoucherService _service1 = service;

    // Method to print all vouchers
    public void PrintAllVouchers()
    {
        foreach (var voucherModel in _service1.GetAll())
        {
            // Print voucher details including its associated order and table IDs
            Console.Write(
                $"Voucher Id:{voucherModel.Id} " +
                $"Voucher Order Id:{voucherModel.OrderModel.Id} " +
                $"Voucher Table Id:{voucherModel.OrderModel.TableModel.Id}" +
                $"Voucher Reserved By:{voucherModel.OrderModel.TableModel.CustomerName}");
            Console.WriteLine();
            Console.WriteLine("This table orders:");
            foreach (var product in voucherModel.OrderModel.ProductModels)
            {
                Console.WriteLine($"Product:{product.Name} {product.Price}");
            }
            Console.WriteLine($"Total Amount to pay:{AmountToPay(voucherModel.OrderModel.ProductModels)}");
     
        }
        Console.WriteLine();
    }

    private double AmountToPay(List<ProductModel> productModels)
    {
        double amount = 0;
        foreach (var productModel in productModels)
        {
            amount += productModel.Price;
        }
        return amount;
    }

    // Method to create a new voucher
    public void CreateVoucher(OrderController orderController, TableController tableController)
    {
        Console.WriteLine("Please enter the following information to create a new voucher:");

        // Prompt user for table number
        Console.WriteLine("Please Enter Table Number:");
        int.TryParse(Console.ReadLine(), out int tableNumber);

        // Get the table associated with the provided table number
        var table = tableController.GetById(tableNumber);

        // Get the order associated with the selected table
        var orderSelected = orderController.GetById(table.Id);

        // Create a new voucher using the selected order
        var newVoucher = new VoucherModel()
        {
            OrderModel = orderSelected,
        };
        _service1.Create(newVoucher);
    }

    // Method to delete a voucher
    public void DeleteVoucher()
    {
        Console.WriteLine("Please enter the following information to delete a voucher:");
        Console.Write("Voucher Id: ");
        int.TryParse(Console.ReadLine(), out int id);
        _service1.Delete(id);
    }
}
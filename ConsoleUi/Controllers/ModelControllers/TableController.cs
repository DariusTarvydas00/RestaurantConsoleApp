using ApplicationLayer.IServices.ISpecServices;
using ApplicationLayer.Models.SpecModels;

namespace ConsoleUi.Controllers.ModelControllers;

public class TableController(ITableService service) : BaseController<ITableService, TableModel>(service)
{
    private readonly ITableService _service1 = service;

    public void PrintAllTables()
    {
        foreach (var tableModel in _service1.GetAll())
        {
            // Print table details
            Console.Write(
                $"Table Id:{tableModel.Id} " +
                $"Seats:{tableModel.SeatAmount}");
            if (tableModel.IsTaken)
            {
                Console.Write(" Table is reserved");
            }
            else
            {
                Console.Write(" Table is available");
            }

            if (tableModel.IsTaken)
            {
                Console.WriteLine($"Occupied y:{tableModel.CustomerName}");
            }
            else
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }

    // Method to create a new table
    public void CreateTable()
    {
        Console.WriteLine("Please enter the following information to create a new table:");
        Console.Write("Seat amount: ");
        int.TryParse(Console.ReadLine(), out int seatAmount);
        Console.Write("Is it occupied (write true or false): ");
        bool.TryParse(Console.ReadLine(), out bool isTaken);
        string customerName = (isTaken ? Console.ReadLine() : "") ?? throw new InvalidOperationException();

        // Create a new table model
        var newTable = new TableModel()
        {
            SeatAmount = seatAmount,
            IsTaken = isTaken,
            CustomerName = customerName
        };
        _service1.Create(newTable);
    }

    // Method to update a table
    public void UpdateTable()
    {
        Console.WriteLine("Please enter the following information to update a table:");
        Console.Write("Table Id: ");
        int.TryParse(Console.ReadLine(), out int id);
        Console.Write("Seat amount: ");
        int.TryParse(Console.ReadLine(), out int seatAmount);
        Console.Write("Is it occupied (write true or false): ");
        bool.TryParse(Console.ReadLine(), out bool isTaken);
        string customerName = (isTaken ? Console.ReadLine() : "") ?? throw new InvalidOperationException();

        // Create a table model to update
        var tableToUpdate = new TableModel()
        {
            Id = id,
            CustomerName = customerName,
            IsTaken = isTaken,
            SeatAmount = seatAmount
        };
        _service1.Update(tableToUpdate);
    }

    // Method to delete a table
    public void DeleteTable()
    {
        Console.WriteLine("Please enter the following information to delete a table:");
        Console.Write("Table Id: ");
        int.TryParse(Console.ReadLine(), out var id);
        _service1.Delete(id);
    }
}
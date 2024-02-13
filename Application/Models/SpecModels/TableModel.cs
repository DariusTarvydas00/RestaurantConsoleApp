namespace ApplicationLayer.Models.SpecModels;

public class TableModel
{
    public int Id { get; set; }
    public bool IsTaken { get; set; }
    public int SeatAmount { get; set; }
    public string CustomerName { get; set; }
}
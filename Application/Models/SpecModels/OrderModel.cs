namespace ApplicationLayer.Models.SpecModels;

public class OrderModel
{
    public int Id { get; set; }
    public TableModel TableModel { get; set; }
    public List<ProductModel> ProductModels { get; set; }
}
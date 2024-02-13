namespace DataAccess.Entities.SpecEntities;

public class ProductEntity : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}
namespace DataAccess.Entities.SpecEntities;

public class OrderEntity : IEntity
{
    public int Id { get; set; }
    public TableEntity TableEntity { get; set; }
    public List<ProductEntity> Products { get; set; }
}
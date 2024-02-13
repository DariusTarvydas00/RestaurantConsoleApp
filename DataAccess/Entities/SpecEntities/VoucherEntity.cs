namespace DataAccess.Entities.SpecEntities;

public class VoucherEntity : IEntity
{
    public int Id { get; set; }
    public OrderEntity OrderEntity { get; set; }
}
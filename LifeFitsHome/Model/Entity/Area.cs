using LifeFitsHome.Model.Entity;



public class Area:IEntity
{
    public int Id { get; set; }

    public string? Description { get; set; }
    public bool? IsSafety { get; set; }
    public int AreaTypeId { get; set; }
    public AreaType AreaType { get; set; }

    public virtual ICollection<Address>? Address { get; set; }

}
using LifeFitsHome.Model.Entity;

public class City:IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RegionId { get; set; }
    public Region Region { get; set; }
    public virtual ICollection<District>? Districts { get; set; }
}
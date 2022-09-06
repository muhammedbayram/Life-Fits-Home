using LifeFitsHome.Model.Entity;

public class District : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
    public virtual ICollection<Address> Addresses { get; set; }
}
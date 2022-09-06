using LifeFitsHome.Model.Entity;

public class Region:IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<City>? Cities {get;set;}
}
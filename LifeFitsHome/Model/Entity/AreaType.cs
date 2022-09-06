using LifeFitsHome.Model.Entity;

public class AreaType:IEntity{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Area> ?Areas {get; set;}

}
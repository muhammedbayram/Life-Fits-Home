using LifeFitsHome.Model.Entity;

public class Gender : IEntity
{

    public int Id { get; set; }
    public string Name { get; set; }
    public virtual User? User { get; set; }





}
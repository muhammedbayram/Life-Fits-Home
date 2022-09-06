using LifeFitsHome.Model.Entity;

public class Address : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string OpenAddress1 { get; set; }
    public string OpenAddress2 { get; set; }
    public int DistrictId { get; set; }
    public District District { get; set; }
    public int AreaId { get; set; }
     public Area Area {get;set;}

}
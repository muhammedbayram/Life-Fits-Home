namespace LifeFitsHome.Model.Entity
{
    public class Vaccine : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public VaccineType? VaccineType { get; set; }
        public int VaccineTypeId { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
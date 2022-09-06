namespace LifeFitsHome.Model.Entity
{
    public class VaccineType : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Vaccine>? Vaccines { get; set; }
    }
}
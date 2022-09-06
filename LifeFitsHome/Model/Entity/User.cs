namespace LifeFitsHome.Model.Entity
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string IdentyNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsSafety { get; set; }
        public Gender? Gender { get; set; }
        public int GenderId { get; set; }
        public virtual ICollection<Vaccine>? Vaccines { get; set; }
        public virtual ICollection<QRCode>? QRCodes { get; set; }


    }
}

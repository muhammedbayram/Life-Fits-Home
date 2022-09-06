using LifeFitsHome.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace LifeFitsHome.Contexts
{
    public class DbContextBase : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<OperationClaim>? OperationClaims { get; set; }
        public DbSet<UserOperationClaim>? UserOperationClaims { get; set; }
        public DbSet<Address>? Addresses { get; set; }
        public DbSet<City>? Cities { get; set; }
        public DbSet<District>? Districts { get; set; }
        public DbSet<Region>? Regions { get; set; }
        public DbSet<Area>? Areas {get; set;}
        public DbSet<AreaType>? AreaTypes{get; set;}
        public DbSet<Gender>? Genders{get; set;}
        public DbSet<QRCode>? QRCodes{get; set;}
        public DbSet<Vaccine>? Vaccines{get; set;}
        public DbSet<VaccineType>? VaccineTypes{get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
            optionsBuilder.UseMySql("server=localhost;database=lifefitshomedb;user=root;port=3306;password=toortoor", serverVersion);
        }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.IdentyNumber).IsRequired();
                entity.Property(e => e.PhoneNumber).IsRequired();
                entity.Property(e => e.PasswordSalt);
                entity.Property(e => e.PasswordHash);
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.IsBlocked);
                entity.Property(e => e.IsSafety);
                entity.HasOne(e=>e.Gender).WithOne(e=>e!.User).HasForeignKey<User>(e=>e.GenderId);
                entity.HasMany(e => e.Vaccines).WithMany(e => e!.Users).UsingEntity(e => e.ToTable("UserVaccine"));
            });
            modelBuilder.Entity<OperationClaim>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.OpenAddress1);
                entity.Property(e => e.OpenAddress2);
                entity.HasOne(e=>e.District).WithMany(e=>e!.Addresses).HasForeignKey(e=>e.DistrictId);
                entity.HasOne(e=>e.Area).WithMany(e=>e!.Address).HasForeignKey(e=>e.AreaId);
            });
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.HasOne(e=>e.Region).WithMany(e=>e!.Cities).HasForeignKey(e=>e.RegionId);
            });
            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.HasOne(e=>e.City).WithMany(e=>e!.Districts).HasForeignKey(e=>e.CityId);
            });
             modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
              modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e=> e.IsSafety);
                entity.HasOne(e=> e.AreaType).WithMany(e=>e!.Areas).HasForeignKey(e=>e.AreaTypeId);
            });
              modelBuilder.Entity<AreaType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
              modelBuilder.Entity<QRCode>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description).IsRequired();
                entity.HasOne(e=>e.User).WithMany(e=>e.QRCodes).HasForeignKey(e=>e.UserId);
            });
              modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
            modelBuilder.Entity<Vaccine>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Description);
                entity.HasOne(e => e.VaccineType).WithMany(e => e.Vaccines).HasForeignKey(e => e.VaccineTypeId);
            });
            modelBuilder.Entity<VaccineType>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
        }
    }
}

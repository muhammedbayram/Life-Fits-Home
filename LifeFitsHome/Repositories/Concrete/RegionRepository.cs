using LifeFitsHome.Contexts;
using LifeFitsHome.Model.Entity;
using LifeFitsHome.Repositories.Base;
using LifeFitsHome.Repositories.Interfaces;

namespace LifeFitsHome.Repositories.Concrete
{
    public class RegionRepository : EfEntityRepositoryBase<Region, DbContextBase>, IRegionRepository
    {
        public List<Region> GetRegion(Region regions)
        {
            using (var context = new DbContextBase())
        {
         var result=from region in context.Regions
         join city in context.Cities
         on region.Id equals city.RegionId
         select new Region();
         return result.ToList();
        }
        
        }
    }
}

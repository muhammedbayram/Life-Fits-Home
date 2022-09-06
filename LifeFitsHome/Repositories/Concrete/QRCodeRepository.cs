using LifeFitsHome.Contexts;
using LifeFitsHome.Repositories.Base;
using LifeFitsHome.Repositories.Interfaces;

namespace LifeFitsHome.Repositories.Concrete
{
    public class QRCodeRepository : EfEntityRepositoryBase <QRCode, DbContextBase>, IQRCodeRepository
    {
    }
}

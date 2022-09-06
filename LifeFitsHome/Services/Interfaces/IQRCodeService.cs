using LifeFitsHome.Services.Base;
using LifeFitsHome.Utilities.Results;

namespace LifeFitsHome.Services.Interfaces
{
    public interface IQRCodeService : IServiceBase<QRCode>
    {
        IDataResult <QRCode> GetQRCodeById(int qrCodeId);
        IDataResult <List<QRCode>> GetAllQRCode();
        IDataResult <List<QRCode>> GetAllQRCodeByUser(int userId);
    }
}

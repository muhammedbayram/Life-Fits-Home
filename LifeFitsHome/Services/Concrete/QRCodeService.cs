using LifeFitsHome.Repositories.Interfaces;
using LifeFitsHome.Services.Interfaces;
using LifeFitsHome.Utilities.Results;
using IResult = LifeFitsHome.Utilities.Results.IResult;

namespace LifeFitsHome.Services.Concrete
{
    public class QRCodeService : IQRCodeService
    {
        private IQRCodeRepository _qRCodeRepository;

        public QRCodeService(IQRCodeRepository qRCodeRepository)
        {
            _qRCodeRepository = qRCodeRepository;
        }

        public IResult Add(QRCode entity)
        {
           var FindedQRCode = _qRCodeRepository.Get(e=>e.Id == entity.Id);
            if (FindedQRCode == null)
            {
                _qRCodeRepository.Add(entity);
                return new SuccessResult("QR Code Ekleme başarılı.");
            }
            return new ErrorResult("Eklenmeye çalışılan QR Code zaten mevcut.");
        }

        public IResult Delete(QRCode entity)
        {
            var FindedQRCode = _qRCodeRepository.Get(e => e.Id == entity.Id);
            if (FindedQRCode != null)
            {
                _qRCodeRepository.Delete(entity);
                return new SuccessResult("QR Code silme başarılı.");
            }
            return new ErrorResult("Silinmeye çalışılan QR Code mevcut değildir.");
        }

        public IDataResult<List<QRCode>> GetAllQRCode()
        {
           return new SuccessDataResult<List<QRCode>>(_qRCodeRepository.GetAll());
        }

        public IDataResult<List<QRCode>> GetAllQRCodeByUser(int userId)
        {
            return new SuccessDataResult<List<QRCode>>(_qRCodeRepository.GetAll(e=>e.UserId == userId));
        }

        public IDataResult<QRCode> GetQRCodeById(int qrCodeId)
        {
            var FindedQRCode = _qRCodeRepository.Get(e => e.Id == qrCodeId);
            if (FindedQRCode != null)
            {
                return new SuccessDataResult<QRCode>(FindedQRCode, "QR Code getirildi.");
            }
            return new ErrorDataResult<QRCode>(FindedQRCode, "Böyle bir QR code mevcut değildir.");
        }

        public IResult Update(QRCode entity)
        {
            var FindedQRCode = _qRCodeRepository.Get(e => e.Id == entity.Id);
            if (FindedQRCode == null)
            {
                return new ErrorResult("Güncellenecek QR Code bulunamadı.");
            }
            _qRCodeRepository.Update(entity);
            return new SuccessDataResult<QRCode>("QRCode güncelleme başarılı.");
        }
    }
}

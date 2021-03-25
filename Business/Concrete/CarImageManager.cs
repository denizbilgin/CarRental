using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager:ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimit(carImage.CarId),CheckIfImageExtensionValid(file));
            if (result != null)
            {
                return result;
            }
            var path = FileHelper.Add(file);
            carImage.ImagePath = path;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            string path = GetById(carImage.Id).Data.ImagePath;
            IResult result = BusinessRules.Run(CheckIfImageExists(carImage.Id),CheckIfImageCanDelete(path));
            if (result != null)
            {
                return result;
            }
            FileHelper.Delete(path);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);

        }

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(),Messages.CarImagesListed);
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimit(carImage.CarId),CheckIfImageExtensionValid(file),CheckIfImageExists(carImage.Id));
            if (result != null)
            {
                return result;
            }
            carImage.Date = DateTime.Now;
            string oldPath = GetById(carImage.Id).Data.ImagePath;
            carImage.ImagePath = FileHelper.Update(file, oldPath);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id).Data);
        }

        private IResult CheckIfImageLimit(int carId)
        {
            var carImageCount = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (carImageCount >= 5)
            {
                return new ErrorResult(Messages.ImageLimitExceeded);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNull(int carId)
        {
            string path ="default1.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                List<CarImage> carimage = new List<CarImage>();
                carimage.Add(new CarImage
                {
                    CarId=carId,
                    Date=DateTime.Now,
                    ImagePath=path
                });
                return new SuccessDataResult<List<CarImage>>(carimage);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId).ToList());
        }

        private IResult CheckIfImageExtensionValid(IFormFile file)
        {
            bool IsValidFileExtension = Messages.ValidImageFileTypes.Any(t => t == Path.GetExtension(file.FileName).ToUpper());
            if (!IsValidFileExtension)
            {
                return new ErrorResult(Messages.InvalidImageExtension);
            }
            return new SuccessResult();
        }

        private IResult CheckIfImageExists(int id)
        {
            if (_carImageDal.IsExists(id))
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarImageMustBeExists);
        }

        private IResult CheckIfImageCanDelete(string path)
        {
            if (File.Exists(path) && Path.GetFileName(path) != @"\WebAPI\wwwroot\Images\default1.jpg")
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.FileCannotDelete);
        }
    }

}

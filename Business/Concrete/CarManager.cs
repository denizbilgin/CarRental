using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheRemoveAspect("ICarService.Get")]
        //[SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        //[SecuredOperation("admin,user")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        //[SecuredOperation("admin,user")]
        [PerformanceAspect(3)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        //[SecuredOperation("admin,user")]
        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarDetailsDto>>GetCarDetail(int id)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsDetails(c => c.Id == id));
        }

        //[SecuredOperation("admin,user")]
        public IDataResult<List<CarDetailsDto>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsDetails(c => c.BrandId == id));
        }

        public IDataResult<List<CarDetailsDto>> GetCarsByBrandIdAndColorId(int brandId, int colorId)
        {
            List<CarDetailsDto> carDetails = _carDal.GetCarsDetails(c => c.BrandId == brandId && c.ColorId == colorId);
            if(carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailsDto>>(Messages.CarNotFound);
            }
            else
            {
                return new SuccessDataResult<List<CarDetailsDto>>(carDetails);
            }
        }

        //[SecuredOperation("admin,user")]
        public IDataResult<List<CarDetailsDto>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsDetails(c => c.ColorId == id));
        }

        [PerformanceAspect(3)]
        //[SecuredOperation("admin,user")]
        public IDataResult<List<CarDetailsDto>> GetCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarsDetails());
        }

        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin,user")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}

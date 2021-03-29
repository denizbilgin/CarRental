using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
        IDataResult<List<CarDetailsDto>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailsDto>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailsDto>> GetCarDetail(int carId);
        IDataResult<List<CarDetailsDto>> GetCarsDetails();
        IDataResult<List<CarDetailsDto>> GetCarsByBrandIdAndColorId(int brandId, int colorId);
        IDataResult<Car> GetCarMinFindex(int carId);
    }
}

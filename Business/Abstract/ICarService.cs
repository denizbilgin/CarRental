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
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<CarDetailsDto>> GetCarsByBrandId(int id);
        IDataResult<List<CarDetailsDto>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailsDto>> GetCarDetail(int id);
        IDataResult<List<CarDetailsDto>> GetCarsDetails();
    }
}

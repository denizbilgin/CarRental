using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=500,Description="birinci araç açıklaması",ModelYear=2014},
                new Car{Id=2,BrandId=1,ColorId=2,DailyPrice=700,Description="ikinci araç açıklaması",ModelYear=2008},
                new Car{Id=3,BrandId=2,ColorId=3,DailyPrice=200,Description="üçüncü araç açıklaması",ModelYear=2020},
                new Car{Id=4,BrandId=3,ColorId=4,DailyPrice=1000,Description="dördüncü araç açıklaması",ModelYear=2014},
                new Car{Id=5,BrandId=4,ColorId=4,DailyPrice=350,Description="beşinci araç açıklaması",ModelYear=2018}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public List<CarDetailsDto> GetCarsDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDto> GetCarsDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}

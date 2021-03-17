using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarsDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands on c.BrandId equals b.Id
                             join co in context.Colors on c.ColorId equals co.Id
                             select new CarDetailsDto
                             {
                                 CarId=c.Id,
                                 BrandName=b.BrandName,
                                 ColorName=co.ColorName,
                                 ModelYear=c.ModelYear,
                                 DailyPrice=c.DailyPrice,
                                 Description=c.Description,
                                 ImagePath=context.CarImages.Where(x => x.CarId == c.Id).FirstOrDefault().ImagePath
                             };
                return result.ToList();
            }
        }
    }
}

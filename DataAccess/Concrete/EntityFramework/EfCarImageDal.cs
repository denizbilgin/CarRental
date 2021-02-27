using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, CarRentalContext>, ICarImageDal
    {
        public bool IsExists(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.CarImages.Any(c => c.Id == id);
            }
        }
    }
}

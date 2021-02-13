using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalsDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in filter==null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars on r.CarId equals c.Id
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join u in context.Users on cu.UserId equals u.Id
                             select new RentalDetailsDto
                             {
                                 FirstName=u.FirstName,
                                 CompanyName=cu.CompanyName,
                                 CarId=c.Id,
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate
                             };
                return result.ToList();

            }
        }
    }
}

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsolUI
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalsDetails();
            foreach (var rental in result.Data)
            {
                Console.WriteLine(rental.CarId + " " + rental.FirstName + " " + rental.CompanyName + " " + rental.RentDate + " " + rental.ReturnDate);
            }
            Console.WriteLine(result.Message);
        }
    }
}

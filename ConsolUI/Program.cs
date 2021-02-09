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
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car  in carManager.GetCarsDetails())
            {
                Console.WriteLine("{0} / {1} / {2} / {3} / {4}",car.Id,car.BrandName,car.ColorName,car.DailyPrice,car.Description);
            }
        }
    }
}

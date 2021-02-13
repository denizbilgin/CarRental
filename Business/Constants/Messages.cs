using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //About Car
        public static string CarAdded = "Araba eklendi.";
        public static string CarDailyPriceError = "Lütfen günlük kiralama bedeli 0'dan büyük bir sayı giriniz.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarsListed = "Arabalar listelendi.";
        public static string CarUpdated = "Araba güncellendi.";

        //About Brand
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandNameError = "Araba ismi uzunluğu 2'den büyük olmalıdır.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka güncellendi.";

        //About Color
        public static string ColorAdded = "Renk eklendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi.";

        //About Customer
        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomersListed = "Müşteriler listelendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";

        //About Rental
        public static string RentalAdded = "Kira eklendi.";
        public static string RentalsListed = "Kiralar listelendi.";
        public static string RentalDeleted = "Kira silindi.";
        public static string RentalUpdated = "Kira güncellendi.";
        public static string RentalAddError = "Kira eklenemedi.";

        //About User
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UsersListed = "Kullanıcılar listelendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
    }
}

using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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

        //About CarImage
        public static string CarImageAdded = "Araba resmi Eklendi";
        public static string CarImagesListed = "Araba resimleri listelendi.";
        public static string CarImageDeleted = "Araba resmi silindi.";
        public static string CarImageUpdated = "Araba resmi güncellendi.";
        public static string ImageLimitExceeded = "Bir arabanın maksimum 5 resmi olabilir";
        public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };
        public static string InvalidImageExtension = "Geçersiz resim uzantısı";
        public static string CarImageMustBeExists = "Böyle bir resim bulunamamaktadır.";
        public static string FileCannotDelete = "Dosya silinemez. Silmek istediğiniz dosya bulunamamaktadır.";

        //Auth
        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string AccessTokenCreated { get; internal set; }
        public static string UserAlreadyExists { get; internal set; }
        public static string SuccessfulLogin { get; internal set; }
        public static User PasswordError { get; internal set; }
        public static User UserNotFound { get; internal set; }
        public static string UserRegistered { get; internal set; }
    }
}

using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //Product
        public static string ProductAdded = "Ürün ekleme işlemi başarılı";
        public static string ProductDeleted = "Ürün silme işlemi başarılı";
        public static string ProductUpdated = "Ürün güncelleme işlemi başarılı";
        public static string ProductFiltered = "Ürün filtreleme işlemi başarılı";
        public static string AuthorizationDenied="Yetkiniz Yok!";

        public static string UserNotFound = "Kullanıcı Bulunamadı";

        public static string WrongPassword = "Hatalı Şifre";

        public static string UserRegistered = " Başarılı... Hoşgeldiniz!";

        public static string UserExists = "Sistemde Böyle Bir Kullanıcı Vardır";

        public static string LoginForUser = "Hoşgeldiniz...";

        //Category
        public static string CategoryAdded = "Kategori Ekleme İşlemi Başarılı..";

        public static string CategoryDeleted = "Kategori Silme İşlemi Başarılı";

        public static string CategoryUpdated = "Kategori Güncelleme İşlemi Başarılı";
        //Customer
        public static string CustomerAdded = "Müşteri Ekleme İşlemi Başarılı";
        public static string CustomerDeleted = " Müşteri Silme İşlemi Başarılı";
        public static string CustomerUpdated = "Müşteri Güncelleme İşlemi Başarılı";
        public static string NationalIdExists = "Sistemde Böyle bir TC-No Vardır";
        public static string RealNationalIdExists = "Hatalı TC-No. Lütfen Tekrar Deneyiniz";
    }
}

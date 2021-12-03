using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Utilities
{
    public static class Messages
    {
        public static class Category
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir kategori bulunamadı.";
                return "Böyle bir kategori bulunamadı.";
            }
            public static string NotFoundById(int categoryID)
            {
                return $"{categoryID} kategori koduna ait bir kategori bulunamadı.";
            }
            public static string AddAsync(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla eklenmiştir.";
            }
            public static string UpdateAsync(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla güncellenmiştir.";
            }
            public static string DeleteAsync(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla silinmiştir.";
            }
            public static string HardDeleteAsync(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla arşivden getirilmiştir.";
            }
        }
        public static class Product
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir makale bulunamadı.";
                return "Böyle bir makale bulunamadı.";
            }
            public static string NotFoundById(int productId)
            {
                return $"{productId} makale koduna ait bir makale bulunamadı.";
            }
            public static string AddAsync(string productName)
            {
                return $"{productName} adlı ürün başarıyla eklenmiştir.";
            }
            public static string UpdateAsync(string productName)
            {
                return $"{productName} adlı ürün başarıyla güncellenmiştir.";
            }
            public static string DeleteAsync(string productName)
            {
                return $"{productName} adlı ürün başarıyla silinmiştir.";
            }
            public static string HardDeleteAsync(string productName)
            {
                return $"{productName} adlı ürün başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string productName)
            {
                return $"{productName} adlı ürün başarıyla arşivden geri getirilmiştir";
            }
            
        }
    }
}

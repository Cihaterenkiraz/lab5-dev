using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    public class DosyaYuklemeController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> YukeDosya(IFormFile file, string ad, string soyad)
        {
            if (file == null || file.Length == 0)
                return Content("Dosya Seçilmedi");

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "Dosyalar",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Dosya yükleme işlemi başarılı, burada diğer form alanlarından gelen bilgileri işleyebilirsiniz.
            // Örnek olarak, burada gelen ad ve soyad bilgilerini bir loga kaydedebiliriz.
            LogKaydet(ad, soyad);

            return RedirectToAction("Index");
        }

        private void LogKaydet(string ad, string soyad)
        {
            // Loglama işlemleri burada yapılabilir.
            // Örneğin:
            // ILogger logger = new Logger();
            // logger.Log($"{ad} {soyad} adlı kullanıcı dosya yükleme işlemi gerçekleştirdi.");
        }
    }
}


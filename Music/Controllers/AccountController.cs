using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Music.Models;
using System.Text.Json; // JSON işlemleri için

namespace Music.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // --- YARDIMCI METOT: ROBOT KONTROLÜ (reCAPTCHA) ---
        private async Task<bool> GoogleCaptchaDogrula()
        {
            try
            {
                var captchaResponse = Request.Form["g-recaptcha-response"];

                // Eğer kutucuk boşsa
                if (string.IsNullOrEmpty(captchaResponse))
                    return false;

                using (var client = new HttpClient())
                {
                    // İnternet yavaşsa bekleme süresi (5 saniye)
                    client.Timeout = TimeSpan.FromSeconds(3);

                    
                    var secretKey = "6LdTHyEsAAAAACMIKZqCFf9CQA5l5kjqa2JyNZED";

                    var response = await client.GetStringAsync($"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={captchaResponse}");

                    if (response.Contains("\"success\": true"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                // İnternet yoksa veya Google hata verirse geliştirmeye devam edebilmek için:
                return true;
            }
            return false;
        }

       
        // 1. KAYIT OLMA (REGISTER)
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string password, int age)
        {
            // 1. Robot Kontrolü
            if (!await GoogleCaptchaDogrula())
            {
                ModelState.AddModelError("", "Lütfen robot olmadığınızı doğrulayın.");
                return View();
            }

            // 2. Kullanıcı Oluşturma
            var user = new AppUser
            {
                UserName = email,
                Email = email,
                Age = age 
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                // Başarılıysa giriş yap ve anasayfaya git
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            // Hata varsa (Örn: Şifre çok kısa)
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }

        // 2. GİRİŞ YAPMA (LOGIN)
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            // 1. Robot Kontrolü
            if (!await GoogleCaptchaDogrula())
            {
                ModelState.AddModelError("", "Lütfen robot olmadığınızı doğrulayın.");
                return View();
            }

            // 2. Giriş Kontrolü
            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Email veya şifre hatalı.");
            return View();
        }

        // 3. ÇIKIŞ YAPMA (LOGOUT)
        
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
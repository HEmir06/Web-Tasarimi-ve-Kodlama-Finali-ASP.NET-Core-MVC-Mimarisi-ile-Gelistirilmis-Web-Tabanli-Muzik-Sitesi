# 🎵 MusicApp - Modern Web Müzik Platformu
<div align="center">
  <img src="https://user-images.githubusercontent.com/74038190/212284100-561aa473-3905-4a80-b561-0d28506553ee.gif" width="100%" height="60" />
</div>

<div align="center">
  <img src="https://img.shields.io/badge/.NET_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/Bootstrap_5-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white" />
  <img src="https://img.shields.io/badge/Entity_Framework-EF-green?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/JQuery_AJAX-0769AD?style=for-the-badge&logo=jquery&logoColor=white" />
  <img src="https://img.shields.io/badge/CSS3_Animations-1572B6?style=for-the-badge&logo=css3&logoColor=white" />
  <img src="https://img.shields.io/badge/Security-Identity-red?style=for-the-badge&logo=security&logoColor=white" />
</div>

<br />

<div align="center">
  <img src="https://readme-typing-svg.herokuapp.com?font=Fira+Code&weight=600&size=25&pause=1000&color=F08C00&center=true&vCenter=true&width=500&lines=MusicApp:+Kendi+Ritmini+Yakala;URL+ile+Müzik+Ekle;Kesintisiz+Müzik+Deneyimi;Web+Tasarımı+ve+Kodlama+Projesi" alt="Typing SVG" />
</div>

**Web Tasarımı ve Kodlama** dersi final projesi olarak geliştirilmiş; kullanıcıların kesintisiz müzik dinleyebileceği, dinamik listeler oluşturabileceği ve AJAX altyapısı sayesinde sayfa yenilenmeden etkileşime girebileceği modern bir web uygulamasıdır.
## 📸 Proje Galerisi

> **Not:** Projenin tüm ekran görüntüleri aşağıdadır.

| 1. Ana Sayfa | 2. Ana Sayfa(Dark Mode)| 3. Giriş Ekranı |
| :---: | :---: | :---: |
| <img width="1254" height="860" alt="Ekran görüntüsü 2025-12-17 212635" src="https://github.com/user-attachments/assets/b3495d41-35ec-4bf8-9d05-bd2b23b7aa17" />
) | <img width="1421" height="863" alt="Ekran görüntüsü 2025-12-17 212622" src="https://github.com/user-attachments/assets/5ad18eb6-28a6-4902-bbcf-1f72252d97a1" />
) | <img width="828" height="460" alt="Ekran görüntüsü 2025-12-17 212654" src="https://github.com/user-attachments/assets/ed9921fe-9f45-4639-9e9f-6f20b93871f6" />
) |

| 4. Kayıt Ekranı  | 5. Şarkı Detayı | 6. Yorumlar |
| :---: | :---: | :---: |
| <img width="567" height="497" alt="Ekran görüntüsü 2025-12-17 212702" src="https://github.com/user-attachments/assets/beadedc5-adf7-4a9a-ad99-014606293b14" />
) |<img width="1884" height="908" alt="Ekran görüntüsü 2025-12-17 222748" src="https://github.com/user-attachments/assets/b566706a-f404-47a8-9f98-688a8b515677" />
) | <img width="1447" height="682" alt="Ekran görüntüsü 2025-12-17 212828" src="https://github.com/user-attachments/assets/207be321-c21b-4639-8fef-276b19a5ff8b" />
) |

| 7. Playlist | 8. Playlistler İçi | 9. Playlist İçi (Dark Mode) |
| :---: | :---: | :---: |
| <img width="1298" height="505" alt="Ekran görüntüsü 2025-12-17 212736" src="https://github.com/user-attachments/assets/b38bd98e-83c8-4ff8-a89a-5110bd186cf5" />
) | <img width="1365" height="463" alt="Ekran görüntüsü 2025-12-17 212730" src="https://github.com/user-attachments/assets/8e74b06e-d731-49ac-af68-005a3c93f117" />
) | <img width="1361" height="676" alt="Ekran görüntüsü 2025-12-17 212759" src="https://github.com/user-attachments/assets/a5c918ff-71b8-48d2-9144-faebb75fe444" />
) |

<br />
<img src="https://user-images.githubusercontent.com/73097560/115834477-dbab4500-a447-11eb-908a-139a6edaec5c.gif" width="100%">
<br />



## 🌟 Temel Özellikler

Bu proje, kullanıcı deneyimini (UX) en üst düzeye çıkarmak için dinamik teknolojilerle donatılmıştır:

### 🔐 Güvenlik ve Üyelik Sistemi (Identity)
* **ASP.NET Core Identity:** Microsoft'un standart üyelik kütüphanesi kullanılarak güvenli **Giriş (Login)**, **Kayıt Ol (Register)** ve **Çıkış (Logout)** işlemleri.
* **CSRF Koruması:** Form işlemlerinde sahteciliği önlemek için `[ValidateAntiForgeryToken]` önlemleri alınmıştır.
* **Yetkilendirme:** Sadece giriş yapmış kullanıcılar müzik ekleyebilir veya playlist oluşturabilir.

### ⚡ AJAX ve Dinamik Altyapı
* **Sayfa Yenilenmeden İşlem:** Müzik Arama işlemi **AJAX** teknolojisi kullanılarak arka planda gerçekleştirilir. Bu sayede kullanıcı deneyimi kesintiye uğramaz.
* **Hızlı ve Akıcı:** Gereksiz sayfa yüklemeleri engellenerek uygulamanın performansı artırılmıştır.

### 🎧 Kesintisiz Müzik Deneyimi
* **Yapışkan (Sticky) Player:** Sayfanın altında sabit duran oynatıcı sayesinde, kullanıcılar sitede gezinirken müzik asla kesilmez.
* **Otomatik Geçiş:** Şarkı bittiğinde sistem otomatik olarak listedeki bir sonraki şarkıyı algılar ve oynatır.

### 🎨 Modern UI/UX Tasarım
* **Özel Scrollbar Tasarımı:** Tarayıcının standart kaydırma çubuğu yerine, sitenin temasıyla (Turuncu/Siyah) uyumlu, yuvarlatılmış hatlara sahip **Custom CSS Scrollbar** entegre edilmiştir.
* **Dark / Light Mode:** Kullanıcının tercihine göre anlık olarak değişen tema desteği.
* **3D Kart Efektleri:** Müzik kartlarında fare hareketine duyarlı 3D derinlik efekti (VanillaTilt.js).
* **Canlı Ekolayzer (Visualizer):** Navbar üzerinde yer alan, saf CSS (Keyframes) ile kodlanmış ve müzik ritmini simüle eden hareketli ekolayzer animasyonu.
* **Rainbow Arka Plan:** Sayfanın arka planında sürekli renk değiştiren ve yumuşak geçişler yapan (Rainbow Effect) dev müzik notası animasyonu.

### 🔗 Kütüphane ve URL Yönetimi
* **URL ile Müzik Ekleme:** Kullanıcılar, internet üzerindeki `.mp3` bağlantılarını (örn: SoundHelix linkleri) sisteme yapıştırarak veritabanına şarkı ekleyebilirler.
* **Kişisel Playlistler:** Kullanıcı bazlı özelleştirilebilir çalma listeleri.

<br />
<img src="https://user-images.githubusercontent.com/73097560/115834477-dbab4500-a447-11eb-908a-139a6edaec5c.gif" width="100%">
<br />



## 🛠️ Kullanılan Teknolojiler <img src="https://media.giphy.com/media/WUlplcMpOCEmTGBtBW/giphy.gif" width="30">

Proje, modern web standartlarına uygun olarak geliştirilmiştir:

| Kategori | Teknolojiler |
| :--- | :--- |
| **Backend** | C#, ASP.NET Core 6.0 MVC |
| **Güvenlik** | **ASP.NET Core Identity**, CSRF Protection |
| **Veritabanı** | MSSQL, Entity Framework Core (Code First) |
| **Frontend** | HTML5, CSS3 (**Keyframes & Animations**), JavaScript (ES6+) |
| **Depolama** | **Local Storage** (Tema Ayarları İçin) |
| **Tasarım** | Bootstrap 5, Custom CSS |
| **Kütüphaneler** | **SweetAlert2** (JS Bildirimleri), **VanillaTilt.js** (3D Efekt) |

---

## 📁 Proje Klasör Yapısı

```text
Music/
│
├── Controllers/
│   ├── AccountController.cs   # Kullanıcı (Giriş/Kayıt) işlemleri
│   ├── CommentsController.cs  # Yorum yönetimi
│   ├── FavoritesController.cs # Favorileme işlemleri
│   ├── HomeController.cs      # Ana sayfa ve genel akış
│   ├── PlaylistsController.cs # Playlist CRUD işlemleri
│   └── SongsController.cs     # Şarkı yönetimi
│
├── Data/
│   └── MusicAppDbContext.cs   # Entity Framework Context
│
├── Models/
│   └── (Veritabanı Tablo Karşılıkları: Song, Genre, Playlist vb.)
│
├── Views/
│   ├── Home/
│   ├── Shared/ (_Layout ve Partial View'lar)
│   └── (Diğer Razor View klasörleri)
│
├── wwwroot/
│   ├── css/     # Site.css ve özel stiller
│   ├── js/      # Player mantığı ve AJAX kodları
│   └── images/  # Statik görseller
│
├── Program.cs   # Dependency Injection ve Middleware ayarları
└── Music.csproj
```
<br />
<img src="https://user-images.githubusercontent.com/73097560/115834477-dbab4500-a447-11eb-908a-139a6edaec5c.gif" width="100%">
<br />

<div align="center">
  <img src="https://skillicons.dev/icons?i=cs,dotnet,html,css,js,bootstrap,jquery,github&perline=9" />
</div>
<br>
 
👨‍💻 Geliştirici

<p>
    Bu proje <strong>Hüseyin Emir Gölemen</strong> tarafından <br />
    <strong>Kastamonu Üniversitesi - Web Tasarımı ve Kodlama</strong> dersi final projesi kapsamında geliştirilmiştir.
</p>

<a href="https://github.com/HEmir06">
    <img src="https://img.shields.io/badge/GitHub-HEmir06-181717?style=for-the-badge&logo=github&logoColor=white" alt="GitHub">
</a>
</div>


<div align="center">
  <img src="https://github-readme-stats.vercel.app/api?username=HEmir06&show_icons=true&theme=dark&hide_border=true&bg_color=00000000" />
</div>

<div align="center">
  <img src="https://github-readme-stats.vercel.app/api/top-langs/?username=HEmir06&layout=compact&theme=dark&hide_border=true&bg_color=00000000&langs_count=6" />
</div>

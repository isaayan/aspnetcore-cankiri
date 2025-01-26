using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using project.Data.Concrete.EfCore;
using project.Entity;

namespace project.Data.Concrete.EfCore
{
    public class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();
            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "admin", Name = "admin", Email = "info@admin.com", Password = "admin1", Image = "p1.jpg", Role = "admin", UserId=1 },
                        new User { UserName = "isaayan", Name = "isa ayan", Email = "info@isaayan.com", Password = "isa123", Image = "p2.jpg", Role = "admin", UserId=2 }
                    );
                    context.SaveChanges();
                }

               

                if (!context.History.Any())
                {
                    context.History.AddRange(
                        new History
                        {
                            HistoryId = 1,
                            Title = "Ilgaz Dağı Milli Parkı",
                            Description = "Türkiye’nin en güzel milli parklarından biri olan Ilgaz Dağı Milli Parkı, Çankırı ve Kastamonu arasında yer alır. Doğal güzellikleri, zengin flora ve faunasıyla her yıl binlerce ziyaretçiyi ağırlıyor.",
                            Content = "Ilgaz Dağı Milli Parkı, yaz aylarında doğa yürüyüşleri, kamp ve piknik alanlarıyla dikkat çekerken, kış aylarında kayak merkezi olarak hizmet verir. Dağ, çam ormanlarıyla kaplıdır ve çeşitli kuş türlerine ev sahipliği yapar. Ayrıca milli parkta, fotoğraf tutkunları için muhteşem manzaralar bulunur. Ziyaretçiler, tertemiz havasıyla rahatlayabilir ve doğal güzelliklerin tadını çıkarabilirler.",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            UserId = 2
                        },
                        new History
                        {
                            HistoryId = 2,
                            Title = "Tarihi Çamaşırhane (Çivitçioğlu Medresesi)",
                            Description = "Çankırı’nın merkezinde yer alan bu tarihi yapı, Osmanlı dönemine ait çamaşırhane olarak kullanılmıştır. Restore edilerek kültürel bir mekan haline getirilmiştir.",
                            Content = "17. yüzyıldan kalma Çamaşırhane, mimari açıdan Osmanlı’nın estetik anlayışını yansıtır. Günümüzde çeşitli sergilere ve etkinliklere ev sahipliği yapmaktadır. Ayrıca, içindeki el işi atölyelerinde geleneksel Çankırı el sanatları tanıtılmaktadır. Ziyaretçiler burada Osmanlı dönemine ait bir çamaşırhanenin çalışma prensiplerini öğrenirken aynı zamanda Çankırı'nın kültürel mirasını keşfetme fırsatı bulurlar.",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            UserId = 2
                        },
                        new History
                        {
                            HistoryId = 3,
                            Title = "Taş Mescit ve Şifahane",
                            Description = "Anadolu Selçuklu dönemine ait olan bu yapı, hem bir mescit hem de bir şifahane (hastane) olarak kullanılmıştır. Çankırı'nın tarihi merkezinde yer alır.",
                            Content = "13. yüzyılda yaptırılan Taş Mescit, kesme taşlardan yapılmış etkileyici bir mimariye sahiptir. Şifahane kısmı, özellikle tıp alanında Selçuklu dönemi çalışmalarını yansıtan bir yapıdır. Günümüzde bu yapı, çeşitli kültürel etkinliklere ve sergilere ev sahipliği yapmaktadır. Tarih ve mimariye ilgi duyan ziyaretçiler için mutlaka görülmesi gereken yerlerden biridir.",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            UserId = 2
                        },
                        new History
                        {
                            HistoryId = 4,
                            Title = "Büyük Cami (Ulu Cami)",
                            Description = "Çankırı’nın en eski camilerinden biri olan Ulu Cami, Osmanlı dönemine ait bir eserdir. Mimari açıdan zarif ve tarihi dokusuyla dikkat çeker.",
                            Content = "16. yüzyılda yaptırılan Ulu Cami, özellikle ahşap süslemeleri ve kemerli yapısıyla öne çıkar. Cami, Çankırı’nın manevi atmosferini hissedebileceğiniz önemli ibadet yerlerinden biridir. Günümüzde de aktif olarak ibadet amacıyla kullanılmaktadır. Ayrıca caminin avlusu, sessiz ve huzurlu bir ortam sunar.",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            UserId = 2
                        },
                        new History
                        {
                            HistoryId = 5,
                            Title = "Çavundur Kaplıcaları",
                            Description = "Termal turizmiyle ünlü olan Çavundur Kaplıcaları, şifalı suları ve modern tesisleriyle ziyaretçilerin ilgisini çeker.",
                            Content = "Çankırı’nın Kurşunlu ilçesinde yer alan Çavundur Kaplıcaları, romatizma, cilt hastalıkları ve kas ağrıları gibi rahatsızlıklara iyi geldiği bilinen termal sularıyla ünlüdür. Kaplıca bölgesinde konaklama imkanı sunan oteller ve sağlık tesisleri bulunmaktadır. Sağlık turizmi için ideal olan bu mekan, doğayla iç içe bir tatil fırsatı sunar.",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            UserId = 2
                        }
                    );
                    context.SaveChanges();
                }

                if (!context.News.Any())
                {
                    context.News.AddRange(
                        new News
                        {
                            NewsId = 1,
                            Title = "Çankırı'da Korkutan Deprem",
                            Description = "Çankırı'da meydana gelen deprem, vatandaşlar arasında paniğe neden oldu.",
                            Content = "Çankırı'da hissedilen deprem, kısa süreli paniğe yol açtı. Yetkililer, depremin merkez üssü ve şiddeti hakkında araştırmalarını sürdürüyor. İlk belirlemelere göre, can veya mal kaybı yaşanmadı.",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            UserId = 2
                        },
                        new News
                        {
                            NewsId = 2,
                            Title = "Çankırı FK'da Flaş Transferler",
                            Description = "Çankırı Futbol Kulübü, yeni sezon öncesi kadrosunu güçlendirmek için önemli transferler gerçekleştirdi.",
                            Content = "Çankırı FK, yeni sezona iddialı bir giriş yapmak amacıyla kadrosuna deneyimli oyuncular kattı. Kulüp yönetimi, transferlerin takıma büyük katkı sağlayacağını belirtti.",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            UserId = 2
                        },
                        new News
                        {
                            NewsId = 3,
                            Title = "Çankırı'da Uyuşturucu Operasyonu: 3 Gözaltı",
                            Description = "Çankırı'da düzenlenen uyuşturucu operasyonunda 3 kişi gözaltına alındı.",
                            Content = "Emniyet güçleri tarafından gerçekleştirilen operasyonda, şüpheli bir araçta yapılan aramada 582 sentetik ecza hapı ele geçirildi. Olayla ilgili 3 kişi gözaltına alındı ve soruşturma devam ediyor.",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            UserId = 2
                        },
                        new News
                        {
                            NewsId = 4,
                            Title = "Çankırı'da Trafiğe Kayıtlı Araç Sayısı 68 Bin 961'e Ulaştı",
                            Description = "Çankırı'da trafiğe kayıtlı araç sayısı artış göstererek 68 bin 961'e ulaştı.",
                            Content = "Türkiye İstatistik Kurumu verilerine göre, Çankırı'da trafiğe kayıtlı araç sayısı 68 bin 961 oldu. Bu araçların büyük çoğunluğunu otomobiller oluşturuyor. Yetkililer, artan araç sayısının trafik yoğunluğunu etkilediğini belirtiyor.",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            UserId = 2
                        },
                        new News
                        {
                            NewsId = 5,
                            Title = "Çankırı'da 'Narkoalan' Uygulamasıyla Suçlulara Kaçış Yok",
                            Description = "Çankırı'da narkotik suçlarla mücadele kapsamında 'Narkoalan' uygulaması başlatıldı.",
                            Content = "Emniyet Müdürlüğü ekipleri, uyuşturucu ile mücadele kapsamında 'Narkoalan' uygulamasıyla denetimlerini artırdı. Bu uygulama sayesinde, uyuşturucu satıcıları ve kullanıcılarına yönelik operasyonlar sıklaştırıldı.",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            UserId = 2
                        }
                    );
                    context.SaveChanges();
                }

                if (!context.Populations.Any())
                {
                    context.Populations.AddRange(
                        
                    
                        new Population
                        {
                            Id = 1,
                            Year = 2023,
                            GeneralPopulation = 205501,
                            MalePopulation = 103037,
                            FemalePopulation = 102464
                        },
                        new Population
                        {
                            Id = 2,
                            Year = 2022,
                            GeneralPopulation = 195766,
                            MalePopulation = 98614,
                            FemalePopulation = 97152
                        },
                        new Population
                        {
                            Id = 3,
                            Year = 2021,
                            GeneralPopulation = 196515,
                            MalePopulation = 99278,
                            FemalePopulation = 97237

                        },
                        new Population
                        {
                            Id = 4,
                            Year = 2020,
                            GeneralPopulation = 192428,
                            MalePopulation = 97065,
                            FemalePopulation = 95363
                        }


                    );
                    context.SaveChanges();
                }

                if (!context.Districts.Any())
                {
                    context.Districts.AddRange(
                        new District
                        {
                            Id = 1,
                            Name = "Atkaracalar"
                        },
                        new District
                        {
                            Id = 2,
                            Name = "Bayramören "
                        },
                        new District
                        {
                            Id = 3,
                            Name = "Eldivan"
                        }
                    );
                    context.SaveChanges();
                }

                if (!context.SliderImages.Any())
                {
                    context.SliderImages.AddRange(
                        new SliderImage
                        {
                            Id = 1,
                            ImagePath = "\\images\\tuz_magarasin-f.jpg",
                            IsActive = true
                        },
                        new SliderImage
                        {
                            Id = 2,
                            ImagePath = "/images/General_view_of_Çankırı.jpeg",
                            IsActive = true
                        },
                        new SliderImage
                        {
                            Id = 3,
                            ImagePath = "/images/x1080.jpeg",
                            IsActive = true
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
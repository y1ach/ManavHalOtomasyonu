using System;
using System.Collections;

namespace ManavOtomasyonu
{
    class Program
    {
        static ArrayList halUrunler = new ArrayList();
        static ArrayList halKilolar = new ArrayList();
        static ArrayList musteriUrunler = new ArrayList();

        static void Main(string[] args)
        {
            bool devam = true;
            while (devam)
            {
                HaldenUrunAl();
                Console.WriteLine("Başka bir arzunuz var mı? (evet/hayır)");
                string cevap = Console.ReadLine().ToLower();
                if (cevap == "hayır")
                {
                    Console.WriteLine("İyi günler! Manav kısmına geçiyoruz...");
                    devam = false;
                }
            }
            ManavIslemleri();
            MusteriUrunleriYazdir();

            Console.WriteLine("Afiyet olsun!");
        }
        static void HaldenUrunAl()
        {
            Console.WriteLine("HAL: Meyve mi Sebze mi almak istersiniz?");
            string secim = Console.ReadLine().ToLower();

            if (secim == "meyve")
            {
                Console.WriteLine("HAL: Elma, Armut, Muz, Çilek, Üzüm'den birini seçiniz:");
                string urun = Console.ReadLine().ToLower();

                Console.WriteLine("Kaç kilo almak istersiniz?");
                int kilo = Convert.ToInt32(Console.ReadLine());

                EkleVeyaGuncelle(urun, kilo);
            }
            else if (secim == "sebze")
            {
                Console.WriteLine("HAL: Patates, Domates, Soğan, Biber, Marul'dan birini seçiniz:");
                string urun = Console.ReadLine().ToLower();

                Console.WriteLine("Kaç kilo almak istersiniz?");
                int kilo = Convert.ToInt32(Console.ReadLine());

                EkleVeyaGuncelle(urun, kilo);
            }
            else
            {
                Console.WriteLine("Geçerli bir ürün seçmediniz.");
            }
        }

        static void EkleVeyaGuncelle(string urun, int kilo)
        {
            int index = halUrunler.IndexOf(urun); 

            if (index != -1) 
            {
                halKilolar[index] = (int)halKilolar[index] + kilo;
            }
            else
            {
                halUrunler.Add(urun);
                halKilolar.Add(kilo);
            }
        }
        static void ManavIslemleri()
        {
            bool devam = true;

            while (devam)
            {
                string secim;
                do
                {
                    Console.WriteLine("MANAV: Meyve mi Sebze mi almak istersiniz?");
                    secim = Console.ReadLine().ToLower();

                    if (secim != "meyve" && secim != "sebze")
                    {
                        Console.WriteLine("Geçerli bir seçim yapmadınız.");
                    }
                } while (secim != "meyve" && secim != "sebze");

                UrunleriListele();

                Console.WriteLine("Hangi ürünü almak istersiniz?");
                string urunSecimi = Console.ReadLine().ToLower();

                int index = halUrunler.IndexOf(urunSecimi); 

                if (index != -1) 
                {
                    Console.WriteLine("Kaç kilo almak istersiniz?");
                    int kilo = int.Parse(Console.ReadLine());

                    if ((int)halKilolar[index] >= kilo)
                    {
                        halKilolar[index] = (int)halKilolar[index] - kilo;
                        musteriUrunler.Add($"{urunSecimi} - {kilo} kilo");

                        if ((int)halKilolar[index] == 0)
                        {
                            halUrunler.RemoveAt(index); 
                            halKilolar.RemoveAt(index);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Yeterli {urunSecimi} yok, mevcut: {halKilolar[index]} kilo.");
                    }
                }
                else
                {
                    Console.WriteLine("Bu ürün mevcut değil.");
                }

                Console.WriteLine("Başka bir arzunuz var mı? (evet/hayır)");
                string cevap = Console.ReadLine().ToLower();
                if (cevap == "hayır")
                    devam = false;
            }
        }
        static void UrunleriListele()
        {
            Console.WriteLine("MANAV: Mevcut ürünler:");
            for (int i = 0; i < halUrunler.Count; i++)
            {
                Console.WriteLine($"{halUrunler[i]} - {halKilolar[i]} kilo");
            }
        }

        static void MusteriUrunleriYazdir()
        {
            Console.WriteLine("MÜŞTERİ: Aldığınız ürünler:");
            foreach (string urun in musteriUrunler)
            {
                Console.WriteLine(urun);
            }
        }
    }
}

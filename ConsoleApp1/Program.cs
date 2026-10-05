using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

class kayıt
{
    public string Aciklama 
    { get; set; } // açıklama alanı
    public decimal Tutar // tutar alanı
    { get; set; } 
    public string Tur // tür alanı
    { get; set; } 
    public string Kategori // kategori alanı
    { get; set; } 
}


class Program // program sınıfı
{
    static List<kayıt> kayıtlar = new List<kayıt>(); // kayıtları tutmak için bir liste
    static void Main(string[] args) // ana program
    {
        bool devam = true; // programın devam edip etmeyeceğini kontrol etmek için  bir değişken
        while (devam) 
        {
            //Console.Clear();
            Console.WriteLine("===== GELİR / GİDER TAKİP UYGULAMASI ====="); 
            Console.WriteLine("1 - gelir/ gider ekle"); 
            Console.WriteLine("2 - kayıtları listele"); 
            Console.WriteLine("3 - kayıt ara"); 
            Console.WriteLine("4 - kayıt sil"); 
            Console.WriteLine("5 - bakiye bilgisini göster"); 
            Console.WriteLine("6 - istatistikleri göster"); 
            Console.WriteLine("0 - çıkış");

            Console.WriteLine("seçimleriniz:"); 
            string secim =
                Console.ReadLine(); 
            Console.WriteLine("seçimleriniz: " + secim); 

            switch (secim) 

            {
                case "1":
                    kayitekle();
                    break; 
                case "2":
                    kayitleriListele(); 
                    break;
                case "3": 
                    kayitAra(); 
                    break; 
                case "4":
                    kayitSil();
                    break;
                case "5":
                    BakiyeyiGöster();
                    break;
                case "6":
                    İstatistikleriGoster();
                    break;
                case "0":
                    Console.WriteLine("çıkış yapılıyor...);" + secim); 
                    break;

                default: 
                    Console.WriteLine("geçersiz seçim;");
                    if (devam)
                    {
                        Console.WriteLine("\n devam etmek için ENTER'a basınız.");
                        Console.ReadLine();
                    }
                    break;
                    

            }

            static void kayitekle()
            {
                kayıt yeniKayıt = new kayıt(); 
                Console.Write("Aciklama :");
                yeniKayıt.Aciklama = Console.ReadLine(); 
                Console.Write("Tutar :"); 
                yeniKayıt.Tutar = Convert.ToDecimal(Console.ReadLine()); 
                Console.Write("tur (gelir/gider: ");
                yeniKayıt.Tur = Console.ReadLine();
                Console.Write("kategori :");
                yeniKayıt.Kategori = Console.ReadLine(); 
                kayıtlar.Add(yeniKayıt);
                Console.WriteLine("kayıt başarıyla eklendi.");
                Console.WriteLine("\n devam etmek için bir tuşa basınız.");
                Console.ReadLine();

            }
            static void kayitleriListele() 
            {
                Console.WriteLine("\n ===== KAYITLAR =====");
                Console.WriteLine("toplam kayıt sayısı:" + kayıtlar.Count); 

                if (kayıtlar.Count == 0) 
                {
                    Console.WriteLine("henüz kayıt bulunmuyor."); 


                    return; 
                }

                foreach (var kayıt in kayıtlar) 
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Açıklama: " + kayıt.Aciklama); 
                    Console.WriteLine("Tutar: " + kayıt.Tutar + "TL");
                    Console.WriteLine("tür: " + kayıt.Tur); 
                    Console.WriteLine("kategori : " + kayıt.Kategori); 
                }
                Console.WriteLine("\n devam etmek için bir tuşa basınız.");
                Console.ReadLine();
            }
            static void kayitAra() 
            {
                Console.Write("aramak istediğiniz kelime:"); 
                string aranan = Console.ReadLine(); 
                Console.WriteLine();
                bool bulundu = false; 
                foreach (kayıt kayıt in kayıtlar) 
                {
                    if (kayıt.Aciklama.ToLower().Contains(aranan.ToLower()) ||
                        kayıt.Kategori.ToLower().Contains(aranan.ToLower())) 
                    {
                        Console.WriteLine("---------------------");
                        Console.WriteLine("açıklama:" + kayıt.Aciklama); 
                        Console.WriteLine("Tutar:" + kayıt.Tutar + "TL"); 
                        Console.WriteLine("tür:" + kayıt.Tur); 
                        Console.WriteLine("kategori: " + kayıt.Kategori); 
                        bulundu = true; 
                    }
                    Console.WriteLine("\n devam etmek için bir tuşa basınız.");
                    Console.ReadLine();
                }
                if (bulundu) 
                {
                    Console.WriteLine("aradığınız kayıt bulundu."); 
                }
                else 
                {
                    Console.WriteLine("aradığınız kayıt bulunamadı");
                }
               
            }
            static void kayitSil()
            {
                Console.WriteLine("silmek istediğiniz kaydı seçin.");
                string aranan = Console.ReadLine();
                for (int i = 0; i < kayıtlar.Count; i++)
                {
                    string Aciklama = kayıtlar[i].Aciklama;
                    if (Aciklama == aranan)

                    {
                        kayıtlar.RemoveAt(i);
                        Console.WriteLine("kayıt bulundu");
                        return;
                    }
                   
                    
                        Console.WriteLine("kayıt başarıyla silindi!");


                    Console.WriteLine("\n devam etmek için bir tuşa basınız.");
                    Console.ReadLine();
                }
                
                
            }


            static void BakiyeyiGöster()
            {

                decimal toplamgider = 0; 
                decimal toplamgelir = 0;
                foreach (kayıt kayıt in kayıtlar)

                {
                    if (kayıt.Tur == "gelir")
                    {
                        toplamgelir = toplamgelir + kayıt.Tutar;
                    }
                    else if (kayıt.Tur == "gider")
                    {
                        toplamgider = toplamgider + kayıt.Tutar;
                    }



                    Console.WriteLine("toplam gelir:" + toplamgelir + "TL");
                    Console.WriteLine("toplam gider:" + toplamgider + "TL"); 
                    decimal bakiye = toplamgelir - toplamgider;

                    Console.WriteLine("bakiye:" + bakiye + "TL");

                    Console.WriteLine("\n devam etmek için bir tuşa basınız.");
                    Console.ReadLine();
                }

            }
            static void İstatistikleriGoster()
                 
            {
              

                int gelirSayisi = 0;
                int giderSayisi = 0;

                decimal toplamGelir = 0;
                decimal toplamGider = 0;
                decimal enyüksekGider = 0;

                foreach (kayıt kayıt in kayıtlar)
                {
                    if (kayıt.Tur == "gelir")
                    { 
                        gelirSayisi++; 
                        toplamGelir += kayıt.Tutar;

                    }
                    else if (kayıt.Tur == "gider")
                    {
                        giderSayisi++;
                        toplamGider += kayıt.Tutar;

                    }
                     if (kayıt.Tutar > enyüksekGider) 
                    {
                       enyüksekGider = kayıt.Tutar;
                    }
                    Console.WriteLine("======== İSTATİSTİKLER ========");
                    Console.WriteLine("toplam kayıt:" + kayıtlar.Count);
                    Console.WriteLine("toplam gider sayısı:" + giderSayisi);
                    Console.WriteLine("toplam gelir:" + toplamGelir + "TL");
                    Console.WriteLine("toplam gider:" + toplamGider + "TL");
                    Console.WriteLine("en yüksek gider:" + enyüksekGider + "TL");

                    Console.WriteLine("\n devam etmek için bir tuşa basınız.");
                    Console.ReadLine();
                    
                }


            }
               static void çıkış()
            {
                Console.WriteLine("çıkış yapılıyor...");
                Environment.Exit(0); 
            }


        }

    }
}

    
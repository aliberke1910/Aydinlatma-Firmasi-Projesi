using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Proje_Denemesi
{
    class Program
    {
        static void Main(string[] args)
        {

            OrderManager orderManager = new OrderManager();
            orderManager.Logger = new SD6060OPL(); //new G6060OPL yazılırsa Ahmet, new SD6060OPL olarak değiştirirsek Burak siparişi alır.
            orderManager.Add();

            G6060OPL g6060OPL = new G6060OPL();
            g6060OPL.CustomerId();
            g6060OPL.Assembler();
            g6060OPL.FullAssembly();
            g6060OPL.DeliveryDay();

            SD6060OPL sD6060OPL = new SD6060OPL();
            sD6060OPL.CustomerId();
            sD6060OPL.Assembler();
            sD6060OPL.FullAssembly();
            sD6060OPL.DeliveryDay();

            Console.ReadLine();

        }
    }

    class OrderManager //Sipariş yöneticisi
    {
        public ILogger Logger { get; set; }
        public void Add()
        {
            Logger.log();
        }
    }

    interface ILogger //Sipariş kaydını yapan personel
    {
        void log(); 
    }

    class Logger:ILogger //Sipariş kaydının base'i
    {
        public void log()
        {
        }

    }

    abstract class Arlight //Üretici firma
    {
        public void DeliveryDay() //Sipariş günü
        {

        }

        public string[] personels = new string[6] { "Ali", "Berke", "Mustafa", "Ahmet", "Burak", "Salih" }; //Personeller

        public string[] customers = new string[2] { "Is Bankasi", "Defacto" }; //Müşteriler

        public void FullAssembly() //Ürünün montajı tam mı? Yoksa eksik montaj mı yapılmalı?
        {
            Console.WriteLine("Bu armatur tam montaj yapilmistir!");
        }
    }

    interface IInformation //Genel bilgiler
    {
        void CustomerId(); //Müşterinin kimliği
        void Assembler(); //Montajı yapacak eleman
        void instruction(); //Ürünün montaj talimat kağıdı konulmalı mı?
    }

    class G6060OPL : Arlight, IInformation, ILogger //G 6060 OPL ürünün ismidir.
    {
        public ILogger Logger { get; set; }

        public void Assembler()
        {
            Console.WriteLine("Montajcisi {0}'dir", personels[0]);
        }
        public void CustomerId()
        {
            Console.WriteLine("Bu urun {0}'ya gidecektir.", customers[1]);
        }

        public void instruction()
        {
            Console.WriteLine("Bu urun standarttir, montaj talimat kagidi atilacaktir!");
        }

        public void DeliveryDay()
        {
            Console.WriteLine("Teslimat Tarihi : " + 26 + "/" + 01 + "/" + 2019);
        }

        public void log()
        {
            Console.WriteLine("Islem kaydi {0} tarafindan alinmistir.", personels[3]);
        }
    }

    class SD6060OPL : Arlight, IInformation, ILogger //SD 6060 OPL ürünün ismidir.
    {
        public ILogger Logger { get; set; }

        public void Assembler()
        {
            Console.WriteLine("Montajcisi {0}'dir.", personels[2]);
        }

        public void CustomerId()
        {
            Console.WriteLine("Bu armatur {0}'a gidecektir", customers[0]);
        }

        public void instruction()
        {
            {
                Console.WriteLine("Bu urun ozeldir, montaj talimat kagidi atilmayacaktir!");
            }
        }

        public void DeliveryDay()
        {
            Console.WriteLine("Teslimat Tarihi : " + 27 + "/" + 01 + "/" + 2019);
        }

        public void log()
        {
            Console.WriteLine("Islem kaydi {0} tarafindan alinmistir.", personels[4]);
        }
    }

}

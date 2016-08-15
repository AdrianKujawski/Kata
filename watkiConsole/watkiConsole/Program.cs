using System;
using System.Threading;

namespace watkiConsole
{
    class Program
    {
        static void Main()
        {
            Odliczanie oOdliczanie = new Odliczanie();
            oOdliczanie.Start();

            MyThreadClass oMyThreadClass = new MyThreadClass();
            Thread oThread = new Thread(oMyThreadClass.Run);

            oThread.Start();
            Silnia.Oblicz(10);
            Console.WriteLine("Oczekiwanie na zakonczenie watku...");
            oThread.Join();
            Console.ReadKey();
        }

    }

    class MyThreadClass
    {
        public void Run()
        {
            Console.WriteLine("Rozpoczynam prace...");
            Silnia.Oblicz(10);
            //Console.WriteLine("Test uspienia watku...");
            //Thread.Sleep(2000);
            Console.WriteLine("Koncze prace...");
        }
    }

	internal class Silnia
    {
        public static void Oblicz(double x)
        {
            for (int i = 0; i < 20000000; i++)
                x = Math.Pow(x, 2) % 3;
        }
    }

    class Odliczanie
    {
        private int _i = 0;

        public void Start()
        {
            Timer timerDoLiczenia = new Timer(Licz, null, 0, 1000);
        }
        private void Licz(object s)
        {
            Console.WriteLine(++_i);
        }
    }
}

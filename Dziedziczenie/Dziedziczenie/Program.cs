using System;

namespace Dziedziczenie
{
	internal class Program
	{
		private static void Main()
		{
			var animal = new Animal(5, 1);
			var kon = new Kon(7, 4, "Rafał");
			var walen = new Walen(15, 6);
			var kucyk = new Zrebak(3, 2, "Miłosz");

			animal.DajGlos();
			walen.Plywanie();
			kon.PrzezuwanieTrawy();
			kucyk.PrzezuwanieTrawy();
			kucyk.GetInfo();
			kon.Zabij();
			kucyk.Zabij();
		}
	}

	internal class Animal : IAnimal
	{
		private readonly int _wiek;
		private int _liczbaKonczyn;

		public Animal()
		{
			_wiek = 1;
			LiczbaKonczyn = 4;
		}

		public Animal(int wiek, int konczyny)
		{
			_wiek = wiek;
			_liczbaKonczyn = konczyny;
		}

		public int LiczbaKonczyn
		{
			get { return _liczbaKonczyn; }
			set
			{
				if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
				LiczbaKonczyn = value;
			}
		}

		public void Oddychanie()
		{
			Console.WriteLine("Zwierze oddycha");
		}

		public virtual void DajGlos()
		{
			Console.WriteLine("Jakiś dźwiek...");
		}

		public virtual void GetInfo()
		{
			Console.WriteLine("Wiek: " + _wiek);
		}
	}

	internal class Kon : AnimalPasacySie
	{
		private readonly string _name;

		public Kon(int wiek, int konczyny, string name) : base(wiek, konczyny)
		{
			_name = name;
		}

		public void Galop()
		{
			Console.WriteLine("Galop!");
		}

		public override void DajGlos()
		{
			Console.WriteLine("Brrrr.... Ihaha!");
		}

		public override void GetInfo()
		{
			base.GetInfo();
			Console.WriteLine("Imię: {0}", _name);
		}

		public sealed override void Zabij()
		{
			Console.WriteLine("Koń został zabity.");
		}
	}


	internal class Zrebak : Kon
	{
		public Zrebak(int wiek, int konczyny, string name) : base(wiek, konczyny, name)
		{
		}

		public new void Zabij()
		{
			Console.WriteLine("Zrebak umarł!");
		}
	}

	internal class Walen : Animal
	{
		public Walen(int wiek, int konczyny) : base(wiek, konczyny) {}

		public void Plywanie()
		{
			Console.WriteLine("Płynie...");
		}

		public new void DajGlos()
		{
			Console.WriteLine("\" echooo \"");
		}
	}

	internal abstract class AnimalPasacySie : Animal, IPasacySie
	{
		public AnimalPasacySie(int wiek, int konczyny) : base(wiek, konczyny) {}

		public void PrzezuwanieTrawy()
		{
			Console.WriteLine("Żuje trawe. Mniam.");
		}

		public abstract void Zabij();
	}


	internal class Pole
	{
		private static int _x;

		public Pole()
		{
			_x++;
		}

		public void GetX()
		{
			Console.WriteLine(_x);
		}
	}
}

internal interface IAnimal
{
	int LiczbaKonczyn { get; set; }
}

internal interface IPasacySie
{
	void PrzezuwanieTrawy();
}

internal class Mutowanie
{
	private static int mnoznik = 2;

	public void MnozKonczyny(IAnimal zwierze)
	{
		Console.WriteLine("Hahaha! Teraz twoje zwierze ma " + zwierze.LiczbaKonczyn*mnoznik + " konczyn!");
	}

	public bool SprawdzCzyJestZwierzeciem(object obj)
	{
		if (obj is IAnimal)
			return true;
		return false;
	}
}
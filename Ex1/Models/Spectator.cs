using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1.Models
{
	class Spectator : Human
	{
		public Spectator(string name, int age)
		{
			Name = name;
			Age = age;
		}

		public void ReactToTrick(object source, Reaction args)
		{
			switch (args.Trick.TypeTrick)
			{
				case TrickType.AcrobatieType:
					Console.WriteLine(Name + " Applaudit pendant le tour de " + args.AnimalName + " car il fait " + args.Trick.Name + " qui est un tour d'acrobatie");
					break;
				case TrickType.MusicType:
					Console.WriteLine(Name + " Siffle pendant le tour de " + args.AnimalName + " car il fait " + args.Trick.Name + " qui est un tour de musique");
					break;
			}
		}
	}
}

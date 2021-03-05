using System;
using System.Collections.Generic;
namespace Ex1.Models
{
	class Monkey : Animal
	{
		List<Trick> m_tricks = new List<Trick>();
		public Monkey(string name)
		{
			Name = name;
		}
		public List<Trick> Tricks
		{
			get { return m_tricks; }
			set { m_tricks = value; }
		}

		public void DoTrick(string name)
		{
			Reaction.Trick = m_tricks.Find(x => string.Compare(x.Name,name,true) == 0);
			Reaction.AnimalName = Name;
			
		}
	}
}

using System;
using System.Collections.Generic;
namespace Ex1.Models
{
	class Monkey : Animal
	{
		public event EventHandler<Reaction> ReactionRequested;
		Spectator m_spectator;
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
		public Spectator Spectator
		{
			get { return m_spectator; }
			set { m_spectator = value; }
		}

		public void DoTrick(string name)
		{
			ReactionRequested = m_spectator.ReactToTrick;
			Reaction reaction = new Reaction()
			{
				AnimalName = Name,
				Trick = m_tricks.Find(x => string.Compare(x.Name, name, true) == 0)
			};
			ReactionRequested.Invoke(this, reaction);
		}
	}
}

using Ex1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1.Controllers
{
	class Instantiation
	{

		public void Construct(ref Spectator spectator, ref Tamer tamer1, ref Tamer tamer2, ref Monkey monkey1, ref Monkey monkey2)
		{
			spectator = new Spectator("Henry", 22);
			monkey1 = new Monkey("Ben");
			monkey2 = new Monkey("Gabriel");
			tamer1 = new Tamer("Rodriguez", 36, monkey1, FillListTrick(0));
			tamer2 = new Tamer("Philip", 32, monkey2, FillListTrick(1));
		}

		List<Trick> FillListTrick(int startPoint)
		{
			List<Trick> tricksMonkey = new List<Trick>();
			for (int i = startPoint; i < startPoint + 3; i++)
			{
				TrickType tricktype = i % 2 > 0 ? TrickType.MusicType : TrickType.AcrobatieType;
				Trick tempTrick = new Trick("trick" + i, tricktype);
				tricksMonkey.Add(tempTrick);
			}
			return tricksMonkey;
		}
	}
}

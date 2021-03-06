using Ex1.Controllers;
using Ex1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1.Views
{
	class Simulation
	{
		#region Declarations
		Instantiation instance = new Instantiation();
		Spectator spectator;
		Tamer tamer1, tamer2;
		Monkey monkey1, monkey2;
		#endregion

		public void StartSimulation()
		{
			instance.Construct(ref spectator,ref tamer1,ref tamer2,ref monkey1,ref monkey2);
			LoopTrick(tamer1);
			LoopTrick(tamer2);

		}

		void LoopTrick(Tamer tamer)
		{
			for (int i = 0; i < tamer.Monkey.Tricks.Count; i++)
			{
				tamer.AskTrickToMonkey(tamer.GetTrickName(i));
				//spectator.ReactToTrick();
			}
		}

		
	}
}

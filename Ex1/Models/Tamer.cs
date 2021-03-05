using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Ex1.Models
{
	class Tamer : Human
	{
		Monkey m_monkey;
		List<string> m_tricksName = new List<string>();
		
		public Tamer(string name, int age, Monkey monkeyTamed, List<Trick> tricks)
		{
			Name = name;
			Age = age;
			Monkey = monkeyTamed;
			Monkey.Tricks = tricks;
			foreach(Trick trick in tricks)
			{
				m_tricksName.Add(trick.Name);
			}
		}

		public Monkey Monkey
		{
			get { return m_monkey; }
			set { m_monkey = value; }
		}

		public void AskTrickToMonkey(string trick)
		{
			Monkey.DoTrick(trick);
		}

		public string GetTrickName(int index)
		{
			return m_tricksName[index];
		}

	}
}

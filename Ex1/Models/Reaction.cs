using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1.Models
{
	static class Reaction
	{
		static string m_animalName;
		static Trick m_trick;

		public static string AnimalName
		{
			get { return m_animalName; }
			set { m_animalName = value; }
		}

		public static Trick Trick
		{
			get { return m_trick; }
			set { m_trick = value; }
		}
	}
}

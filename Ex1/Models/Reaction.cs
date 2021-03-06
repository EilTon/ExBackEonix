using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1.Models
{
	public class Reaction : EventArgs
	{
		public string m_animalName;
		public Trick m_trick;

		public string AnimalName
		{
			get { return m_animalName; }
			set { m_animalName = value; }
		}

		public Trick Trick
		{
			get { return m_trick; }
			set { m_trick = value; }
		}
	}
}

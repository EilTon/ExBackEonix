using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1.Models
{
	enum TrickType { AcrobatieType, MusicType }

	class Trick
	{
		string m_name;
		TrickType m_trickType;

		public Trick(string name,TrickType trickType)
		{
			Name = name;
			TypeTrick = trickType;
		}

		public string Name
		{
			get { return m_name; }
			set { m_name = value; }
		}

		public TrickType TypeTrick
		{
			get { return m_trickType; }
			set { m_trickType = value; }
		}
	}

	
}

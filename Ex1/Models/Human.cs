using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1.Models
{
	public abstract class Human
	{
		string m_name;
		int m_age;

		public string Name
		{
			get { return m_name; }
			set { m_name = value; }
		}

		public int Age
		{
			get { return m_age; }
			set { m_age = value; }
		}
	}
}

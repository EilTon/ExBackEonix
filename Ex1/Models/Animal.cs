using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1.Models
{
	public abstract class Animal
	{
		string m_name;
		public string Name
		{
			get { return m_name; }
			set { m_name = value; }
		}
	}
}

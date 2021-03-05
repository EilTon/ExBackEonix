using Ex2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ex2.DAL
{
	public class PersonContext : DbContext
	{
		public DbSet<Person> Persons { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
	public class MyContext : DbContext, IDisposable
	{
		public MyContext() :base(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
		{

		}

		public DbSet<Pessoa> Pessoa { get; set; }
	}
}
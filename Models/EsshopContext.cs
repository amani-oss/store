using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Esshop.Models
{
	public class EsshopContext:DbContext
	{
		public EsshopContext() : base("name= EsshopDB") { }
		public DbSet<Prooduit> Prooduits { get; set; }


    }
}
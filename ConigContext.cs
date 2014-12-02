using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

public class ConigContext : DbContext
{
    DbSet<Regular> Regulares { get; set; }
    DbSet<Irregular> Irregulares { get; set; }

	public ConigContext()
	{
	}
}

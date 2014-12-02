using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

public class ConigContext : DbContext
    {
       public DbSet<Irregular> Irregulares { get; set; }
       public DbSet<NoEnMatricula> NoEnMatricula { get; set; }
       public DbSet<NoEnConig> NoEnConig { get; set; }

        public ConigContext()
        {
        }
    }



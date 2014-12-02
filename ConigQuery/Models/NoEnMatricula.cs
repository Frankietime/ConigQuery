using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

public class NoEnMatricula
{
    public int NoEnMatriculaId { get; set; }
    public string Cuil { get; set; }
    public string Estado { get; set; }
    public string Nombre { get; set; }
    public string Curso { get; set; }

    public NoEnMatricula()
    {
    }
}

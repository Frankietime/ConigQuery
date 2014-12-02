using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Tools.Excel;
using GemBox.Spreadsheet;
using LinqToExcel;
using LinqToExcel.Query;



namespace ConigQuery
{
    class ExcelDB
    {
        private string File;
        private string pathToExcelFile;
        private string sheetName;
        public ExcelQueryFactory excelFile;

        public ExcelDB(string File, string Sheet)
        {

            this.File = File;
            this.pathToExcelFile = pathToExcelFile = "" + @"C:\Users\Frank\Documents\Visual Studio 2013\Projects\ConigQuery\Excels\" + File;
            this.sheetName = Sheet;
            var excelFile = new ExcelQueryFactory(pathToExcelFile);
        }

        // Muestra el contenido de la tabla
        public void showContent()
        {
            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            var Alumno = from a in excelFile.Worksheet(sheetName) select a;
            foreach (var a in Alumno)
            {
                string AlumnoInfo = "Cuil : {0}; Nombre: {1}; Curso: {2}; Turno: {3}; Estado: {4};";
                Console.WriteLine(string.Format(AlumnoInfo, a["Cuil"], a["Nombre"], a["Curso"], a["Turno"], a["Estado"]));
            }

            Console.ReadLine();
        }

        //Devuelve una lista con los valores de la columna seleccionada
        public List<string> getContent(string col)
        {
            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            var Alumno = from a in excelFile.Worksheet(sheetName) select a;
            var list = new List<string>();
            foreach (var a in Alumno)
            {
                string AlumnoInfo = "{0}";
                list.Add(string.Format(AlumnoInfo, a[col]));
            }
            return list;
        }

        //Busca un valor en el archivo y si lo encuentra devuelve toda la fila a través de una lista "row", si no lo encuentra, devuelve el valor en el primer indice de row
        public List<string> getSpecificRow(string id, string content)
        {
            var row = new List<string>();
            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            var rowQuery = from a in excelFile.Worksheet(sheetName) select a;
            foreach (var a in rowQuery)
            {
              //  Console.WriteLine("Searching:" + a[0] + " " + a[1] + " " + a[2] + " " + a[3] + " " + a[4] + " " + a[5] + " ");
                if(a[id] == content)
                {
                    row.Add(a[0]);
                    row.Add(a[1]);
                    row.Add(a[2]);
                    row.Add(a[3]);
                    row.Add(a[4]);
                    row.Add(a[5]);
                }
                else
                {
                    Console.WriteLine("No encontro el " + id);
                    row.Add(content);
                }
            }
            return row;
        }

        //Inserta Campos
        public void insertData()
        {

        }
      /*  public string Search(string word, bool strong)
        {
            string result = "BUSQUEDA FALLIDA";
            if (strong)
            {

            } else
            {

            }*/
        //}
    }
}



            
            
           
            
            
         

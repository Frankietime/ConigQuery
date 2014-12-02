using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Data.Entity;
using System.IO;


namespace ConigQuery
{
    class Program
    {
        static void Main(string[] args)
        {             

            /* El siguiente programa realiza consultas en Conig, una Webapp para ABM's, reclamos de servicio tecnico y demas operaciones de gestion del programa conectar igualdad.
             * Las consultas se realizan en funcion del nro de serie de la netbook, los resultados de la consulta se comparan con los registros almacenados en un excel y, de acuerdo 
             * a los resultados de la comparacion, se inserta el registro en alguna de las dos tablas de la base de datos local: Irregulares y NoEnMatricula */

            var db = new ConigContext();

            // Abriendo Conig en Firefox                        
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://servicioscorp.anses.gob.ar/clavelogon/logon.aspx");
            driver.Manage().Window.Maximize();

            // Login            
            IWebElement user = driver.FindElement(By.Id("Usuario"));
            IWebElement pass = driver.FindElement(By.Id("Clave"));
            IWebElement submit = driver.FindElement(By.Id("Ingresar"));

            user.SendKeys("");
            pass.SendKeys("");
            submit.SendKeys(Keys.Enter);

            

            // Ingresando al aplicativo            
            IWebElement ingreso = driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/ul/li/a"));
            ingreso.Click();

            //Solapa Consultas
            IWebElement consultas = driver.FindElement(By.Id("ctl00_lnk_Consultas"));
            consultas.Click();

            IWebElement consultasSelect = driver.FindElement(By.XPath("/html/body/form/div[3]/div/div[2]/div/div[2]/div[1]/fieldset/div/div[1]/div/table/tbody/tr[4]/td/label"));

            consultasSelect.Click();
            consultasSelect.SendKeys(Keys.Enter);

            //Consultas/Historial de Cambios de Titularidad
            IWebElement searchBySerial = driver.FindElement(By.XPath("/html/body/form/div[3]/div/div[2]/div/div[2]/div/div/fieldset/div/table/tbody/tr/td[2]/label"));

            searchBySerial.Click();

            //Rutina de consulta
            ExcelDB remito = new ExcelDB("Remito.xlsx", "Sheet1");
            ExcelDB matricula = new ExcelDB("Matricula.xlsx", "Sheet1");

            // Obtiene todos los nros de serie que deberan consultarse en Conig
            var list = new List<string>();
            list = remito.getContent("Serial");

            WebScraper scraper = new WebScraper(driver, list, "Serial");

            for (int i = 0; i < list.Count; i++)
            {
                // Envia consulta
                IWebElement inputSerial = driver.FindElement(By.ClassName("CajaTexto"));
                string serial = list[i];
                inputSerial.SendKeys(serial);
                inputSerial.SendKeys(Keys.Enter);

                var tabla = new List<string>();

                // Chequea el resultado                
                if (scraper.Check())
                {
                    // Rutina de Clasificacion: Se copian los datos de la tabla devuelta por la consulta y se insertan en las tablas locales Irregular o NoEnMatricula                 
                    // 1° Obtiene los datos de la tabla
                    tabla = scraper.getTable();
                    if (tabla.Count > 2) // Chequea que la tabla posea informacion reelevante. Si no, realiza una nueva consulta
                    {
                        Console.WriteLine(tabla[0]);                        

                        // Edita el nro de CUIL para convertirlo en nro de DNI
                        string dni = tabla[2];
                        dni = dni.Trim();
                        dni = dni.Remove(0, 2);
                        dni = dni.Remove(8, 1);

                        Console.WriteLine(dni);

                        // 2° Busca equivalencias entre el dni obtenido de la consulta y los dni almacenados en la matricula
                        var Mat_dni = matricula.getContent("Dni");
                        for (int j = 0; j < Mat_dni.Count; j++)
                        {
                            if (Mat_dni[j] == dni)
                            {
                                // Inserta registro de Matricula en "Irregulares"
                                List<string> row = matricula.getSpecificRow("Dni", dni);
                                Irregular Alumno = new Irregular();
                                Alumno.Nombre = row[0];
                                Alumno.Cuil = row[1];
                                Alumno.Curso = row[2];
                                Alumno.Estado = row[3];

                                db.Irregulares.Add(Alumno);
                                db.SaveChanges();
                                Console.WriteLine("Insertando Data en Irregulares: " + tabla[2] + " " + tabla[0] + " " + tabla[6] + tabla[7] + " ");
                                
                                break;
                            }
                            else
                            {
                                if (j == Mat_dni.Count - 1) //Si es la ultima iteracion y no encontro nada -> Inserta Cuil de Conig en "NoEnMatricula"
                                {
                                    NoEnMatricula Alumno = new NoEnMatricula();
                                    Console.WriteLine("Insertando Data en NoEnMatricula: " + tabla[2] + " " + tabla[0] + " " + tabla[6] + tabla[7] + " ");
                                    Alumno.Cuil = tabla[2];
                                    Alumno.Nombre = tabla[0];
                                    Alumno.Curso = tabla[6] + " " + tabla[7];
                                    Alumno.Estado = "null";

                                    db.NoEnMatricula.Add(Alumno);
                                    db.SaveChanges();
                                }
                            }                            
                        }
                        //Prepara caja de texto para proxima consulta
                        inputSerial = driver.FindElement(By.ClassName("CajaTexto"));
                        inputSerial.Clear();
                        }
                    }
                    else
                    {
                        // Clasifica
                        Console.WriteLine("NO RESULT");

                        //Prepara caja de texto para proxima consulta
                        inputSerial = driver.FindElement(By.ClassName("CajaTexto"));
                        inputSerial.Clear();
                    }
               inputSerial = driver.FindElement(By.Id("ctl00_body_txtNroSerie"));
            }
            Console.ReadLine();
        }
    }
}

//TODO: agregar mas criterios de clasificacion para derivar los datos a la NoEnConig 



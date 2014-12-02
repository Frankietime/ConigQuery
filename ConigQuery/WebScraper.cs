using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConigQuery
{
    class WebScraper
    {
        private List<string> list;
        private string p;
        private IWebDriver driver;

        public WebScraper(IWebDriver driver, List<string> list, string p)
        {
            this.driver = driver;
            this.list = list;
            this.p = p;
        }

        // Chequea si el aplicativo devuelve un error o una tabla con los datos solicitados
        public bool Check()
        {
            bool error = true;
            bool tabla = true;
            bool result = true;

            try
            {
                IWebElement findError = driver.FindElement(By.Id("ctl00_body_lbl_Msj_NroSerie"));               
                error = false;
            }
            catch (Exception)
            {               
                error = true;
            }

            try
            {
                IWebElement findTabla = driver.FindElement(By.Id("ctl00_body_dg_ReasignacionHisto"));                
                tabla = true;
            }
            catch (Exception)
            {
                tabla = false;
            }

            // Devuelve true or false de acuerdo a si la consulta devolvio una tabla o no hay tabla para esa consulta. 
            // Si no se encuentra nada lo informa mediante mensaje de consola.
            if (error)
            {
                result = false;
            }
            else
            {
                if (tabla)
                {
                    result = true;
                }

                else
                {
                    result = false;
                }                
            }
            return result;
        }
            // Devuelve lista con los valores de la tabla seleccionada
            public List<string> getTable()
            {
                List<string> list = new List<string>();                 
                
                // Obtiene string de campo Nombre
                string nombreString = driver.FindElement(By.XPath("/html/body/form/div[3]/div/div[2]/div/div[2]/div[3]/fieldset/div/table/tbody/tr[2]/td[1]")).Text;
                

                // Si Nombre esta vacio, se reubica
                if(nombreString.Length < 1)
                {
                    // Reubicando
                    // Obtiene los strings de cada campo
                    nombreString = driver.FindElement(By.XPath("/html/body/form/div[3]/div/div[2]/div/div[2]/div[3]/fieldset/div/table/tbody/tr[3]/td[1]")).Text;
                    string serieString = driver.FindElement(By.XPath("/html/body/form/div[3]/div/div[2]/div/div[2]/div[3]/fieldset/div/table/tbody/tr[3]/td[2]")).Text;
                    string cuilString = driver.FindElement(By.XPath("/html/body/form/div[3]/div/div[2]/div/div[2]/div[3]/fieldset/div/table/tbody/tr[3]/td[3]")).Text;
                    string cueString = driver.FindElement(By.XPath("/html/body/form/div[3]/div/div[2]/div/div[2]/div[3]/fieldset/div/table/tbody/tr[3]/td[4]")).Text;
                    string fechaString = driver.FindElement(By.XPath("/html/body/form/div[3]/div/div[2]/div/div[2]/div[3]/fieldset/div/table/tbody/tr[3]/td[5]")).Text;
                    string tipoString = driver.FindElement(By.XPath("/html/body/form/div[3]/div/div[2]/div/div[2]/div[3]/fieldset/div/table/tbody/tr[3]/td[6]")).Text;
                    string seccionString = driver.FindElement(By.XPath("/html/body/form/div[3]/div/div[2]/div/div[2]/div[3]/fieldset/div/table/tbody/tr[3]/td[7]")).Text;
                    string turnoString = driver.FindElement(By.XPath("/html/body/form/div[3]/div/div[2]/div/div[2]/div[3]/fieldset/div/table/tbody/tr[3]/td[8]")).Text;

                    // Insera strings en lista y la devuelve
                    list.Add(nombreString);
                    list.Add(serieString);
                    list.Add(cuilString);
                    list.Add(cueString);
                    list.Add(fechaString);
                    list.Add(tipoString);
                    list.Add(seccionString);
                    list.Add(turnoString);
                    return list;
                }
                else{


                    // Continua obteniendo los strings de cada campo
                    string serieString = driver.FindElement(By.XPath("/html/body/form/div[3]/div/div[2]/div/div[2]/div[3]/fieldset/div/table/tbody/tr[2]/td[2]")).Text;
                    string cuilString = driver.FindElement(By.XPath("/html/body/form/div[3]/div/div[2]/div/div[2]/div[3]/fieldset/div/table/tbody/tr[2]/td[3]")).Text;
                    string cueString = driver.FindElement(By.XPath("/html/body/form/div[3]/div/div[2]/div/div[2]/div[3]/fieldset/div/table/tbody/tr[2]/td[4]")).Text;
                    string fechaString = driver.FindElement(By.XPath("/html/body/form/div[3]/div/div[2]/div/div[2]/div[3]/fieldset/div/table/tbody/tr[2]/td[5]")).Text;
                    string tipoString = driver.FindElement(By.XPath("/html/body/form/div[3]/div/div[2]/div/div[2]/div[3]/fieldset/div/table/tbody/tr[2]/td[6]")).Text;
                    string seccionString = driver.FindElement(By.XPath("/html/body/form/div[3]/div/div[2]/div/div[2]/div[3]/fieldset/div/table/tbody/tr[2]/td[7]")).Text;
                    string turnoString = driver.FindElement(By.XPath("/html/body/form/div[3]/div/div[2]/div/div[2]/div[3]/fieldset/div/table/tbody/tr[2]/td[8]")).Text;
                
                    // Insera strings en lista y la devuelve
                    list.Add(nombreString);
                    list.Add(serieString);
                    list.Add(cuilString);
                    list.Add(cueString);
                    list.Add(fechaString);
                    list.Add(tipoString);
                    list.Add(seccionString);
                    list.Add(turnoString);
                    return list;
                    }
                }
                
             


        }
    }


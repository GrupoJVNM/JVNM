using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
   public class SelectWithOutC : MiniSQLQuery
    {
        public string TableName;
        List<String> selectedC;

        public SelectWithOutC(string tableName, List<String> selectedC)
        {
            TableName = tableName;
            this.selectedC = selectedC;
        }

        public string Execute(Database database)
        {
            //try
            //{
                List<List<String>> li = new List<List<string>>();
                li = database.SelectWithOutC(TableName, selectedC);

                String resultado = "[" + selectedC[0];

                for (int k = 1; k < selectedC.Count; k++)
                {


                    resultado = resultado.Insert(resultado.Length, (","));
                    resultado = resultado.Insert(resultado.Length, selectedC[k]);

                }
               
                resultado = resultado + "]";
            try
            {
                for (int i = 0; i < li[0].Count; i++)//Nombre Age 
                {
                    resultado = resultado + "{";
                    for (int j = 0; j < li.Count; j++)
                    {


                       string  dato = li[j][i];
                        dato = "'" + dato + "' ,";
                        resultado = resultado + dato;

                    }
                    resultado= resultado.TrimEnd(',');
                    resultado = resultado + "}";


                }
                
                return resultado;
            }
            catch
            {
                return resultado; //Query.Error;
            }
        }
    }
}

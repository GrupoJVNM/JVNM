using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
   public class Select : MiniSQLQuery
    {
        public String Table = null;
        public List<String> SelectedC = null;
        public DataComparator Compare;
        public String CondiC = null;
        public String Value = null;


        public Select(String table, List<String> selectedC, DataComparator compare, String condiC, String value)
        {
            Table = table;
            SelectedC = selectedC;
            Compare = compare;
            CondiC = condiC;
            Value = value;
        }
        public string Execute(Database database)
        {
            try
            {
                List<List<String>> li = new List<List<string>>();
                li = database.Select(Table, SelectedC, Compare, CondiC, Value);

                String resultado = "[" + SelectedC[0];

                for (int k = 1; k < SelectedC.Count; k++)
                {
                    resultado = resultado.Insert(resultado.Length, (","));
                    resultado = resultado.Insert(resultado.Length, SelectedC[k]);

                }

                resultado = resultado + "]";
                try
                {

                    for (int i = 0; i < li[0].Count; i++)//Nombre Age 
                {
                    resultado = resultado + "{";
                    for (int j = 0; j < li.Count; j++)
                    {


                        string dato = li[j][i];
                        dato = "'" + dato + "' ,";
                        resultado = resultado + dato;

                    }
                    resultado = resultado.TrimEnd(',');
                    resultado = resultado + "}";


                }
                return resultado;
            }
            catch
            {
                return resultado;// Query.Error;
            }
        }
        catch
        {
            return Query.TableDoesNotExist;
        }
        }
    }
}


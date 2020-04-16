using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
   public class SelectAll : MiniSQLQuery
    {
        public String Table = null;
        public DataComparator Compare;
        public String CondiC = null;
        public String Value = null;

        public SelectAll(String table, DataComparator compare, String condiC, String value)
        {
            Table = table;
            Compare = compare;
            CondiC = condiC;
            Value = value;
        }
        public string Execute(Database database)
        {
            //try
            //{
                Table t = database.GetList().Find(table => table.GetTableName().Equals(Table));



                List<List<String>> li = new List<List<string>>();
                li = database.SelectAll(Table, Compare, CondiC, Value);

                String resultado = "[" + t.GetListTableColumn()[0].Name; 

                for (int k = 1; k < t.GetListTableColumn().Count; k++)
                {
                    resultado = resultado.Insert(resultado.Length, (","));
                    resultado = resultado.Insert(resultado.Length, t.GetListTableColumn()[k].Name);

                }

                resultado = resultado + "]";
            try
            {
                for (int i = 0; i < t.GetListTableColumn()[0].GetList().Count; i++) 
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
    }
}


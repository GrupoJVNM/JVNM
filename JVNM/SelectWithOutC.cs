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
        List<String> SelectedC;

        public SelectWithOutC(string tableName, List<String> selectedC)
        {
            TableName = tableName;
            this.SelectedC = selectedC;
        }

        public string Execute(Database database)
        {
            if (database.permission(TableName, "SELECT") || database.User.Equals("admin"))
            {

                try
                {
                    List<List<String>> li = new List<List<string>>();
                    li = database.SelectWithOutC(TableName, SelectedC);

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
                        return resultado; //Query.Error;
                    }
                }
                catch
                {
                    return Query.TableDoesNotExist;
                }
            }
            else
            {
                return Query.SecurityNotSufficientPrivileges;
            }
        }
    }
}

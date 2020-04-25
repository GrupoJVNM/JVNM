using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
   public class SelectAllWithOutC : MiniSQLQuery
    {
       public string TableName;

        public SelectAllWithOutC(string tableName) {
           TableName = tableName;
        }
        public string Execute(Database database)
        {
            if (database.permission(TableName, "SELECT") || database.User.Equals("admin"))
            {
                try
                {
                    Table t = database.GetList().Find(table => table.GetTableName().Equals(TableName));



                    List<List<String>> li = new List<List<string>>();
                    li = database.selectAllWithOutC(TableName);

                    String resultado = "[" + t.GetListTableColumn()[0].Name;

                    for (int k = 1; k < t.GetListTableColumn().Count; k++)
                    {


                        resultado = resultado.Insert(resultado.Length, (","));
                        resultado = resultado.Insert(resultado.Length, t.GetListTableColumn()[k].Name);

                    }

                    resultado = resultado + "]";
                    try
                    {
                        for (int i = 0; i < t.GetListTableColumn()[0].GetList().Count; i++)//Nombre Age 
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


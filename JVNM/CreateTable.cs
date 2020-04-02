using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
    public class CreateTable : MiniSQLQuery
    {
        public String Name;
        public List<TableColumn> ColumnsName;
       

        public CreateTable(string name, List<String> columns)
        {
            Name = name;
            ColumnsName = new List<TableColumn>();
            for(int i = 0; i<columns.Count; i++) {
                if (i == 0)
                {
                    if (columns[i + 1].Equals("INT"))
                    {
                        ColumnsName.Add(new TableColumn(columns[i], DataType.Int));
                    }
                    else if (columns[i + 1].Equals("TEXT"))
                    {
                        ColumnsName.Add(new TableColumn(columns[i], DataType.Text));
                    }
                    else
                    {
                        ColumnsName.Add(new TableColumn(columns[i], DataType.Double));
                    }

                }
                else if ((i % 2) == 0)
                {
                    if (columns[i + 1].Equals("INT"))
                    {
                        ColumnsName.Add(new TableColumn(columns[i], DataType.Int));
                    }
                    else if (columns[i + 1].Equals("TEXT"))
                    {
                        ColumnsName.Add(new TableColumn(columns[i], DataType.Text));
                    }
                    else
                    {
                        ColumnsName.Add(new TableColumn(columns[i], DataType.Double));
                    }


                }
            
            }
           
        }

        public string Execute(Database database)
        {

            try
            {
                database.AddTable(new Table(Name, ColumnsName));
                return Query.CreateTableSuccess;
            }
            catch
            {
                return Query.TableDoesNotExist;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
    public class Table
    {
        String name;
        public List<TableColumn> columns;

        public Table(String name, List<TableColumn> columns){
            this.name = name;
            this.columns = columns;
        }

        public void AddTuple(List<String> list)
        {

        }

        public void AlterTable()
        {

        }

        public void Insert()
        {

        }

        public void Select()
        {

        }

        public void AddColumn()
        {

        }
        public void Delete()
        {

        }
    }
}

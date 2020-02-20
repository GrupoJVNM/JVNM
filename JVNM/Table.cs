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
            columns[0].Add(list[0]);
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

        public void AddColumn(String name, DataType type)
        {
            TableColumn newColumn = new TableColumn(name, type);
            columns.Add(newColumn);
        }
        public void Delete()
        {

        }

        public List<TableColumn> getListTableColumn()
        {
            return columns;
        }
    }
}

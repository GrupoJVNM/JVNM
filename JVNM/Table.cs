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
            //recorrer todas las columnas
            for (int i = 0; i < columns.Count; i++)
            {
                //por cada columna comprobar el tipo de la columa y de la lista que vamos a introducir

                if (columns[i].GetType().Equals(list[i].GetType()))
                {
                    //si el tipo de dato es igual lo puede añadir
                    columns[i].GetList().Add(list[i]);
                }
                else
                {
                    //los tipos de datos de la columna y de la lista son difernetes
                    Console.Write("TIPOS DE DATOS DIFERNETES");
                }

            }

        }

       

        public void Insert()
        {
            //añadir un unico valor a una tabla



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

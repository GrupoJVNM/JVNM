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

        //solo una condición en el select()
        public List<List<String>> Select(List<String> selectedC, DataComparator compare, TableColumn condiC, String value) 
        {
            List<List<String>> allSelected = new List<List<String>>();

            for(int i=0; i<condiC.GetList().Count; i++)
            {
                //SE puede crear una lista donde se guarden los idnices que cumplan la condicion

                if(condiC.GetList()[i] == value )
                {
                    for(int j=0; j < selectedC.Count; j++)
                    {
                        List<String> listaFila = new List<String>();

                        TableColumn t = columns.Find(column => column.getColumnName() == selectedC[j]);
                        
                        listaFila.Add(t.GetList()[i]);
                        allSelected.Add(listaFila);
                    }
                }
            }

            return allSelected;
        }

        public List<String> SelectAll()//aqui solo se manda la condicion
        {



            return null;
        }

        public void AddColumn(String name, DataType type)
        {
            TableColumn newColumn = new TableColumn(name, type);
            columns.Add(newColumn);
        }
        public void DeleteTuple(TableColumn tc, String date)
        {
           
         //pasamos un dato (clave principal) y lo buscamos en la tabla columna de la tabla que nos pasan
            for (int i=0; i<tc.GetList().Count; i++)
            {
                if (tc.GetList()[i].Equals(date) )
                {

                    for (int j = 0; j < columns.Count(); j++)
                    {

                        columns[j].GetList().RemoveAt(i);
                    }
                }
                else
                {
                    Console.WriteLine("NO SE HA ENCONTRADO EL DATO");
                }
            }
        }
              

        public List<TableColumn> getListTableColumn()
        {
            return columns;
        }
        
        public String getColumnName()
        {
            return;
        }

    }
}

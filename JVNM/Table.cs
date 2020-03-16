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
                if (int.TryParse(list[i], out int a) && columns[i].getType().Equals("Int")) {
                    columns[i].Add(list[i]);
            }

                
                    if (double.TryParse(list[i], out double b) && columns[i].getType().Equals("Double"))
                    {
                        columns[i].Add(list[i]);
                    }
                   

                    if (columns[i].getType().Equals("Text") && list[i]!=null)
                {
                   
                    columns[i].Add(list[i]);
                }
                else
                {
                    //los tipos de datos de la columna y de la lista son difernetes
                    Console.Write("TIPOS DE DATOS DIFERENTES");
                }

            }

        }

        //solo una condición en el select()
        public List<List<String>> Select(List<String> selectedC, DataComparator compare, TableColumn condiC, String value) 
        {
            List<List<String>> allSelected = new List<List<String>>();
            String dateT = condiC.getType();
            List<String> listaFila = new List<String>();

            for (int i=0; i<condiC.GetList().Count; i++)
            {
                //SE puede crear una lista donde se guarden los idnices que cumplan la condicion
                if (compare== DataComparator.Equal)
                {
                    if (condiC.GetList()[i] == value)
                    {
                        for (int j = 0; j < selectedC.Count; j++)
                        {
                            

                            TableColumn t = columns.Find(column => column.getColumnName().Equals(selectedC[j]));

                            listaFila.Add(t.GetList()[i]);
                            allSelected.Add(listaFila);
                        }
                    }
                }
                else if (compare == DataComparator.Bigger)
                {
                    if (dateT.Equals("Int"))
                    {
                        if (int.Parse(condiC.GetList()[i]) > int.Parse(value))
                        {
                            for (int j = 0; j < selectedC.Count; j++)
                            {
                                
                                TableColumn t = columns.Find(column => column.getColumnName().Equals(selectedC[j]));

                                listaFila.Add(t.GetList()[i]);
                                allSelected.Add(listaFila);
                            }
                        }
                    }
                    else if(dateT.Equals("Double"))
                    {
                        if (double.Parse(condiC.GetList()[i]) > double.Parse(value))
                        {
                            for (int j = 0; j < selectedC.Count; j++)
                            {
                               
                                TableColumn t = columns.Find(column => column.getColumnName().Equals(selectedC[j]));

                                listaFila.Add(t.GetList()[i]);
                                allSelected.Add(listaFila);
                            }
                        }

                    }             

                }
                else //"Less"
                {
                    if (dateT.Equals("Int"))
                    {
                        if (int.Parse(condiC.GetList()[i]) < int.Parse(value))
                        {
                            for (int j = 0; j < selectedC.Count; j++)
                            {
                                
                                TableColumn t = columns.Find(column => column.getColumnName().Equals(selectedC[j]));

                                listaFila.Add(t.GetList()[i]);
                                allSelected.Add(listaFila);
                            }
                        }
                    }
                    else if (dateT.Equals("Double"))
                    {
                        if (double.Parse(condiC.GetList()[i]) < double.Parse(value))
                        {
                            for (int j = 0; j < selectedC.Count; j++)
                            {
                                
                                TableColumn t = columns.Find(column => column.getColumnName().Equals(selectedC[j]));

                                listaFila.Add(t.GetList()[i]);
                                allSelected.Add(listaFila);
                            }
                        }

                    }

                }
               
            }

            return allSelected;
        }

        public List<List<String>> SelectAll(DataComparator compare, TableColumn condiC, String value)//aqui solo se manda la condicion
        {
            List<List<String>> allSelected = new List<List<String>>();
            String dateT = condiC.getType();
            List<String> listaFila = new List<String>();

           
                for (int i = 0; i < condiC.GetList().Count; i++)
                {
                    //SE puede crear una lista donde se guarden los idnices que cumplan la condicion
                    if (compare == DataComparator.Equal)
                    {
                        if (condiC.GetList()[i] == value)
                        {
                            for (int j = 0; j < columns.Count; j++)
                            {
                                
                                listaFila.Add(columns[j].GetList()[i]);

                                
                            }
                            allSelected.Add(listaFila);
                        }
                    }

                    else if (compare == DataComparator.Bigger)
                    {
                       
                        if (dateT.Equals("Int"))
                        {
                            if (int.Parse(condiC.GetList()[i]) > int.Parse(value))
                            {
                                for (int j = 0; j < columns.Count; j++)
                                {
                                   
                                    listaFila.Add(columns[j].GetList()[i]);
                                    
                                }
                                allSelected.Add(listaFila);
                            }
                        }
                        else if (dateT.Equals("Double"))
                        {
                            if (double.Parse(condiC.GetList()[i]) > double.Parse(value))
                            {
                                for (int j = 0; j < columns.Count; j++)
                                {

                                    
                                    listaFila.Add(columns[j].GetList()[i]);
                                    
                                }
                                allSelected.Add(listaFila);
                            }

                        }

                    }
                    else //"Less"
                    {
                       
                        if (dateT.Equals("Int"))
                        {
                            if (int.Parse(condiC.GetList()[i]) < int.Parse(value))
                            {
                                for (int j = 0; j < columns.Count; j++)
                                {

                                   
                                    listaFila.Add(columns[j].GetList()[i]);
                                    
                                }
                                allSelected.Add(listaFila);
                            }
                        }
                        else if (dateT.Equals("Double"))
                        {
                            if (double.Parse(condiC.GetList()[i]) < double.Parse(value))
                            {
                               
                                for (int j = 0; j < columns.Count; j++)
                                {

                                    
                                    listaFila.Add(columns[j].GetList()[i]);
                                    
                                }
                                allSelected.Add(listaFila);
                            }

                        }

                    }

                }
            
            

            return allSelected;
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
              

        public List<List<String>> selectAllWithOutC()
        {
            List<String> listaFila = new List<String>();
            List<List<String>> allSelected = new List<List<string>>();

                for (int i = 0; i < columns[0].GetList().Count; i++)
                {

                    for (int j = 0; j < columns.Count; j++)
                    {
                        listaFila.Add(columns[j].GetList()[i]);

                    }
                    allSelected.Add(listaFila);

                }

            return allSelected;
        }

        
        public List<TableColumn> getListTableColumn()
        {
            return columns;
        }
       
        public String getTableName()
        {
            return name;
        }
    }
}

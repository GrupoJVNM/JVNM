using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JVNM
{
    public class TableColumn
    {
        public String Name;
        public DataType Type;
        public List<String> DataList;

        public TableColumn(String name, DataType dataType)
        {
            Name = name;
            Type = dataType;
            DataList = new List<String>();
        }

        public void Add(String data)
        {
            DataList.Add(data);
        }

        public Boolean Delete(String data)
        {
            //Al borrar NO reducir el tamaño de la lista, simplemente dejar el valor en blanco
            Boolean result = false;
            
         
            //find data
            for (int i = 0; i < DataList.Count; i++)
            {
                if (DataList[i] == data)
                {


                    DataList[i] = null;
                    
                    
                }
                
                
                result = true;
                //delete data
            }

            return result;
        }

        public void Update(String data, String newData)
        {            
            for (int i = 0; i < DataList.Count; i++)
            {
                if(DataList[i] == data)
                {
                    DataList[i] = newData;
                }
            }            
        }

        public List<String> GetList()
        {
            return DataList;
        }

        public String GetTypeC()
        {
            return Type.ToString();
        }

        public String GetColumnName()
        {
            return Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JVNM
{
    public class TableColumn
    {
        String name;
        DataType type;
        List<String> dataList;

        public TableColumn(String name, DataType dataType)
        {
            this.name = name;
            this.type = dataType;
            dataList = new List<String>();
        }

        public void Add(String data)
        {
            dataList.Add(data);
        }

        public Boolean Delete(String data)
        {
            //Al borrar NO reducir el tamaño de la lista, simpelemente dejar el valor en blanco
            Boolean result = false;
            //find date
            for (int i = 0; i < dataList.Count; i++)
            {
                //delete date
            }

            return result;
        }

        public void Update(String data, String newData)
        {            
            for (int i = 0; i < dataList.Count; i++)
            {
                if(dataList[i] == data)
                {
                    dataList[i] = newData;
                }
            }            
        }

        public List<String> GetList()
        {
            return dataList;
        }

        public String getType()
        {
            return type.ToString();
        }

        public String getColumnName()
        {
            return name;
        }
    }
}

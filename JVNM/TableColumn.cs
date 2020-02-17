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

        public List<String> Add(String data)
        {
            dataList.Add(data);
            return dataList;
        }

        public Boolean Delete(String data)
        {
            Boolean result=false;
            //find date
            for(int i=0; i < dataList.Count; i++ )
            {
                //delete date
            }

            return result;
        }

        public List<String> Update(String data)
        {
            //find date
            //update date
            return dataList;
        }
    }



}

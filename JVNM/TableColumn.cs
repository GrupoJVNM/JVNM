using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
    public class TableColumn
    {
        List<DataType> dataList;

        public TableColumn()
        {
            dataList = new List<DataType>();
        }

        public List<DataType> Add(DataType date)
        {
            dataList.Add(date);
            return dataList;
        }

        public Boolean Delete(DataType date)
        {
            Boolean result=false;
            //find date
            for(int i=0; i < dataList.Count; i++ )
            {
                //delete date
            }

            return result;
        }

        public List<DataType> Update(DataType date)
        {
            //find date
            //update date
            return dataList;
        }
    }



}

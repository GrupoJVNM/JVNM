using System;
using System.Collections.Generic;
using JVNM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestTable
    {
        
        

        [TestMethod]

       public void AddTuple()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn columnInt = new TableColumn("columnInt", DataType.Int);
            TableColumn columnDouble = new TableColumn("columnInt", DataType.Double);
            TableColumn columnText = new TableColumn("columnInt", DataType.Text);
            List<String> list2 = new List<String>();
            columnList.Add(columnInt);
            columnList.Add(columnDouble);
            columnList.Add(columnText);
            Table table = new Table("myTable", columnList);


         

            list2.Add("18");
            list2.Add("22,6");
            list2.Add("Vghv");
            //table.AddTuple(list2);
            Assert.IsTrue(table.getListTableColumn().Count==3);

        }
        [TestMethod]
        public void AlterTable()
        {
            
            table.AlterTable();
        }
        [TestMethod]
        public void Insert()
        {
            
            table.Insert();
        }
        [TestMethod]
        public void Select()
        {
            
            table.Select();
        }
        [TestMethod]
        public void AddColumn()
        {
            
            table.AddColumn();
        }
        [TestMethod]
        public void Delete()
        {
          
            table.Delete();
        }
    }
}


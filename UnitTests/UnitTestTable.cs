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
            table.getListTableColumn()[0].GetList().Add("18");
            int num = int.Parse(table.getListTableColumn()[0].GetList()[0]);
            table.getListTableColumn()[1].GetList().Add("22,6");
            double num2 = double.Parse(table.getListTableColumn()[1].GetList()[0]);
            table.getListTableColumn()[2].GetList().Add("Vghv");
            String num3 = (table.getListTableColumn()[2].GetList()[0]);
            Assert.IsTrue(table.getListTableColumn().Count == 3);
            Assert.AreEqual(18, num);
            Assert.AreEqual(22,6, num2);
            Assert.AreEqual("Vghv", num3);
            

       }
        [TestMethod]
        public void Select()
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
           
        }
        [TestMethod]
        public void AddColumn()
        {
            List<TableColumn> columnList = new List<TableColumn>();
            Table table = new Table("myTable", columnList);
            table.AddColumn("column1", DataType.Text);
            Assert.IsTrue(columnList.Count == 1);
            Assert.IsNotNull(columnList);
            Assert.AreEqual(columnList[0].getColumnName(), "column1");

            table.AddColumn("column2", DataType.Int);
            Assert.AreEqual(columnList[1].getColumnName(), "column2");
            Assert.AreEqual(columnList[0].getColumnName(), "column1");

        }
        [TestMethod]
        public void Delete()
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
          
        }
    }
}


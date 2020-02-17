using System;
using System.Collections.Generic;
using JVNM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestTable
    {
        
        List<TableColumn> columnList = new List<TableColumn>();
        
        TableColumn columnInt = new TableColumn("columnInt", DataType.Int);
        TableColumn columnDouble = new TableColumn("columnInt", DataType.Double);
        TableColumn columnText = new TableColumn("columnInt", DataType.Text);
        List<String> list2 = new List<String>();
        
        
        [TestMethod]

       public void AddTuple()
        {
            columnList.Add(columnInt);
            columnList.Add(columnDouble);
            columnList.Add(columnText);
            Table table = new Table("myTable", columnList);

            list2.Add("18");
            list2.Add("22,6");
            list2.Add("Vghv");
            table.AddTuple(list2);

        }
        [TestMethod]
        public void AlterTable()
        {
            Table table = new Table("myTable", columnList);
            table.AlterTable();
        }
        [TestMethod]
        public void Insert()
        {
            Table table = new Table("myTable", columnList);
            table.Insert();
        }
        [TestMethod]
        public void Select()
        {
            Table table = new Table("myTable", columnList);
            table.Select();
        }
        [TestMethod]
        public void AddColumn()
        {
            Table table = new Table("myTable", columnList);
            table.AddColumn();
        }
        [TestMethod]
        public void Delete()
        {
            Table table = new Table("myTable", columnList);
            table.Delete();
        }
    }
}


using System;
using System.Collections.Generic;
using JVNM;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTests
{
    [TestClass]
    public class TestTableColumn
    {
        TableColumn column = new TableColumn("Name", DataType.Text);
        public List<String> DataList;
        

        [TestMethod]
        public void TestAdd()
        {
            column.Add("Itxaso");
            DataList = column.GetList();
            Assert.IsTrue(DataList.Count == 1);
            Assert.IsNotNull(DataList);
            Assert.AreEqual(DataList[0], "Itxaso");

            column.Add("Ana");
            DataList = column.GetList();
            Assert.IsTrue(DataList.Count == 2);
            Assert.AreEqual(DataList[1], "Ana");

            column.Add(null);
            DataList = column.GetList();
            Assert.IsTrue(DataList.Count == 3);
            Assert.AreEqual(DataList[2], null);

            column.Add("Gaizka");
            DataList = column.GetList();
            Assert.IsTrue(DataList.Count == 4);
            Assert.AreEqual(DataList[3], "Gaizka");

        }

        [TestMethod]
        public void TestDelete1()
        {
            column.Add("Ixtaso");
            column.Add("Ane");
            column.Add(null);
            column.Add("Gaizka");

            column.Delete("Ane");
            DataList = column.GetList();
            Assert.IsTrue(DataList.Count == 4);
            Assert.IsFalse(DataList[1] == "Ane");
            Assert.AreEqual(DataList[1], null);

            column.Delete("Uxue");
            DataList = column.GetList();
            Assert.IsTrue(DataList.Count == 4);

        }

        [TestMethod]
        public void TestUpdate1()
        {
            column.Add("Ixtaso");
            column.Add("Ane");
            column.Add(null);
            column.Add("Gaizka");
    
            column.Update("Ane", "AnaMaria");
            DataList = column.GetList();
            Assert.IsTrue(DataList.Count == 4);
            Assert.AreNotEqual(DataList[1], "Ane");
            Assert.AreEqual(DataList[1], "AnaMaria");

            column.Update("Uxue", "Patri");
            DataList = column.GetList();
            Assert.IsTrue(DataList.Count == 4);
            
        }
    }
}

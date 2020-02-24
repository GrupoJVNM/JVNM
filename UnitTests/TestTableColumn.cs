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
        List<String> dataList;
        

        [TestMethod]
        public void TestAdd()
        {
            column.Add("Itxaso");
            dataList = column.GetList();
            Assert.IsTrue(dataList.Count == 1);
            Assert.IsNotNull(dataList);
            Assert.AreEqual(dataList[0], "Itxaso");

            column.Add("Ana");
            dataList = column.GetList();
            Assert.IsTrue(dataList.Count == 2);
            Assert.AreEqual(dataList[1], "Ane");

            column.Add(null);
            dataList = column.GetList();
            Assert.IsTrue(dataList.Count == 3);
            Assert.AreEqual(dataList[2], "");

            column.Add("Gaizka");
            dataList = column.GetList();
            Assert.IsTrue(dataList.Count == 4);
            Assert.AreEqual(dataList[3], "Gaizka");

        }

        [TestMethod]
        public void TestDelete1()
        {
            column.Add("Ixtaso");
            column.Add("Ane");
            column.Add(null);
            column.Add("Gaizka");

            column.Delete("Ane");
            dataList = column.GetList();
            Assert.IsTrue(dataList.Count == 4);
            Assert.IsFalse(dataList[1] == "Ane");
            Assert.AreEqual(dataList[1], "");

            column.Delete("Uxue");
            dataList = column.GetList();
            Assert.IsTrue(dataList.Count == 4);

        }

        [TestMethod]
        public void TestUpdate1()
        {
            column.Add("Ixtaso");
            column.Add("Ane");
            column.Add(null);
            column.Add("Gaizka");
    
            column.Update("Ane", "AnaMaria");
            dataList = column.GetList();
            Assert.IsTrue(dataList.Count == 4);
            Assert.AreNotEqual(dataList[1], "Ane");
            Assert.AreEqual(dataList[1], "AnaMaria");

            column.Update("Uxue", "Patri");
            dataList = column.GetList();
            Assert.IsTrue(dataList.Count == 4);
            
        }
    }
}

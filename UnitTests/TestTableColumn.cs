using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TestTableColumn
    {
        List<DataType> dataList = new dataList() { Ana, Mario, Juan };

        [TestMethod]
        public void TestAdd()
        {
            dataList.Add("Itxaso");
            Assert.AreEquals();

        }

        [TestMethod]
        public void TestDelete()
        {

        }

        [TestMethod]
        public void TestUpdate()
        {

        }
    }
}

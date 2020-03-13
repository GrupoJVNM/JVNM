using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JVNM;
using System.Collections.Generic;

namespace UnitTests
{
    
    [TestClass]
    public class TestDatabase
    {

        Database db = new Database("myDatabase", "username", "password");
        public List <Table> tables;

        [TestMethod]
        public void TestLoad()
        {

            //db.Load(); 
        }
        [TestMethod]
        public void TestSave()
        {
            //db.Save();
        }
        [TestMethod]
        public void TestAddTable()
        {
           // db.AddTable(table);
        }
        [TestMethod]
        public void TestDeleteTable()
        {
          //  db.DeleteTable(tables);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JVNM;
using System.Collections.Generic;

namespace UnitTests
{
    
    [TestClass]
    public class TestDatabase
    {

        Database db = new Database("bd1", "username", "password");
        public List <Table> tables;

        [TestMethod]
        public void TestLoad()
        {

             db.Load("bd1"); 
        }
        [TestMethod]
        public void TestSave()
        {
            db.Load("bd1");
            List<TableColumn> li = new List<TableColumn>();
            Table t1 = new Table("empleados",li);
            db.AddTable(t1);

            db.DeleteTable(t1);
            db.Save("bd1");
            db.Close("bd1");

            //COMPROBAMOS
            db.Load("bd1");
            if(  db.getList().Find(tables => tables.getTableName().Equals(t1)) == null)
            {
                Console.WriteLine("Lo ha borrado");
            }


        }
        [TestMethod]
        public void TestAddTable()
        {
            db.Load("bd1");
            List<TableColumn> li = new List<TableColumn>();
            Table t1 = new Table("empleados", li);
            db.AddTable(t1);

    
            //COMPROBAMOS
          
            if (db.getList().Find(tables => tables.getTableName().Equals(t1)) !=null )
            {
                Console.WriteLine("Se ha creado");
            }


        }
        [TestMethod]
        public void TestDeleteTable()
        {
            db.Load("bd1");
            List<TableColumn> li = new List<TableColumn>();
            Table t1 = new Table("empleados", li);
            db.AddTable(t1);

            db.DeleteTable(t1);
           
            //COMPROBAMOS
          
            if (db.getList().Find(tables => tables.getTableName().Equals(t1)) == null)
            {
                Console.WriteLine("Lo ha borrado");
            }
        }
    }
}

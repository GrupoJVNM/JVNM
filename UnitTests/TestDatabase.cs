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
            List<TableColumn> columnasT1 = new List<TableColumn>();
            Table t1 = new Table("empleados",columnasT1);
            TableColumn tc1 = new TableColumn("nombre", DataType.Text);
            tc1.GetList().Add("Ana");
            columnasT1.Add(tc1);

            List<TableColumn> columnasT2 = new List<TableColumn>();
            Table t2 = new Table("directores", columnasT2);
            TableColumn tc2 = new TableColumn("nombres", DataType.Text);
            tc2.GetList().Add("Fran");
            columnasT2.Add(tc2);
            

          

            db.AddTable(t1);
            db.AddTable(t2);
            db.DeleteTable(t2);
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

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JVNM;
using System.Collections.Generic;

namespace UnitTests
{
    
    [TestClass]
    public class TestDatabase
    {

        Database Db = new Database("bd1", "username", "password");
        public List <Table> Tables;

        [TestMethod]
        public void TestLoad()
        {

            Db.Load("bd1"); 
        }
        [TestMethod]
        public void TestSave()
        {
            Db.Load("bd1");
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




            Db.AddTable(t1);
            Db.AddTable(t2);
            Db.DeleteTable(t2);
            Db.Save("bd1");
            Db.Close("bd1");

            //COMPROBAMOS
            Db.Load("bd1");
            if(Db.getList().Find(tables => tables.getTableName().Equals(t1)) == null)
            {
                Console.WriteLine("Lo ha borrado");
            }


        }
        [TestMethod]
        public void TestAddTable()
        {
            Db.Load("bd1");
            List<TableColumn> li = new List<TableColumn>();
            Table t1 = new Table("empleados", li);
            Db.AddTable(t1);

    
            //COMPROBAMOS
          
            if (Db.getList().Find(tables => tables.getTableName().Equals(t1)) !=null )
            {
                Console.WriteLine("Se ha creado");
            }


        }
        [TestMethod]
        public void TestDeleteTable()
        {
            Db.Load("bd1");
            List<TableColumn> li = new List<TableColumn>();
            Table t1 = new Table("empleados", li);
            Db.AddTable(t1);

            Db.DeleteTable(t1);
           
            //COMPROBAMOS
          
            if (Db.getList().Find(tables => tables.getTableName().Equals(t1)) == null)
            {
                Console.WriteLine("Lo ha borrado");
            }
        }
    }
}

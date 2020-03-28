using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JVNM;
using System.Collections.Generic;
using System.IO;

namespace UnitTests
{
    
    [TestClass]
    public class TestDatabase
    {

        Database Db = new Database("bd1", "username", "password");
        public List <Table> Tables;

        [TestMethod]
        public void TestCreate()
        {
            string path = @"../Debug/MyDB_CODIGO/bd1.txt";
            Db.Create("bd1");
            Assert.IsTrue(File.Exists(path));
            
        }

        [TestMethod]
        public void TestLoad()
        {
            Db.Create("bd4");
            Db.Close("bd4");

            List<TableColumn> columnasT1 = new List<TableColumn>();
            Table t1 = new Table("empleados", columnasT1);
            TableColumn tc1 = new TableColumn("nombre", DataType.Text);
            tc1.GetList().Add("Ana");
            columnasT1.Add(tc1);
            Db.AddTable(t1);
            Db.Load("bd4");
            Assert.IsTrue(Db.GetList().Find(tables => tables.GetTableName().Equals(t1)) == null);

            List<TableColumn> columnasT2 = new List<TableColumn>();
            Table t2 = new Table("empleados", columnasT2);
            TableColumn tc2 = new TableColumn("nombre", DataType.Text);
            tc2.GetList().Add("Ana");
            columnasT2.Add(tc2);
            Db.AddTable(t2);
            Assert.IsFalse(Db.GetList().Find(tables => tables.GetTableName().Equals(t2)) == null);

        }
        [TestMethod]
        public void TestSave()
        {
            Db.Create("bd2");
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
            Db.Save("bd2");
            Db.Close("bd2");

            //COMPROBAMOS
            Db.Load("bd2");
            if(Db.GetList().Find(tables => tables.GetTableName().Equals(t1)) != null)
            {
                Console.WriteLine("Lo ha guardado");
            }


        }
        [TestMethod]
        public void TestAddTable()
        {
            Db.Create("bd3");
            List<TableColumn> li = new List<TableColumn>();
            Table t1 = new Table("empleados", li);
            Db.AddTable(t1);

    
            //COMPROBAMOS
          
            if (Db.GetList().Find(tables => tables.GetTableName().Equals(t1)) !=null )
            {
                Console.WriteLine("Se ha creado");
            }


        }
        [TestMethod]
        public void TestClose()
        {
            Db.Create("bd6");

        }
        //[TestMethod]
        //public void TestDeleteTable()
        //{
        //    Db.Load("bd1");
        //    List<TableColumn> li = new List<TableColumn>();
        //    Table t1 = new Table("empleados", li);
        //    Db.AddTable(t1);

        //    Db.DeleteTable(t1);

        //    //COMPROBAMOS

        //    if (Db.GetList().Find(tables => tables.GetTableName().Equals(t1)) == null)
        //    {
        //        Console.WriteLine("Lo ha borrado");
        //    }
        //}
    }
}

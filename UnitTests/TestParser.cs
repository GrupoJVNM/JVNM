using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JVNM;




namespace UnitTests
{
    [TestClass]
   public class TestParser          //***********************************************************
                                            //CUIDADO CON ESPACIOS EN LAS SENTENCIAS!!!!!!!
                                    //********************************************************
    {
        [TestMethod]
        public void TestSelect()
        {
            Database db = new Database("bd1", "user", "password");
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("SELECT Name, Age FROM Employees_Personal WHERE Age>17;");
            Assert.IsInstanceOfType(q1, typeof(Select));
        }
        [TestMethod]
        public void TestSelectAll()
        {
            Database db = new Database("bd1", "user", "password");
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("SELECT * FROM Employees_Personal WHERE Age>17;");
            Assert.IsInstanceOfType(q1, typeof(SelectAll));
        }
        [TestMethod]
        public void TestSelectWithOutC()
        {
            Database db = new Database("bd1", "user", "password");
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("SELECT Name,Age FROM Employees_Personal;");
            Assert.IsInstanceOfType(q1, typeof(SelectWithOutC));
        }
        [TestMethod]
        public void TestSelectAllWithOutC()
        {
            Database db = new Database("bd1", "user", "password");
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("SELECT * FROM Employees_Personal;");
            Assert.IsInstanceOfType(q1, typeof(SelectAllWithOutC));
        }

        [TestMethod]
        public void TestDelete()
        {
            Database db = new Database("bd1", "user", "password");
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("DELETE FROM Employees_Personal WHERE Age=18;");
            Assert.IsInstanceOfType(q1, typeof(DeleteTuple));
        }
        [TestMethod]
        public void Testinsert()
        {
            Database db = new Database("bd1", "user", "password");
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("INSERT INTO Employees_Personal VALUES ('Eva',5);");
            Assert.IsInstanceOfType(q1, typeof(Insert));
        }
        [TestMethod]
        public void TestUpdate()
        {
            Database db = new Database("bd1", "user", "password");
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("UPDATE Employees_Personal SET Name='Ana' WHERE Age=15;");
            Assert.IsInstanceOfType(q1, typeof(Update));
        }

        [TestMethod]
        public void TestDrop()
        {
            Database db = new Database("bd1", "user", "password");
            Parser.Parse("CREATE TABLE Employees (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("DROP TABLE Employees;");
            Assert.IsInstanceOfType(q1, typeof(DropTable));
        }



    }
}

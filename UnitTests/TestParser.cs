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
    public class TestParser          
    {
        [TestMethod]
        public void TestSelect()
        {
            
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("SELECT Name, Age FROM Employees_Personal WHERE Age>17;");
            Assert.IsInstanceOfType(q1, typeof(Select));
        }


        [TestMethod]
        public void TestSelect_Error()
        {
           
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("SELECT * FROM Employees_Personal WHERE Age>17;");
            Assert.IsNotInstanceOfType(q1, typeof(Select));
        }


        [TestMethod]
        public void TestSelectAll()
        {
        
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("SELECT * FROM Employees_Personal WHERE Age>17;");
            Assert.IsInstanceOfType(q1, typeof(SelectAll));
        }

        [TestMethod]
        public void TestSelectAll_Error()
        {
           
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("SELECT * FROM Employees_Personal;");
            Assert.IsNotInstanceOfType(q1, typeof(SelectAll));
        }

        [TestMethod]
        public void TestSelectWithOutC()
        {
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("SELECT Name,Age FROM Employees_Personal;");
            Assert.IsInstanceOfType(q1, typeof(SelectWithOutC));
        }

        [TestMethod]
        public void TestSelectWithOutC_Error()
        {
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("SELECT * FROM Employees_Personal;");
            Assert.IsNotInstanceOfType(q1, typeof(SelectWithOutC));
        }

        [TestMethod]
        public void TestSelectAllWithOutC()
        {
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("SELECT * FROM Employees_Personal;");
            Assert.IsInstanceOfType(q1, typeof(SelectAllWithOutC));
        }

        [TestMethod]
        public void TestSelectAllWithOutC_Error()
        {
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("SELECT * FROM Employees_Personal WHERE Age=5;");
            Assert.IsNotInstanceOfType(q1, typeof(SelectAllWithOutC));
        }

        [TestMethod]
        public void TestDelete()
        {
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("DELETE FROM Employees_Personal WHERE Age=18;");
            Assert.IsInstanceOfType(q1, typeof(DeleteTuple));
        }

        [TestMethod]
        public void TestDelete_Error()
        {
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("SELECT * FROM Employees_Personal WHERE Age=5;");
            Assert.IsNotInstanceOfType(q1, typeof(DeleteTuple));
        }


        [TestMethod]
        public void TestInsert()
        {
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("INSERT INTO Employees_Personal VALUES ('Eva',5);");
            Assert.IsInstanceOfType(q1, typeof(Insert));
        }

        [TestMethod]
        public void TestInsert_Error()
        {
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("SELECT * FROM Employees_Personal WHERE Age=5;");
            Assert.IsNotInstanceOfType(q1, typeof(Insert));
        }
       
        
        [TestMethod]
        public void TestUpdate()
        {
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("UPDATE Employees_Personal SET Name='Ana' WHERE Age=15;");
            Assert.IsInstanceOfType(q1, typeof(Update));
        }

        [TestMethod]
        public void TestUpdate_Error()
        {
            Parser.Parse("CREATE TABLE Employees_Personal (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("SELECT * FROM Name;");
            Assert.IsNotInstanceOfType(q1, typeof(Update));
        }


        [TestMethod]
        public void TestDrop()
        {
            Parser.Parse("CREATE TABLE Employees (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("DROP TABLE Employees;");
            Assert.IsInstanceOfType(q1, typeof(DropTable));
        }

        [TestMethod]
        public void TestDrop_Error()
        {
            Parser.Parse("CREATE TABLE Employees (Name TEXT, Age INT);");
            MiniSQLQuery q1 = Parser.Parse("SELECT * FROM Employees;");
            Assert.IsNotInstanceOfType(q1, typeof(DropTable));
        }

        //CREATE TABLE 
        [TestMethod]
        public void TestCreateTable()
        {
            MiniSQLQuery q1 = Parser.Parse("CREATE TABLE Employees (Name TEXT, Age INT);");
            Assert.IsInstanceOfType(q1, typeof(CreateTable));
        }
        [TestMethod]
        public void TestCreateTable_Error()
        {
            MiniSQLQuery q1 = Parser.Parse("DROP TABLE Employees;");
            Assert.IsNotInstanceOfType(q1, typeof(CreateTable));
        }


        //CREATE SECURITY
        [TestMethod]
        public void TestCreateSecurity()
        {
            MiniSQLQuery q1 = Parser.Parse("CREATE SECURITY PROFILE Employee;");
            Assert.IsInstanceOfType(q1, typeof(CreateSecurityProfile));

        }
        [TestMethod]
        public void TestCreateSecurity_Error()
        {
            MiniSQLQuery q1 = Parser.Parse("DROP TABLE Employees;");
            Assert.IsNotInstanceOfType(q1, typeof(CreateSecurityProfile));

        }
        [TestMethod]
        public void TestDropSecurityProfile()
        {
            Parser.Parse("CREATE SECURITY PROFILE Employee;");
            MiniSQLQuery q1 = Parser.Parse("DROP SECURITY PROFILE Employee;");
            Assert.IsInstanceOfType(q1, typeof(DropSecurityProfile));

        }
        [TestMethod]
        public void TestDropSecurityProfile_Error()
        {
            Parser.Parse("CREATE SECURITY PROFILE Employee;");
            MiniSQLQuery q1 = Parser.Parse("SELECT * FROM Employee;");
            Assert.IsNotInstanceOfType(q1, typeof(DropSecurityProfile));

        }
        //GRANT
        [TestMethod]
        public void TestGrant()
        {
            Parser.Parse("CREATE SECURITY PROFILE Employee;");
            MiniSQLQuery q1 = Parser.Parse("GRANT UPDATE ON Employees_Public TO Employee;");
            Assert.IsInstanceOfType(q1, typeof(Grant));

        }
        [TestMethod]
        public void TestGrant_Error()
        {
            Parser.Parse("CREATE SECURITY PROFILE Employee;");
            MiniSQLQuery q1 = Parser.Parse("DROP TABLE Employees;");
            Assert.IsNotInstanceOfType(q1, typeof(Grant));

        }

        //REVOKE
        [TestMethod]
        public void TestRevoke()
        {
            Parser.Parse("CREATE SECURITY PROFILE Employee;");
            Parser.Parse("GRANT UPDATE ON Employees_Public TO Employee;");
            MiniSQLQuery q1 = Parser.Parse("REVOKE UPDATE ON Employees_Public TO Employee;");
            Assert.IsInstanceOfType(q1, typeof(Revoke));

        }

        [TestMethod]
        public void TestRevoke_Error()
        {
            Parser.Parse("CREATE SECURITY PROFILE Employee;");
            Parser.Parse("GRANT UPDATE ON Employees_Public TO Employee;");
            MiniSQLQuery q1 = Parser.Parse("GRANT UPDATE ON Employees_Public TO Employee;");
            Assert.IsNotInstanceOfType(q1, typeof(Revoke));

        }

        //ADD USER
        [TestMethod]
        public void TestAddUser()
        {
            Database db = new Database("bd1", "user", "password");
            Parser.Parse("CREATE SECURITY PROFILE Employee;");
            MiniSQLQuery q1 = Parser.Parse("ADD USER ('Eva','1234',Employee);");
            Assert.IsInstanceOfType(q1, typeof(AddUser));

        }
        [TestMethod]
        public void TestAddUser_Error()
        {
            Database db = new Database("bd1", "user", "password");
            Parser.Parse("CREATE SECURITY PROFILE Employee;");
            MiniSQLQuery q1 = Parser.Parse("DELETE USER Eva;");
            Assert.IsNotInstanceOfType(q1, typeof(AddUser));

        }

        [TestMethod]
        public void TestDeleteUser()
        {
            Database db = new Database("bd1", "user", "password");
            Parser.Parse("CREATE SECURITY PROFILE Employee;");
            Parser.Parse("ADD USER ('Eva','1234',Employee);");
            MiniSQLQuery q1 = Parser.Parse("DELETE USER Eva;");
            Assert.IsInstanceOfType(q1, typeof(DeleteUser));

        }
        [TestMethod]
        public void TestDeleteUser_Error()
        {
            Database db = new Database("bd1", "user", "password");
            Parser.Parse("CREATE SECURITY PROFILE Employee;");
            Parser.Parse("ADD USER ('Eva','1234',Employee);");
            MiniSQLQuery q1 = Parser.Parse("ADD USER ('Eva','1234',Employee);");
            Assert.IsNotInstanceOfType(q1, typeof(DeleteUser));

        }

    }
}

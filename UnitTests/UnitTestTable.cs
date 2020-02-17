using System;
using System.Collections.Generic;
using JVNM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestTable
    {
        public List<TableColumn> list = new List<TableColumn>();
        [TestMethod]

       public void AddTuple()
        {
            
            list.Add("Nombre");
            list.Add("Apellido");
            Table table = new Table("myTable", List<TableColumn> ) 
           
        }
    }
}

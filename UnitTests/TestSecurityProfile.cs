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
    public class TestSecurityProfile
    {
        [TestMethod]
        public void GrantTest()
        {
            SecurityProfile sp = new SecurityProfile("Persona");
            sp.Grant("Mascota", "SELECT");
            Assert.IsTrue(sp.Privilege.Contains("SELECT"));
            Assert.IsTrue(sp.Tables.Contains("Mascota"));
        }

        [TestMethod]
        public void RevokeTest()
        {
            SecurityProfile sp = new SecurityProfile("Persona");
            sp.Grant("Mascota", "SELECT");
            sp.Grant("Viaje", "DELETE");
            sp.Revoke("Mascota", "SELECT");

            Assert.IsTrue(sp.Privilege.Contains("DELETE"));
            Assert.IsTrue(sp.Tables.Contains("Viaje"));

            Assert.IsFalse(sp.Privilege.Contains("SELECT"));
            Assert.IsFalse(sp.Tables.Contains("Mascota"));
        }

    }
}

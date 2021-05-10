using Microsoft.VisualStudio.TestTools.UnitTesting;
using videoRental3Assign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videoRental3Assign.Tests
{
    [TestClass()]
    public class SoftForm2Tests
    {
        [TestMethod()]
        public void SoftForm2Test()
        {
            SoftForm2 obj = new SoftForm2();
            if (obj.fetchcost(1) > 0)
            {
                Assert.IsTrue(true);
            }
            else {
                Assert.IsTrue(false);
            }
            
        }


        [TestMethod()]
        public void SoftForm3Test()
        {
            SoftForm2 obj = new SoftForm2();
            if (obj.chkBooking(1) == 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }

        }

    }
}
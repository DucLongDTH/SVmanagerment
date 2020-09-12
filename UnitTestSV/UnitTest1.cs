using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SVMANAGERMENT;
namespace UnitTestSV
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTinhTuoi()
        {
            long x = 19;
            DateTime ngay = DateTime.Parse("12/12/2000");
            Assert.AreEqual(x, BeCore.TinhTuoi(ngay, DateTime.Now));
        }

        [TestMethod]
        public void TestThemSV()
        {
            // Case 1: return 1 -- khong trung ma, tuoi tu 18-26
            // Case 2: return -1 -- tuoi khong hop le
            // Case 3: return 0 -- ma bi trung
            // Case 4: return 99 - truong nhap rong
            DateTime ngay = DateTime.Parse("12/12/2000");
            Assert.AreEqual(99, BeCore.ThemSV("18001040","Long","Phan", ngay,"HN" , "1515","CNPM1","CNTT"));
        }
    }
}

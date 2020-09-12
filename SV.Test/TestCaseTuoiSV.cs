using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SVMANAGERMENT;

namespace SV.Test
{
    [TestFixture]
    public class TestCaseTuoiSV
    {
        // Case them thanh cong : khong trung ma , tuoi tu 18 - 26 , cac thong tin khac k duoc de trong -- return 1
        // Case trung ma -- return 0 
        // Case tuoi khong hop le !(18-26) -- return -1
        [Test]
        public void ThemSV1()
        {
            // SV : [18001040,Long, Phan , 12/12/2000 , HN , 11234 , CNPM1 , CNTT ]
            string masv = "18001040";
            string tensv = "Long";
            string hodem = "Phan";
            string diachi = "HN";
            string sdt = "11234";
            string malop = "CNPM";
            string makhoa = "CNTT";
            DateTime ngaysinh = DateTime.Parse("12/12/2000");
            //Assert.AreNotEqual(1, BeCore.ThemSV(masv,tensv,hodem,ngaysinh,diachi,sdt,malop,makhoa));
            Assert.AreEqual(20, BeCore.TinhTuoi(ngaysinh, DateTime.Now));
        }
    }
}

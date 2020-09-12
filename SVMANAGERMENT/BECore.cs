using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SVMANAGERMENT
{
    public class BeCore
    {
        public static SqlConnection ketnoi;
        public static SqlCommand cmd;
        public static SqlDataAdapter sqladapter;
        public static string sqlconnect = @"Data Source=.;Initial Catalog=SVMANAGERMENT;Integrated Security=True";

        public static int CheckLogin(string tk , string mk)
        {
            if(tk == "" || mk == "")
            {
                return 0;
            }
            else
            {
                ketnoi = new SqlConnection(sqlconnect);
                ketnoi.Open();
                cmd = new SqlCommand("Select Count(*) From NguoiDung Where username = @tk and password = @mk", ketnoi);
                cmd.Parameters.Add(new SqlParameter("@tk", tk));
                cmd.Parameters.Add(new SqlParameter("@mk", mk));
                int check = int.Parse(cmd.ExecuteScalar().ToString());
                ketnoi.Close();
                return check;
            }
        }

        public static DataSet getKhoa()
        {
            ketnoi = new SqlConnection(sqlconnect);
            DataSet data = new DataSet();
            cmd = new SqlCommand(" Select * From Khoa", ketnoi);
            sqladapter = new SqlDataAdapter(cmd);
            sqladapter.Fill(data,"Khoa");
            return data;
        }
        public static DataSet getLop(string tenkhoa)
        {
            ketnoi = new SqlConnection(sqlconnect);
            DataSet data = new DataSet();
            cmd = new SqlCommand(" Select * From Lop Where MaKhoa = @makhoa", ketnoi);
            cmd.Parameters.Add(new SqlParameter("@makhoa", tenkhoa));
            sqladapter = new SqlDataAdapter(cmd);
            sqladapter.Fill(data, "Lop");
            return data;
        }

        public static DataSet getMonHoc(string tenkhoa)
        {
            ketnoi = new SqlConnection(sqlconnect);
            DataSet data = new DataSet();
            cmd = new SqlCommand(" Select * From MonHoc Where MaKhoa = @makhoa", ketnoi);
            cmd.Parameters.Add(new SqlParameter("@makhoa", tenkhoa));
            sqladapter = new SqlDataAdapter(cmd);
            sqladapter.Fill(data, "MH");
            return data;
        }
        public static DataSet getSV(string tenlop)
        {
            ketnoi = new SqlConnection(sqlconnect);
            DataSet data = new DataSet();
            if(tenlop == "CNPM1")
            {
                cmd = new SqlCommand("Select * from V_SVCNPM1", ketnoi);
                sqladapter = new SqlDataAdapter(cmd);
                sqladapter.Fill(data, "SV");
                return data;
            }
            else if(tenlop == "CNPM2")
            {
                cmd = new SqlCommand("Select * from V_SVCNPM2", ketnoi);
                sqladapter = new SqlDataAdapter(cmd);
                sqladapter.Fill(data, "SV");
                return data;
            }
            else if(tenlop == "NCQL")
            {
                cmd = new SqlCommand("Select * from V_SVNCQL", ketnoi);
                sqladapter = new SqlDataAdapter(cmd);
                sqladapter.Fill(data, "SV");
                return data;
            }
            else if(tenlop == "QTDN")
            {
                cmd = new SqlCommand("Select * from V_SVQTDN", ketnoi);
                sqladapter = new SqlDataAdapter(cmd);
                sqladapter.Fill(data, "SV");
                return data;
            }
            return data;
        }

        public static DataSet getDiem(string tenlop, string tenmonhoc)
        {
            ketnoi = new SqlConnection(sqlconnect);
            DataSet data = new DataSet();
            if (tenlop == "CNPM1")
            {
                if(tenmonhoc == "DEVC")
                {
                    cmd = new SqlCommand("Select * from cnpm1_devc", ketnoi);
                    sqladapter = new SqlDataAdapter(cmd);
                    sqladapter.Fill(data, "DT");
                    return data;
                }
                else if(tenmonhoc == "CSDL")
                {
                    cmd = new SqlCommand("Select * from cnpm1_csdl", ketnoi);
                    sqladapter = new SqlDataAdapter(cmd);
                    sqladapter.Fill(data, "DT");
                    return data;
                }
            }
            else if (tenlop == "CNPM2")
            {
                if (tenmonhoc == "DEVC")
                {
                    cmd = new SqlCommand("Select * from cnpm2_devc", ketnoi);
                    sqladapter = new SqlDataAdapter(cmd);
                    sqladapter.Fill(data, "DT");
                    return data;
                }
                else if (tenmonhoc == "CSDL")
                {
                    cmd = new SqlCommand("Select * from cnpm2_csdl", ketnoi);
                    sqladapter = new SqlDataAdapter(cmd);
                    sqladapter.Fill(data, "DT");
                    return data;
                }
            }
            else if (tenlop == "NCQL")
            {
                cmd = new SqlCommand("Select * from ncql_mac", ketnoi);
                sqladapter = new SqlDataAdapter(cmd);
                sqladapter.Fill(data, "DT");
                return data;
            }
            else if (tenlop == "QTDN")
            {
                cmd = new SqlCommand("Select * from qtdn_ktl", ketnoi);
                sqladapter = new SqlDataAdapter(cmd);
                sqladapter.Fill(data, "DT");
                return data;
            }
            return data;
        }
        private static int CheckMa(string masv)
        {
            ketnoi = new SqlConnection(sqlconnect);
            ketnoi.Open();
            cmd = new SqlCommand("Select Count(*) From SinhVien Where MASV = @masv", ketnoi);
            cmd.Parameters.Add(new SqlParameter("@masv", masv));
            int check = int.Parse(cmd.ExecuteScalar().ToString());
            ketnoi.Close();
            return check;
        }
        public static long TinhTuoi(DateTime ngaysinh , DateTime now)
        {
            TimeSpan ts = new TimeSpan(now.Ticks - ngaysinh.Ticks);
            long age = (long)(ts.Days / 365);
            return age;
        }
        public static int ThemSV(string masv, string tensv, string hodem, DateTime ngaysinh, string diachi, string sdt, string malop, string makhoa)
        {
            if (CheckMa(masv) == 1) return 0;
            else if (TinhTuoi(ngaysinh, DateTime.Now) < 18 || TinhTuoi(ngaysinh, DateTime.Now) > 26) return -1;
            else if (masv == "" || tensv == "" || hodem == "" || diachi == "" || sdt == "" || malop == "" || makhoa == "") return 99;
            else
            {
                string ngay = ngaysinh.ToString("dd/MM/yyyy");
                ketnoi = new SqlConnection(sqlconnect);
                ketnoi.Open();
                cmd = new SqlCommand("them_sv", ketnoi);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@masv", masv));
                cmd.Parameters.Add(new SqlParameter("@tensv", tensv));
                cmd.Parameters.Add(new SqlParameter("@hodem", hodem));
                cmd.Parameters.Add(new SqlParameter("@ngaysinh", ngay));
                cmd.Parameters.Add(new SqlParameter("@diachi", diachi));
                cmd.Parameters.Add(new SqlParameter("@malop", malop));
                cmd.Parameters.Add(new SqlParameter("@makhoa", makhoa));
                cmd.Parameters.Add(new SqlParameter("@sdt", sdt));
                cmd.ExecuteNonQuery();
                ketnoi.Close();
                return 1;
            }
        }

        public static int XoaSV(string masv)
        {
            try
            {
                ketnoi = new SqlConnection(sqlconnect);
                ketnoi.Open();
                cmd = new SqlCommand("xoa_sv", ketnoi);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@masv", masv));
                cmd.ExecuteNonQuery();
                ketnoi.Close();
                return 1;
            }
            catch 
            {
                return 0;
            }

        }

        public static int SuaSV(string masv, string tensv, string hodem, string ngaysinh, string diachi, string sdt)
        {
            try
            {
                ketnoi = new SqlConnection(sqlconnect);
                ketnoi.Open();
                cmd = new SqlCommand("sua_sv", ketnoi);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@masv", masv));
                cmd.Parameters.Add(new SqlParameter("@tensv", tensv));
                cmd.Parameters.Add(new SqlParameter("@hodem", hodem));
                cmd.Parameters.Add(new SqlParameter("@ngaysinh", ngaysinh));
                cmd.Parameters.Add(new SqlParameter("@diachi", diachi));
                cmd.Parameters.Add(new SqlParameter("@sdt", sdt));
                cmd.ExecuteNonQuery();
                ketnoi.Close();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public static DataSet TimSV(string tensv, string malop)
        {
            ketnoi = new SqlConnection(sqlconnect);
            DataSet data = new DataSet();
            cmd = new SqlCommand("tim_sv", ketnoi);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@tensv", tensv));
            cmd.Parameters.Add(new SqlParameter("@malop", malop));
            sqladapter = new SqlDataAdapter(cmd);
            sqladapter.Fill(data, "SV");
            return data;
        }
        private static int KiemTraMa(string masv)
        {
            ketnoi = new SqlConnection(sqlconnect);
            ketnoi.Open();
            cmd = new SqlCommand("Select Count(*) From DiemThi Where MASV = @masv", ketnoi);
            cmd.Parameters.Add(new SqlParameter("@masv", masv));
            int check = int.Parse(cmd.ExecuteScalar().ToString());
            ketnoi.Close();
            return check;
        }
        public static int SuaDiem(string masv, string diem1 , string diem2, string monhoc)
        {
            int check = KiemTraMa(masv);
            if( check == 0)
            {
                return -1;
            }
            else
            {
                try
                {
                    ketnoi = new SqlConnection(sqlconnect);
                    ketnoi.Open();
                    cmd = new SqlCommand("suadiem", ketnoi);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@masv", masv));
                    cmd.Parameters.Add(new SqlParameter("@diem1", diem1));
                    cmd.Parameters.Add(new SqlParameter("@diem2", diem2));
                    cmd.Parameters.Add(new SqlParameter("@monhoc", monhoc));
                    cmd.ExecuteNonQuery();
                    ketnoi.Close();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
            
        }
    }
}

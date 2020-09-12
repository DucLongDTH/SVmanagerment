using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVMANAGERMENT
{
    public partial class KetQuaHocTap : UserControl
    {
        public KetQuaHocTap()
        {
            InitializeComponent();
        }

        private void KetQuaHocTap_Load(object sender, EventArgs e)
        {
            GetKhoa();
            string tenkhoa ="CNTT";
            GetLop(tenkhoa);
            GetMonHoc(tenkhoa);
        }

        private void GetKhoa()
        {
            DataSet rs = BeCore.getKhoa();
            KQHT_cbKhoa.DataSource = rs.Tables["Khoa"];
            KQHT_cbKhoa.DisplayMember = "TenKhoa";
            KQHT_cbKhoa.ValueMember = "MaKhoa";
        }

        private void GetLop(string tenkhoa)
        {
            DataSet rs = BeCore.getLop(tenkhoa);
            KQHT_cbLop.DataSource = rs.Tables["Lop"];
            KQHT_cbLop.DisplayMember = "TenLop";
            KQHT_cbLop.ValueMember = "MaLop";
        }

        private void GetMonHoc(string tenkhoa)
        {
            DataSet rs = BeCore.getMonHoc(tenkhoa);
            KQHT_cbMonHoc.DataSource = rs.Tables["MH"];
            KQHT_cbMonHoc.DisplayMember = "TenMH";
            KQHT_cbMonHoc.ValueMember = "MaMH";
        }
        private void KQHT_cbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenkhoa = KQHT_cbKhoa.SelectedValue.ToString();
            GetLop(tenkhoa);
            GetMonHoc(tenkhoa);

        }
        private void GetData()
        {
            string tenlop = KQHT_cbLop.SelectedValue.ToString();
            string monhoc = KQHT_cbMonHoc.SelectedValue.ToString();
            DataSet rs = BeCore.getDiem(tenlop, monhoc);
            KQHT_dgvDiemThi.DataSource = null;
            KQHT_dgvDiemThi.DataSource = rs.Tables["DT"];
        }
        private void KQHT_cbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void KQHT_dgvDiemThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if(index >= 0)
            {
                KQHT_txtMASV.Text = KQHT_dgvDiemThi.Rows[index].Cells["Mã Sinh Viên"].Value.ToString();
                KQHT_txtMASV.Enabled = false;
                KQHT_txtDiem1.Text = KQHT_dgvDiemThi.Rows[index].Cells["Điểm lần 1"].Value.ToString();
                KQHT_txtDiem2.Text = KQHT_dgvDiemThi.Rows[index].Cells["Điểm lần 2"].Value.ToString();
            }
        }

        private void KQHT_btnSua_Click(object sender, EventArgs e)
        {   
            if(KQHT_txtMASV.Text == ""|| KQHT_txtDiem1.Text == "" || KQHT_txtDiem2.Text == "" || KQHT_cbMonHoc.SelectedValue.ToString() == "")
            {
                newMessBox.Show("Bạn cần điền đủ thông tin trước khi sửa", "Lỗi thêm thông tin", MessageBoxButtons.OK);
            }
            else if(int.Parse(KQHT_txtDiem1.Text) <0 || int.Parse(KQHT_txtDiem1.Text) > 10 || int.Parse(KQHT_txtDiem2.Text) < 0 || int.Parse(KQHT_txtDiem2.Text) > 10)
            {
                newMessBox.Show("Điểm không hợp lệ !", "Lỗi thêm thông tin", MessageBoxButtons.OK);
            }
            else
            {
                int rs = BeCore.SuaDiem(KQHT_txtMASV.Text, KQHT_txtDiem1.Text, KQHT_txtDiem2.Text, KQHT_cbMonHoc.SelectedValue.ToString());
                if(rs == 1)
                {
                    newMessBox.Show("Đã sửa điểm !", "Thành Công", MessageBoxButtons.OK);
                    GetData();

                }
                else if(rs == 0)
                {
                    newMessBox.Show(" Lỗi hệ thống vui lòng quay lại sau ", "Thất Bại", MessageBoxButtons.OK);

                }
                else
                {
                    newMessBox.Show(" Mã sinh viên không đúng mời kiểm tra lại ! ", "Thất Bại", MessageBoxButtons.OK);
                }
            }
        }

        private void KQHT_btnIn_Click(object sender, EventArgs e)
        {
            // Khoi Tao Exel
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            // Khoi Tao Workbook
            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
            // Khoi Tao WorkSheet
            Microsoft.Office.Interop.Excel.Worksheet ws = null;
            ws = wb.Sheets["Sheet1"];
            ws = wb.ActiveSheet;
            app.Visible = true;
            
            // Do du lieu
            ws.Cells[1, 1] = " Bảng Điểm Lớp " + KQHT_cbLop.SelectedValue.ToString() + " Môn học " + KQHT_cbMonHoc.SelectedValue.ToString().ToUpper();
            ws.Cells[3, 1] = "STT";
            ws.Cells[3, 2] = "Mã Sinh Viên";
            ws.Cells[3, 3] = "Họ Đệm";
            ws.Cells[3, 4] = "Tên";
            ws.Cells[3, 5] = "Điểm thi lần 1";
            ws.Cells[3, 6] = "Điểm thi lần 2";

            for (int i = 0; i < KQHT_dgvDiemThi.RowCount ; i++)
            {
                for (int j = 0; j < KQHT_dgvDiemThi.ColumnCount ; j++)
                {
                    ws.Cells[i + 4, 1] = i+1; // cot stt
                    ws.Cells[i + 4, j + 2] = KQHT_dgvDiemThi.Rows[i].Cells[j].Value.ToString();
                }
            }
            // Dinh dang Trang
            ws.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait; // dang trang nam doc
            //ws.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4; // trang kho A4
            // Dinh dang Cot
            ws.Range["A1"].ColumnWidth = 8.25;
            ws.Range["B1"].ColumnWidth = 15;
            ws.Range["C1"].ColumnWidth = 12;
            ws.Range["D1"].ColumnWidth = 12;
            ws.Range["E1"].ColumnWidth = 12;
            ws.Range["G1"].ColumnWidth = 12;
            ws.Range["F1"].ColumnWidth = 12;
            // Dinh dang Font
            ws.Range["A1", "F50"].Font.Name = "Times New Roman";
            ws.Range["A1", "F50"].Font.Size = 12;
            // Merge Cot 
            ws.Range["A1", "F1"].MergeCells = true;
            ws.Range["A1", "F1"].Font.Color = Color.Black;
            ws.Range["A1", "F1"].Interior.Color = Color.Yellow;
            ws.Range["A1", "F1"].HorizontalAlignment = 3;
            ws.Range["A1", "F1"].Font.Bold = true;
            ws.Range["A3","F3"].Font.Bold = true;
            ws.Range["A3", "F3"].HorizontalAlignment = 3;
            ws.Range["A3", "F3"].Interior.Color = Color.Green;
            ws.Range["A3", "F3"].Font.Color = Color.White;
            // Ke bang
            ws.Range["A3", "F" + (KQHT_dgvDiemThi.RowCount + 3)].Borders.LineStyle = 1;
            ws.Range["A4", "A" + (KQHT_dgvDiemThi.RowCount + 3)].HorizontalAlignment = 3;
            ws.Range["B4", "B" + (KQHT_dgvDiemThi.RowCount + 3)].HorizontalAlignment = 3;
            ws.Range["C4", "C" + (KQHT_dgvDiemThi.RowCount + 3)].HorizontalAlignment = 3;
            ws.Range["D4", "D" + (KQHT_dgvDiemThi.RowCount + 3)].HorizontalAlignment = 3;
            ws.Range["E4", "E" + (KQHT_dgvDiemThi.RowCount + 3)].HorizontalAlignment = 3;
            ws.Range["G4", "G" + (KQHT_dgvDiemThi.RowCount + 3)].HorizontalAlignment = 3;
            ws.Range["F4", "F" + (KQHT_dgvDiemThi.RowCount + 3)].HorizontalAlignment = 3;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace SVMANAGERMENT
{
    public partial class SinhVien : UserControl
    {
        public SinhVien()
        {
            InitializeComponent();
        }

        public void SinhVien_Load(object sender, EventArgs e)
        {
            string tenkhoa = "CNTT";
            GetKhoa();
            GetLop(tenkhoa);
            QLSV_btnSua.Enabled = false;
            QLSV_btnXoa.Enabled = false;
        }
        private void GetKhoa()
        {
            DataSet rs = BeCore.getKhoa();
            QLSV_cbKhoa.DataSource = rs.Tables["Khoa"];
            QLSV_cbKhoa.DisplayMember = "TenKhoa";
            QLSV_cbKhoa.ValueMember = "MaKhoa";
        }
        private void GetLop(string tenkhoa)
        {
            DataSet rs = BeCore.getLop(tenkhoa);
            QLSV_cbLop.DataSource = rs.Tables["Lop"];
            QLSV_cbLop.DisplayMember = "TenLop";
            QLSV_cbLop.ValueMember = "MaLop";
        }
        private void DataLop()
        {
            QLSV_dgvSV.DataSource = null;
            string tenlop = QLSV_cbLop.SelectedValue.ToString();
            DataSet rs = BeCore.getSV(tenlop);
            QLSV_dgvSV.DataSource = rs.Tables["SV"];
        }
        private void QLSV_cbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenkhoa = QLSV_cbKhoa.SelectedValue.ToString();
            DataSet rs = BeCore.getLop(tenkhoa);
            QLSV_cbLop.DataSource = rs.Tables["Lop"];
            QLSV_cbLop.DisplayMember = "TenLop";
            QLSV_cbLop.ValueMember = "MaLop";
        }

        private void QLSV_cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLop();
        }
        private void ClearText()
        {
            QLSV_txtDiaChi.Text = "";
            QLSV_txtHodem.Text = "";
            QLSV_txtMASV.Text = "";
            QLSV_txtSDT.Text = "";
            QLSV_txtTen.Text = "";
        }
        private void QLSV_btnThem_Click(object sender, EventArgs e)
        {
            int rs = BeCore.ThemSV(QLSV_txtMASV.Text, QLSV_txtTen.Text, QLSV_txtHodem.Text, QLSV_date.Value, QLSV_txtDiaChi.Text, QLSV_txtSDT.Text, QLSV_cbLop.SelectedValue.ToString(), QLSV_cbKhoa.SelectedValue.ToString());
            if (rs == 1)
            {
                newMessBox.Show(" Thêm Sinh Viên mã: " + QLSV_txtMASV.Text + " thành công", "Thành Công", MessageBoxButtons.OK);
                DataLop();
                ClearText();

            }
            else if (rs == -1)
            {
                newMessBox.Show("Tuổi sinh viên không hợp lệ (18 - 26)", "Lỗi Thêm Thông Tin", MessageBoxButtons.OK);
            }
            else if (rs == 0)
            {
                newMessBox.Show(" mã: " + QLSV_txtMASV.Text + " bị trùng", "Lỗi", MessageBoxButtons.OK);
            }
            else if (rs == 99)
            {
                newMessBox.Show("Bạn phải điền đầy đủ thông tin sinh viên", "Lỗi Thêm Thông Tin", MessageBoxButtons.OK);
                ClearText();
            }

        }

        private void QLSV_dgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            QLSV_btnThem.Enabled = false;
            QLSV_btnSua.Enabled = true;
            QLSV_btnXoa.Enabled = true;

            int index = e.RowIndex;
            if (index >= 0)
            {
                QLSV_txtMASV.Text = QLSV_dgvSV.Rows[index].Cells["Mã Sinh Viên"].Value.ToString();
                QLSV_txtMASV.Enabled = false;
                QLSV_txtHodem.Text = QLSV_dgvSV.Rows[index].Cells["Họ Đệm"].Value.ToString();
                QLSV_txtTen.Text = QLSV_dgvSV.Rows[index].Cells["Tên"].Value.ToString();
                DateTime date = DateTime.ParseExact(QLSV_dgvSV.Rows[index].Cells["Ngày Sinh"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                QLSV_date.Value = date;
                QLSV_txtDiaChi.Text = QLSV_dgvSV.Rows[index].Cells["Địa Chỉ"].Value.ToString();
                QLSV_txtSDT.Text = QLSV_dgvSV.Rows[index].Cells["SĐT"].Value.ToString();
            }
        }

        private void QLSV_btnXoa_Click(object sender, EventArgs e)
        {
            if (newMessBox.Show("Bạn có chắc muốn xóa sinh viên mã: " + QLSV_txtMASV.Text, "Xóa Sinh Viên", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int rs = BeCore.XoaSV(QLSV_txtMASV.Text);
                if (rs == 1)
                {
                    newMessBox.Show(" Xóa sinh viên mã: " + QLSV_txtMASV.Text + "thành công", "Thành Công", MessageBoxButtons.OK);
                    DataLop();
                    ClearText();
                    QLSV_btnThem.Enabled = true;
                    QLSV_btnSua.Enabled = false;
                    QLSV_btnXoa.Enabled = false;
                    QLSV_txtMASV.Enabled = true;
                }
                else
                {
                    newMessBox.Show(" Xóa sinh viên mã: " + QLSV_txtMASV.Text + " Thất Bại", "Lỗi", MessageBoxButtons.OK);
                }
            }

        }

        private void QLSV_btnSua_Click(object sender, EventArgs e)
        {
            if (QLSV_txtDiaChi.Text == "" || QLSV_txtHodem.Text == "" || QLSV_txtMASV.Text == "" || QLSV_txtSDT.Text == "" || QLSV_txtTen.Text == "")
            {
                newMessBox.Show("Bạn phải điền đầy đủ thông tin sinh viên", "Lỗi Thêm Thông Tin", MessageBoxButtons.OK);
            }
            else
            {
                string ngaysinh = QLSV_date.Value.Date.ToString("dd/MM/yyyy");
                int rs = BeCore.SuaSV(QLSV_txtMASV.Text, QLSV_txtTen.Text, QLSV_txtHodem.Text, ngaysinh, QLSV_txtDiaChi.Text, QLSV_txtSDT.Text);
                if (rs == 1)
                {
                    newMessBox.Show(" Sửa Sinh Viên mã: " + QLSV_txtMASV.Text + "thành công", "Thành Công", MessageBoxButtons.OK);
                    DataLop();
                    ClearText();
                    QLSV_btnThem.Enabled = true;
                    QLSV_btnSua.Enabled = false;
                    QLSV_btnXoa.Enabled = false;
                    QLSV_txtMASV.Enabled = true;
                }
                else
                {
                    newMessBox.Show("  Sinh Viên mã: " + QLSV_txtMASV.Text + " sửa Thất Bại", "Lỗi", MessageBoxButtons.OK);
                }

            }
        }

        private void QLSV_btnRF_Click(object sender, EventArgs e)
        {
            ClearText();
            QLSV_btnThem.Enabled = true;
            QLSV_btnSua.Enabled = false;
            QLSV_btnXoa.Enabled = false;
            QLSV_txtMASV.Enabled = true;
        }

        private void QLSV_btnTim_Click(object sender, EventArgs e)
        {
            QLSV_dgvSV.DataSource = null;
            string tenlop = QLSV_cbLop.SelectedValue.ToString();
            string tensv = QLSV_txtTimKiem.Text;
            DataSet rs = BeCore.TimSV(tensv, tenlop);
            QLSV_dgvSV.DataSource = rs.Tables["SV"];
        }
    }
}

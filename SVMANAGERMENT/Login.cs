using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVMANAGERMENT
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }        
        private void button1_MouseHover(object sender, EventArgs e)
        {
            btbDN.BackColor = Color.White;
            btbDN.ForeColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btbDN.BackColor = Color.Transparent;
            btbDN.ForeColor = Color.White;
        }
        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Red;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Transparent;
            button2.ForeColor = Color.White;
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            txtpassword.UseSystemPasswordChar = false;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            txtpassword.UseSystemPasswordChar = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (newMessBox.Show("Bạn có muốn thoát không ? ", " Thoát Chương Trình", MessageBoxButtons.YesNo) == DialogResult.Yes) this.Close(); 
        }

        private void btbDN_Click(object sender, EventArgs e)
        {
            int rs = BeCore.CheckLogin(txtuser.Text, txtpassword.Text);
            if(rs == 1)
            {
                newMessBox.Show(@"Đăng nhập thành công", "Thành Công", MessageBoxButtons.OK);
                MainPage form = new MainPage();
                this.Hide();
                form.Show();
            }
            else
            {
                newMessBox.Show(@"Sai Tài Khoản \ Mật khẩu !", "Lỗi Đăng Nhập", MessageBoxButtons.OK);
            }
            
        }
    }
}

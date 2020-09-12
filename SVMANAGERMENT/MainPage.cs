using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVMANAGERMENT
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            panel_Active1.Hide();
            panel_Active2.Hide();
            timer1.Start();
            panel_Home.Show();
            panel_Home.BringToFront();
            //panel_SV.Hide();
            label_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void button_QLSV_Click(object sender, EventArgs e)
        {
            panel_Active1.Show();
            panel_Active2.Hide();
            panel_SV.Show();
            panel_SV.BringToFront();
            panel_Home.Hide();
        }

        private void button_KQHT_Click(object sender, EventArgs e)
        {
            panel_Active1.Hide();
            panel_Active2.Show();
            panel_SV.Hide();
            panel_Home.Hide();
            panel_KQ.Show();
            panel_KQ.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_time.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            if (newMessBox.Show("Bạn có muốn thoát không ? ", " Thoát Chương Trình", MessageBoxButtons.YesNo) == DialogResult.Yes) Application.Exit();
        }


    }
}

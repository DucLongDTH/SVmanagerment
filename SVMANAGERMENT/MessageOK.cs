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
    public partial class MessageOK : Form
    {
        public MessageOK()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string Caption
        {
            get => label_title.Text; set => label_title.Text = value;
        }
        public string Message
        {
            get => label_notice.Text; set => label_notice.Text = value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using agsXMPP;

namespace TeleClient
{
    public partial class LoginDlg : Form
    {
        public LoginDlg()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //TeleClient beenden
            Application.Exit();
        }
    }
}

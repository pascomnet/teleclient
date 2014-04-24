using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TeleClient
{
    public partial class LoginFrm : Form
    {

        /// <summary>
        /// Konstruktor für LoginFrm
        /// </summary>
        public LoginFrm()
        {
            InitializeComponent();

            IConnection connection = Program.Connection;

            this.textUsername.Text = "jdallmeier";
            this.textPassword.Text = "12345678";
            this.textServer.Text = "10.3.4.10";
        }

        /// <summary>
        /// Klickevent des Buttons Beenden
        /// Das Programm wird beendet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            //TeleClient beenden
            Application.Exit();
        }

        /// <summary>
        /// Klickevent des Login Buttons
        /// Die Verbindung zum Server wird hergestellt
        /// Das Hauptfenster wird angezeigt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            pBar.Style = ProgressBarStyle.Marquee;
            pBar.Visible = true;
            
            IConnection connection = Program.Connection;
            this.DialogResult = DialogResult.OK;
            Task.Factory.StartNew(new Action(() =>
            {
                connection.Login(textUsername.Text, textPassword.Text, textServer.Text);
            }));

            textUsername.ReadOnly = true;
            textPassword.ReadOnly = true;
            textServer.ReadOnly = true;
            btnLogin.Enabled = false;
        }

        /// <summary>
        /// Wenn der Focus im Servereingabefeld ist kann der Benutzer 
        /// durch Klicken auf "Enter" den Loginbutton auslösen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textServer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.btnLogin_Click(sender, e);
            }
        }

        /// <summary>
        /// Beim Schließen des LoginFrms wird das Programm beendet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

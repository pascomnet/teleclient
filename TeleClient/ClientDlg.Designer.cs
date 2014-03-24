namespace TeleClient
{
    partial class ClientDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblDial = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.textNumber = new System.Windows.Forms.TextBox();
            this.btnDial = new System.Windows.Forms.Button();
            this.btnHangup = new System.Windows.Forms.Button();
            this.groupJournal = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(279, 33);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(85, 23);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Abmelden";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(39, 91);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(112, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Sie sind eingeloggt als";
            // 
            // lblDial
            // 
            this.lblDial.AutoSize = true;
            this.lblDial.Location = new System.Drawing.Point(39, 147);
            this.lblDial.Name = "lblDial";
            this.lblDial.Size = new System.Drawing.Size(49, 13);
            this.lblDial.TabIndex = 2;
            this.lblDial.Text = "Wählbox";
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(184, 91);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(180, 20);
            this.textUsername.TabIndex = 3;
            // 
            // textNumber
            // 
            this.textNumber.Location = new System.Drawing.Point(184, 140);
            this.textNumber.Name = "textNumber";
            this.textNumber.Size = new System.Drawing.Size(180, 20);
            this.textNumber.TabIndex = 4;
            // 
            // btnDial
            // 
            this.btnDial.Location = new System.Drawing.Point(42, 204);
            this.btnDial.Name = "btnDial";
            this.btnDial.Size = new System.Drawing.Size(153, 23);
            this.btnDial.TabIndex = 5;
            this.btnDial.Text = "Abheben";
            this.btnDial.UseVisualStyleBackColor = true;
            // 
            // btnHangup
            // 
            this.btnHangup.Location = new System.Drawing.Point(216, 204);
            this.btnHangup.Name = "btnHangup";
            this.btnHangup.Size = new System.Drawing.Size(148, 23);
            this.btnHangup.TabIndex = 6;
            this.btnHangup.Text = "Auflegen";
            this.btnHangup.UseVisualStyleBackColor = true;
            // 
            // groupJournal
            // 
            this.groupJournal.Location = new System.Drawing.Point(42, 271);
            this.groupJournal.Name = "groupJournal";
            this.groupJournal.Size = new System.Drawing.Size(322, 370);
            this.groupJournal.TabIndex = 7;
            this.groupJournal.TabStop = false;
            this.groupJournal.Text = "Journal";
            // 
            // ClientDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 663);
            this.Controls.Add(this.groupJournal);
            this.Controls.Add(this.btnHangup);
            this.Controls.Add(this.btnDial);
            this.Controls.Add(this.textNumber);
            this.Controls.Add(this.textUsername);
            this.Controls.Add(this.lblDial);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnLogout);
            this.Name = "ClientDlg";
            this.Text = "TeleClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblDial;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.TextBox textNumber;
        private System.Windows.Forms.Button btnDial;
        private System.Windows.Forms.Button btnHangup;
        private System.Windows.Forms.GroupBox groupJournal;
    }
}
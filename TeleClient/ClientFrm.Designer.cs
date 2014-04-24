namespace TeleClient
{
    partial class ClientFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientFrm));
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblDial = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.btnDial = new System.Windows.Forms.Button();
            this.btnHangup = new System.Windows.Forms.Button();
            this.dataGridViewJournal = new System.Windows.Forms.DataGridView();
            this.lblCall = new System.Windows.Forms.Label();
            this.lblMissedCall = new System.Windows.Forms.Label();
            this.cboDial = new System.Windows.Forms.ComboBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.textPhone = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJournal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(292, 33);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(72, 23);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Abmelden";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(39, 38);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(120, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Angemeldeter Benutzer:";
            // 
            // lblDial
            // 
            this.lblDial.AutoSize = true;
            this.lblDial.Location = new System.Drawing.Point(39, 193);
            this.lblDial.Name = "lblDial";
            this.lblDial.Size = new System.Drawing.Size(49, 13);
            this.lblDial.TabIndex = 2;
            this.lblDial.Text = "Wählbox";
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(165, 35);
            this.textUsername.Name = "textUsername";
            this.textUsername.ReadOnly = true;
            this.textUsername.Size = new System.Drawing.Size(121, 20);
            this.textUsername.TabIndex = 3;
            // 
            // btnDial
            // 
            this.btnDial.Location = new System.Drawing.Point(42, 250);
            this.btnDial.Name = "btnDial";
            this.btnDial.Size = new System.Drawing.Size(153, 23);
            this.btnDial.TabIndex = 5;
            this.btnDial.Text = "Abheben";
            this.btnDial.UseVisualStyleBackColor = true;
            this.btnDial.Click += new System.EventHandler(this.btnDial_Click);
            // 
            // btnHangup
            // 
            this.btnHangup.Location = new System.Drawing.Point(216, 250);
            this.btnHangup.Name = "btnHangup";
            this.btnHangup.Size = new System.Drawing.Size(148, 23);
            this.btnHangup.TabIndex = 6;
            this.btnHangup.Text = "Auflegen";
            this.btnHangup.UseVisualStyleBackColor = true;
            this.btnHangup.Click += new System.EventHandler(this.btnHangup_Click);
            // 
            // dataGridViewJournal
            // 
            this.dataGridViewJournal.AllowUserToAddRows = false;
            this.dataGridViewJournal.AllowUserToDeleteRows = false;
            this.dataGridViewJournal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJournal.Location = new System.Drawing.Point(42, 311);
            this.dataGridViewJournal.Name = "dataGridViewJournal";
            this.dataGridViewJournal.ReadOnly = true;
            this.dataGridViewJournal.Size = new System.Drawing.Size(322, 371);
            this.dataGridViewJournal.TabIndex = 9;
            this.dataGridViewJournal.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewJournal_CellDoubleClick);
            this.dataGridViewJournal.SelectionChanged += new System.EventHandler(this.dataGridViewJournal_SelectionChanged);
            // 
            // lblCall
            // 
            this.lblCall.AutoSize = true;
            this.lblCall.Location = new System.Drawing.Point(39, 149);
            this.lblCall.Name = "lblCall";
            this.lblCall.Size = new System.Drawing.Size(0, 13);
            this.lblCall.TabIndex = 10;
            this.lblCall.Visible = false;
            // 
            // lblMissedCall
            // 
            this.lblMissedCall.AutoSize = true;
            this.lblMissedCall.Location = new System.Drawing.Point(39, 103);
            this.lblMissedCall.Name = "lblMissedCall";
            this.lblMissedCall.Size = new System.Drawing.Size(0, 13);
            this.lblMissedCall.TabIndex = 11;
            this.lblMissedCall.Visible = false;
            // 
            // cboDial
            // 
            this.cboDial.FormattingEnabled = true;
            this.cboDial.Location = new System.Drawing.Point(165, 190);
            this.cboDial.Name = "cboDial";
            this.cboDial.Size = new System.Drawing.Size(199, 21);
            this.cboDial.TabIndex = 12;
            this.cboDial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDial_KeyPress);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(39, 61);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(118, 13);
            this.lblPhone.TabIndex = 13;
            this.lblPhone.Text = "Zugewiesenes Telefon:";
            // 
            // textPhone
            // 
            this.textPhone.Location = new System.Drawing.Point(165, 58);
            this.textPhone.Name = "textPhone";
            this.textPhone.ReadOnly = true;
            this.textPhone.Size = new System.Drawing.Size(199, 20);
            this.textPhone.TabIndex = 14;
            // 
            // ClientFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 708);
            this.Controls.Add(this.textPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.cboDial);
            this.Controls.Add(this.lblMissedCall);
            this.Controls.Add(this.lblCall);
            this.Controls.Add(this.dataGridViewJournal);
            this.Controls.Add(this.btnHangup);
            this.Controls.Add(this.btnDial);
            this.Controls.Add(this.textUsername);
            this.Controls.Add(this.lblDial);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnLogout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ClientFrm";
            this.Text = "TeleClient";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientFrm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJournal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblDial;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.Button btnDial;
        private System.Windows.Forms.Button btnHangup;
        private System.Windows.Forms.DataGridView dataGridViewJournal;
        private System.Windows.Forms.Label lblCall;
        private System.Windows.Forms.Label lblMissedCall;
        private System.Windows.Forms.ComboBox cboDial;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox textPhone;
    }
}
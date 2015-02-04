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
using agsXMPP.Xml.Dom;
using agsXMPP.protocol.client;
using agsXMPP.sasl;

namespace TeleClient
{
    public partial class ClientFrm : Form
    {

        public BindingList<JournalEntry> JournalEntries { get; set; }
        public BindingList<String> DialEntries { get; set; }

        /// <summary>
        /// Konstruktor des Hauptfensters
        /// </summary>
        public ClientFrm()
        {
            InitializeComponent();
            IConnection connection = Program.Connection;
            btnHangup.Enabled = false;

            //Abonnieren des JournalReceived Events
            connection.JournalReceived += JournalReceived;

            //Abonnieren des JournalEntryReceived Events
            connection.JournalEntryReceived += JournalEntryReceived;

            //Abonnieren des UserinfoReceived Events
            connection.UserinfoReceived += UserinfoReceived;

            //Abonnieren des ChannelEventReceived Events
            connection.ChannelEventReceived += ChannelEventReceived;

            //Erstellen der Journalliste
            JournalEntries = new BindingList<JournalEntry>();

            //Erstellen der Dialliste
            DialEntries = new BindingList<String>();

            //DataGrid Formationen
            dataGridViewJournal.RowHeadersVisible = false;
            dataGridViewJournal.AllowUserToResizeRows = false;
            dataGridViewJournal.AllowUserToResizeColumns = false;
            dataGridViewJournal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Binden der Journaldaten an das DataGrid
            dataGridViewJournal.DataSource = JournalEntries;

            //Binden der Dialentries an die ComboBox
            cboDial.DataSource = DialEntries;

        }

        /// <summary>
        /// Reaktion auf Empfang des JournalEntryReceived Events
        /// Der eben erzeugte Journaleintrag wird in die Liste eingefügt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void JournalEntryReceived(object sender, JournalEntryEventArgs e)
        {
            Program.UIDispatcher.BeginInvoke(new Action(() =>
            {
                lblMissedCall.Visible = false;
                // Journaleintrag schreiben
                this.JournalEntries.Insert(0, e.JournalEntry);

                // Falls Anruf verpasst, diesen anzeigen
                JournalEntry firstEntry = JournalEntries[0];
                if (firstEntry.Dauer == 0)
                {
                    lblMissedCall.BackColor = Color.FromArgb(251, 171, 165);
                    lblMissedCall.Text = "Verpasster Anruf von: " + firstEntry.Name;
                    lblMissedCall.Visible = true;
                }
            }));
        }

        /// <summary>
        /// Reaktion auf Empfang des UserinfoReceived Events
        /// Das Feld des angemeldeten Benutzers wird gefüllt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UserinfoReceived(object sender, UserinfoEventArgs e)
        {
            Program.UIDispatcher.BeginInvoke(new Action(() =>
            {
                // Anzeigen des akutell angemeldeten Benutzers
                textUsername.Text = e.Userinfo.UseBez;
                // Anzeigen des zum Benutzer gehörigen Telefon
                if (e.Userinfo.PhoneDevice == null)
                {
                    // Wenn Benutzer kein Telefon zugewiesen ist
                    textPhone.Text = "Sie haben kein Telefon";
                }
                else
                {
                    // Ansonsten zugewiesenes Telefon anzeigen
                    textPhone.Text = e.Userinfo.PhoneDevice;
                }
            }));
        }

        /// <summary>
        /// Reaktion auf Empfang des JournalReceived Events
        /// Das DataGrid wird gefüllt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void JournalReceived(object sender, JournalEventArgs e)
        {
            Program.UIDispatcher.BeginInvoke(new Action(() =>
            {
                JournalEntries.Clear();
                lblMissedCall.Visible = false;
                foreach (JournalEntry entry in e.Entries)
                {
                    JournalEntries.Add(entry);
                }
                cboDial.Text = "";

                //Falls Journaleinträge vorhanden
                //und ein verpassten Anruf da ist
                if (JournalEntries.Count != 0)
                {
                    //Diesen anzeigen
                    JournalEntry firstEntry = JournalEntries[0];
                    if (firstEntry.Dauer == 0)
                    {
                        lblMissedCall.BackColor = Color.FromArgb(251, 171, 165);
                        lblMissedCall.Text = "Verpasster Anruf von: " + firstEntry.Name;
                        lblMissedCall.Visible = true;
                    }
                }
            }));
        }

        /// <summary>
        /// Reaktion auf Empfang des ChannelEventReceived Events
        /// Der aktuelle Call wird angezeigt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ChannelEventReceived(object sender, ChanneleventEventArgs e)
        {
            Program.UIDispatcher.BeginInvoke(new Action(() =>
            {
                //Eingehender Anruf
                if (e.ChannelEvent.EventType == "ringing" && e.ChannelEvent.Outbound == false)
                {
                    btnHangup.Enabled = true;
                    lblCall.Visible = true;
                    lblCall.Tag = "incoming";
                    lblCall.Text = "Eingehender Anruf von " + e.ChannelEvent.SourceName + " (" + e.ChannelEvent.SourceNumber + ")";
                }

                //Ausgehender Anruf
                if (e.ChannelEvent.EventType == "ringing" && e.ChannelEvent.Outbound == true)
                {
                    btnHangup.Enabled = true;
                    lblCall.Visible = true;
                    lblCall.Text = "Ausgehender Anruf an " + e.ChannelEvent.TargetName + " (" + e.ChannelEvent.TargetNumber + ")";
                    btnDial.Enabled = false;
                    if (cboDial.Text != "")
                        this.FillComboBox(cboDial.Text);
                }

                //Eigene Leitung belegt durch eingehenden Anruf
                if (e.ChannelEvent.EventType == "busy" && e.ChannelEvent.Outbound==false)
                {
                    btnHangup.Enabled = true;
                    lblCall.Visible = true;
                    lblCall.Text = "Sie telefonieren mit " + e.ChannelEvent.SourceName + " (" + e.ChannelEvent.SourceNumber + ")";
                    btnDial.Enabled = false;
                }

                //Eigene Leitung belegt durch ausgehenden Anruf
                if (e.ChannelEvent.EventType == "busy" && e.ChannelEvent.Outbound==true)
                {
                    btnHangup.Enabled = true;
                    lblCall.Visible = true;
                    lblCall.Text = "Sie telefonieren mit " + e.ChannelEvent.TargetName + " (" + e.ChannelEvent.TargetNumber + ")";
                    btnDial.Enabled = false;
                    if(cboDial.Text!="")
                        this.FillComboBox(cboDial.Text);
                }

                //Hangup
                if (e.ChannelEvent.EventType == "hangup")
                {
                    btnHangup.Enabled = false;
                    lblCall.Visible = false;
                    lblCall.Text = "";
                    lblCall.Tag = null;
                    btnDial.Enabled = true;
                }

                cboDial.Text = "";
            }));
        }

        /// <summary>
        /// Logout durch Klicken des Logoutbuttons
        /// Verbindung wird geschlossen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            IConnection connection = Program.Connection;
            connection.Logout();
        }

        /// <summary>
        /// Event bei Beenden des Programms
        /// Verbindung wird geschlossen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            IConnection connection = Program.Connection;
            connection.Logout();
            Application.Exit();
        }

        /// <summary>
        /// Formatierung der ausgewählten Spalte des DataGridViews
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewJournal_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridViewJournal.ClearSelection();
        }

        /// <summary>
        /// Klickevent auf "Abheben" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDial_Click(object sender, EventArgs e)
        {
            IConnection connection = Program.Connection;
            // Wenn der Benutzer kein Telefon besitzt wird eine Messagebox gezeigt
            if (connection.UserInfo.PhoneDevice == null)
            {
                cboDial.Text = "";
                MessageBox.Show("Sie haben kein Telefon!", "Error");
            }
            // Ansonsten wird gewählt
            else
            {
                // Der Benutzer hat nur eine Leitung zur Verfügung
                // Wenn diese bereits belegt ist wird eine Messagebox gezeigt
                if (connection.Presence.Show == ShowType.dnd)
                {
                    cboDial.Text = "";
                    MessageBox.Show("Nur eine Leitung verfügbar!", "Error");
                }
                else
                {
                    // Bei einem eingehenden Anruf wird per Klick 
                    // auf den "Abheben" Button der Anruf angenommen
                    if (lblCall.Tag == "incoming")
                    {
                        connection.SendOffhook();
                    }

                    // Wenn der Benutzer keine Nummer in die Wählbox eingibt aber 
                    // trotzdem den "Abheben" Button drückt wird eine Messagebox angezeigt
                    if (lblCall.Tag == null && cboDial.Text == "")
                    {
                        MessageBox.Show("Sie müssen eine Nummer in das Wählfeld eingeben!", "Fehler");
                    }
                    // Ansonsten wird die eingegebene Nummer gewählt
                    else
                    {
                        connection.SendDial(this.cboDial.Text);
                    }
                }
            }
        }

        /// <summary>
        /// Klickevent auf "Auflegen" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHangup_Click(object sender, EventArgs e)
        {
            // Bei Klick auf den "Auflegen" Button wird das aktuelle Gespräch aufgelegt
            Program.Connection.SendHangup();
        }

        /// <summary>
        /// Ruffunktion aus dem Journal
        /// Bei einem Doppelklick auf einen Journaleintrag wird die Nummer des Eintrags gewählt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewJournal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)dataGridViewJournal.Rows[e.RowIndex].Cells[2];
            this.FillComboBox(cell.Value.ToString());
            Program.Connection.SendDial(cell.Value.ToString());
        }

        /// <summary>
        /// Wird eine Nummer in die Wählbox eingegeben kann diese per Enter direkt gewählt werden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboDial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.btnDial_Click(sender, e);
            }
        }

        /// <summary>
        /// Befüllen der ComboBox mit der übergebenen Nummer
        /// </summary>
        /// <param name="number"></param>
        private void FillComboBox(string number)
        {
            // Wenn noch keine Einträge vorhanden
            if (DialEntries.Count == 0)
            {
                DialEntries.Insert(0, number);
                cboDial.Text = "";
            }
            // Wenn schon Einträge vorhanden 
            // und der erste die gleiche Nummer hat 
            // diesen nicht in die ComboBoc schreiben
            if (DialEntries.First() != number)
            {
                DialEntries.Insert(0, number);
                cboDial.Text = "";
            }
        }

        /// <summary>
        /// Durch Klick auf den verpassten Anruf wird dieser wieder ausgeblendet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMissedCall_Click(object sender, EventArgs e)
        {
            // Nur wenn ein verpasster Anruf angezeigt wird
            if (lblMissedCall.Visible == true)
                lblMissedCall.Visible = false;
        }
    }
}

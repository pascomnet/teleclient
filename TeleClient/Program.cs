/**
 *  TeleClient, a Sample Application to show how to connect to MobyDick XMPP Server
 *  Copyright (C) 2015 pascom Netzwerktechnik GmbH & Co. KG
 *  Author: Jonas Dallmeier
 *
 *  This program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License along
 *
 *  ith this program; if not, write to the Free Software Foundation, Inc.,
 *  51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. 
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace TeleClient
{
    static class Program
    {
        private static readonly IConnection _connection;
        private static LoginFrm _LoginFrm;
        private static ClientFrm _ClientFrm;
        private static Dispatcher _UIDispatcher;

        public static Dispatcher UIDispatcher
        {
            get { return Program._UIDispatcher; }
        }

        internal static IConnection Connection
        {
            get { return Program._connection; }
        }

        /// <summary>
        /// Konstruktor des Hauptprogramms
        /// </summary>
        static Program()
        {
            _connection = new XmppConnection();
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Connection.Connected += Connection_Connected;
            Connection.Disconnected += Connection_Disconnected;


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _UIDispatcher = Dispatcher.CurrentDispatcher;
            _LoginFrm = new LoginFrm();
            _ClientFrm = new ClientFrm();
            _LoginFrm.Show();
            Application.Run();
        }

        /// <summary>
        /// Handler-Methode für den Disconnected Zustand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Connection_Disconnected(object sender, DisconnectEventArgs e)
        {
            UIDispatcher.BeginInvoke(new Action(() =>
            {
                switch (e.Reason)
                {
                    case DisconnectReason.LOGOUT:
                    case DisconnectReason.ERROR:
                    case DisconnectReason.AUTH_ERROR:
                    case DisconnectReason.SOCKET_ERROR:
                    default:
                        ResetForms();
                        _ClientFrm.Hide();
                        _LoginFrm.Show();
                        break;
                }    
            }));
        }

        /// <summary>
        /// Handler-Methode für den Connected Zustand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Connection_Connected(object sender, EventArgs e)
        {
            UIDispatcher.BeginInvoke(new Action(() =>
            {
                ResetForms();
                _LoginFrm.Hide();
                _ClientFrm.Show();
            }));
        }

        /// <summary>
        /// Setzt die Anzeige des Forms wieder zurück
        /// </summary>
        static void ResetForms()
        {
            _LoginFrm.ResetText();
            _ClientFrm.DialEntries.Clear();
            _ClientFrm.JournalEntries.Clear();
            foreach (Control x in _LoginFrm.Controls)
            {
                if (x is TextBox)
                    ((TextBox)x).ReadOnly = false;
                if (x is Button)
                    x.Enabled = true;
                if (x is ProgressBar)
                    x.Visible = false;
            }
        }
    }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timothy_test
{            
        public partial class frm_menu : Form
    {
        globalKeyboardHook gkh = new globalKeyboardHook();
        List<string> abc = new List<string>();
        bool minimizedToTray;
        NotifyIcon notifyIcon;
        public frm_menu()
        {
            InitializeComponent();
            lbl_comment.Text = "          Press :ff" + Environment.NewLine + "on text editor to activate" + Environment.NewLine + "Smart Suggestion Window.";
            
        }
        protected override void WndProc(ref Message message)
        {
            if (message.Msg == SingleInstance.WM_SHOWFIRSTINSTANCE)
            {
                ShowWindow();
            }
            base.WndProc(ref message);
        }
        void MinimizeToTray()
        {
            notifyIcon = new NotifyIcon();
            //notifyIcon.Click += new EventHandler(NotifyIconClick);
            notifyIcon.DoubleClick += new EventHandler(NotifyIconClick);
            notifyIcon.Icon = this.Icon;
            notifyIcon.Text = ProgramInfo.AssemblyTitle;
            notifyIcon.Visible = true;
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
            minimizedToTray = true;
        }
        public void ShowWindow()
        {
            if (minimizedToTray)
            {
                notifyIcon.Visible = false;
                this.Show();
                this.WindowState = FormWindowState.Normal;
                minimizedToTray = false;
            }
            else {
                WinApi.ShowToFront(this.Handle);
            }
        }
        void NotifyIconClick(Object sender, System.EventArgs e)
        {
            ShowWindow();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HealthCareMaster hc = new HealthCareMaster();
            hc.Show();
        }
        [STAThread]
        private void frm_menu_Load(object sender, EventArgs e)
        {
           // WindowState = FormWindowState.Minimized;
           // ShowInTaskbar = false;
            gkh.HookedKeys.Add(Keys.Oem1);
            gkh.HookedKeys.Add(Keys.F);
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
        }
        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
           abc.Add(e.KeyCode.ToString());
            if (abc.Count == 1)
            { if (!abc[0].Equals("Oem1"))
                    { abc.Clear(); }
            }
            if (abc.Count == 2)
            {
               if (!abc[0].Equals("Oem1") && !abc[1].Equals("F"))
                { abc.Clear(); }
            }
            if (abc.Count == 3)
            {
                if (abc[0].Equals("Oem1") && abc[1].Equals("F") && abc[2].Equals("F"))
                {
                    frm_popupwindow popup = new frm_popupwindow();
                    popup.Show();
                    abc.Clear();
                }
            }
        }

        private void frm_menu_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)

            {
                MinimizeToTray();
            }
        }

      

        private void runOnStaretupToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if (((ToolStripMenuItem)settingsToolStripMenuItem.DropDownItems[0]).Checked == true)
                { RegisterInStartup(true); }
            else { RegisterInStartup(false); }
        }
        private void RegisterInStartup(bool isChecked)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isChecked)
            {
                registryKey.SetValue("timothy_test.exe", Application.ExecutablePath);
            }
            else
            {
                registryKey.DeleteValue("timothy_test.exe");
            }
        }

        private void Show_Click(object sender, EventArgs e)
        {

            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}




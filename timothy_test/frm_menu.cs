using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
            lbl_comment.Text = "Press :ff on any text editor" + Environment.NewLine + "    window to activate" + Environment.NewLine + "     Smart Suggestion.";
            RegisterInStartup(true);
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
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon.Visible = true;
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon.Visible = false;
            }
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
                   
                    if (System.Windows.Forms.Application.OpenForms["frm_popupwindow"] as frm_popupwindow != null)
                    {
                        System.Windows.Forms.Application.OpenForms["frm_popupwindow"].Activate();
                        //frm_popupwindow.ActiveForm.Resume();
                        // MessageBox.Show("Smart Suggestion is already open.","Health Care Application.");
                        if(System.Windows.Forms.Application.OpenForms["frm_popupwindow"].WindowState==FormWindowState.Minimized)
                        {
                            System.Windows.Forms.Application.OpenForms["frm_popupwindow"].WindowState = FormWindowState.Normal;
                        }
                    }
                    else
                    {
                        // MessageBox.Show("Form1 is not opened");

                        frm_popupwindow popup = new frm_popupwindow();
                        //popup.WindowState = FormWindowState.Minimized;
                        popup.Show();
                        popup.Activate();
                       // popup.WindowState = FormWindowState.Normal;
                       
                    }
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

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowWindow();
        }
    }
}




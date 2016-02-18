using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        string itm;
        
        
        public frm_menu()
        {
            InitializeComponent();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HealthCareMaster hc = new HealthCareMaster();
            hc.Show();
        }

        private void frm_menu_Load(object sender, EventArgs e)
        {
            gkh.HookedKeys.Add(Keys.Oem1);
            gkh.HookedKeys.Add(Keys.F);
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
        }
        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            
                itm=(e.KeyCode.ToString());
            if (itm != null)
            {
                abc.Add(itm);
            }
            if (abc.Count > 2)
            {
                if (abc[0].Equals("Oem1") && abc[1].Equals("F") && abc[2].Equals("F"))
                {
                    frm_popupwindow poup = new frm_popupwindow();
                    poup.Show();
                }
                abc.Clear();
            }
            e.Handled = true;
        }

    }
}

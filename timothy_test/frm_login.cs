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
    
    public partial class frm_login : Form
    {
        string result;
        BusinessLayer bl = new BusinessLayer();
        public frm_login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if(txtuid.Text.Equals(""))
            {
                MessageBox.Show("Please enter userid.", "Health Care Application.");
            }
            else if(txtpass.Text.Equals(""))
            {
                MessageBox.Show("Please enter password.", "Health Care Application.");
            }
            else
            {
                result=(bl.validateuser(txtuid.Text,txtpass.Text));
                    if(result!=null)
                {

                }
            }
        }
    }
}

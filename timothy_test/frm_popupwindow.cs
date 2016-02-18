using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlServerCe;


namespace timothy_test
{
    public partial class frm_popupwindow : Form
    {
        DataTable dt = new DataTable();
        BusinessLayer bl = new BusinessLayer();
        
        public frm_popupwindow()
        {
            InitializeComponent();
        }

        private void frm_popupwindow_Load(object sender, EventArgs e)
        {
            bind_list();
        }

        public void bind_list()
        {
            //function for binding the list that is adding the items in listbox            
            try
            {
                dt = bl.displaylist();
                foreach (DataRow r in dt.Rows)
                {
                    lst_main.Items.Add(r["MenuKey"].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }
    }
}

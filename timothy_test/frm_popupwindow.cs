using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;


namespace timothy_test
{
    public partial class frm_popupwindow : Form
    {
        DataTable dt = new DataTable();
        BusinessLayer bl = new BusinessLayer();
        int cnt = 0, maxcnt = 0, mainmenuid=0, flag;
        string submenuname;
        List<string> list = new List<string>();

        List<KeyValuePair<int,string>> data = new List<KeyValuePair<int,string>>();

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
                if (lst_main.Items.Count > 0)
                {
                    lst_main.Items.Clear();
                }
                dt = bl.displaylist();
                foreach (DataRow r in dt.Rows)
                {
                    lst_main.Items.Add(r["MenuKey"].ToString());
                    data.Add(new KeyValuePair<int, string>((int)r["Id"],r["MenuKey"].ToString()));
                }
                dt.Clear();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {

            try
            {
                if (cnt >= 0)
                {
                    cnt--;
                }
                    if (cnt == 0)
                    { bind_list(); }
                    //if (cnt == 1)
                    //{
                    //    for (int i = 0; i < data.Count; i++)
                    //    {
                    //        if (data[i].Value == lst_main.SelectedItem.ToString())
                    //        {
                    //            mainmenuid = data[i].Key;
                    //            maxcnt = bl.getsubmenucount(data[i].Key);
                    //            break;
                    //        }
                    //    }
                    //}
                    if (cnt >= 1 && cnt <= maxcnt)
                    {
                        submenuname = "menu" + cnt;
                        dt = bl.getsubmenus(mainmenuid, submenuname);
                        if (lst_main.Items.Count > 0)
                        {
                            lst_main.Items.Clear();
                        }
                        foreach (DataRow r in dt.Rows)
                        {
                            lst_main.Items.Add(r["Value"].ToString());
                            list.Add(r["Value"].ToString());
                        }
                    flag = bl.getismultiple(mainmenuid, submenuname);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void lst_main_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            try
            {
                if (lst_main.SelectedIndex > -1)
                {
                    cnt++;
                    if (cnt == 1)
                    {
                        for (int i = 0; i < data.Count; i++)
                        {
                            if (data[i].Value == lst_main.SelectedItem.ToString())
                            {
                                mainmenuid = data[i].Key;
                                maxcnt = bl.getsubmenucount(data[i].Key);
                                break;
                            }
                        }
                    }
                    if (cnt >= 1 && cnt <= maxcnt)
                    {
                        submenuname = "menu" + cnt;
                        dt = bl.getsubmenus(mainmenuid, submenuname);
                        if (lst_main.Items.Count > 0)
                        {
                            lst_main.Items.Clear();
                        }
                        foreach (DataRow r in dt.Rows)
                        {
                            lst_main.Items.Add(r["Value"].ToString());
                            list.Add(r["Value"].ToString());
                        }
                        flag = bl.getismultiple(mainmenuid, submenuname);
                        if (flag == 1)
                        {
                            lst_main.SelectionMode = SelectionMode.MultiSimple;
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

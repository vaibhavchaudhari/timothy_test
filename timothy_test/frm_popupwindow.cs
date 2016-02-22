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
using System.Web.UI.WebControls;

namespace timothy_test
{
    public partial class frm_popupwindow : Form
    {
        DataTable dt = new DataTable();
        BusinessLayer bl = new BusinessLayer();
        int cnt = 0, maxcnt = 0, mainmenuid=0, flag;
        string submenuname,descreption,selectediteam;
        List<string> list = new List<string>();
        List<string> newmenu = new List<string>();
        List<int> listBox1_selection = new List<int>();
        List<KeyValuePair<int,string>> data = new List<KeyValuePair<int,string>>();

        private void lst_main_DoubleClick(object sender, EventArgs e)
        {
            if (lst_main.SelectionMode == SelectionMode.One)
            { btn_next_Click(sender, e); }
        }

        private void lst_main_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==(Keys.Enter))
            {
                btn_next_Click(sender, e);
            }
        }

        public frm_popupwindow()
        {
            InitializeComponent();
        }

        private void frm_popupwindow_Load(object sender, EventArgs e)
        {
            bind_list();
            btn_prev.Visible = false;
            btn_next.Enabled = false;
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
                    { bind_list();
                    btn_prev.Visible = false;
                    txt_displaytext.Text = "";
                    lbl_selectiontype.Text = "";
                }
                if (cnt >= 1 && cnt <= maxcnt)
                {
                    if (btn_next.Visible == false) { btn_next.Visible = true; }
                    string newchar = list[cnt - 1].ToString();
                    string oldchar = newmenu[cnt-1].ToString();
                    descreption = descreption.Replace((oldchar), (newchar));
                    //selectediteam = newchar;
                   
                    txt_displaytext.Text = descreption;
                }
                if (cnt >= 1 && cnt <= maxcnt)
                    {
                    if (btn_next.Visible == false) { btn_next.Visible = true; }
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
                        string pqr = (list[cnt - 1]) + ":Can Select Multiple Values.";
                        pqr = pqr.Replace('#', ' ');
                        lbl_selectiontype.Text = pqr;
                    }
                    else {
                        lst_main.SelectionMode = SelectionMode.One;
                        string pqr = (list[cnt - 1]) + ":Select Single Value.";
                        pqr = pqr.Replace('#', ' ');
                        lbl_selectiontype.Text = pqr;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void lst_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btn_next.Enabled == false) { btn_next.Enabled = true; }
            if (lst_main.SelectionMode == SelectionMode.MultiSimple)
            {
                TrackSelectionChange((System.Windows.Forms.ListBox)sender, listBox1_selection);
                
            }
           
        }
        private void TrackSelectionChange(System.Windows.Forms.ListBox lb, List<int> selection)
        {
            System.Windows.Forms.ListBox.SelectedIndexCollection sic = lb.SelectedIndices;
             foreach (int index in sic)
                if (!selection.Contains(index)) selection.Add(index);

            foreach (int index in new List<int>(selection))
                if (!sic.Contains(index)) selection.Remove(index);
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_prev.Visible == false && newmenu.Count > 0)
                {
                    newmenu.Clear();
                }
                if (lst_main.SelectedIndex > -1)
                {
                    cnt++;
                    if (cnt == 1)
                    {
                        btn_prev.Visible = true;
                        for (int i = 0; i < data.Count; i++)
                        {
                            if (data[i].Value == lst_main.SelectedItem.ToString())
                            {
                                mainmenuid = data[i].Key;
                                maxcnt = bl.getsubmenucount(data[i].Key);
                                break;
                            }
                        }
                        descreption = bl.getdescreption(mainmenuid);
                        txt_displaytext.Text = descreption;
                        var pattern = @"(\#(?:.*?)\#)";
                        if (list.Count > 0)
                        {
                            list.Clear();
                        }
                        foreach (var m in System.Text.RegularExpressions.Regex.Split(descreption, pattern))
                        {
                            if (m.StartsWith("#") && m.EndsWith("#"))
                            {
                                list.Add(m);
                            }
                        }

                    }
                    if (cnt > 1 && cnt <= maxcnt + 1)
                    {
                        if (lst_main.SelectionMode == SelectionMode.MultiSimple)
                        {
                            string Tags = string.Empty;
                            if(listBox1_selection.Count>0)
                            {
                                for(int i=0;i<listBox1_selection.Count;i++)
                               {
                                    Tags += lst_main.Items[listBox1_selection[i]] + ",";
                                }
                                listBox1_selection.Clear();
                                Tags = Tags.Trim(',');
                                if (Tags.Contains(','))
                                {
                                    Tags = Tags.Insert((Tags.LastIndexOf(',')), " " + "and" + " ");
                                    Tags = Tags.Remove(Tags.LastIndexOf(','), 1);
                                }
                                    string oldchar = list[cnt - 2].ToString();
                                string newchar = Tags;
                                newmenu.Add(newchar);
                                descreption = descreption.Replace((oldchar), (newchar));
                                selectediteam = newchar;
                               
                                txt_displaytext.Text = descreption;
                            }
                        }
                        else
                        {
                            string oldchar = list[cnt - 2].ToString();
                            string newchar = lst_main.SelectedItem.ToString();
                            newmenu.Add(newchar);
                            descreption = descreption.Replace((oldchar), (newchar));
                            selectediteam = newchar;
                            
                            txt_displaytext.Text = descreption;
                        }
                        if(cnt==maxcnt+1)
                        {
                            Clipboard.SetDataObject(descreption, false, 5, 100);
                            SendKeys.SendWait("^V");
                            btn_next.Visible = false;
                            lst_main.Items.Clear();
                            lbl_selectiontype.Text = "";
                            
                            
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
                           // list.Add(r["Value"].ToString());
                        }
                        btn_next.Enabled = false;
                        flag = bl.getismultiple(mainmenuid, submenuname);
                        if (flag == 1)
                        {
                            lst_main.SelectionMode = SelectionMode.MultiSimple;
                            string pqr = (list[cnt - 1]) + ":Can Select Multiple Values.";
                            pqr = pqr.Replace('#', ' ');
                            lbl_selectiontype.Text = pqr;
                        }
                        else { lst_main.SelectionMode = SelectionMode.One;
                            string pqr = (list[cnt - 1]) + ":Select Single Value.";
                            pqr = pqr.Replace('#', ' ');
                            lbl_selectiontype.Text = pqr;
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

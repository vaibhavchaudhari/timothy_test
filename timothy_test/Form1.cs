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
    public partial class Form1 : Form
    {      
        BusinessLayer bl = new BusinessLayer();
        DataTable dt;
        int cnt = 0, llcnt = 0, ID = 0, startpoint = 0,mainmenueupdateid=0;
        string ans,status, lastWord, value1;
        List<string> list = new List<string>();
        public Form1()
        {
            InitializeComponent();            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bind_list();
            MainWindow();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            function_clear();
            lst_submenu.Items.Clear();
            status = "NEW";           
            txt_name.Focus();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            //serchin a record as per the text in textbox
            if (String.IsNullOrEmpty(txtSearch.Text.Trim()) == false)
            {
                lst_disease.Items.Clear();
                foreach (string str in list)
                {
                    if (str.ToLower().StartsWith(txtSearch.Text.ToLower().Trim()))
                    {
                        lst_disease.Items.Add(str);
                    }
                }
            }
        }
        private void btn_showall_Click(object sender, EventArgs e)
        {
            function_clear();
            bind_list();
        }
        protected void function_clear()
        {
            //finction for making all textboxes blank
            txt_description.Text = "";
            txt_name.Text = "";
            txtSearch.Text = "";
            txt_mainmenuname.Text = "";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //searching function on text change of text search
            if (String.IsNullOrEmpty(txtSearch.Text.Trim()) == false)
            {
                lst_disease.Items.Clear();
                foreach (string str in list)
                {
                    if (str.ToLower().StartsWith(txtSearch.Text.ToLower().Trim()))
                    {
                        lst_disease.Items.Add(str);
                    }
                }
            }
        }

        private void lst_disease_Click(object sender, EventArgs e)
        {
            if(status=="NEW")
            {
                status = "";
            }
            if (txt_description.Text != "")
            {
                txt_description.Text = "";
                txt_description.Controls.Clear();
            }
            try {
                //function for getting value of key in textbox txt_name
                string keys = lst_disease.GetItemText(lst_disease.SelectedItem);          
                if (keys != "")
            { 
            txt_name.Text = keys;
            DataTable decsreption = (bl.getvalue(keys));
            txt_description.Text = decsreption.Rows[0]["Value"].ToString();
            mainmenueupdateid = (Int32)decsreption.Rows[0]["Id"];
                if(lst_submenu.Items.Count>0)
                {
                    lst_submenu.Items.Clear();
                }
                for (int i = 0; i <= txt_description.TextLength; i++)
                {
                        //adding the values in listbox of sub menu 
                    if (txt_description.Text.Contains("menu"+i))
                    {
                        txt_mainmenuname.Text = txt_name.Text;
                            lst_submenu.Items.Add("menu" + i);
                            //lst_submenu.DisplayMember = "Name";
                            //lst_submenu.ValueMember = "Value";

                            //List<KeyValuePair<string, int>> data = new List<KeyValuePair<string, int>>();
                            //data.Add(new KeyValuePair<string, int>("-- Select --", 0));
                            //data.Add(new KeyValuePair<string, int>("15 minutes", 15));
                            //data.Add(new KeyValuePair<string, int>("30 minutes", 30));
                            //data.Add(new KeyValuePair<string, int>("45 minutes", 45));
                            //data.Add(new KeyValuePair<string, int>("60 minutes", 60));
                            //data.Add(new KeyValuePair<string, int>("75 minutes", 75));
                            //data.Add(new KeyValuePair<string, int>("90 minutes", 90));
                            //data.Add(new KeyValuePair<string, int>("105 minutes", 105));
                            //data.Add(new KeyValuePair<string, int>("120 minutes", 120));
                            //data.Add(new KeyValuePair<string, int>("Custom minutes", -1));

                            //lst_submenu.DataSource = null;
                            //lst_submenu.Items.Clear();

                            //lst_submenu.DataSource = new BindingSource(data, null);
                            //lst_submenu.DisplayMember = "Key";
                            //lst_submenu.ValueMember = "Value";
                        }
                 }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            string key = txt_name.Text;
            string value = txt_description.Text;
            if (txt_name.Text == "" || txt_description.Text == "")
            {
                MessageBox.Show("PLEASE ENTER DATA FIRST");
            }
            else {
                if (status == "NEW")
                {
                  
                    try
                    {
                        //serching for is record already exist or not
                        int count = bl.ispreviousrecord(key);
                        if (count > 0)
                        {
                            MessageBox.Show("RECORD ALREADY EXIST PLEASE CHECK");
                        }
                        else
                        {
                            //function for saving that is inserting record in database
                            ans = bl.savemenu(key, value, cnt);
                            if (ans != null)
                            {
                                MessageBox.Show("RECORD INSERTED SUCCESSFULLY");
                                bind_list();
                                function_clear();
                                lst_submenu.Items.Clear();
                                status = "";
                                if (llcnt > 0)
                                {
                                    txt_description.Controls.Clear();
                                }
                            }
                            else
                            {
                                MessageBox.Show("PLEASE TRY AGAIN");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    int countofmenu=0;
                    for (int i = 0; i <= txt_description.TextLength; i++)
                    {
                        if (txt_description.Text.Contains("menu" + i))
                        {
                            countofmenu++;
                        }
                    }
                  string [] newsubmenukeyvalue=new string[countofmenu];
                    int count=0;
                   for (int i=1;i<=txt_description.TextLength;i++)
                    {
                        if(txt_description .Text.Contains("menu"+i))
                        {                           
                            newsubmenukeyvalue[count] = "menu" + i;
                            count++;
                        }
                    }
                    try { 
                        //if the save button is presed without new then function for updating the record
                   ans = bl.updatemenu(txt_name.Text,newsubmenukeyvalue,txt_description.Text, mainmenueupdateid);
                    if (ans != null)
                    {
                        MessageBox.Show("RECORD UPDATED SUCCESSFULLY");
                        bind_list();
                        function_clear();
                            lst_submenu.Items.Clear();
                        if (llcnt > 0)
                        {
                            txt_description.Controls.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("PLEASE TRY AGAIN");
                    }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }              
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == ""||txt_description.Text=="")
            {
                MessageBox.Show("PLEASE SELECT VALUE FIRST");
            }
            else
            {
                DialogResult delresult = MessageBox.Show("DO YOU REALLY WANT TO DELETE", "CONFIRM DELETION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (delresult == DialogResult.Yes)
                {
                    try {
                        //checking for is menue contains sub menu or not
                        if (txt_description.Text.Contains("menu"))
                        { 
                            MessageBox.Show("MENU CONTAINS SUBMENU CANNOT DELETE");
                        }
                        else
                        {
                            //function for deleting the record
                            ans = bl.delete_record(txt_name.Text);
                            if (ans != null)
                            {
                                MessageBox.Show("DELETED SUCCESSFULLY");
                                bind_list();
                                lst_submenu.Items.Clear();
                                function_clear();
                            }
                            else
                            {
                                MessageBox.Show("PLEASE TRY AGAIN");
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

        private void txt_description_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == ' ')
            {
                int st = txt_description.SelectionStart;
                String nm;
                lastWord = txt_description.Text.Split(' ')[txt_description.Text.Split(' ').Count() - 1];
                if (status == "NEW" && lastWord.ToLower().Equals("menu"))
                {
                    //function for adding new menu with incresed counter like menu1,menu2...
                    cnt++;
                    txt_description.Text = txt_description.Text.Remove((txt_description.TextLength - 5), 5);
                    nm = (" menu" + cnt);
                    startpoint = txt_description.TextLength - 6;
                    txt_description.SelectionStart = txt_description.TextLength;
                    txt_description.SelectionLength = 0;
                    txt_description.SelectionColor = Color.Blue;
                    txt_description.AppendText(nm);
                    txt_description.SelectionColor = txt_description.ForeColor;
                }
                if (cnt > 1 && status == "NEW")
                {
                    for (int i = 0; i < txt_description.Text.Length; i++)
                    {
                        if (txt_description.Text.Contains("menu" + i))
                        {
                            nm = "menu" + i;
                            this.CheckKeyword(nm, Color.Blue, 0);
                            txt_description.SelectionStart = st + 1;
                        }
                    }
                }

                if (status != "NEW")
                {
                    //function for adding menu with incresed counter like menu1,menu2... when status is not new that is while updating the record
                    int s = txt_description.SelectionStart;
                    int startpoint = s - 5;
                    string word = txt_description.Text.Substring(startpoint, 5);
                    if (word.ToLower().Trim().Equals("menu"))
                    {
                        for (int i = 1; i <= txt_description.Text.Length; i++)
                        {
                            if (txt_description.Text.Contains("menu" + i))
                            {
                                llcnt++;
                                if(i>llcnt)
                                {
                                    llcnt = i;
                                }
                            }                            
                        }
                        llcnt = llcnt + 1;
                       txt_description.Text = txt_description.Text.Remove(startpoint , 5);
                        nm = (" menu" + llcnt);
                       txt_description.Text = txt_description.Text.Insert(startpoint, nm);
                        txt_description.SelectionStart = st + 1;
                        llcnt = 0;
                    }
                }                
            }           
        }
        
        private void txt_description_TextChanged(object sender, EventArgs e)
      {
            string nm;
            for(int i=0;i<=txt_description.TextLength;i++)
            {
                if(txt_description .Text .Contains ("menu"+i))
                {
                    nm = "menu" + i;
                    this.CheckKeyword(nm, Color.Blue, 0);
                }
            }
        }

        private void lst_submenu_SelectedIndexChanged(object sender, EventArgs e)
        { //code to bind gridview to display data..
            try
            {
                BindGrid();
                clearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //code to add record into database on button click
            try
            {
                if (txt_Value.Text != "" && txt_Value.Text.Trim() == " " && txt_record_id.Text != "")
                {
                    string s = data_grid.Rows[0].Cells["SubMenuId"].Value.ToString();
                   ans= bl.save_submenu(s, txt_Value.Text);
                 if(ans != null)
                    { 
                            MessageBox.Show("Record Inserted Successfully");
                            BindGrid();
                            clearData();
                     }                  
                }
                else
                {
                    MessageBox.Show("Please Provide Value!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            //code to update record into database on button click
            try
            {
                if (txt_Value.Text != "" || txt_Value.Text.Trim() != "" || txt_record_id.Text != "")
                {
                 ans=bl.update_submenu(txt_record_id.Text);
                    if (ans != null)
                    {
                        MessageBox.Show("Record Updated Successfully");                          
                           BindGrid();
                           clearData();                      
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Record to Update");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_delete_record_Click(object sender, EventArgs e)
        {
            ////code to delete record into database on button click
            try
            {
                if (txt_Value.Text != "" || txt_Value.Text.Trim() != "" || txt_record_id.Text != "")
                {
                   
                    ans = bl.del_submenu(txt_record_id.Text);
                    if (ans != null)
                    {
                        MessageBox.Show("Record Deleted Successfully!");
                            BindGrid();
                            clearData();
                     }
                 }
               else
                {
                    MessageBox.Show("Please Select Record to Delete!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void data_grid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {//data grid view Mouse click event
            try { ID = Convert.ToInt32(data_grid.Rows[e.RowIndex].Cells[0].Value.ToString()); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void data_grid_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in data_grid.SelectedRows)
                {
                    value1 = row.Cells[0].Value.ToString();
                    MessageBox.Show(value1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void data_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.data_grid.Rows[e.RowIndex];
                    txt_Value.Text = row.Cells["Value"].Value.ToString();
                    txt_record_id.Text = row.Cells["Id"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void clearData()
        {//code to clear all specified textboxes when this function is called
            try
            {
                txt_Value.Text = String.Empty;
                txt_record_id.Text = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindGrid()
        {//code to bind gridview with the database..
            try
            {
                string text = lst_submenu.GetItemText(lst_submenu.SelectedItem);
                if (text != "")
                {
                    DataTable dt = bl.BindGrid(text);
                }
                    if (dt != null)
                {
                    data_grid.DataSource = dt;
                    data_grid.Columns["Id"].Visible = false;
                    data_grid.Columns["SubMenuId"].Visible = false;
                    int i = 1; foreach (DataGridViewRow row in data_grid.Rows)
                    {
                        row.Cells["serial_number"].Value = i; i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
       
        private void CheckKeyword(string word, Color color, int startIndex)
        {
            //special function for converting normal menu word with forecolor
            if (this.txt_description.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.txt_description.SelectionStart;

                while ((index = this.txt_description.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.txt_description.Select((index + startIndex), word.Length);
                    this.txt_description.SelectionColor = color;
                    this.txt_description.Select(selectStart, 0);
                    this.txt_description.SelectionColor = Color.Black;
                }
            }
        }       
        public void MainWindow()
        {
            //function for adding values in list collection which will be benificial for sorting purpose
            list.Clear();
            foreach (String str in lst_disease.Items)
            {
                list.Add(str);
            }
        }
        public void bind_list()
        {
            //function for binding the list that is adding the items in listbox            
            if (lst_disease.Items.Count > 0)
            {
                lst_disease.Items.Clear();
            }
            try {
                dt = bl.displaylist();
                foreach (DataRow r in dt.Rows)
            {
                lst_disease.Items.Add(r["MenuKey"].ToString());               
            }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }
    }
}

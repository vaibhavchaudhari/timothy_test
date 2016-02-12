using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nemiro.OAuth;
using Nemiro.OAuth.LoginForms;
using System.IO;
using System.Text.RegularExpressions;

namespace timothy_test
{


    public partial class HealthCareMaster : Form
    {
        BusinessLayer bl = new BusinessLayer();
        DataTable dt;
        SqlCeConnection connection;
        string connectionString, nmmenu, id, text, result, ans, status = "NEW", itemofdata;
        int id1, delete_id;
        string s = "Health Care Application";               
        int llcnt = 0, mainmenueupdateid = 0;
        List<string> list = new List<string>();
        List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
        
        public HealthCareMaster()
        {
            InitializeComponent();          
            connectionString = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
            // TODO: This line of code loads data into the 'helathDiagnosticDataSet1.SubMenuValue' table. You can move, or remove it, as needed.
           // this.subMenuValueTableAdapter.Fill(this.helathDiagnosticDataSet1.SubMenuValue);
            bind_list();
            MainWindow();
            status = "NEW";
            btn_new.BackColor = Color.LightBlue;
            txt_name.Select();
            if (lst_disease.Items.Count == 0)
            {
                panel2.Enabled = false;
            }
            if (string.IsNullOrEmpty(Properties.Settings.Default.AccessToken))
            {
                this.GetAccessToken();
            }
        }
        private void GetAccessToken()
        {
            var login = new DropboxLogin("4077k3k1tkb3oyj", "ipvghmm1wpbqewv");
            login.Owner = this;
            login.ShowDialog();
            if (login.IsSuccessfully)
            {
                Properties.Settings.Default.AccessToken = login.AccessToken.Value;
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("Error While Login",s);
            }
        }
        private void btn_new_Click(object sender, EventArgs e)
        {
            function_clear();
            status = "NEW";
            lst_disease.SelectedIndex = -1;
            txt_name.Focus();
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
            lbl_mainmenuname.Text = "";
            lst_grid.DataSource = null;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            clearData();
            //searching function on text change of text search
            if (txtSearch.Text == "")
            {
                bind_list();
            }
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

            btn_new.BackColor = SystemColors.Control;
            if (status == "NEW")
            {
                status = "";
            }
            if (txt_description.Text != "")
            {
                txt_description.Text = "";
                txt_description.Controls.Clear();
            }
            try
            {
                if (test_grid.DataSource != null)
                {
                    test_grid.DataSource = null;
                    test_grid.Columns.Clear();
                }
              

                //function for getting value of key in textbox txt_name
                string keys = lst_disease.GetItemText(lst_disease.SelectedItem);
                if (keys != "")
                {
                    txt_name.Text = keys;
                    DataTable decsreption = (bl.getvalue(keys));
                    mainmenueupdateid = (Int32)decsreption.Rows[0]["Id"];
                    Bind_firstgrid();
                    DataTable submenulist = bl.fillsubmenulist(mainmenueupdateid);
                    if (data.Count > 0)
                    {
                        data.Clear();
                    }
                    if (submenulist != null && submenulist.Rows.Count > 0)
                    {
                        foreach (DataRow row in submenulist.Rows)
                        {
                            data.Add(new KeyValuePair<string, string>(row["SubMenuKeyValue"].ToString(), row["AliasName"].ToString()));
                        }
                    }
                    txt_description.Text = decsreption.Rows[0]["Value"].ToString();
                    if (data.Count > 0)
                    {                       
                        lbl_mainmenuname.Text = txt_name.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), s);
            }
        }
        private void Bind_firstgrid()
        {
            lbl_mainmenuname.Text = txt_name.Text;
            try
            {
                using (connection = new SqlCeConnection(connectionString))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand("select Id,AliasName,IsMultipleChoice from SubMenuKey where MainMenuId ='" + mainmenueupdateid + "'", connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        connection.Open();

                        DataTable dt1 = new DataTable();
                        dt1.Load(cmd.ExecuteReader());
                        {
                            lst_grid.DataSource = dt1;
                            int i = 1; foreach (DataGridViewRow row in lst_grid.Rows)
                            {
                                row.Cells["serial_no"].Value = i;
                                lst_grid.Rows[i - 1].Tag = row.Cells["Id"].Value;                               
                                i++;
                            }
                            lst_grid.Columns[1].Width = 30;
                            lst_grid.Columns[2].Width = 150;
                            lst_grid.Columns[3].Width = 80;
                            lst_grid.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                            lst_grid.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                            lst_grid.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                            lst_grid.DefaultCellStyle.Font = new Font("TimesNewRoman", 10);
                            lst_grid.ColumnHeadersDefaultCellStyle.Font = new Font("TimesNewRoman", 10);
                            lst_grid.Columns[2].HeaderText = "Value";
                            lst_grid.Columns[3].HeaderText = "MultiValue";
                        }
                        lst_grid.Columns["Id"].Visible = false;
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), s);
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            string key = txt_name.Text.Trim();
            string value = txt_description.Text.Trim();
            if (txt_name.Text == "")
            {
                MessageBox.Show("Please Enter Name To Add Record.", s);
                return;
            }
            else if (txt_description.Text == "")
            {
                MessageBox.Show("Please Enter Description.", s);
                return;
            }
            else {
                if (status == "NEW")
                {
                    try
                    {
                        int noofhash = Regex.Matches(txt_description.Text, "[#]").Count;
                        if (noofhash % 2 != 0)
                        {
                            MessageBox.Show("Number of Menus are Not Matching.", s);
                            return;
                        }
                        //serching for is record already exist or not
                        int count = bl.ispreviousrecord(key);
                        if (count > 0)
                        {
                            MessageBox.Show("Record Already Exists!", s);
                        }
                        else
                        {
                            //function for saving that is inserting record in database
                            if (data.Count > 0)
                            {
                                data.Clear();
                            }
                            int cnt = 1;
                            string str = txt_description.Text;
                            var pattern = @"(\#(?:.*?)\#)";
                            foreach (var m in System.Text.RegularExpressions.Regex.Split(str, pattern))
                            {
                                if (m.StartsWith("#") && m.EndsWith("#"))
                                {
                                    itemofdata = m;
                                    itemofdata = itemofdata.Replace('#', ' ');
                                    data.Add(new KeyValuePair<string, string>(("menu" + cnt), (itemofdata.Trim())));
                                    cnt++;
                                }
                            }
                            ans = bl.savemenu(key, value, cnt, data);
                            if (ans != null)
                            {
                                MessageBox.Show("Record Inserted Successfully.", s);
                                nmmenu = txt_name.Text;
                                bind_list();
                                MainWindow();
                                //function_clear();
                                data.Clear();
                                Bind_firstgrid();
                                int currentPrinterIndex = lst_disease.Items.IndexOf(nmmenu);

                                if (nmmenu != "")
                                {
                                    txt_name.Text = nmmenu;
                                    DataTable decsreption = (bl.getvalue(nmmenu));
                                    mainmenueupdateid = (Int32)decsreption.Rows[0]["Id"];
                                    Bind_firstgrid();
                                }
                                lst_disease.SelectedIndex = currentPrinterIndex;
                                if (llcnt > 0)
                                {
                                    txt_description.Controls.Clear();
                                }
                                if (panel2.Enabled == false)
                                {
                                    panel2.Enabled = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please Try Again!!!", s);
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
                    try
                    {
                        int noofhash = Regex.Matches(txt_description.Text, "[#]").Count;
                        if (noofhash % 2 != 0)
                        {
                            MessageBox.Show("Number of Menus are Not Matching.", s);
                            return;
                        }
                        //if the save button is presed without new then function for updating the record
                        if (data.Count > 0)
                        {
                            data.Clear();
                        }
                        int cnt = 1;
                        string str = txt_description.Text;
                        var pattern = @"(\#(?:.*?)\#)";
                        foreach (var m in System.Text.RegularExpressions.Regex.Split(str, pattern))
                        {
                            if (m.StartsWith("#") && m.EndsWith("#"))
                            {
                                itemofdata = m;
                                itemofdata = itemofdata.Replace('#', ' ');
                                data.Add(new KeyValuePair<string, string>(("menu" + cnt), (itemofdata.Trim())));
                                cnt++;
                            }
                        }
                        ans = bl.updatemenu(txt_name.Text, data, txt_description.Text, mainmenueupdateid);
                        if (ans != null)
                        {
                            Bind_firstgrid();
                            MessageBox.Show("Record Updated Successfully.", s);
                            nmmenu = txt_name.Text;
                            bind_list();
                            nmmenu = txt_name.Text;
                            bind_list();

                            MainWindow();
                            //function_clear();
                            data.Clear();
                            int currentPrinterIndex = lst_disease.Items.IndexOf(nmmenu);
                            if (nmmenu != "")
                            {
                                txt_name.Text = nmmenu;
                                DataTable decsreption = (bl.getvalue(nmmenu));
                                mainmenueupdateid = (Int32)decsreption.Rows[0]["Id"];
                                Bind_firstgrid();
                            }
                            lst_disease.SelectedIndex = currentPrinterIndex;
                            if (llcnt > 0)
                            {
                                txt_description.Controls.Clear();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Try Again.", s);
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

            if (txt_name.Text == "" || txt_description.Text == "")
            {
                MessageBox.Show("Please Select Record To Delete.", s);
            }
            else
            {
                DialogResult delresult = MessageBox.Show("Do You Really Want to Delete", s, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (delresult == DialogResult.Yes)
                {
                    try
                    {
                        //function for deleting the record
                        ans = bl.delete_record(txt_name.Text);
                        if (!ans.Equals("0"))
                        {
                            function_clear();
                            bind_list();
                            MessageBox.Show("Record Deleted Successfully.", s);
                            MainWindow();
                            if (lst_disease.Items.Count == 0)
                            {
                                status = "NEW";
                                panel2.Enabled = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Try Again.", s);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }
        private void txt_description_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ControlExtensions.Suspend(txt_description);
                // string str = txt_description.Text;
                int noofhash = Regex.Matches(txt_description.Text, "[#]").Count;
                int getcount = 0;
                var pattern = @"(\#(?:.*?)\#)";
                if (noofhash % 2 == 0)
                {
                    // this.txt_description.ForeColor = Color.Black;//parag
                    foreach (var m in System.Text.RegularExpressions.Regex.Split(txt_description.Text.Trim(), pattern))
                    {
                        getcount++;
                        if (m.StartsWith("#") && m.EndsWith("#"))
                        {
                            itemofdata = m;
                            itemofdata = itemofdata.Trim();
                            this.CheckKeyword(itemofdata, Color.Red, 0);
                        }
                        else
                        {
                            if (getcount == 1 || m.Trim() == "" || m.Trim() == " ")
                            { continue; }
                            itemofdata = m;
                            itemofdata = itemofdata.Trim();
                            this.CheckKeyword(itemofdata, Color.Black, 0);
                        }
                    }
                }
                ControlExtensions.Resume(txt_description);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), s);
            }

        }
        private void test_grid_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            test_grid.Refresh();
            if ((e.RowIndex > -1) && (test_grid.CurrentCell.ColumnIndex == 2))
            {
                int a = e.RowIndex;                
                id = test_grid.Rows[e.RowIndex].Cells["Id"].Value.ToString();              
                if (id == "")
                {
                    id1 = 0;
                }
                else
                {
                    id1 = Convert.ToInt32(test_grid.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                }

                if (id1 == 0)
                {
                    using (connection = new SqlCeConnection(connectionString))
                    {
                        SqlCeCommand cmd = connection.CreateCommand();
                        {
                            connection.Open();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "insert into SubMenuValue(SubMenuId,Value)values(" + text + ",'" + test_grid.Rows[e.RowIndex].Cells["Value"].Value.ToString() + "')";
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            Bindtest();
                        }

                    }
                }
                else
                {
                    using (connection = new SqlCeConnection(connectionString))
                    {
                        SqlCeCommand cmd = connection.CreateCommand();
                        {
                            connection.Open();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "update SubMenuValue set Value='" + test_grid.Rows[e.RowIndex].Cells["Value"].Value.ToString() + "' where Id=" + id1 + "";
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            Bindtest();
                        }

                    }


                }
            }
            else if ((e.RowIndex > -1) && (test_grid.CurrentCell.ColumnIndex == 3))
            {
                int a = e.RowIndex;               
                id = test_grid.Rows[e.RowIndex].Cells["Id"].Value.ToString();               
                if (id == "")
                {
                    id1 = 0;
                }
                else
                {
                    id1 = Convert.ToInt32(test_grid.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                }

                if (id1 == 0)
                {
                    using (connection = new SqlCeConnection(connectionString))
                    {
                        SqlCeCommand cmd = connection.CreateCommand();
                        {
                            connection.Open();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "insert into SubMenuValue(SubMenuId,Value) values(" + text + ",'" + test_grid.Rows[e.RowIndex].Cells["Value"].Value.ToString() + "')";
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            Bindtest();
                        }

                    }
                }
                else
                {
                    using (connection = new SqlCeConnection(connectionString))
                    {
                        SqlCeCommand cmd = connection.CreateCommand();
                        {
                            connection.Open();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "update SubMenuValue set Value='" + test_grid.Rows[e.RowIndex].Cells["Value"].Value.ToString() + "' where Id=" + id1 + "";
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            Bindtest();
                        }

                    }
                }
            }
        }

        private void txt_description_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (txt_description.Text != "")
                {
                    int selectionindex = txt_description.SelectionStart;
                    if (selectionindex <= 0)
                    {
                        return;
                    }
                    char getchar = txt_description.Text[selectionindex - 1];
                    if (e.KeyCode == Keys.Back && getchar == ('#') || e.KeyCode == Keys.Delete && getchar == ('#'))
                    {
                        int a = Regex.Matches(txt_description.Text, "[#]").Count;
                        if (a % 2 == 0)
                        {
                            int start = txt_description.SelectionStart;
                            string xyz = txt_description.Text.Substring(0, start - 1);
                            int index = xyz.LastIndexOf('#');
                            if (start > 0 && index > 0)
                            {
                                txt_description.Text = txt_description.Text.Remove(index, start - index);
                                txt_description.SelectionStart = index;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), s);
            }

        }

        private void Sync_Click(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\HealthDiagnostic.sdf";
            path = path.Replace("\\", "/");
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            OAuthUtility.PutAsync
               (
               "https://api-content.dropbox.com/1/files_put/auto/",
               new HttpParameterCollection
               {
                    {"access_token", Properties.Settings.Default.AccessToken },
                    {"path","/HealthDiagnostic.sdf" },
                    {"overwrite","true" },
                    {"autoname","true" },
                   { fs }
               },
               callback: upload_file
               );
        }

        private void upload_file(RequestResult result)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<RequestResult>(upload_file), result);
                return;
            }
            else
            {
                if (result["erros"].HasValue)
                {
                    MessageBox.Show(result["erros"].ToString(), "Health Care Application");
                }
                else
                {
                    MessageBox.Show("successfully uploaded", "Health Care Application");
                }
            }
        }
        private void test_grid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (test_grid.RowCount - 1 == test_grid.CurrentCell.RowIndex)
            {
                return;
            }
            else
            {
                delete_id = Convert.ToInt32(test_grid.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            }
            if (delete_id == 0 )
            {
                return;
            }
            else
            {
                int colindex = test_grid.CurrentCell.ColumnIndex;
                if (colindex == 3 && test_grid.Columns[colindex].HeaderText == "Delete")
                {
                    DialogResult delresult = MessageBox.Show("Do You Really Want to Delete record", s, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (delresult == DialogResult.Yes)
                    {
                        using (connection = new SqlCeConnection(connectionString))
                        {
                            SqlCeCommand cmd = connection.CreateCommand();
                            {
                                connection.Open();
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "delete from SubMenuValue where Id=" + delete_id + "";
                                cmd.ExecuteNonQuery();
                               // test_grid.Refresh();
                            }
                            Bindtest();
                        }

                    }
                }

                else if (colindex == 1 && test_grid.Columns[colindex].HeaderText == "Delete")
                {
                    DialogResult delresult = MessageBox.Show("Do You Really Want to Delete record", s, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (delresult == DialogResult.Yes)
                    {

                        using (connection = new SqlCeConnection(connectionString))
                        {
                            SqlCeCommand cmd = connection.CreateCommand();
                            {
                                connection.Open();
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "delete from SubMenuValue where Id=" + delete_id + "";
                                cmd.ExecuteNonQuery();
                                test_grid.Refresh();
                            }
                            Bindtest();
                        }
                    }
                }
                else if (colindex == 0 && test_grid.Columns[colindex].HeaderText == "Delete")
                {
                    DialogResult delresult = MessageBox.Show("Do You Really Want to Delete record", s, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (delresult == DialogResult.Yes)
                    {
                        using (connection = new SqlCeConnection(connectionString))
                        {
                            SqlCeCommand cmd = connection.CreateCommand();
                            {
                                connection.Open();
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "delete from SubMenuValue where Id=" + delete_id + "";
                                cmd.ExecuteNonQuery();
                                test_grid.Refresh();
                            }
                            Bindtest();
                        }
                    }
                }
            }
        }
     
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            function_clear();
            bind_list();
        }     
        private void lst_grid_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {            
            int a = e.RowIndex;      
            if (e.ColumnIndex > 0 && e.RowIndex>-1) 
            {
                if (test_grid.Columns.Contains("btn"))
                { test_grid.Columns.Remove("btn"); }                            
                text = lst_grid.Rows[e.RowIndex].Cells[1].Value.ToString();
                Bindtest();
                adddel();
            }
                if (e.ColumnIndex == 3)
            {
                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                ch1 = (DataGridViewCheckBoxCell)lst_grid.Rows[lst_grid.CurrentRow.Index].Cells[3];
                if (ch1.Value == null)
                {
                    ch1.Value = false;
                }
                switch (ch1.Value.ToString())
                {
                    case "True":
                        ch1.Value = false;
                        break;
                    case "False":
                        ch1.Value = true;
                        break;
                }
                if (ch1.Value.ToString().Equals("True"))
                {
                    using (connection = new SqlCeConnection(connectionString))
                    {
                        using (SqlCeCommand cmd = new SqlCeCommand("Update SubMenuKey set IsMultipleChoice=1 where Id=" + text + "", connection))
                        {
                            connection.Open();
                            result = cmd.ExecuteNonQuery().ToString();
                            connection.Close();
                            if (result == null)
                            {
                                MessageBox.Show("Record Was Not Updated!",s);
                            }
                            else
                            {
                                MessageBox.Show("MultiValue Updated.",s);
                                Bindtest();
                            }
                        }
                    }
                }

                else if (ch1.Value.ToString().Equals("False"))
                {
                    using (connection = new SqlCeConnection(connectionString))
                    {
                        using (SqlCeCommand cmd = new SqlCeCommand("Update SubMenuKey set IsMultipleChoice=0 where Id=" + text + "", connection))
                        {
                            connection.Open();
                            result = cmd.ExecuteNonQuery().ToString();
                            connection.Close();
                            if (result == null)
                            {
                                MessageBox.Show("Record Was Not Updated!",s);
                            }
                            else
                            {
                                MessageBox.Show("Record Updated Successfully.",s);
                                Bindtest();
                            }
                        }
                    }
                }
            }
        }               
        private void clearData()
        {//code to clear all specified textboxes when this function is called
            try
            {
                txt_description.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void adddel()
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            test_grid.Columns.Add(btn);
            btn.HeaderText = "Delete";
            btn.Text = "Delete";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;

        }
        private void Bindtest()
        {
           
            try
            {   
                using (connection = new SqlCeConnection(connectionString))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand("select Id,Value from SubMenuValue where SubMenuId='" + text + "'", connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        connection.Open();

                        DataTable dt1 = new DataTable();
                        DataColumn dcAuto = new DataColumn();
                        dcAuto.AutoIncrement = true;
                        dcAuto.AutoIncrementSeed = 1;
                        dcAuto.ColumnName = "Sr. No.";
                        dt1.Columns.Add(dcAuto);
                        SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);
                        da.Fill(dt1);
                        test_grid.DataSource = dt1;
                        test_grid.Columns["Id"].Visible = false;
                        test_grid.DefaultCellStyle.Font = new Font("TimesNewRoman", 10);
                        test_grid.ColumnHeadersDefaultCellStyle.Font = new Font("TimesNewRoman", 10);
                        connection.Close();
                        test_grid.Refresh(); 
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
            else
            {
                this.txt_description.SelectionColor = Color.Black;
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
            try
            {
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

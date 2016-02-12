using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlServerCe;
using System.Configuration;
namespace timothy_test
{
    class DataLayer
    {
        public SqlCeConnection con;
        public SqlCeCommand cmd;
        string result;
        public DataLayer()
        {
            con = new SqlCeConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
            cmd = new SqlCeCommand();
        }
        public DataTable displaylist()
        {
            try
            {

                con.Open();
                cmd = new SqlCeCommand("select Id,MenuKey from MainMenu", con);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();
                return (dt);
            }
            catch (Exception e)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw (e);
            }
        }
        public string savemenu(string keys, string value, int updatecount, List<KeyValuePair<string, string>> data)
        {
            try
            {
                con.Open();
                cmd = new SqlCeCommand("insert into MainMenu(MenuKey,Value) VALUES(@keys,@value)", con);
                cmd.Parameters.AddWithValue("@keys", keys);
                cmd.Parameters.AddWithValue("@value", value);
                result = cmd.ExecuteNonQuery().ToString();
                cmd.Dispose();

                cmd = new SqlCeCommand("select Id from MainMenu where MenuKey=@keys", con);
                cmd.Parameters.AddWithValue("@keys", keys);
                int mainmenueid = (Int32)cmd.ExecuteScalar();
                cmd.Dispose();
                for (int i = 0; i <= data.Count - 1; i++)
                {
                    string submenukey = ("menu" + i);
                    cmd = new SqlCeCommand("insert into SubMenuKey(MainMenuId,SubMenuKeyValue,IsMultipleChoice,AliasName) VALUES(@mainmenueid,@submenukey,@ismultiple,@aliasname)", con);
                    cmd.Parameters.AddWithValue("@mainmenueid", mainmenueid);
                    cmd.Parameters.AddWithValue("@submenukey", data[i].Key);
                    cmd.Parameters.AddWithValue("@ismultiple", 0);
                    cmd.Parameters.AddWithValue("@aliasname", data[i].Value);
                    cmd.ExecuteNonQuery().ToString();
                }
                con.Close();
                return (result);
            }
            catch (Exception e)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw (e);
            }
        }
        public DataTable getvalue(string keys)
        {
            try
            {
                con.Open();
                cmd = new SqlCeCommand("select Id,Value from MainMenu where MenuKey=@keys", con);
                cmd.Parameters.AddWithValue("@keys", keys);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();
                return (dt);
            }
            catch (Exception e)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw (e);
            }
        }
        public string delete_record(string keys)
        {
            try
            {
                con.Open();
                cmd = new SqlCeCommand("delete from MainMenu where MenuKey=@keys", con);
                cmd.Parameters.AddWithValue("@keys", keys);
                result = cmd.ExecuteNonQuery().ToString();
                con.Close();
                return (result);
            }
            catch (Exception e)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw (e);
            }
        }
        public string updatemenu(string mainmenuekey, List<KeyValuePair<string, string>> newsubmenuekeyvalue, string descreption, int mainmenueupdateid)
        {
            int count = 0;
            DataTable previousmenue = new DataTable();
            try
            {
                con.Open();
                // cmd = new SqlCeCommand("select STUFF((SELECT ',' + AliasName FROM SubMenuKey where MainMenuId="+ mainmenueupdateid + " FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '')submenukey", con);
                cmd = new SqlCeCommand("select AliasName FROM SubMenuKey where MainMenuId=" + mainmenueupdateid + "", con);
                //cmd.Parameters.AddWithValue("@mainmenueid", mainmenueupdateid);
                previousmenue.Load(cmd.ExecuteReader());
                //  previousmenue = cmd.ExecuteScalar();
                cmd.Dispose();
                con.Close();
                con.Open();
                cmd = new SqlCeCommand("update MainMenu set Value=@descreption, MenuKey=@mainmenuekey where Id=@id", con);
                cmd.Parameters.AddWithValue("@descreption", descreption);
                cmd.Parameters.AddWithValue("@mainmenuekey", mainmenuekey);
                cmd.Parameters.AddWithValue("@id", mainmenueupdateid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                int datacount = previousmenue.Rows.Count;
                string[] previousmenuelist = new string[datacount];
                for (int i = 0; i <= datacount - 1; i++)
                {
                    previousmenuelist[i] = previousmenue.Rows[i]["AliasName"].ToString();
                }
                // = previousmenue.Split(',').Select(submenukey => submenukey.Trim()).ToArray();
                if ((newsubmenuekeyvalue.Count) < (previousmenuelist.Length))
                {
                    //Delete values for Sub menu which is not present in table
                    //delete from SubMenuKey where MainMenuId = 36 and SubMenuKeyValue not in ('menu1','menu2','menu3')
                    //Consider that menu1, 2 , 3 are coming as new value so deleting value menu4 from old insert as per above query.

                    string[] nm = new string[newsubmenuekeyvalue.Count];
                    for (int p = 0; p <= newsubmenuekeyvalue.Count - 1; p++)
                    { nm[p] = newsubmenuekeyvalue[p].Value; }
                    string delitem = string.Format("'{0}'", string.Join("','", nm));
                    con.Open();
                    cmd = new SqlCeCommand("delete from SubMenuKey where MainMenuId=" + mainmenueupdateid + " and AliasName not in (" + delitem + ")", con);
                    result = cmd.ExecuteNonQuery().ToString();
                    con.Close();
                    cmd.Dispose();
                    return (result);
                }


                else if ((newsubmenuekeyvalue.Count) > (previousmenuelist.Length - 1))
                {
                    if (previousmenuelist[0] == "")
                    {
                        con.Open();
                        cmd = new SqlCeCommand("insert into SubMenuKey(MainMenuId,SubMenuKeyValue,IsMultipleChoice,AliasName) values(@id,@newmenuekey,@ismultiple,@aliasname)", con);
                        cmd.Parameters.AddWithValue("@id", mainmenueupdateid);
                        cmd.Parameters.AddWithValue("@newmenuekey", newsubmenuekeyvalue[0].Key);
                        cmd.Parameters.AddWithValue("@ismultiple", 0);
                        cmd.Parameters.AddWithValue("@aliasname", newsubmenuekeyvalue[0].Value);

                        result = cmd.ExecuteNonQuery().ToString();
                        cmd.Dispose();
                        con.Close();

                    }

                    //Insert into table new values which are not present
                    //Run one for loop through all the new menu list
                    //insert into SubmenuKey (MainMenuId,SubMenuKeyValue,IsMultipleChoice)
                    //select 37,'menu1',0 from SubMenuKey where MainMenuId = 37 and SubMenuKeyValue != 'menu1'
                    for (int i = 0; i < previousmenuelist.Length; i++)
                    {
                        for (int j = 0; j < previousmenuelist.Length; j++)
                        {
                            if (previousmenuelist[j].Equals(newsubmenuekeyvalue[i].Value))
                            {
                                break;
                            }
                        }
                        count++;
                    }
                    for (int z = (count); z <= newsubmenuekeyvalue.Count - 1; z++)
                    {
                        con.Open();
                        cmd = new SqlCeCommand("insert into SubMenuKey(MainMenuId,SubMenuKeyValue,IsMultipleChoice,AliasName) values(@id,@newmenuekey,@ismultiple,@aliasname)", con);
                        cmd.Parameters.AddWithValue("@id", mainmenueupdateid);
                        cmd.Parameters.AddWithValue("@newmenuekey", newsubmenuekeyvalue[z].Key);
                        cmd.Parameters.AddWithValue("@ismultiple", 0);
                        cmd.Parameters.AddWithValue("@aliasname", newsubmenuekeyvalue[z].Value);
                        result = cmd.ExecuteNonQuery().ToString();
                        cmd.Dispose();
                        con.Close();
                    }
                    // return (result);
                }
                string querystring = "";
                for (int i = 0; i <= newsubmenuekeyvalue.Count - 1; i++)
                {
                    con.Open();
                    cmd = new SqlCeCommand("update SubMenuKey set AliasName='" + newsubmenuekeyvalue[i].Value + "' where SubMenuKeyValue='" + newsubmenuekeyvalue[i].Key + "' and MainMenuId=" + mainmenueupdateid + "", con);
                    result = cmd.ExecuteNonQuery().ToString();
                    cmd.Dispose();
                    con.Close();
                }
                if (!string.IsNullOrEmpty(querystring))
                {
                    //call databse code to fire the above statement.
                    con.Open();
                    cmd = new SqlCeCommand(querystring, con);
                    result = cmd.ExecuteNonQuery().ToString();
                    cmd.Dispose();
                    con.Close();
                }

                //previousmenue = "";
                return (result);
            }
            catch (Exception e)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw (e);
            }
        }


        public int ispreviousrecord(string key)
        {
            try
            {
                con.Open();
                cmd = new SqlCeCommand("select count(*) from MainMenu where MenuKey='" + key + "'", con);
                //cmd.Parameters.AddWithValue("@key", key);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                int count = (Int32)cmd.ExecuteScalar();
                cmd.Dispose();
                con.Close();
                return (count);
            }
            catch (Exception e)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw (e);
            }
        }
        public DataTable BindGrid(string text)
        {
            try
            {
                con.Open();
                cmd = new SqlCeCommand("SELECT * FROM SubMenuValue where SubMenuId='" + text + "'", con);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();
                cmd.Dispose();
                return (dt);
            }
            catch (Exception e)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw (e);
            }
        }
        public string del_submenu(string record_id)
        {
            try
            {
                con.Open();
                cmd = new SqlCeCommand("delete from SubMenuValue where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", record_id);
                result = cmd.ExecuteNonQuery().ToString();
                cmd.Dispose();
                con.Close();
                return (result);
            }
            catch (Exception e)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw (e);
            }
        }
        public string update_submenu(string record_id, string value)
        {
            try
            {
                con.Open();
                cmd = new SqlCeCommand("update SubMenuValue set Value=@Value where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Value", value);
                cmd.Parameters.AddWithValue("@Id", record_id);
                result = cmd.ExecuteNonQuery().ToString();
                cmd.Dispose();
                con.Close();
                return (result);
            }
            catch (Exception e)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw (e);
            }

        }
        public string save_submenu(string submenuid, string Value)
        {
            try
            {
                con.Open();
                cmd = new SqlCeCommand("insert into SubMenuValue(SubMenuId,Value) values(@SubMenuId,@Value)", con);
                cmd.Parameters.AddWithValue("@SubMenuId", submenuid);
                cmd.Parameters.AddWithValue("@Value", Value);
                result = cmd.ExecuteNonQuery().ToString();
                cmd.Dispose();
                con.Close();
                return (result);
            }
            catch (Exception e)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw (e);
            }

        }
        public DataTable fillsubmenulist(int mainmenueupdateid)
        {
            try
            {
                con.Open();
                cmd = new SqlCeCommand("SELECT SubMenuKeyValue,AliasName FROM SubMenuKey where MainMenuId='" + mainmenueupdateid + "'", con);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();
                cmd.Dispose();
                return (dt);
            }
            catch (Exception e)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw (e);
            }
        }
    }
}
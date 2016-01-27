using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace timothy_test
{
    class DataLayer
    {
        public SqlConnection con;
        public SqlCommand cmd;
        string result,previousmenue;
        public DataLayer()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
            cmd = new SqlCommand();
        }
        public DataTable displaylist()
        {
            try { 
            con.Open();
            cmd = new SqlCommand("select Id,MenuKey from MainMenu", con);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return (dt);
            }
            catch(Exception e)
            {
                throw (e);
            }
        }
        public string savemenu(string keys, string value, int updatecount)
        {
            try { 
            con.Open();
            cmd = new SqlCommand("insert into MainMenu VALUES(@keys,@value)", con);
            cmd.Parameters.AddWithValue("@keys", keys);
            cmd.Parameters.AddWithValue("@value", value);
            result = cmd.ExecuteNonQuery().ToString();
            cmd.Dispose();
            cmd = new SqlCommand("select Id from MainMenu where MenuKey=@keys", con);
            cmd.Parameters.AddWithValue("@keys", keys);
            int mainmenueid = (Int32)cmd.ExecuteScalar();
            cmd.Dispose();
            for (int i = 1; i <= updatecount; i++)
            {
                string submenukey = ("menu" + i);
                cmd = new SqlCommand("insert into SubMenuKey VALUES(@mainmenueid,@submenukey,@ismultiple)", con);
                cmd.Parameters.AddWithValue("@mainmenueid", mainmenueid);
                cmd.Parameters.AddWithValue("@submenukey", submenukey);
                cmd.Parameters.AddWithValue("@ismultiple", 1);
                cmd.ExecuteNonQuery().ToString();
            }
            con.Close();
            return (result);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
        public DataTable getvalue(string keys)
        {
            try { 
            con.Open();
            cmd = new SqlCommand("select Id,Value from MainMenu where MenuKey=@keys", con);
            cmd.Parameters.AddWithValue("@keys", keys);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return (dt);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
        public string delete_record(string keys)
        {
            try { 
            con.Open();
            cmd = new SqlCommand("delete from MainMenu where MenuKey=@keys", con);
            cmd.Parameters.AddWithValue("@keys", keys);
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return (result);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
        public string updatemenu(string mainmenuekey,string []newsubmenuekeyvalue, string descreption,int mainmenueupdateid)
        {
            
            int count=0;
            //int flag=0;
            //con.Open();
            //cmd = new SqlCommand("select Id FROM MainMenu where MenuKey=@mainmenuekey", con);
            //cmd.Parameters.AddWithValue("@mainmenuekey", mainmenuekey);
            //id = (int)cmd.ExecuteScalar();
            //cmd.Dispose();
            //con.Close();
            try { 
            con.Open();
            cmd = new SqlCommand("select STUFF((SELECT ',' + SubMenuKeyValue FROM SubMenuKey where MainMenuId=@mainmenueid FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '')submenukey", con);
            cmd.Parameters.AddWithValue("@mainmenueid", mainmenueupdateid);
            previousmenue = cmd.ExecuteScalar().ToString();
            cmd.Dispose();
            con.Close();
            con.Open();
            cmd = new SqlCommand("update MainMenu set Value=@descreption, MenuKey=@mainmenuekey where Id=@id", con);
            cmd.Parameters.AddWithValue("@descreption", descreption);
            cmd.Parameters.AddWithValue("@mainmenuekey", mainmenuekey);
            cmd.Parameters.AddWithValue("@id", mainmenueupdateid);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            string [] previousmenuelist = previousmenue.Split(',').Select(submenukey => submenukey.Trim()).ToArray();
            if((newsubmenuekeyvalue.Length)<(previousmenuelist.Length))
            {
                //Delete values for Sub menu which is not present in table
                //delete from SubMenuKey where MainMenuId = 36 and SubMenuKeyValue not in ('menu1','menu2','menu3')
                //Consider that menu1, 2 , 3 are coming as new value so deleting value menu4 from old insert as per above query.
                string delitem = string.Format("'{0}'", string.Join("','", newsubmenuekeyvalue));
                con.Open();
                cmd = new SqlCommand("delete from SubMenuKey where MainMenuId="+ mainmenueupdateid + " and SubMenuKeyValue not in ("+delitem+")", con);
                result = cmd.ExecuteNonQuery().ToString();
                con.Close();
                cmd.Dispose();
                 return (result);
            }

            else if ((newsubmenuekeyvalue.Length) > (previousmenuelist.Length))
            {

                //Insert into table new values which are not present
                //Run one for loop through all the new menu list
                //insert into SubmenuKey (MainMenuId,SubMenuKeyValue,IsMultipleChoice)
                //select 37,'menu1',0 from SubMenuKey where MainMenuId = 37 and SubMenuKeyValue != 'menu1'
                for (int i = 0; i < previousmenuelist.Length; i++)
                {
                    for (int j = 0; j < previousmenuelist.Length; j++)
                    {
                        if (previousmenuelist[j].Equals(newsubmenuekeyvalue[i]))
                        {
                            break;
                        }
                    }
                    count++;
                }
                for(int z=(count); z<=newsubmenuekeyvalue.Length-1; z++)
                {
                    con.Open();
                    cmd = new SqlCommand("insert into SubMenuKey values(@id,@newmenuekey,@ismultiple)", con);
                    cmd.Parameters.AddWithValue("@id", mainmenueupdateid);
                    cmd.Parameters.AddWithValue("@newmenuekey", newsubmenuekeyvalue[z]);
                    cmd.Parameters.AddWithValue("@ismultiple", 1);
                    result = cmd.ExecuteNonQuery().ToString();
                    cmd.Dispose();
                    con.Close();                                     
                }
                return (result);
            }
            previousmenue = "";
            return ("abc");
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
        public int ispreviousrecord(string key)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select count(*) from MainMenu where MenuKey=@key", con);
                cmd.Parameters.AddWithValue("@key", key);
                int count= (Int32)cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                return (count);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
        public DataTable BindGrid(string text)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT * FROM SubMenuValue where SubMenuId='" + text + "'", con);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();
                cmd.Dispose();
                return (dt);
            }
            catch(Exception e)
            {
                throw (e);
            }
        }
        public string del_submenu(string record_id)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("delete from SubMenuValue where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", record_id);
                result = cmd.ExecuteNonQuery().ToString();
                cmd.Dispose();
                con.Close();
                return (result);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
        public string update_submenu(string record_id)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("update SubMenuValue set Value=@Value where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", record_id);
                result = cmd.ExecuteNonQuery().ToString();
                cmd.Dispose();
                con.Close();
                return (result);
            }
            catch (Exception e)
            {
                throw (e);
            }

        }
        public string save_submenu(string submenuid, string Value)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("insert into SubMenuValue(SubMenuId,Value) values(@SubMenuId,@Value)", con);
                cmd.Parameters.AddWithValue("@SubMenuId", submenuid);
                cmd.Parameters.AddWithValue("@Value", Value);
                result = cmd.ExecuteNonQuery().ToString();
                cmd.Dispose();
                con.Close();
                return (result);
            }
            catch (Exception e)
            {
                throw (e);
            }

        }
    }
}

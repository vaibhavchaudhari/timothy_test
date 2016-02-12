using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace timothy_test
{
    class BusinessLayer
    {
        DataLayer dl = new DataLayer();
        public DataTable displaylist()
        {
            return (dl.displaylist());
        }
        public string savemenu(string key, string value, int llcnt,List<KeyValuePair<string, string>> data)
        {
            return (dl.savemenu(key, value, llcnt, data));
        }
        public DataTable getvalue(string keys)
        {
            return (dl.getvalue(keys));
        }
        public string delete_record(string keys)
        {
            return (dl.delete_record(keys));
        }
        public string updatemenu(string mainmenuekey, List<KeyValuePair<string, string>> newsubmenuekeyvalue, string descreption,int mainmenueupdateid)
        {
           return( dl.updatemenu( mainmenuekey,newsubmenuekeyvalue,descreption, mainmenueupdateid));
        }
        public int ispreviousrecord(string key)
        {
            return (dl.ispreviousrecord(key));
        }
        public DataTable BindGrid(string text)
        {
           return( dl.BindGrid(text));
        }
        public string  del_submenu(string record_id)
        {
            return (dl.del_submenu(record_id));
        }
        public string update_submenu(string record_id, string value)
        {
            return (dl.update_submenu(record_id, value));
        }
        public string save_submenu(string submenuid,string Value)
        {
            return (dl.save_submenu(submenuid,Value));
        }

        public DataTable fillsubmenulist(int mainmenueupdateid)
        {
            return (dl.fillsubmenulist(mainmenueupdateid));
        }

       
    }
}

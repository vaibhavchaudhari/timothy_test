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
    class BusinessLayer
    {
        DataLayer dl = new DataLayer();
        public DataTable displaylist()
        {
            return (dl.displaylist());
        }
        public string savemenu(string key, string value, int llcnt)
        {
            return (dl.savemenu(key, value, llcnt));
        }
        public DataTable getvalue(string keys)
        {
            return (dl.getvalue(keys));
        }
        public string delete_record(string keys)
        {
            return (dl.delete_record(keys));
        }
        public string updatemenu(string mainmenuekey, string[] newsubmenuekeyvalue, string descreption,int mainmenueupdateid)
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
        public string update_submenu(string record_id)
        {
            return (dl.del_submenu(record_id));
        }
        public string save_submenu(string submenuid,string Value)
        {
            return (dl.save_submenu(submenuid,Value));
        }
    }
}

using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class MYsql
    {
        private MySqlConnection conn;
        public bool status;

        public MYsql()
        {
            status = Connection();
        }

        private bool Connection()
        {
            string host = "gudi.kr";
            string user = "gdc3";
            string password = "gdc3";
            string port = "5002";
            string db = "gdc3_4";

            string connStr = string.Format("server={0};uid={1};password={2};port={3};database={4}", host, user, password, port, db);
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                this.conn = conn;
                return true;
            }
            catch
            {
                conn.Close();
                this.conn = null;
                return false;
            }
        }

        public bool ConnectionClose()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool NonQuery(string sql)
        {
            try
            {
                if (status)
                {
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    comm.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public MySqlDataReader Reader(string sql)
        {
            try
            {
                if (status)
                {
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    return comm.ExecuteReader();
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public void ReaderClose(MySqlDataReader reader)
        {
            reader.Close();
        }
    }

    class WebAPI
    {
        public bool SelectListView(string url, ListView listView)
        {
            try
            {
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(url);
                StreamReader sr = new StreamReader(stream);
                string result = sr.ReadToEnd();
                ArrayList list = JsonConvert.DeserializeObject<ArrayList>(result);
                for (int i = 0; i < list.Count; i++)
                {
                    JArray j = (JArray)list[i];
                    string[] arr = new string[j.Count];
                    for (int k = 0; k < j.Count; k++)
                    {
                        arr[k] = j[k].ToString();
                    }
                    
                    listView.Items.Add(new ListViewItem(arr));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /*public bool Selectpic(string url,PictureBox picture)
        {
            try
            {
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(url);
                StreamReader sr = new StreamReader(stream);
                string result = sr.ReadToEnd();
                ArrayList list = JsonConvert.DeserializeObject<ArrayList>(result);
                for (int i = 0; i < list.Count; i++)
                {
                    JArray j = (JArray)list[i];
                    string[] arr = new string[j.Count];
                    for (int k = 0; k < j.Count; k++)
                    {
                        
                        arr[k] = j[k].ToString();
                        if (k == 2)
                        {
                            MessageBox.Show(arr[k]);
                            picture.Load();
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }*/

        public bool Post(string url, Hashtable ht)
        {
            try
            {
                WebClient wc = new WebClient();
                NameValueCollection param = new NameValueCollection();

                foreach (DictionaryEntry data in ht)
                {
                    //MessageBox.Show(string.Format("{0},{1}",data.Key.ToString(), data.Value.ToString()));
                    param.Add(data.Key.ToString(), data.Value.ToString());
                }
                byte[] result = wc.UploadValues(url, "POST", param);
                string resultstr = Encoding.UTF8.GetString(result);
                if ("1" == resultstr)
                {
                    MessageBox.Show("성공");
                }
                else
                {
                    MessageBox.Show("실패");
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

    }

}

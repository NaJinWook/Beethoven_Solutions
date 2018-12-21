using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form_User : Form
    {
        private MYsql db = new MYsql();
        Hashtable hashtable = new Hashtable();
        Commons cmm = new Commons();
        Label lb1, lb2;
        Panel pnl1;
        ArrayList arr = new ArrayList();
        Button btn1, btn2, btn3, btn4;
        public TextBox tb1, tb2;
        ListView lv = new ListView();
        ob_Set os = new ob_Set();
        public Form_User()
        {
            InitializeComponent();
            Load += Form_User_Load;
        }

        private void Form_User_Load(object sender, EventArgs e)
        {
            arr.Add(new ob_Pnl(this, "", "", 400, 350, 20, 150));

            pnl1 = os.Pnl((ob_Pnl)arr[0]);
            Controls.Add(pnl1);
            Label();
            Textbox();
            Button();
            Listview();
        }
        private void Label()
        {
            /*       회원번호부분         */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(75, 30));
            hashtable.Add("point", new Point(50, 50));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb1");
            hashtable.Add("text", "회원번호");
            lb1 = cmm.getLabel(hashtable, this);
            lb1.ForeColor = Color.Black;
            lb1.BackColor = Color.Gray;
            lb1.Font = new Font("맑은 고딕", 12, FontStyle.Bold);

            /*       몸무게부분         */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(75, 30));
            hashtable.Add("point", new Point(50, 100));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb1");
            hashtable.Add("text", "몸무게");
            lb1 = cmm.getLabel(hashtable, this);
            lb1.ForeColor = Color.Black;
            lb1.BackColor = Color.Gray;
            lb1.Font = new Font("맑은 고딕", 15, FontStyle.Bold);
        }

        private void Textbox()
        {
            /*       회원번호검색       */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(130, 50));
            hashtable.Add("width", "50");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb1");
            hashtable.Add("enabled", true);
            tb1 = cmm.getTextBox(hashtable, this);
            tb1.Font = new Font("맑은 고딕", 14, FontStyle.Regular);
            /*       몸무게등록       */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(130, 100));
            hashtable.Add("width", "50");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb2");
            hashtable.Add("enabled", true);
            tb2 = cmm.getTextBox(hashtable, this);
            tb2.Font = new Font("맑은 고딕", 14, FontStyle.Regular);
        }
        private void Button()
        {
            /*    검색부분     */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(50, 40));
            hashtable.Add("point", new Point(185, 46));
            hashtable.Add("color", Color.Yellow);
            hashtable.Add("name", "btn1");
            hashtable.Add("text", "검색");
            hashtable.Add("click", (EventHandler)btn_search);
            btn1 = cmm.getButton(hashtable, this);

            /*    등록부분     */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(50, 40));
            hashtable.Add("point", new Point(185, 97));
            hashtable.Add("color", Color.Yellow);
            hashtable.Add("name", "btn2");
            hashtable.Add("text", "등록");
            hashtable.Add("click", (EventHandler)btn_register);
            btn2 = cmm.getButton(hashtable, this);

            /*    그래프부분     */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(50, 40));
            hashtable.Add("point", new Point(235, 97));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn3");
            hashtable.Add("text", "그래프");
            hashtable.Add("click", (EventHandler)btn_graph);
            btn3 = cmm.getButton(hashtable, this);


        }
        private void Listview()
        {
            hashtable = new Hashtable();
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "listView");
            //hashtable.Add("click", (MouseEventHandler)listView_click);
            //lv.FullRowSelect = true;
            lv = cmm.getListView(hashtable, pnl1);
            lv.Dock = DockStyle.Fill;

            lv.Columns.Add("회원번호", 70, HorizontalAlignment.Center);
            lv.Columns.Add("이름", 50, HorizontalAlignment.Center);
            lv.Columns.Add("몸무게", 70, HorizontalAlignment.Center);
            lv.Columns.Add("등록일", 100, HorizontalAlignment.Center);
            lv.Columns.Add("입력날짜", 100, HorizontalAlignment.Center);
        }


        private void btn_search(object o, EventArgs e)
        {
            int num;
            bool success = int.TryParse(tb1.Text, out num);

            //string sql = string.Format("select a.mNo,a.mName,b.kg,a.mStart,date_format(b.nowDate, '%Y-%m-%d') as nowDate from member2 a,weight b where a.mNo = '{0}' and b.mNo = '{0}';", tb1.Text);
            if (success == false)
            {
                MessageBox.Show("회원번호만 입력해주세요");
                return;
            }
            string sql = string.Format("call User_select('{0}')", tb1.Text);
            MySqlDataReader sdr = db.Reader(sql);
            lv.Items.Clear();
            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                }
                lv.Items.Add(new ListViewItem(arr));
            }
            db.ReaderClose(sdr);

        }


        private void btn_register(object o, EventArgs e)
        {
            //MessageBox.Show("gd");
            //string sql = string.Format("insert into weight(mNo,rNum,kg) select '{0}',  case when  max(rNum) is null then 1 else  max(rNum) +1 end as rNum,'{1}' from weight where mNo = '{2}';", tb1.Text, tb2.Text, tb1.Text);
            int num;
            bool success = int.TryParse(tb1.Text + tb2.Text, out num);

            if (success == false)
            {
                MessageBox.Show("숫자만입력해주세요2");
                return;
            }

            string sql = string.Format("call User_insert('{0}','{1}');", tb1.Text, tb2.Text);
            db.NonQuery(sql);
            tb2.Text = "";

            sql = string.Format("call User_select('{0}')", tb1.Text);
            MySqlDataReader sdr = db.Reader(sql);
            lv.Items.Clear();
            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                }
                lv.Items.Add(new ListViewItem(arr));
            }
            db.ReaderClose(sdr);
        }



        private void btn_graph(object o, EventArgs e)
        {
            MessageBox.Show("그래프");
        }

    }

}





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
    public partial class Form_member : Form
    {
        private MYsql db = new MYsql();
        ob_Set os = new ob_Set();
        ArrayList arr = new ArrayList();
        Panel main_pnl;
        Panel pnl1, pnl2, pnl3, pnl4;
        Button btn1, btn2, btn3, btn4, btn5;
        TextBox tb, tb1, tb2, tb3, tb4, tb5, tb6;
        Label lb1;
        ComboBox cb1;
        ListView lv = new ListView();
        ImageList il = new ImageList();
        Hashtable hashtable = new Hashtable();
        Commons cmm = new Commons();
        private string temp;
        private string printAll = "select mNo,mName,Age,Sex,phone,address,locker from member;";

        public Form_member()
        {
            InitializeComponent();
            Load += Form_member_Load;
        }

        private void Form_member_Load(object sender, EventArgs e)
        {
            arr.Add(new ob_Pnl(this, "", "", 1441, 613, 10, 10));
            arr.Add(new ob_Pnl(this, "", "", 1441, 460, 0, 54));
            arr.Add(new ob_Pnl(this, "", "", 1461, 45, 0, 520));
            arr.Add(new ob_Pnl(this, "", "", 1461, 65, 0, 570));
            arr.Add(new ob_Pnl(this, "", "", 1441, 50, 0, 0));
            arr.Add(new ob_Tbx(this, "", "", 500, 20, 500, 25));
            arr.Add(new ob_Btn(this, "btn4", "검색", 40, 23, 1010, 25));
            arr.Add(new ob_Btn(this, "btn5", "전체보기", 70, 23, 1060, 25));

            main_pnl = os.Pnl((ob_Pnl)arr[0]);
            pnl1 = os.Pnl((ob_Pnl)arr[1]);
            pnl2 = os.Pnl((ob_Pnl)arr[2]);
            pnl3 = os.Pnl((ob_Pnl)arr[3]);
            pnl4 = os.Pnl((ob_Pnl)arr[4]);
            tb = os.Tbx((ob_Tbx)arr[5]);
            btn4 = os.Btn((ob_Btn)arr[6]);
            btn5 = os.Btn((ob_Btn)arr[7]);

            Controls.Add(main_pnl);
            main_pnl.Controls.Add(pnl1);
            main_pnl.Controls.Add(pnl2);
            main_pnl.Controls.Add(pnl3);
            main_pnl.Controls.Add(pnl4);
            pnl4.Controls.Add(tb);//검색 텍스트박스
            pnl4.Controls.Add(btn4);//검색 버튼
            pnl4.Controls.Add(btn5);
            btn4.Click += search;
            btn5.Click += btn_click;

            option();
            hashtable = new Hashtable();
            hashtable.Add("width", "70");
            hashtable.Add("point", new Point(1, 25));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "선택");
            hashtable.Add("text", "이름");
            hashtable.Add("value", "이름");
            hashtable.Add("Key", "1");
            cb1 = cmm.getComboBox(hashtable, pnl4);
            cb1.Items.Add("이름");
            cb1.Items.Add("회원번호");
            cb1.Items.Add("전화번호");

            //--------------------------------------여기부터 패널3번부분

            hashtable = new Hashtable();
            hashtable.Add("width", "80");
            hashtable.Add("point", new Point(61, 10));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb1");
            hashtable.Add("enabled", true);
            tb1 = cmm.getTextBox(hashtable, pnl3);

            hashtable = new Hashtable();
            hashtable.Add("width", "65");
            hashtable.Add("point", new Point(181, 10));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb2");
            hashtable.Add("enabled", true);
            tb2 = cmm.getTextBox(hashtable, pnl3);

            hashtable = new Hashtable();
            hashtable.Add("width", "60");
            hashtable.Add("point", new Point(281, 10));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb3");
            hashtable.Add("enabled", true);
            tb3 = cmm.getTextBox(hashtable, pnl3);

            hashtable = new Hashtable();
            hashtable.Add("width", "280");
            hashtable.Add("point", new Point(411, 10));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb4");
            hashtable.Add("enabled", true);
            tb4 = cmm.getTextBox(hashtable, pnl3);

            hashtable = new Hashtable();
            hashtable.Add("width", "510");
            hashtable.Add("point", new Point(731, 10));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb5");
            hashtable.Add("enabled", true);
            tb5 = cmm.getTextBox(hashtable, pnl3);

            hashtable = new Hashtable();
            hashtable.Add("width", "60");
            hashtable.Add("point", new Point(1310, 10));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb6");
            hashtable.Add("enabled", true);
            tb6 = cmm.getTextBox(hashtable, pnl3);

            //=============================================================

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(30, 15));
            hashtable.Add("point", new Point(30, 15));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb1");
            hashtable.Add("text", "이름");
            lb1 = cmm.getLabel(hashtable, pnl3);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(30, 15));
            hashtable.Add("point", new Point(150, 15));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb2");
            hashtable.Add("text", "나이");
            lb1 = cmm.getLabel(hashtable, pnl3);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(30, 15));
            hashtable.Add("point", new Point(250, 15));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb3");
            hashtable.Add("text", "성별");
            lb1 = cmm.getLabel(hashtable, pnl3);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(60, 15));
            hashtable.Add("point", new Point(350, 15));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb4");
            hashtable.Add("text", "전화번호");
            lb1 = cmm.getLabel(hashtable, pnl3);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(30, 15));
            hashtable.Add("point", new Point(700, 15));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb5");
            hashtable.Add("text", "주소");
            lb1 = cmm.getLabel(hashtable, pnl3);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(60, 15));
            hashtable.Add("point", new Point(1250, 15));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb6");
            hashtable.Add("text", "라커 번호");
            lb1 = cmm.getLabel(hashtable, pnl3);

            //================================================여기까지 패널 3번
            //------------------------------------------------패널 2번
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 45));
            hashtable.Add("point", new Point(1230, 0));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn1");
            hashtable.Add("text", "수정");
            hashtable.Add("click", (EventHandler)btn_click);
            btn1 = cmm.getButton(hashtable, pnl2);

            //hashtable = new Hashtable();
            //hashtable.Add("size", new Size(100, 70));
            //hashtable.Add("point", new Point(1240, 0));
            //hashtable.Add("color", Color.White);
            //hashtable.Add("name", "btn2");
            //hashtable.Add("text", "저장");
            //hashtable.Add("click", (EventHandler)btn_click);
            //btn2 = cmm.getButton(hashtable, pnl2);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 45));
            hashtable.Add("point", new Point(1340, 0));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn3");
            hashtable.Add("text", "삭제");
            hashtable.Add("click", (EventHandler)btn_click);
            btn3 = cmm.getButton(hashtable, pnl2);

            //=========================================여기까지 패널2번

            hashtable = new Hashtable();
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "listView");
            il.ImageSize = new Size(16,20);
            lv.SmallImageList = il;
            hashtable.Add("click", (MouseEventHandler)listView_click);
            lv.FullRowSelect = true;
            lv = cmm.getListView(hashtable, pnl1);
            //lv.Dock = DockStyle.Fill;
            Select(printAll);
        }

        private void btn_click(object o, EventArgs a)
        {
            Button btn = (Button)o;
            switch (btn.Name)
            {
                case "btn1":
                    Update();
                    break;
                case "btn3":
                    Delete();
                    break;
                case "btn5":
                    Select(printAll);
                    break;
            }
        }

        private void listView_click(object o, EventArgs a)
        {
            ListView lv = (ListView)o;
            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;
            ListViewItem item = itemGroup[0];
            temp = item.SubItems[0].Text;
            tb1.Text = item.SubItems[1].Text;
            tb2.Text = item.SubItems[2].Text;
            tb3.Text = item.SubItems[3].Text;
            tb4.Text = item.SubItems[4].Text;
            tb5.Text = item.SubItems[5].Text;
            tb6.Text = item.SubItems[6].Text;
        }

        private void Delete()
        {

        }

        private void search(object o, EventArgs e)
        {
            //MessageBox.Show(cb1.Text);
            //tb
            if (cb1.Text == "회원번호")
            {
                Select(string.Format("select * from member where mNo like'%{0}%'; ", tb.Text));
            }
            else if (cb1.Text == "이름")
            {
                Select(string.Format("select * from member where mName like'%{0}%'; ", tb.Text));
            }
            else if (cb1.Text == "전화번호")
            {
                Select(string.Format("select * from member where phone like'%{0}%'; ", tb.Text));
            }
            else if (tb.Text == "")
            {
                lv.Items.Clear();
            }
            else
            {
                Select(string.Format("select * from member where mName like'%{0}%'; ", tb.Text));
            }
        }

        private void Select(string sql)
        {
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            tb6.Text = "";
            lv.Clear();
            lv.Columns.Add("번호", 70, HorizontalAlignment.Center);
            lv.Columns.Add("이름", 120, HorizontalAlignment.Center);
            lv.Columns.Add("나이", 80, HorizontalAlignment.Center);
            lv.Columns.Add("성별", 80, HorizontalAlignment.Center);
            lv.Columns.Add("전화번호", 400, HorizontalAlignment.Center);
            lv.Columns.Add("주소", 580, HorizontalAlignment.Center);
            lv.Columns.Add("라커", 70, HorizontalAlignment.Center);

            MySqlDataReader sdr = db.Reader(sql);
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

        private void Update()
        {
            DialogResult dialogresult = MessageBox.Show("수정 하시겠습니까?", "", MessageBoxButtons.YesNo);
            if (dialogresult == DialogResult.Yes)
            {
                string sql = string.Format("update member set mName='{0}',Age={1},Sex='{2}',phone='{3}',address='{4}',locker={5} where mNo={6};", tb1.Text, tb2.Text, tb3.Text, tb4.Text, tb5.Text, tb6.Text, temp);
                if (db.NonQuery(sql))
                    Select(printAll);
            }
            else
            {
                return;
            }
        }

        private void option()
        {
            main_pnl.BackColor = Color.White;
            pnl1.BackColor = Color.Blue;
            pnl2.BackColor = Color.Yellow;
            pnl3.BackColor = Color.White;
            pnl4.BackColor = Color.Pink;
        }
        /*
        private bool TextBoxCheck()
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("권한이름을 입력하세요.");
                textBox2.Focus();
                return false;
            }
            return true;
        }*/
    }
}
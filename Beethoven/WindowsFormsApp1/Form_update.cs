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
    public partial class Form_update : Form
    {
        ob_Set os = new ob_Set();
        private MYsql db = new MYsql();
        ArrayList arr = new ArrayList();
        Commons cmm = new Commons();
        Hashtable hashtable = new Hashtable();
        TextBox tb1, tb2, tb3, tb4, tb5, tb6;
        Label lb1, lb2, lb3, lb4, lb5, lb6;
        Button btn1, btn2, btn3;
        //string pass1, pass2, pass3, pass4, pass5, pass6, pass7;
        Member member;

        public Form_update()
        {
            InitializeComponent();
            Load += Form_test_Load;
        }

        public Form_update(Member member)
        {
            InitializeComponent();
            this.member = member;
            /*
            pass1 = test1;
            pass2 = test2;
            pass3 = test3;
            pass4 = test4;
            pass5 = test5;
            pass6 = test6;
            pass7 = temp;
            */
            Load += Form_test_Load;
        }

        public void Form_test_Load(object sender, EventArgs e)
        {
            //--------------------------------------여기부터 패널3번부분

            hashtable = new Hashtable();
            hashtable.Add("width", "80");
            hashtable.Add("point", new Point(61, 10));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb1");
            hashtable.Add("enabled", true);
            tb1 = cmm.getTextBox(hashtable, this);
            tb1.Text = member.mName;

            hashtable = new Hashtable();
            hashtable.Add("width", "65");
            hashtable.Add("point", new Point(61, 50));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb2");
            hashtable.Add("enabled", true);
            tb2 = cmm.getTextBox(hashtable, this);
            tb2.Text = member.Age;

            hashtable = new Hashtable();
            hashtable.Add("width", "60");
            hashtable.Add("point", new Point(61, 90));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb3");
            hashtable.Add("enabled", true);
            tb3 = cmm.getTextBox(hashtable, this);
            tb3.Text = member.Sex;

            hashtable = new Hashtable();
            hashtable.Add("width", "280");
            hashtable.Add("point", new Point(61, 130));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb4");
            hashtable.Add("enabled", true);
            tb4 = cmm.getTextBox(hashtable, this);
            tb4.Text = member.phone;

            hashtable = new Hashtable();
            hashtable.Add("width", "510");
            hashtable.Add("point", new Point(61, 170));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb5");
            hashtable.Add("enabled", true);
            tb5 = cmm.getTextBox(hashtable, this);
            tb5.Text = member.address;

            hashtable = new Hashtable();
            hashtable.Add("width", "60");
            hashtable.Add("point", new Point(61, 210));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb6");
            hashtable.Add("enabled", true);
            tb6 = cmm.getTextBox(hashtable, this);
            tb6.Text = member.locker;

            //=============================================================

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(30, 15));
            hashtable.Add("point", new Point(30, 15));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb1");
            hashtable.Add("text", "이름");
            lb1 = cmm.getLabel(hashtable, this);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(30, 15));
            hashtable.Add("point", new Point(30, 55));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb2");
            hashtable.Add("text", "나이");
            lb1 = cmm.getLabel(hashtable, this);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(30, 15));
            hashtable.Add("point", new Point(30, 95));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb3");
            hashtable.Add("text", "성별");
            lb1 = cmm.getLabel(hashtable, this);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(60, 15));
            hashtable.Add("point", new Point(30, 135));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb4");
            hashtable.Add("text", "전번");
            lb1 = cmm.getLabel(hashtable, this);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(30, 15));
            hashtable.Add("point", new Point(30, 170));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb5");
            hashtable.Add("text", "주소");
            lb1 = cmm.getLabel(hashtable, this);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(60, 15));
            hashtable.Add("point", new Point(30, 210));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb6");
            hashtable.Add("text", "라커 번호");
            lb1 = cmm.getLabel(hashtable, this);

            //================================================여기까지 패널 3번
            //------------------------------------------------패널 2번
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 45));
            hashtable.Add("point", new Point(30, 250));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn1");
            hashtable.Add("text", "추가");
            hashtable.Add("click", (EventHandler)btn_click);
            btn1 = cmm.getButton(hashtable, this);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 45));
            hashtable.Add("point", new Point(150, 250));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn2");
            hashtable.Add("text", "수정");
            hashtable.Add("click", (EventHandler)btn_click);
            btn2 = cmm.getButton(hashtable, this);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 45));
            hashtable.Add("point", new Point(270, 250));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn3");
            hashtable.Add("text", "삭제");
            hashtable.Add("click", (EventHandler)btn_click);
            btn3 = cmm.getButton(hashtable, this);

            //=========================================여기까지 패널2번
        }

        private void btn_click(object o, EventArgs a)
        {
            Button btn = (Button)o;
            switch (btn.Name)
            {
                case "btn1":
                    Add();
                    break;
                case "btn2":
                    Update();
                    break;
                case "btn3":
                    Delete();
                    break;
                case "btn5":
                    //Select(printAll);
                    break;
            }
        }

        private void Add()
        {
            MessageBox.Show("추가");
        }

        private void Update()
        {
            string sql = string.Format("update member set mName='{0}',Age='{1}',Sex='{2}',phone='{3}',address='{4}',locker='{5}' where mNo={6};", tb1.Text, tb2.Text, tb3.Text, tb4.Text, tb5.Text, tb6.Text, member.mNo);
            MessageBox.Show(sql);
            db.NonQuery(sql);
            this.Close();
        }

        private void Delete()
        {
            MessageBox.Show("삭제");
        }
    }
}

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
    public partial class Form_register : Form
    {
        private MYsql db = new MYsql();
        ob_Set os = new ob_Set();
        ArrayList arr = new ArrayList();
        Panel main_pnl, pnl1, pnl2;
        Label lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9;
        Hashtable hashtable = new Hashtable();
        Commons cmm = new Commons();
        RadioButton rb1, rb2;
        Button btn1, btn2, btn3, btn4, btn5;
        //Form_calender cal;
        Form_calender fc;
        public string start;
        public string end;
        public string gender;
        public TextBox tb1, tb2, tb3, tb4, tb5, tb6, tb7;

        //private string Date;
        //private string Date2;


        public Form_register()
        {
            InitializeComponent();
            Load += Form_register_Load;

        }

        private void Form_register_Load(object sender, EventArgs e)
        {
            main_pnl = new Panel();
            arr.Add(new ob_Pnl(this, "", "", 1461, 633, 0, 0));
            arr.Add(new ob_Pnl(this, "", "", 975, 613, 10, 10));
            arr.Add(new ob_Pnl(this, "", "", 455, 613, 995, 10));

            main_pnl = os.Pnl((ob_Pnl)arr[0]);
            pnl1 = os.Pnl((ob_Pnl)arr[1]);
            pnl2 = os.Pnl((ob_Pnl)arr[2]);

            Controls.Add(main_pnl);
            main_pnl.Controls.Add(pnl1);
            main_pnl.Controls.Add(pnl2);


            Label();
            Textbox();
            Button();
            Radiobutton();
            Pass();
            option();
        }

        private void option()
        {
            main_pnl.BackColor = Color.White;
            pnl1.BackColor = Color.FromArgb(220, 235, 254);
        }


        /*     라벨     */
        private void Label()
        {
            /*       이름부분         */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(90, 50));
            hashtable.Add("point", new Point(35, 15));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb1");
            hashtable.Add("text", "이름");
            lb1 = cmm.getLabel(hashtable, pnl1);
            lb1.ForeColor = Color.Black;
            lb1.BackColor = Color.Gray;
            lb1.Font = new Font("나눔 고딕", 25, FontStyle.Bold);

            /*       나이부분         */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(90, 50));
            hashtable.Add("point", new Point(35, 105));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb2");
            hashtable.Add("text", "나이");
            lb2 = cmm.getLabel(hashtable, pnl1);
            lb2.ForeColor = Color.Black;
            lb2.BackColor = Color.Gray;
            lb2.Font = new Font("나눔 고딕", 25, FontStyle.Bold);

            /*       성별부분         */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(90, 50));
            hashtable.Add("point", new Point(35, 195));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb3");
            hashtable.Add("text", "성별");
            lb3 = cmm.getLabel(hashtable, pnl1);
            lb3.ForeColor = Color.Black;
            lb3.BackColor = Color.Gray;
            lb3.Font = new Font("나눔 고딕", 25, FontStyle.Bold);

            /*       전화번호부분         */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(160, 50));
            hashtable.Add("point", new Point(35, 285));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb5");
            hashtable.Add("text", "전화번호");
            lb5 = cmm.getLabel(hashtable, pnl1);
            lb5.ForeColor = Color.Black;
            lb5.BackColor = Color.Gray;
            lb5.Font = new Font("나눔 고딕", 25, FontStyle.Bold);

            /*       주소부분         */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(90, 50));
            hashtable.Add("point", new Point(35, 375));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb4");
            hashtable.Add("text", "주소");
            lb4 = cmm.getLabel(hashtable, pnl1);
            lb4.ForeColor = Color.Black;
            lb4.BackColor = Color.Gray;
            lb4.Font = new Font("나눔 고딕", 25, FontStyle.Bold);

            /*       라커부분          */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(90, 50));
            hashtable.Add("point", new Point(35, 465));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb6");
            hashtable.Add("text", "라커");
            lb6 = cmm.getLabel(hashtable, pnl1);
            lb6.ForeColor = Color.Black;
            lb6.BackColor = Color.Gray;
            lb6.Font = new Font("나눔 고딕", 25, FontStyle.Bold);

            /*       달력부분              */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(90, 50));
            hashtable.Add("point", new Point(330, 465));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb7");
            hashtable.Add("text", "기간");
            lb7 = cmm.getLabel(hashtable, pnl1);
            lb7.ForeColor = Color.Black;
            lb7.BackColor = Color.Gray;
            lb7.Font = new Font("나눔 고딕", 25, FontStyle.Bold);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(40, 40));
            hashtable.Add("point", new Point(695, 465));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb8");
            hashtable.Add("text", "~");
            lb8 = cmm.getLabel(hashtable, pnl1);
            lb8.ForeColor = Color.Black;
            lb8.BackColor = Color.Gray;
            lb8.Font = new Font("나눔 고딕", 25, FontStyle.Bold);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(650, 50));
            hashtable.Add("point", new Point(35, 550));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb9");
            hashtable.Add("text", "테스트입니다. 설명같은거 아무거나 적기");
            lb9 = cmm.getLabel(hashtable, pnl1);
            lb9.ForeColor = Color.Black;
            lb9.BackColor = Color.Gray;
            lb9.Font = new Font("나눔 고딕", 25, FontStyle.Bold);
        }


        /*     텍박     */
        private void Textbox()
        {
            /*       이름부분       */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(230, 15));
            hashtable.Add("width", "700");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb1");
            hashtable.Add("enabled", true);
            tb1 = cmm.getTextBox(hashtable, pnl1);
            tb1.Font = new Font("나눔 고딕", 25, FontStyle.Regular);

            /*       나이부분         */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(230, 105));
            hashtable.Add("width", "700");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb2");
            hashtable.Add("enabled", true);
            tb2 = cmm.getTextBox(hashtable, pnl1);
            tb2.Font = new Font("나눔 고딕", 25, FontStyle.Regular);

            /*       전화번호부분         */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(230, 285));
            hashtable.Add("width", "700");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb3");
            hashtable.Add("enabled", true);
            tb3 = cmm.getTextBox(hashtable, pnl1);
            tb3.Font = new Font("나눔 고딕", 25, FontStyle.Regular);

            /*       주소부분         */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(230, 375));
            hashtable.Add("width", "700");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb4");
            hashtable.Add("enabled", true);
            tb4 = cmm.getTextBox(hashtable, pnl1);
            tb4.Font = new Font("나눔 고딕", 25, FontStyle.Regular);

            /*       라커          */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(230, 465));
            hashtable.Add("width", "80");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb5");
            hashtable.Add("enabled", true);
            tb5 = cmm.getTextBox(hashtable, pnl1);
            tb5.TextAlign = HorizontalAlignment.Center;
            tb5.Font = new Font("나눔 고딕", 25, FontStyle.Regular);
            tb5.Enabled = false;

            /*       달력부분    시작일     */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(500, 465));
            hashtable.Add("width", "190");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb6");
            hashtable.Add("enabled", true);
            tb6 = cmm.getTextBox(hashtable, pnl1);
            tb6.TextAlign = HorizontalAlignment.Center;
            tb6.Font = new Font("나눔 고딕", 25, FontStyle.Regular);
            tb6.Enabled = false;

            /*       달력부분    종료일     */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(740, 465));
            hashtable.Add("width", "190");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb7");
            hashtable.Add("enabled", true);
            tb7 = cmm.getTextBox(hashtable, pnl1);
            tb7.TextAlign = HorizontalAlignment.Center;
            tb7.Font = new Font("나눔 고딕", 25, FontStyle.Regular);
            tb7.Enabled = false;


        }


        /*     버튼     */
        private void Button()
        {
            /*    달력부분     */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(70, 50));
            hashtable.Add("point", new Point(425, 465));
            hashtable.Add("color", Color.Yellow);
            hashtable.Add("name", "btn1");
            hashtable.Add("text", "달력");
            hashtable.Add("click", (EventHandler)btn_calendar);
            btn1 = cmm.getButton(hashtable, pnl1);

            /*    라커부분     */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(90, 50));
            hashtable.Add("point", new Point(130, 465));
            hashtable.Add("color", Color.Yellow);
            hashtable.Add("name", "btn2");
            hashtable.Add("text", "라커");
            //hashtable.Add("click", (EventHandler)btn_click);
            btn2 = cmm.getButton(hashtable, pnl1);

            /*    등록부분     */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 70));
            hashtable.Add("point", new Point(700, 530));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn3");
            hashtable.Add("text", "등록");
            hashtable.Add("click", (EventHandler)btn_register);
            btn3 = cmm.getButton(hashtable, pnl1);


            /*    초기화부분     */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 70));
            hashtable.Add("point", new Point(830, 530));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn4");
            hashtable.Add("text", "초기화");
            hashtable.Add("click", (EventHandler)btn_reset);
            btn4 = cmm.getButton(hashtable, pnl1);
        }

        /*     라디오버튼    */
        private void Radiobutton()
        {
            /* 남성부분 */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(230, 165));
            hashtable.Add("size", new Size(100, 100));
            hashtable.Add("name", "rb1");
            hashtable.Add("text", "남성");
            hashtable.Add("click", (EventHandler)rdb_click);
            rb1 = cmm.getRadioButton(hashtable, pnl1);
            rb1.Font = new Font("Impact", 25);

            /* 여성부분 */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(340, 165));
            hashtable.Add("size", new Size(100, 100));
            hashtable.Add("name", "rb2");
            hashtable.Add("text", "여성");
            hashtable.Add("click", (EventHandler)rdb_click);
            rb2 = cmm.getRadioButton(hashtable, pnl1);
            rb2.Font = new Font("Impact", 25);
        }

        /*calender 폼에서 받아온 출력*/
        private void btn_calendar(object o, EventArgs a)
        {
            //fc = new Form_calender(tb6, tb7, start, end);

            //fc.MdiParent = this.ParentForm;
            //fc.WindowState = FormWindowState.Maximized;
            //fc.FormBorderStyle = FormBorderStyle.None;
            //pnl2.Controls.Add(fc);
            //fc.Show();

            //MessageBox.Show(fc.Date); 
            //fc.Date2 

            //fc.ShowDialog();


            //tb6.Text = "11";
            //tb7.Text = "22";

            //tb6.Text = start;
            //tb7.Text = end;
            //tb6.Text = Date;
            //tb7.Text = Date2;
        }
        private void Pass()
        {
            fc = new Form_calender(tb5, tb6, tb7, start, end);

            fc.MdiParent = this.ParentForm;
            fc.WindowState = FormWindowState.Maximized;
            fc.FormBorderStyle = FormBorderStyle.None;
            pnl2.Controls.Add(fc);
            fc.Show();
        }

        /* 라디오버튼 이벤트*/
        private void rdb_click(object o, EventArgs a)
        {
            RadioButton rdb = (RadioButton)o;

            switch (rdb.Text)
            {
                case "남성":
                    gender = "남성";
                    break;

                case "여성":
                    gender = "여성";
                    break;
            }

        }
        private void btn_register(object o, EventArgs a)
        {
            string sql = string.Format("insert into member (mName, Age, Sex, phone, address, locker, mStart, mEnd, cost) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');",tb1.Text, tb2.Text, gender, tb3.Text, tb4.Text, tb5.Text, tb6.Text, tb7.Text, fc.money);
            db.NonQuery(sql);
        }


        private void btn_reset(object o, EventArgs a)
        {
            //MessageBox.Show("초기화");
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            tb6.Text = "";
            tb7.Text = "";
        }
    }
}
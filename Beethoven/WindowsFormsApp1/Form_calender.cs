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
    public partial class Form_calender : Form
    {
        ArrayList btn_array;
        MYsql db = new MYsql();
        Commons cmm = new Commons();

        Hashtable hashtable = new Hashtable();
        Button btn1, btn2, btn3, btn4, btn5, btn6, btn7, lk_btn;
        Label lb1, lb2, lb3;
        Panel Calendar_pnl, Locker_pnl;
        private TextBox tb1, tb5, tb6, tb7;
        private string start, end;
        public DateTime startDate; //시작일
        public DateTime endDate;  //종료일
        public string Date;    //시작일 string으로 받는 변수
        public string Date2;   //종료일 string으로 받는 변수
        public string locker;
        public int money;
        private MonthCalendar monthCalendar1;

        public Form_calender(TextBox tb5, TextBox tb6, TextBox tb7, string start, string end)
        {
            InitializeComponent();
            Load += Form_calender_Load;
            ClientSize = new Size(600, 400);
            this.MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "회원기간 등록창";
            this.BackColor = Color.White;
            this.tb5 = tb5;
            this.tb6 = tb6;
            this.tb7 = tb7;
        }

        private void Form_calender_Load(object sender, EventArgs e)
        {
            Panel();
            Calender();
            Textbox();
            Label();
            Button();
            Locker();

            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
        }

        private void Panel()
        {
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(455, 305));
            hashtable.Add("point", new Point(0, 0));
            hashtable.Add("color", Color.FromArgb(231, 235, 254));
            hashtable.Add("name", "Calender_pnl");
            Calendar_pnl = cmm.getPanel(hashtable, this);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(455, 305));
            hashtable.Add("point", new Point(0, 310));
            hashtable.Add("color", Color.FromArgb(231, 235, 254));
            hashtable.Add("name", "Locker_pnl");
            Locker_pnl = cmm.getPanel(hashtable, this);
        }

        private void Calender()
        {

            // Create the calendar.
            monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            // Set the calendar location.
            monthCalendar1.Location = new System.Drawing.Point(225, 133);

            Calendar_pnl.Controls.Add(this.monthCalendar1);

        }

        private void Textbox()
        {
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(226, 75));
            hashtable.Add("width", "218");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb1");
            hashtable.Add("enabled", true);
            tb1 = cmm.getTextBox(hashtable, Calendar_pnl);
            tb1.Font = new Font("나눔 고딕", 25, FontStyle.Bold);
            tb1.TextAlign = HorizontalAlignment.Center;
            tb1.ReadOnly = true;
            tb1.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();

        }

        private void Label()
        {
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(120, 45));
            hashtable.Add("point", new Point(57, 75));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb1");
            hashtable.Add("text", "시작일");
            lb1 = cmm.getLabel(hashtable, Calendar_pnl);
            lb1.Font = new Font("나눔 고딕", 30, FontStyle.Bold);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(435, 45));
            hashtable.Add("point", new Point(5, 5));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb2");
            hashtable.Add("text", "날짜를 선택하고 버튼을 눌러주세요.");
            lb2 = cmm.getLabel(hashtable, Calendar_pnl);
            lb2.Font = new Font("나눔 고딕", 25, FontStyle.Bold);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(415, 35));
            hashtable.Add("point", new Point(25, 5));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb3");
            hashtable.Add("text", "사용하실 라커 번호를 눌러주세요.");
            lb3 = cmm.getLabel(hashtable, Locker_pnl);
            lb3.Font = new Font("나눔 고딕", 25, FontStyle.Bold);
        }


        private void Button()
        {
            /*         1개월          */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(98, 77));
            hashtable.Add("point", new Point(12, 135));
            hashtable.Add("color", Color.Silver);
            hashtable.Add("name", "btn1");
            hashtable.Add("text", "1개월");
            hashtable.Add("click", (EventHandler)btn_calendar);
            btn1 = cmm.getButton(hashtable, Calendar_pnl);
            btn1.TabStop = false; // 탭방지
            btn1.FlatStyle = FlatStyle.Flat; // 테두리 제거
            btn1.FlatAppearance.BorderSize = 0; // 테두리 제거

            /*         3개월          */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(98, 77));
            hashtable.Add("point", new Point(116, 135));
            hashtable.Add("color", Color.Silver);
            hashtable.Add("name", "btn2");
            hashtable.Add("text", "3개월");
            hashtable.Add("click", (EventHandler)btn_calendar);
            btn2 = cmm.getButton(hashtable, Calendar_pnl);
            btn2.TabStop = false; // 탭방지
            btn2.FlatStyle = FlatStyle.Flat; // 테두리 제거
            btn2.FlatAppearance.BorderSize = 0; // 테두리 제거



            /*         6개월          */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(98, 77));
            hashtable.Add("point", new Point(12, 217));
            hashtable.Add("color", Color.Silver);
            hashtable.Add("name", "btn3");
            hashtable.Add("text", "6개월");
            hashtable.Add("click", (EventHandler)btn_calendar);
            btn3 = cmm.getButton(hashtable, Calendar_pnl);
            btn3.TabStop = false; // 탭방지
            btn3.FlatStyle = FlatStyle.Flat; // 테두리 제거
            btn3.FlatAppearance.BorderSize = 0; // 테두리 제거


            /*         12개월          */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(98, 77));
            hashtable.Add("point", new Point(116, 217));
            hashtable.Add("color", Color.Silver);
            hashtable.Add("name", "btn4");
            hashtable.Add("text", "1년");
            hashtable.Add("click", (EventHandler)btn_calendar);
            btn4 = cmm.getButton(hashtable, Calendar_pnl);
            btn4.TabStop = false; // 탭방지
            btn4.FlatStyle = FlatStyle.Flat; // 테두리 제거
            btn4.FlatAppearance.BorderSize = 0; // 테두리 제거

            /*         라커 선택 가능          */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(55, 35));
            hashtable.Add("point", new Point(5, 45));
            hashtable.Add("color", Color.Green);
            hashtable.Add("name", "btn5");
            hashtable.Add("text", "가능");
            btn5 = cmm.getButton(hashtable, Locker_pnl);
            btn5.TabStop = false; // 탭방지
            btn5.FlatStyle = FlatStyle.Flat; // 테두리 제거
            btn5.FlatAppearance.BorderSize = 0; // 테두리 제거
            btn5.Enabled = false;
            btn5.ForeColor = Color.White;
            btn5.Font = new Font("나눔 고딕", 12, FontStyle.Bold);

            /*         라커 선택 불가          */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(55, 35));
            hashtable.Add("point", new Point(5, 83));
            hashtable.Add("color", Color.Red);
            hashtable.Add("name", "btn6");
            hashtable.Add("text", "불가능");
            btn6 = cmm.getButton(hashtable, Locker_pnl);
            btn6.TabStop = false; // 탭방지
            btn6.FlatStyle = FlatStyle.Flat; // 테두리 제거
            btn6.FlatAppearance.BorderSize = 0; // 테두리 제거
            btn6.Enabled = false;
            btn6.ForeColor = Color.White;
            btn6.Font = new Font("나눔 고딕", 12, FontStyle.Bold);

            /*         라커 선택 안함          */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(55, 160));
            hashtable.Add("point", new Point(5, 131));
            hashtable.Add("color", Color.Silver);
            hashtable.Add("name", "btn7");
            hashtable.Add("text", "사용안함");
            hashtable.Add("click", (EventHandler)No_lock_Click);
            btn7 = cmm.getButton(hashtable, Locker_pnl);
            btn7.TabStop = false; // 탭방지
            btn7.FlatStyle = FlatStyle.Flat; // 테두리 제거
            btn7.FlatAppearance.BorderSize = 0; // 테두리 제거
            btn7.Font = new Font("나눔 고딕", 20, FontStyle.Bold);
            btn7.Click += No_lock_Click;
        }

        private void No_lock_Click(object o, EventArgs e)
        {
            Button lk_btn = (Button)o;
            tb5.Text = "X";
            for (int i = 0; i < btn_array.Count; i++)
            {
                Button clear = (Button)btn_array[i];
                if (clear.BackColor == Color.Blue) clear.BackColor = Color.Green;
            }  
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            startDate = (DateTime)monthCalendar1.SelectionRange.Start;
            Date = startDate.ToShortDateString();
            tb1.Text = Date;
            tb1.ReadOnly = true;

        }

        private void btn_calendar(object o, EventArgs a)
        {
            Button btn = (Button)o;
            money = 0;
            startDate = (DateTime)monthCalendar1.SelectionRange.Start;
            Date = startDate.ToShortDateString();

            if (tb1.Text == "")
            {
                MessageBox.Show("날짜를 선택해주세요");
                return;
            }
            switch (btn.Name)
            {
                case "btn1": 
                    endDate = startDate.AddDays(30);
                    Date2 = endDate.ToShortDateString();
                    tb6.Text = Date;
                    tb7.Text = Date2;
                    start = Date;
                    end = Date2;
                    money = 50000;
                    break;
                case "btn2":
                    endDate = startDate.AddDays(90);
                    Date2 = endDate.ToShortDateString();
                    tb6.Text = Date;
                    tb7.Text = Date2;
                    money = 100000;
                    break;
                case "btn3":
                    endDate = startDate.AddDays(180);
                    Date2 = endDate.ToShortDateString();
                    tb6.Text = Date;
                    tb7.Text = Date2;
                    money = 150000;
                    break;
                case "btn4":
                    endDate = startDate.AddDays(365);
                    Date2 = endDate.ToShortDateString();
                    tb6.Text = Date;
                    tb7.Text = Date2;
                    money = 200000;
                    break;
                default:
                    break;
            }
            //this.Visible = false;
        }

        /*             라커              */
        private void Locker()
        {
            int count = 0;
            int k = 0;
            btn_array = new ArrayList();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    count++;
                    hashtable = new Hashtable();
                    hashtable.Add("size", new Size(35, 35));
                    hashtable.Add("point", new Point(65 + (38 * j), 45 + (38 * i + k)));
                    hashtable.Add("color", Color.Green);
                    hashtable.Add(string.Format("name", "lk_btn{0}"), count);
                    hashtable.Add(string.Format("text", "{0}"), count);
                    if (count == 20 || count == 40)
                    {
                        k = k + 10;
                    }
                    lk_btn = cmm.getButton(hashtable, Locker_pnl);
                    lk_btn.TabStop = false; // 탭방지
                    lk_btn.FlatStyle = FlatStyle.Flat; // 테두리 제거
                    lk_btn.FlatAppearance.BorderSize = 0; // 테두리 제거
                    lk_btn.ForeColor = Color.White;
                    lk_btn.Font = new Font("나눔 고딕", 11, FontStyle.Bold);
                    lk_btn.Click += Lk_btn_Click;
                    btn_array.Add(lk_btn);
                    Lk_rest();
                }
            }
        }

        private void Lk_btn_Click(object o, EventArgs e)
        {
            Button lk_btn = (Button)o;
            string tb = lk_btn.Text;

            for (int i = 0; i < btn_array.Count; i++)
            {
                Button clear = (Button)btn_array[i];
                if(clear.BackColor != Color.Red) clear.BackColor = Color.Green;
            }

            lk_btn.BackColor = Color.Blue;
            locker = tb.ToString();
            tb5.Text = locker;
        }

        public void Lk_rest()
        {
            string sql = "select locker from member";
            MySqlDataReader sdr = db.Reader(sql);
            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                    //이프문추가 사용중인 라커 빨강으로
                    if (lk_btn.Text == arr[i])
                    {
                        lk_btn.BackColor = Color.Red;
                        lk_btn.Enabled = false;
                    }
                }
            }
            db.ReaderClose(sdr);
        }
    }
}
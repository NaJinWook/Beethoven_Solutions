using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
        Panel main_pnl, pnl1, pnl2, register_title;
        Label lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9;
        Hashtable hashtable = new Hashtable();
        Commons cmm = new Commons();
        PrivateFontCollection ft1, ft2, ft3;
        Font font1, font2, font3;
        RadioButton rb1, rb2;
        Button btn1, btn2, btn3, btn4;
        Form_calender fc;
        ListView lv;
        private string printAll = "select mNo,mName,Age,Sex,phone,address,locker, concat( case when DATEDIFF(mEnd, now()) < 0 then 0 else DATEDIFF(mEnd, now()) end, '일'), delYn from member;";
        public string gender;
        public TextBox tb1, tb2, tb3, tb4, tb5, tb6, tb7;
        bool sub = false;
        Member member;

        public Form_register()
        {
            InitializeComponent();
            Load += Form_register_Load;
        }

        public Form_register(bool sub, Member member)
        {
            InitializeComponent();
            Load += Form_register_Load;
            this.sub = sub;
            this.member = member;
        }

        private void Form_register_Load(object sender, EventArgs e)
        {
            main_pnl = new Panel();
            arr.Add(new ob_Pnl(this, "", "", 1461, 633, 0, 0));
            arr.Add(new ob_Pnl(this, "", "", 975, 613, 10, 10));
            arr.Add(new ob_Pnl(this, "", "", 455, 613, 995, 10));
            arr.Add(new ob_Pnl(this, "", "", 975, 53, 0, 0));

            main_pnl = os.Pnl((ob_Pnl)arr[0]);
            pnl1 = os.Pnl((ob_Pnl)arr[1]);
            pnl2 = os.Pnl((ob_Pnl)arr[2]);
            register_title = os.Pnl((ob_Pnl)arr[3]);

            Controls.Add(main_pnl);
            main_pnl.Controls.Add(pnl1);
            main_pnl.Controls.Add(pnl2);
            pnl1.Controls.Add(register_title);

            fonts();
            Label();
            Textbox();
            Button();
            Radiobutton();
            Pass();
            option();

            if (sub) // 멤버 리스트를 더블 클릭했을 때 pass2()를 통해 값을 레지스터폼에 전달
            {
                pass2();
            }
        }

        /*     라벨     */
        private void Label()
        {
            /*       이름부분         */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(90, 50));
            hashtable.Add("point", new Point(20, 65));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb1");
            hashtable.Add("text", "이름");
            lb1 = cmm.getLabel(hashtable, pnl1);
            lb1.ForeColor = Color.Black;
            lb1.BackColor = Color.Transparent;
            lb1.Font = font1;

            /*       나이부분         */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(90, 50));
            hashtable.Add("point", new Point(20, 145));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb2");
            hashtable.Add("text", "나이");
            lb2 = cmm.getLabel(hashtable, pnl1);
            lb2.ForeColor = Color.Black;
            lb2.BackColor = Color.Transparent;
            lb2.Font = font1;

            /*       성별부분         */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(90, 50));
            hashtable.Add("point", new Point(20, 225));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb3");
            hashtable.Add("text", "성별");
            lb3 = cmm.getLabel(hashtable, pnl1);
            lb3.ForeColor = Color.Black;
            lb3.BackColor = Color.Transparent;
            lb3.Font = font1;

            /*       전화번호부분         */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(145, 50));
            hashtable.Add("point", new Point(20, 305));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb5");
            hashtable.Add("text", "전화번호");
            lb5 = cmm.getLabel(hashtable, pnl1);
            lb5.ForeColor = Color.Black;
            lb5.BackColor = Color.Transparent;
            lb5.Font = font1;

            /*       주소부분         */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(90, 50));
            hashtable.Add("point", new Point(20, 385));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb4");
            hashtable.Add("text", "주소");
            lb4 = cmm.getLabel(hashtable, pnl1);
            lb4.ForeColor = Color.Black;
            lb4.BackColor = Color.Transparent;
            lb4.Font = font1;

            /*       라커부분          */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(90, 50));
            hashtable.Add("point", new Point(20, 547));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb6");
            hashtable.Add("text", "라커");
            lb6 = cmm.getLabel(hashtable, pnl1);
            lb6.ForeColor = Color.Black;
            lb6.BackColor = Color.Transparent;
            lb6.Font = font1;

            /*       달력부분              */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(90, 50));
            hashtable.Add("point", new Point(20, 467));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb7");
            hashtable.Add("text", "기간");
            lb7 = cmm.getLabel(hashtable, pnl1);
            lb7.ForeColor = Color.Black;
            lb7.BackColor = Color.Transparent;
            lb7.Font = font1;

            /*        물결          */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(40, 40));
            hashtable.Add("point", new Point(380, 465));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb8");
            hashtable.Add("text", "~");
            lb8 = cmm.getLabel(hashtable, pnl1);
            lb8.ForeColor = Color.Black;
            lb8.BackColor = Color.Transparent;
            lb8.Font = font1;

            /*        회원가입 라벨          */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(230, 40));
            hashtable.Add("point", new Point(380, 5));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb9");
            hashtable.Add("text", "회     원    가    입");
            lb9 = cmm.getLabel(hashtable, register_title);
            lb9.ForeColor = Color.Black;
            lb9.BackColor = Color.Transparent;
            lb9.Font = font3;
            if(sub)
            {
                lb9.Text = "회     원    수    정";
            }
        }

        /*     텍박     */
        private void Textbox()
        {
            /*       이름부분       */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(180, 70));
            hashtable.Add("width", "700");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb1");
            hashtable.Add("enabled", true);
            tb1 = cmm.getTextBox(hashtable, pnl1);
            tb1.Font = font2;
            tb1.BorderStyle = BorderStyle.Fixed3D;

            /*       나이부분         */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(180, 150));
            hashtable.Add("width", "700");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb2");
            hashtable.Add("enabled", true);
            tb2 = cmm.getTextBox(hashtable, pnl1);
            tb2.KeyPress += Tb3_KeyPress;
            tb2.Font = font2;
            tb2.BorderStyle = BorderStyle.Fixed3D;

            /*       전화번호부분         */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(180, 310));
            hashtable.Add("width", "700");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb3");
            hashtable.Add("enabled", true);
            tb3 = cmm.getTextBox(hashtable, pnl1);
            tb3.Font = font2;
            tb3.BorderStyle = BorderStyle.Fixed3D;
            tb3.KeyPress += Tb3_KeyPress;

            /*       주소부분         */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(180, 390));
            hashtable.Add("width", "700");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb4");
            hashtable.Add("enabled", true);
            tb4 = cmm.getTextBox(hashtable, pnl1);
            tb4.Font = font2;
            tb4.BorderStyle = BorderStyle.Fixed3D;

            /*       라커          */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(180, 550));
            hashtable.Add("width", "110");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb5");
            hashtable.Add("enabled", true);
            tb5 = cmm.getTextBox(hashtable, pnl1);
            tb5.TextAlign = HorizontalAlignment.Center;
            tb5.Font = font2;
            tb5.BorderStyle = BorderStyle.Fixed3D;
            tb5.Enabled = false;

            /*       달력부분    시작일     */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(180, 470));
            hashtable.Add("width", "190");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb6");
            hashtable.Add("enabled", true);
            tb6 = cmm.getTextBox(hashtable, pnl1);
            tb6.TextAlign = HorizontalAlignment.Center;
            tb6.Font = font2;
            tb6.BorderStyle = BorderStyle.Fixed3D;
            tb6.Enabled = false;

            /*       달력부분    종료일     */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(435, 470));
            hashtable.Add("width", "190");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb7");
            hashtable.Add("enabled", true);
            tb7 = cmm.getTextBox(hashtable, pnl1);
            tb7.TextAlign = HorizontalAlignment.Center;
            tb7.Font = font2;
            tb7.BorderStyle = BorderStyle.Fixed3D;
            tb7.Enabled = false;
        }

        /*     버튼     */
        private void Button()
        {
            if(sub)
            {
                /*    수정부분     */
                hashtable = new Hashtable();
                hashtable.Add("size", new Size(100, 70));
                hashtable.Add("point", new Point(700, 530));
                hashtable.Add("color", Color.Black);
                hashtable.Add("name", "btn3");
                hashtable.Add("text", "저장");
                hashtable.Add("click", (EventHandler)Update);
                btn3 = cmm.getButton(hashtable, pnl1);
                btn3.ForeColor = Color.White;
                btn3.FlatStyle = FlatStyle.Flat; // 테두리 제거
                btn3.FlatAppearance.BorderSize = 0; // 테두리 제거
                btn3.Font = font2;

                /*    삭제부분     */
                hashtable = new Hashtable();
                hashtable.Add("size", new Size(100, 70));
                hashtable.Add("point", new Point(830, 530));
                hashtable.Add("color", Color.Black);
                hashtable.Add("name", "btn4");
                hashtable.Add("text", "삭제");
                hashtable.Add("click", (EventHandler)Delete);
                btn4 = cmm.getButton(hashtable, pnl1);
                btn4.ForeColor = Color.White;
                btn4.FlatStyle = FlatStyle.Flat; // 테두리 제거
                btn4.FlatAppearance.BorderSize = 0; // 테두리 제거
                btn4.Font = font2;
            }
            else
            {
                /*    등록부분     */
                hashtable = new Hashtable();
                hashtable.Add("size", new Size(100, 70));
                hashtable.Add("point", new Point(757, 532));
                hashtable.Add("color", Color.Black);
                hashtable.Add("name", "btn1");
                hashtable.Add("text", "등록");
                hashtable.Add("click", (EventHandler)Register);
                btn1 = cmm.getButton(hashtable, pnl1);
                btn1.ForeColor = Color.White;
                btn1.FlatStyle = FlatStyle.Popup; // 테두리 제거
                btn1.FlatAppearance.BorderSize = 0; // 테두리 제거
                btn1.Font = font2;


                /*    초기화부분     */
                hashtable = new Hashtable();
                hashtable.Add("size", new Size(100, 70));
                hashtable.Add("point", new Point(865, 532));
                hashtable.Add("color", Color.Black);
                hashtable.Add("name", "btn2");
                hashtable.Add("text", "초기화");
                hashtable.Add("click", (EventHandler)Reset);
                btn2 = cmm.getButton(hashtable, pnl1);
                btn2.ForeColor = Color.White;
                btn2.FlatStyle = FlatStyle.Popup; // 테두리 제거
                btn2.FlatAppearance.BorderSize = 0; // 테두리 제거
                btn2.Font = font2;
            }
        }

        /*     라디오버튼    */
        private void Radiobutton()
        {
            /* 남성부분 */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(185, 225));
            hashtable.Add("size", new Size(100, 60));
            hashtable.Add("name", "rb1");
            hashtable.Add("text", "남성");
            hashtable.Add("click", (EventHandler)rdb_click);
            rb1 = cmm.getRadioButton(hashtable, pnl1);
            rb1.BackColor = Color.Transparent;
            rb1.Font = font1;
            rb1.ForeColor = Color.Blue;

            /* 여성부분 */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(295, 225));
            hashtable.Add("size", new Size(100, 60));
            hashtable.Add("name", "rb2");
            hashtable.Add("text", "여성");
            hashtable.Add("click", (EventHandler)rdb_click);
            rb2 = cmm.getRadioButton(hashtable, pnl1);
            rb2.BackColor = Color.Transparent;
            rb2.Font = font1;
            rb2.ForeColor = Color.Red;
        }

        //private void test(object o, EventArgs e)
        //{
        //    this.Close();
        //}

        private void option()
        {
            main_pnl.BackColor = Color.White;
            pnl1.BorderStyle = BorderStyle.FixedSingle;
            pnl1.BackColor = Color.White;
            register_title.BorderStyle = BorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        /*          텍스트박스에 숫자만 입력 받게           */
        private void Tb3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
                MessageBox.Show("숫자만 입력해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /*        라디오버튼 이벤트        */
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

        /*        값 전달        */
        private void Pass()
        {
            fc = new Form_calender(tb5, tb6, tb7);
            
            fc.MdiParent = this.ParentForm;
            fc.WindowState = FormWindowState.Maximized;
            fc.FormBorderStyle = FormBorderStyle.None;
            pnl2.Controls.Add(fc);
            fc.Show();
        }

        private void pass2() // 멤버클릭했을 때 값 레지스터 전달
        {
            string sql = string.Format("select mName, Age, Sex, phone, address, locker, date_format(mStart, '%Y-%m-%d'), date_format(mEnd, '%Y-%m-%d') from member where mNo = {0};", member.mNo);
            MySqlDataReader sdr = db.Reader(sql);
            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                    tb1.Text = arr[0];
                    tb2.Text = arr[1];
                    if (arr[2] == "남성")
                    {
                        rb1.Checked = true;
                    }
                    else if (arr[2] == "여성")
                    {
                        rb2.Checked = true;
                    }
                    tb3.Text = arr[3];
                    tb4.Text = arr[4];
                    tb5.Text = arr[5];
                    tb6.Text = arr[6];
                    tb7.Text = arr[7];
                }
            }
            db.ReaderClose(sdr);
            Update();
        }

        private void Select(string sql)
        {
            MySqlDataReader sdr = db.Reader(sql);
            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                }
            }
            db.ReaderClose(sdr);
        }

        private void Update(object o, EventArgs e) // 업데이트
        {
            if (rb1.Checked == true)
            {
                gender = "남성";
            }
            else if (rb2.Checked == true)
            {
                gender = "여성";
            }

            string sql = string.Format("update member set mName='{0}',Age='{1}',Sex='{2}',phone='{3}',address='{4}',locker='{5}',mStart='{6}', mEnd='{7}' where mNo={8};", tb1.Text, tb2.Text, gender, tb3.Text, tb4.Text, tb5.Text, tb6.Text, tb7.Text, member.mNo);
            DialogResult dialogResult = MessageBox.Show(string.Format("{0}님 회원 정보를 저장하시겠습니까?", member.mName), "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("회원 정보가 저장되었습니다.", "저장 완료");
                db.NonQuery(sql);
                this.Close();
            }
        }

        private void Delete(object o, EventArgs e) // 삭제
        {
            string sql = string.Format("update member set delYn = 'Y' where mNo = {0}", member.mNo);
            DialogResult dialogResult = MessageBox.Show("선택한 사용자를 삭제하시겠습니까?", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                dialogResult = MessageBox.Show("삭제하면 복구할 수 없습니다. 정말 삭제하시겠습니까?", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                {
                    if (dialogResult == DialogResult.Yes)
                    {
                        MessageBox.Show("회원 정보가 삭제되었습니다.","삭제 완료");
                        db.NonQuery(sql);
                        this.Close();
                    }
                }
            }   
        }

        private void Register(object o, EventArgs a) // 회원등록
        {
            if (tb1.Text == "" || gender == null || tb3.Text == "" || tb5.Text == "" || tb6.Text == "" || tb7.Text == "")
            {
                MessageBox.Show("회원 정보를 정확히 입력해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = string.Format("insert into member (mName, Age, Sex, phone, address, locker, mStart, mEnd, cost) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');", tb1.Text, tb2.Text, gender, tb3.Text, tb4.Text, tb5.Text, tb6.Text, tb7.Text, fc.money);
                DialogResult dialogResult = MessageBox.Show("회원 등록을 하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    tb5.Text = "사용 안함";

                    MessageBox.Show("회원이 등록되었습니다.", "등록 완료");
                    db.NonQuery(sql);
                    tb1.Text = "";
                    tb2.Text = "";
                    tb3.Text = "";
                    tb4.Text = "";
                    tb5.Text = "";
                    tb6.Text = "";
                    tb7.Text = "";
                    Pass();
                }   
            }
        }

        private void Reset(object o, EventArgs a) // 텍스트박스값 초기화
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

        private void fonts()
        {
            ft1 = new PrivateFontCollection();
            ft2 = new PrivateFontCollection();
            ft3 = new PrivateFontCollection();

            ft1.AddFontFile("Font\\HANYGO230.ttf");
            ft2.AddFontFile("Font\\HANYGO240.ttf");
            ft3.AddFontFile("Font\\HANYGO250.ttf");

            font1 = new Font(ft1.Families[0], 25);
            font2 = new Font(ft1.Families[0], 20);
            font3 = new Font(ft3.Families[0], 20);
        }
    }
}
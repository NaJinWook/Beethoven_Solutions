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
        ob_Set os = new ob_Set();
        ArrayList arr = new ArrayList();
        Panel main_pnl;
        Panel pnl1, pnl2, pnl3;
        Button btn1, btn2, btn3,btn4;
        TextBox tb,tb1,tb2,tb3,tb4,tb5,tb6;
        Label lb1;
        ComboBox cb1;
        ListView lv = new ListView();
        Hashtable hashtable=new Hashtable();
        Commons cmm = new Commons();

        public Form_member()
        {
            InitializeComponent();
            Load += Form_member_Load;
            this.BackColor = Color.White;
        }

        private void Form_member_Load(object sender, EventArgs e)
        {
            arr.Add(new ob_Pnl(this, "", "", 1441, 613, 10, 10));
            arr.Add(new ob_Pnl(this, "", "", 1461, 460, 0, 54));
            arr.Add(new ob_Pnl(this, "", "", 1461, 45, 0, 520));
            arr.Add(new ob_Pnl(this, "", "", 1461, 65, 0, 570));
            arr.Add(new ob_Tbx(this, "", "", 500, 20, 500, 25));
            arr.Add(new ob_Btn(this, "btn4", "검색", 40, 23, 1010, 25));
            //arr.Add(new ob_Btn(this, "btn5", "색", 40, 23, 1060, 25));

            main_pnl = os.Pnl((ob_Pnl)arr[0]);
            pnl1 = os.Pnl((ob_Pnl)arr[1]);
            pnl2 = os.Pnl((ob_Pnl)arr[2]);
            pnl3 = os.Pnl((ob_Pnl)arr[3]);
            tb = os.Tbx((ob_Tbx)arr[4]);
            btn4 = os.Btn((ob_Btn)arr[5]);
            //btn5 = os.Btn((ob_Btn)arr[5]);

            Controls.Add(main_pnl);
            main_pnl.Controls.Add(pnl1);
            main_pnl.Controls.Add(pnl2);
            main_pnl.Controls.Add(pnl3);
            //main_pnl.Controls.Add(tb);//검색 텍스트박스
            //main_pnl.Controls.Add(btn4);//검색 버튼
            //Controls.Add(btn5);

            option();
            hashtable = new Hashtable();
            hashtable.Add("width", "70");
            hashtable.Add("point", new Point(20, 25));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "선택");
            hashtable.Add("value", "이름");
            hashtable.Add("key", "1");
            //cb1 = cmm.getComboBox2(hashtable, this);
            //cb1.Items.Add("회원번호");
            //cb1.Items.Add("이름");
            //cb1.Items.Add("전화번호");

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
            hashtable.Add("point", new Point(1120, 0));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn1");
            hashtable.Add("text", "수정");
            hashtable.Add("click", (EventHandler)btn_click);
            btn1 = cmm.getButton(hashtable, pnl2);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 45));
            hashtable.Add("point", new Point(1230, 0));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn2");
            hashtable.Add("text", "저장");
            hashtable.Add("click", (EventHandler)btn_click);
            btn2 = cmm.getButton(hashtable, pnl2);

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
            hashtable.Add("click", (MouseEventHandler)listView_click);
            lv=cmm.getListView(hashtable, pnl1);
            lv.Dock = DockStyle.Fill;
            Select();

        }
        private void Select()
        {
            lv.Columns.Add("번호",60, HorizontalAlignment.Center);
            lv.Columns.Add("이름", 120, HorizontalAlignment.Center);
            lv.Columns.Add("나이", 70, HorizontalAlignment.Center);
            lv.Columns.Add("성별", 70, HorizontalAlignment.Center);
            lv.Columns.Add("전화번호", 400, HorizontalAlignment.Center);
            lv.Columns.Add("주소", 600, HorizontalAlignment.Center);
            lv.Columns.Add("라커", 70, HorizontalAlignment.Center);
            lv.Columns.Add("삭제", 70, HorizontalAlignment.Center);

        }

        
        private void btn_click(object o, EventArgs a)
        {

        }
        private void listView_click(object o, EventArgs a)
        {
            
        }
        private void option()
        {
            main_pnl.BackColor = Color.FromArgb(240, 240, 240);
            pnl1.BackColor = Color.Blue;
            pnl1.Dock = DockStyle.Fill;
            pnl2.BackColor = Color.Yellow;
            pnl3.BackColor = Color.Red;
        }
    }
}

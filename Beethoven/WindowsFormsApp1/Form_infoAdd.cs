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
    public partial class Form_infoAdd : Form
    {
        ob_Set os = new ob_Set();
        ArrayList arr = new ArrayList();
        Commons cmm = new Commons();
        TextBox tb1, tb2, tb3, tb4, tb5, tb6;
        Label lb1;
        Button btn1, btn2, btn3;
        Panel pn1,pn2,pn3,pn4,main_pnl;
        Hashtable hashtable;
        ListView lv;
       

        public Form_infoAdd()
        {
            InitializeComponent();
            Load += Form_infoAdd_Load;
        }

        private void Form_infoAdd_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("Sky");
            //arr.Add(new ob_Pnl(this, "", "", 1461, 633, 20, 24));

            //pn1 = os.Pnl((ob_Pnl)arr[0]);
            hashtable = new Hashtable();
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1441, 613));
            hashtable.Add("point", new Point(10, 10));
            hashtable.Add("color", Color.Blue);
            hashtable.Add("name", "pn1");
            main_pnl = cmm.getPanel2(hashtable, this);

            hashtable = new Hashtable();
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(720, 460));
            hashtable.Add("point", new Point(20, 54));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "pn1");
            pn1 = cmm.getPanel(hashtable, main_pnl);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1461, 65));
            hashtable.Add("point", new Point(20, 520));
            hashtable.Add("color", Color.SkyBlue);
            hashtable.Add("name", "pn2");
            pn2 = cmm.getPanel(hashtable, main_pnl);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1461, 65));
            hashtable.Add("point", new Point(20, 590));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "pn3");
            pn3 = cmm.getPanel(hashtable, main_pnl);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(720, 460));
            hashtable.Add("point", new Point(760, 54));
            hashtable.Add("color", Color.Blue);
            hashtable.Add("name", "pn3");
            pn4 = cmm.getPanel(hashtable, main_pnl);

            //------------------------------------------------패널 2번

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 70));
            hashtable.Add("point", new Point(1130, 0));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn1");
            hashtable.Add("text", "수정");
            hashtable.Add("click", (EventHandler)btn_click);
            btn1 = cmm.getButton(hashtable, pn2);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 70));
            hashtable.Add("point", new Point(1240, 0));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn2");
            hashtable.Add("text", "저장");
            hashtable.Add("click", (EventHandler)btn_click);
            btn2 = cmm.getButton(hashtable, pn2);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 70));
            hashtable.Add("point", new Point(1350, 0));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn3");
            hashtable.Add("text", "삭제");
            hashtable.Add("click", (EventHandler)btn_click);
            btn3 = cmm.getButton(hashtable, pn2);

            //=========================================여기까지 패널2번

            //--------------------------------------여기부터 패널3번부분
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(30, 20));
            hashtable.Add("point", new Point(30, 25));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb1");
            hashtable.Add("text", "제품명");
            lb1 = cmm.getLabel(hashtable, pn3);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(50, 20));
            hashtable.Add("point", new Point(170, 25));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb2");
            hashtable.Add("text", "회사명");
            lb1 = cmm.getLabel(hashtable, pn3);
            //품명 회사명 품번 키로수 무게 수량 구매일
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(60, 20));
            hashtable.Add("point", new Point(381, 25));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb3");
            hashtable.Add("text", "제품번호");
            lb1 = cmm.getLabel(hashtable, pn3);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(60, 20));
            hashtable.Add("point", new Point(601, 25));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb4");
            hashtable.Add("text", "키로수");
            lb1 = cmm.getLabel(hashtable, pn3);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(30, 20));
            hashtable.Add("point", new Point(721, 25));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb5");
            hashtable.Add("text", "무게");
            lb1 = cmm.getLabel(hashtable, pn3);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(60, 20));
            hashtable.Add("point", new Point(811, 25));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb6");
            hashtable.Add("text", "수량");
            lb1 = cmm.getLabel(hashtable, pn3);

            //--------------------------------------------------------------------
            hashtable = new Hashtable();
            hashtable.Add("width", "100");
            hashtable.Add("point", new Point(61, 20));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb1");
            hashtable.Add("enabled", true);
            tb1 = cmm.getTextBox(hashtable, pn3);

            hashtable = new Hashtable();
            hashtable.Add("width", "150");
            hashtable.Add("point", new Point(221, 20));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb2");
            hashtable.Add("enabled", true);
            tb2 = cmm.getTextBox(hashtable, pn3);
            //품명 회사명 품번 키로수 무게 수량 구매일
            hashtable = new Hashtable();
            hashtable.Add("width", "150");
            hashtable.Add("point", new Point(441, 20));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb3");
            hashtable.Add("enabled", true);
            tb3 = cmm.getTextBox(hashtable, pn3);

            hashtable = new Hashtable();
            hashtable.Add("width", "60");
            hashtable.Add("point", new Point(661, 20));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb4");
            hashtable.Add("enabled", true);
            tb4 = cmm.getTextBox(hashtable, pn3);

            hashtable = new Hashtable();
            hashtable.Add("width", "60");
            hashtable.Add("point", new Point(751, 20));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb5");
            hashtable.Add("enabled", true);
            tb5 = cmm.getTextBox(hashtable, pn3);

            hashtable = new Hashtable();
            hashtable.Add("width", "100");
            hashtable.Add("point", new Point(871, 20));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb6");
            hashtable.Add("enabled", true);
            tb6 = cmm.getTextBox(hashtable, pn3);

            //=============================================================


            hashtable = new Hashtable();
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "listView");
            hashtable.Add("click", (MouseEventHandler)listView_click);
            lv = cmm.getListView(hashtable, pn1);
            lv.Columns.Add("제품명",100,HorizontalAlignment.Center);
            lv.Columns.Add("회사명", 150, HorizontalAlignment.Center);
            lv.Columns.Add("제품번호",120, HorizontalAlignment.Center);
            lv.Columns.Add("키로수",50, HorizontalAlignment.Center);
            lv.Columns.Add("무게", 50, HorizontalAlignment.Center);
            lv.Columns.Add("수량", 50, HorizontalAlignment.Center);
            lv.Columns.Add("구매일",200, HorizontalAlignment.Center);

            option();
        }

        private void listView_click(object sender, MouseEventArgs e)
        {

        }

        private void btn_click(object sender, EventArgs e)
        {

        }
        
        private void option()
        {
            pn1.BackColor = Color.White;
        }
    }
}

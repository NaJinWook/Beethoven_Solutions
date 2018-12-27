using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
        TextBox tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8;
        Label lb1;
        Button btn1, btn2, btn3, btn4, btn5, btn6;
        Panel pn1, pn2, pn3, pn4, main_pnl;
        Hashtable hashtable;
        ListView lv;
        ComboBox cb1;
        PictureBox pc1;
        WebAPI api;
        private string hNo, filename;
        public int hNum;

        MYsql db = new MYsql();
        public Form_infoAdd()
        {
            InitializeComponent();
            Load += Form_infoAdd_Load;
        }

        private void Form_infoAdd_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("Sky");
            api = new WebAPI();

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1441, 613));
            hashtable.Add("point", new Point(10, 10));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "pn1");
            main_pnl = cmm.getPanel2(hashtable, this);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(720, 460));
            hashtable.Add("point", new Point(0, 54));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "pn1");
            pn1 = cmm.getPanel(hashtable, main_pnl);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1461, 45));
            hashtable.Add("point", new Point(0, 520));
            hashtable.Add("color", Color.SkyBlue);
            hashtable.Add("name", "pn2");
            pn2 = cmm.getPanel(hashtable, main_pnl);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1461, 65));
            hashtable.Add("point", new Point(0, 570));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "pn3");
            pn3 = cmm.getPanel(hashtable, main_pnl);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(720, 460));
            hashtable.Add("point", new Point(760, 54));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "pn3");
            pn4 = cmm.getPanel(hashtable, main_pnl);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(720, 460));
            hashtable.Add("point", new Point(0, 0));
            hashtable.Add("pictureboxsizemode", PictureBoxSizeMode.StretchImage);
            pc1 = cmm.getPictureBox(hashtable, pn4);


            //pn1 = os.Pnl((ob_Pnl)arr[0]);
            hashtable = new Hashtable();
            hashtable.Add("width", "70");
            hashtable.Add("point", new Point(1, 25));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "선택");
            hashtable.Add("text", "제품명");
            hashtable.Add("value", "제품명");
            hashtable.Add("key", "1");
            cb1 = cmm.getComboBox(hashtable, main_pnl);
            cb1.Items.Add("제품명");
            cb1.Items.Add("회사명");
            cb1.Items.Add("제품번호");

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(40, 23));
            hashtable.Add("point", new Point(1010, 0));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn4");
            hashtable.Add("text", "검색");
            hashtable.Add("click", (EventHandler)btn_click);
            btn4 = cmm.getButton(hashtable, main_pnl);//검색

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(70, 23));
            hashtable.Add("point", new Point(1060, 0));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn5");
            hashtable.Add("text", "전체보기");
            hashtable.Add("click", (EventHandler)btn_click);
            btn5 = cmm.getButton(hashtable, main_pnl);//전체보기

            hashtable = new Hashtable();
            hashtable.Add("width", "500");
            hashtable.Add("point", new Point(500, 0));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb7");
            hashtable.Add("enabled", true);
            tb7 = cmm.getTextBox(hashtable, main_pnl);

            //------------------------------------------------패널 2번

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 45));
            hashtable.Add("point", new Point(1130, 0));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "update");
            hashtable.Add("text", "수정");
            hashtable.Add("click", (EventHandler)btn_click);
            btn1 = cmm.getButton(hashtable, pn2);

            hashtable = new Hashtable();
            hashtable.Add("width", "800");
            hashtable.Add("point", new Point(200, 12));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb8");
            hashtable.Add("enabled", true);
            tb8 = cmm.getTextBox(hashtable, pn2);// url 텍박 

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 45));
            hashtable.Add("point", new Point(1240, 0));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "insert");
            hashtable.Add("text", "저장");
            hashtable.Add("click", (EventHandler)btn_click);
            btn2 = cmm.getButton(hashtable, pn2);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 45));
            hashtable.Add("point", new Point(1350, 0));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn3");
            hashtable.Add("text", "삭제");
            //hashtable.Add("click", (EventHandler)btn2_click);
            btn3 = cmm.getButton(hashtable, pn2);

            //=========================================여기까지 패널2번
            //--------------------------------------여기부터 패널3번부분
            /* hashtable = new Hashtable();
             hashtable.Add("size", new Size(55, 20));
             hashtable.Add("point", new Point(30, 15));
             hashtable.Add("color", Color.White);
             hashtable.Add("name", "lb1");
             hashtable.Add("text", "제품번호");
             lb1 = cmm.getLabel(hashtable, pn3);
             */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(50, 20));
            hashtable.Add("point", new Point(170, 15));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb2");
            hashtable.Add("text", "제품명");
            lb1 = cmm.getLabel(hashtable, pn3);
            //품명 회사명 품번 키로수 무게 수량 구매일
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(60, 20));
            hashtable.Add("point", new Point(381, 15));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb3");
            hashtable.Add("text", "회사명");
            lb1 = cmm.getLabel(hashtable, pn3);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(60, 20));
            hashtable.Add("point", new Point(601, 15));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb4");
            hashtable.Add("text", "무게");
            lb1 = cmm.getLabel(hashtable, pn3);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(30, 20));
            hashtable.Add("point", new Point(721, 15));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb5");
            hashtable.Add("text", "수량");
            lb1 = cmm.getLabel(hashtable, pn3);
            //--------------------------------------------------------------------
            /*
            hashtable = new Hashtable();
            hashtable.Add("width", "50");
            hashtable.Add("point", new Point(85, 10));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb1");
            hashtable.Add("enabled", true);
            tb1 = cmm.getTextBox(hashtable, pn3);
            */
            hashtable = new Hashtable();
            hashtable.Add("width", "150");
            hashtable.Add("point", new Point(221, 10));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb2");
            hashtable.Add("enabled", true);
            tb2 = cmm.getTextBox(hashtable, pn3);

            hashtable = new Hashtable();
            hashtable.Add("width", "150");
            hashtable.Add("point", new Point(441, 10));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb3");
            hashtable.Add("enabled", true);
            tb3 = cmm.getTextBox(hashtable, pn3);

            hashtable = new Hashtable();
            hashtable.Add("width", "60");
            hashtable.Add("point", new Point(661, 10));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb4");
            hashtable.Add("enabled", true);
            tb4 = cmm.getTextBox(hashtable, pn3);

            hashtable = new Hashtable();
            hashtable.Add("width", "60");
            hashtable.Add("point", new Point(751, 10));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb5");
            hashtable.Add("enabled", true);
            tb5 = cmm.getTextBox(hashtable, pn3);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 30));
            hashtable.Add("point", new Point(820, 8));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn6");
            hashtable.Add("text", "이미지 첨부");
            hashtable.Add("click", (EventHandler)upload_click);
            btn3 = cmm.getButton(hashtable, pn3);
            //=============================================================
            hashtable = new Hashtable();
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "listView");
            hashtable.Add("click", (MouseEventHandler)listView_click);
            lv = cmm.getListView(hashtable, pn1);
            lv.Columns.Add("제품번호", 80, HorizontalAlignment.Center);
            lv.Columns.Add("제품명", 150, HorizontalAlignment.Center);
            lv.Columns.Add("회사명", 150, HorizontalAlignment.Center);
            lv.Columns.Add("무게(kg)", 80, HorizontalAlignment.Center);
            lv.Columns.Add("수량", 80, HorizontalAlignment.Center);
            lv.Columns.Add("구매일", 195, HorizontalAlignment.Center);
            option();
            api.SelectListView("http://localhost:5000/select", lv);
        }


        private void listView_click(object sender, MouseEventArgs e)
        {
            //Hashtable ht = new Hashtable();
            int index;

            ListView lv = (ListView)sender;
            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;
            ListViewItem item = itemGroup[0];
            hNo = item.SubItems[0].Text;
            tb2.Text = item.SubItems[1].Text;
            tb3.Text = item.SubItems[2].Text;
            tb4.Text = item.SubItems[3].Text;
            tb5.Text = item.SubItems[4].Text;
            index = lv.FocusedItem.Index;

            //api.SelectListView("http://localhost:5000/select", lv);
            hNum = Convert.ToInt32(lv.Items[index].SubItems[0].Text);
            Selectpic("http://localhost:5000/select_img", hNum);
        }

        public bool Selectpic(string url, int hNum)
        {
            try
            {
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(url);
                StreamReader sr = new StreamReader(stream);
                string result = sr.ReadToEnd();
                ArrayList list = JsonConvert.DeserializeObject<ArrayList>(result);
                for (int i = hNum - 1; i < hNum; i++)
                {
                    JArray j = (JArray)list[i];
                    string[] arr = new string[j.Count];
                    for (int k = 0; k < j.Count; k++)
                    {
                        if (k == 2)
                        {
                            arr[k] = j[k].ToString();
                            pc1.Load(arr[k]);
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void btn_click(object o, EventArgs e)
        {
            Button btn = (Button)o;
            WebDB(btn.Name);
        }

        private void upload_click(object o, EventArgs e)
        {

            OpenFileDialog of = new OpenFileDialog();//파일을 띄운다
            of.Filter = "Images only.|*.jpg;*.jpeg;*.png;*.gif";//해당 확장명의 파일만 보이도록 필터

            if (of.ShowDialog() == DialogResult.OK)//파일열기
            {
                string filePath = of.FileName;//파일의 경로
                tb8.Text = filePath;
            }
        }

        private void WebDB(string name)
        {
            Hashtable ht = new Hashtable();

            api.SelectListView("http://localhost:5000/select", lv);
            if (name == "update")
            {
                ht.Add("hNo", hNo);
                ht.Add("hName", tb2.Text);
                ht.Add("cpName", tb3.Text);
                ht.Add("weight", tb4.Text);
                ht.Add("EA", tb5.Text);
                //ht.Add("hUrl", tb8.Text);
                api.Post("http://localhost:5000/update", ht);
                api.SelectListView("http://localhost:5000/select", lv);
            }

            else if (name == "insert")
            {
                Image img = Image.FromFile(tb8.Text);
                int start = tb8.Text.LastIndexOf("\\") + 1;
                int len = tb8.Text.Length - start;
                filename = tb8.Text.Substring(start, len);// 파일의 경로에 string 값의 마지막 파일명을 잘라서 사용

                WebClient wc = new WebClient();

                MemoryStream ms = new MemoryStream();//스트림을 바이트단위로 바로 바뀌지 않아서 메모리 스트림 생성
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imgData = ms.ToArray();

                string filedata = Convert.ToBase64String(imgData);//바이트 스트링으로 변환

                ht.Add("hName", tb2.Text);
                ht.Add("cpName", tb3.Text);
                ht.Add("weight", tb4.Text);
                ht.Add("EA", tb5.Text);
                ht.Add("filename", filename);
                ht.Add("filedata", filedata);
                api.Post("http://localhost:5000/insert", ht);
                api.SelectListView("http://localhost:5000/select", lv);
            }
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            tb8.Text = "";
            hNo = "";
            filename = "";
        }

        private void option()
        {
            pn1.BackColor = Color.White;
        }
        
    }
}
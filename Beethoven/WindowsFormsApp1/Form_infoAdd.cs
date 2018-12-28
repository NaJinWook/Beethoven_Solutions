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
using System.Drawing.Text;
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
        PrivateFontCollection ft1, ft2;
        Font font1, font2;
        TextBox tb1, tb2, tb3, tb4, tb5, tb6, tb7;
        Label lb1,lb2,lb3,lb4;
        Button btn1, btn2, btn3, btn4, btn5, btn6, btn7;
        Panel pn1, pn2, pn3, pn4, main_pnl,pn5;
        Hashtable hashtable;
        ListView lv;
        ComboBox cb1;
        PictureBox pc1;
        private string urlstr;
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
            fonts();

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1441, 613));
            hashtable.Add("point", new Point(10, 10));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "pn1");
            main_pnl = cmm.getPanel2(hashtable, this);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(780, 520));
            hashtable.Add("point", new Point(0, 20));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "pn1");
            pn1 = cmm.getPanel(hashtable, main_pnl);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1461, 60));
            hashtable.Add("point", new Point(0, 550));
            hashtable.Add("color", Color.FromArgb(45, 35, 135));
            hashtable.Add("name", "pn2");
            pn2 = cmm.getPanel(hashtable, main_pnl);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(620, 520));
            hashtable.Add("point", new Point(790, 20));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "pn3");
            pn4 = cmm.getPanel(hashtable, main_pnl);
            pn4.BorderStyle = BorderStyle.FixedSingle;
            
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(620, 520));
            hashtable.Add("point", new Point(0, 0));
            hashtable.Add("pictureboxsizemode", PictureBoxSizeMode.CenterImage);
            pc1 = cmm.getPictureBox(hashtable, pn4);
            pc1.Image = Properties.Resources.normal_img;
            
            //------------------------------------------------패널 2번

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 50));
            hashtable.Add("point", new Point(1111, 5));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "update");
            hashtable.Add("text", "수정");
            hashtable.Add("click", (EventHandler)btn_click);
            btn1 = cmm.getButton(hashtable, pn2);
            btn1.Font = font1;
            btn1.ForeColor = Color.White;
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.FlatAppearance.BorderSize = 0;

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 50));
            hashtable.Add("point", new Point(1221, 5));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "insert");
            hashtable.Add("text", "저장");
            hashtable.Add("click", (EventHandler)btn_click);
            btn2 = cmm.getButton(hashtable, pn2);
            btn2.Font = font1;
            btn2.ForeColor = Color.White;
            btn2.FlatStyle = FlatStyle.Flat;
            btn2.FlatAppearance.BorderSize = 0;
            
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 50));
            hashtable.Add("point", new Point(1331, 5));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "btn3");
            hashtable.Add("text", "삭제");
            btn3 = cmm.getButton(hashtable, pn2);
            btn3.Font = font1;
            btn3.ForeColor = Color.White;
            btn3.FlatStyle = FlatStyle.Flat;
            btn3.FlatAppearance.BorderSize = 0;
            
            //=========================================여기까지 패널2번
            //--------------------------------------여기부터 패널3번부분

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(67, 30));
            hashtable.Add("point", new Point(10, 15));
            hashtable.Add("color", Color.FromArgb(45, 35, 135));
            hashtable.Add("name", "lb1");
            hashtable.Add("text", "제품명");
            lb1 = cmm.getLabel(hashtable, pn2);
            lb1.Font = font2;
            lb1.ForeColor = Color.White;

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(67, 30));
            hashtable.Add("point", new Point(240, 15));
            hashtable.Add("color", Color.FromArgb(45, 35, 135));
            hashtable.Add("name", "lb2");
            hashtable.Add("text", "회사명");
            lb2 = cmm.getLabel(hashtable, pn2);
            lb2.Font = font2;
            lb2.ForeColor = Color.White;

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(50, 30));
            hashtable.Add("point", new Point(470, 15));
            hashtable.Add("color", Color.FromArgb(45, 35, 135));
            hashtable.Add("name", "lb3");
            hashtable.Add("text", "무게");
            lb3 = cmm.getLabel(hashtable, pn2);
            lb3.Font = font2;
            lb3.ForeColor = Color.White;

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(50, 30));
            hashtable.Add("point", new Point(610, 15));
            hashtable.Add("color", Color.FromArgb(45, 35, 135));
            hashtable.Add("name", "lb4");
            hashtable.Add("text", "수량");
            lb4 = cmm.getLabel(hashtable, pn2);
            lb4.Font = font2;
            lb4.ForeColor = Color.White;
            //--------------------------------------------------------------------

            hashtable = new Hashtable();
            hashtable.Add("width", "150");
            hashtable.Add("point", new Point(80, 15));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb2");
            hashtable.Add("enabled", true);
            tb2 = cmm.getTextBox(hashtable, pn2);
            tb2.Font = font1;

            hashtable = new Hashtable();
            hashtable.Add("width", "150");
            hashtable.Add("point", new Point(310, 15));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb3");
            hashtable.Add("enabled", true);
            tb3 = cmm.getTextBox(hashtable, pn2);
            tb3.Font = font1;

            hashtable = new Hashtable();
            hashtable.Add("width", "60");
            hashtable.Add("point", new Point(525, 15));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb4");
            hashtable.Add("enabled", true);
            tb4 = cmm.getTextBox(hashtable, pn2);
            tb4.Font = font1;

            hashtable = new Hashtable();
            hashtable.Add("width", "60");
            hashtable.Add("point", new Point(675, 15));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb5");
            hashtable.Add("enabled", true);
            tb5 = cmm.getTextBox(hashtable, pn2);
            tb5.Font = font1;

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(70, 50));
            hashtable.Add("point", new Point(760, 5));
            hashtable.Add("color", Color.FromArgb(45, 35, 135));
            hashtable.Add("name", "btn6");
            hashtable.Add("text", "");
            hashtable.Add("click", (EventHandler)upload_click);
            btn6 = cmm.getButton(hashtable, pn2);
            btn6.Image= Properties.Resources.file_img;
            btn6.ForeColor = Color.White;
            btn6.FlatStyle = FlatStyle.Flat;
            btn6.FlatAppearance.BorderSize = 0;

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(100, 50));
            hashtable.Add("point", new Point(940, 5));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "btn7");
            hashtable.Add("text", "CLEAR");
            hashtable.Add("click", (EventHandler)btn_clear);
            btn7 = cmm.getButton(hashtable, pn2);
            btn7.Font = font1;
            btn7.ForeColor = Color.White;
            btn7.FlatStyle = FlatStyle.Flat;
            btn7.FlatAppearance.BorderSize = 0;

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
            lv.Columns.Add("구매일", 235, HorizontalAlignment.Center);
            lv.Font = font1;
            option();
            api.SelectListView("http://192.168.3.12:5000/select", lv);
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            urlstr = "";
            hNo = "";
            filename = "";
        }
        private void listView_click(object sender, MouseEventArgs e)
        {
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
            hNum = Convert.ToInt32(lv.Items[index].SubItems[0].Text);
            api.Selectpic("http://192.168.3.12:5000/select_img", hNum,pc1, urlstr);
        }
       
        private void btn_clear(object o,EventArgs e)
        {
            Button btn = (Button)o;
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            urlstr = "";
            hNo = "";
            filename = "";
            pc1.Image = Properties.Resources.normal_img;
        }

        private void btn_click(object o, EventArgs e)
        {
            Button btn = (Button)o;
            if(tb2.Text == ""&&tb3.Text == ""&&tb4.Text == ""&&tb5.Text == ""&& urlstr == ""&&hNo=="")
            {
                MessageBox.Show("값을 입력해주세요.");
            }
            else
            {
                WebDB(btn.Name);
            }
        }

        private void upload_click(object o, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Images only.|*.jpg;*.jpeg;*.png;*.gif";

            if (of.ShowDialog() == DialogResult.OK)
            {
                string filePath = of.FileName;
                urlstr = filePath;
            }
        }

        private void fonts()
        {
            ft1 = new PrivateFontCollection();
            ft2 = new PrivateFontCollection();

            ft1.AddFontFile("Font\\HANYGO230.ttf");
            ft2.AddFontFile("Font\\HANYGO250.ttf");

            font1 = new Font(ft1.Families[0], 13);
            font2 = new Font(ft2.Families[0], 15);
        }

        private void WebDB(string name)
        {
            Hashtable ht = new Hashtable();
            api.SelectListView("http://192.168.3.12:5000/select", lv);
            if (name == "update")
            {
                Image img = Image.FromFile(urlstr);
                int start = urlstr.LastIndexOf("\\") + 1;
                int len = urlstr.Length - start;
                filename = urlstr.Substring(start, len);// 파일의 경로에 string 값의 마지막 파일명을 잘라서 사용

                WebClient wc = new WebClient();

                MemoryStream ms = new MemoryStream();//스트림을 바이트단위로 바로 바뀌지 않아서 메모리 스트림 생성
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imgData = ms.ToArray();

                string filedata = Convert.ToBase64String(imgData);//바이트 스트링으로 변환
                
                ht.Add("hNo", hNo);
                ht.Add("hName", tb2.Text);
                ht.Add("cpName", tb3.Text);
                ht.Add("weight", tb4.Text);
                ht.Add("EA", tb5.Text);
                ht.Add("filename", filename);
                ht.Add("filedata", filedata);
                api.Post("http://192.168.3.12:5000/update", ht);
                api.SelectListView("http://192.168.3.12:5000/select", lv);
            }

            else if (name == "insert")
            {
                Image img = Image.FromFile(urlstr);
                int start = urlstr.LastIndexOf("\\") + 1;
                int len = urlstr.Length - start;
                filename = urlstr.Substring(start, len);//파일의 경로에 string 값의 마지막 파일명을 잘라서 사용

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
                api.Post("http://192.168.3.12:5000/insert", ht);
                api.SelectListView("http://192.168.3.12:5000/select", lv);
            }
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            urlstr = "";
            hNo = "";
            filename = "";
        }

        private void option()
        {
            pn1.BackColor = Color.White;
        }
    }
}
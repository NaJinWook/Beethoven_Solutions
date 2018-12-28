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
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form_User : Form
    {
        private MYsql db = new MYsql();
        Hashtable hashtable = new Hashtable();
        Commons cmm = new Commons();
        Label lb1, lb2;
        private string sql;
        Chart chart2;
        Panel pnl1, pnl2;
        ArrayList arr = new ArrayList();
        Button btn1, btn2, btn3, btn4;
        public TextBox tb1, tb2;
        ListView lv = new ListView();
        ob_Set os = new ob_Set();
        Font font1, font2;
        PrivateFontCollection ft1, ft2;

        public Form_User()
        {
            InitializeComponent();
            Load += Form_User_Load;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Beethoven Management System ver 0.1";
            ClientSize = new Size(540, 660);
        }

        private void Form_User_Load(object sender, EventArgs e)
        {
            fonts();
            Panel();
            Label();
            Textbox();
            Button();
            Listview();

        }

        /*      패널      */
        private void Panel()
        {
            arr.Add(new ob_Pnl(this, "", "", 500, 128, 20, 30)); //위쪽 버튼 부분
            arr.Add(new ob_Pnl(this, "", "", 500, 470, 20, 170)); //리스트뷰 and 그래프 밑쪽
            pnl1 = os.Pnl((ob_Pnl)arr[1]);
            pnl2 = os.Pnl((ob_Pnl)arr[0]);
            this.BackColor = Color.FromArgb(45, 35, 135);
            pnl2.BackColor = Color.White;
            Controls.Add(pnl1);
            Controls.Add(pnl2);

        }
        private void Label()
        {
            /*       회원번호부분         */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(75, 30));
            hashtable.Add("point", new Point(20, 20));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb1");
            hashtable.Add("text", "회원번호");
            lb1 = cmm.getLabel(hashtable, pnl2);
            lb1.ForeColor = Color.Black;
            lb1.BackColor = Color.White;
            lb1.Font = new Font("맑은 고딕", 12, FontStyle.Bold);

            /*       몸무게부분         */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(75, 30));
            hashtable.Add("point", new Point(20, 60));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb2");
            hashtable.Add("text", "몸무게");
            lb2 = cmm.getLabel(hashtable, pnl2);
            lb2.ForeColor = Color.Black;
            lb2.BackColor = Color.White;
            lb2.TextAlign = ContentAlignment.MiddleCenter;
            lb2.Font = new Font("맑은 고딕", 12, FontStyle.Bold);
        }

        private void Textbox()
        {
            /*       회원번호검색       */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(105, 20));
            hashtable.Add("width", "60");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb1");
            hashtable.Add("enabled", true);
            tb1 = cmm.getTextBox(hashtable, pnl2);
            tb1.Font = new Font("맑은 고딕", 14, FontStyle.Regular);
            tb1.KeyPress += Tb_KeyPress;
            tb1.Font = font1;
            /*       몸무게등록       */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(105, 60));
            hashtable.Add("width", "60");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb2");
            hashtable.Add("enabled", true);
            tb2 = cmm.getTextBox(hashtable, pnl2);
            tb2.Font = new Font("맑은 고딕", 14, FontStyle.Regular);
            tb2.KeyPress += Tb_KeyPress;
            tb1.Font = font1;
        }
        private void Button()
        {
            /*    검색부분     */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(50, 35));
            hashtable.Add("point", new Point(170, 19));
            hashtable.Add("color", Color.Yellow);
            hashtable.Add("name", "btn1");
            hashtable.Add("text", "검색");
            hashtable.Add("click", (EventHandler)btn_search);
            btn1 = cmm.getButton(hashtable, pnl2);
            btn1.BackColor = Color.Black;
            btn1.ForeColor = Color.White;
            btn1.FlatStyle = FlatStyle.Flat; // 테두리 제거
            //btn1.FlatAppearance.BorderSize = 0; // 테두리 제거
            btn1.Font = font1;
            /*    등록부분     */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(50, 35));
            hashtable.Add("point", new Point(170, 60));
            hashtable.Add("color", Color.Yellow);
            hashtable.Add("name", "btn2");
            hashtable.Add("text", "등록");
            hashtable.Add("click", (EventHandler)btn_register);
            btn2 = cmm.getButton(hashtable, pnl2);
            btn2.BackColor = Color.Black;
            btn2.ForeColor = Color.White;
            btn2.FlatStyle = FlatStyle.Flat; // 테두리 제거
            btn2.Font = font1;
            //btn2.FlatAppearance.BorderSize = 0; // 테두리 제거

            /*    그래프부분     */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(90, 40));
            hashtable.Add("point", new Point(405, 85));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn3");
            hashtable.Add("text", "그래프");
            hashtable.Add("click", (EventHandler)btn_graph);
            btn3 = cmm.getButton(hashtable, pnl2);
            btn3.BackColor = Color.Black;
            btn3.ForeColor = Color.White;
            btn3.FlatStyle = FlatStyle.Flat; // 테두리 제거
            btn3.Font = font1;
            //btn3.FlatAppearance.BorderSize = 0; // 테두리 제거


            /*    리스트부분     */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(90, 40));
            hashtable.Add("point", new Point(315, 85));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn4");
            hashtable.Add("text", "리스트");
            hashtable.Add("click", (EventHandler)btn_list);
            btn4 = cmm.getButton(hashtable, pnl2);
            btn4.BackColor = Color.Black;
            btn4.ForeColor = Color.White;
            btn4.FlatStyle = FlatStyle.Flat; // 테두리 제거
            //btn4.FlatAppearance.BorderSize = 0; // 테두리 제거
            btn4.Font = font1;
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
            lv.ColumnWidthChanging += Lv_ColumnWidthChanging;
            lv.View = View.Details;
            lv.Font = font1;
            lv.Columns.Add("회원번호", 70, HorizontalAlignment.Center);
            lv.Columns.Add("이름", 65, HorizontalAlignment.Center);
            lv.Columns.Add("몸무게", 70, HorizontalAlignment.Center);
            lv.Columns.Add("등록일", 150, HorizontalAlignment.Center);
            lv.Columns.Add("입력날짜", 140, HorizontalAlignment.Center);
            lv.ColumnClick += Lv_ColumnClick1;
        }

        private void Lv_ColumnClick1(object sender, ColumnClickEventArgs e)
        {
            if (this.lv.Sorting == SortOrder.Ascending || lv.Sorting == SortOrder.None)
            {
                this.lv.ListViewItemSorter = new ListViewItemComparer(e.Column, "desc");
                lv.Sorting = SortOrder.Descending;
            }
            else
            {
                this.lv.ListViewItemSorter = new ListViewItemComparer(e.Column, "asc");
                lv.Sorting = SortOrder.Ascending;

            }
            lv.Sort();
        }



        /*        검색 이벤트        */
        private void btn_search(object o, EventArgs e)
        {

            if (tb1.Text == "")
            {
                lv.Items.Clear();
                MessageBox.Show("빈칸입니다");
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
        private void Lv_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = lv.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }
        /*        등록 이벤트        */
        private void btn_register(object o, EventArgs e)
        {
            //MessageBox.Show("gd");
            //string sql = string.Format("insert into weight(mNo,rNum,kg) select '{0}',  case when  max(rNum) is null then 1 else  max(rNum) +1 end as rNum,'{1}' from weight where mNo = '{2}';", tb1.Text, tb2.Text, tb1.Text);

            sql = string.Format("call User_insert('{0}','{1}');", tb1.Text, tb2.Text);
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

        /*        그래프 이벤트        */
        private void btn_graph(object o, EventArgs e)
        {
            lv.Visible = false;

            //pnl1.BackColor = Color.Black;

            chart2 = new Chart();
            ChartArea chartArea2 = new ChartArea();
            Legend legend2 = new Legend();
            Series series2 = new Series();

            chartArea2.Name = "ChartArea2";
            legend2.Name = "Legend2";
            series2.ChartArea = "ChartArea2";
            series2.ChartType = SeriesChartType.Line;
            series2.Legend = "Legend2";
            series2.Name = "몸무게";

            chart2.Name = "chart2";

            chart2.Dock = DockStyle.Fill;

            chart2.Text = "chart2";
            chart2.BackColor = Color.Silver;
            chart2.ChartAreas.Add(chartArea2);
            chart2.Legends.Add(legend2);
            chart2.Series.Add(series2);

            chart2.Series["몸무게"].IsValueShownAsLabel = false;

            sql = (string.Format("call Day_select('{0}')", tb1.Text));


            //MessageBox.Show(sql);
            MySqlDataReader sdr = db.Reader(sql);
            chart2.Series["몸무게"].Points.Clear();
            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                }
                chart2.Series["몸무게"].Points.AddXY(arr[0], arr[1]);
            }
            db.ReaderClose(sdr);

            pnl1.Controls.Add(chart2);







        }
        /*        리스트 이벤트        */
        private void btn_list(object o, EventArgs e)
        {
            if (lv.Visible == false)
            {
                chart2.Visible = false;
                lv.Visible = true;
            }
        }

        /*        예외처리        */
        private void Tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
                MessageBox.Show("숫자만 입력해주세요.");
            }
        }


        private void fonts()
        {
            ft1 = new PrivateFontCollection();
            ft2 = new PrivateFontCollection();

            ft1.AddFontFile("Font\\HANYGO230.ttf");
            ft2.AddFontFile("Font\\HANYGO250.ttf");

            font1 = new Font(ft1.Families[0], 12);
            font2 = new Font(ft2.Families[0], 50);

        }

        internal class ListViewItemComparer : IComparer
        {
            private int column;
            private string sort = "asc";

            public ListViewItemComparer()
            {
                column = 0;
            }
            public ListViewItemComparer(int column, string sort)
            {
                this.column = column;
                this.sort = sort;
            }
            public int Compare(object x, object y)
            {
                int chk = 1;
                try
                {
                    if (sort == "asc")
                        chk = 1;
                    else
                        chk = -1;
                    if (Convert.ToInt32(((ListViewItem)x).SubItems[column].Text) > Convert.ToInt32(((ListViewItem)y).SubItems[column].Text))
                        return chk;
                    else
                        return -chk;
                }
                catch (Exception)
                {
                    if (sort == "asc")
                        return String.Compare(((ListViewItem)x).SubItems[column].Text, ((ListViewItem)y).SubItems[column].Text);
                    else
                        return String.Compare(((ListViewItem)y).SubItems[column].Text, ((ListViewItem)x).SubItems[column].Text);
                }
            }
        }
    }   
}
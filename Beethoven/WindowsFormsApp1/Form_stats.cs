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
    public partial class Form_stats : Form
    {
        Hashtable hashtable;
        Panel pn1,pn2,pn3,pn4,pn5;
        ListView lv;
        PrivateFontCollection ft1, ft2;
        Font font1, font2;
        
        ComboBox cb1;
        Chart chart1,chart2;
        //ImageList il = new ImageList();
        private MYsql db = new MYsql();
        Commons cmm = new Commons();
        private string sql = "select count(*) from member where sex = '남성';";
        private string sql2 = "select count(*) from member where sex = '여성';";
        private string sql3 = "select DATE_FORMAT(mStart, '%Y년 %m월') as '일자',sum(cost) as '월 매출' from member where mstart Like '2018%' group by DATE_FORMAT(mStart, '%Y%m') order by 1;";
        private string cbyear = "select DATE_FORMAT(mStart, '%Y')as '년' from member group by DATE_FORMAT(mStart, '%Y');";

        public Form_stats()
        {
            InitializeComponent();
            Load += Form_stats_Load;
        }
        //1461,633
        private void Form_stats_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("Sky");
            fonts();
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1461, 633));
            hashtable.Add("point", new Point(0, 0));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "BackgroundPN4");
            pn4 = cmm.getPanel2(hashtable, this);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(305, 623));
            hashtable.Add("point", new Point(5, 5));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "BackgroundPN5");
            pn5 = cmm.getPanel(hashtable, pn4);
            pn5.BorderStyle = BorderStyle.FixedSingle;

            hashtable = new Hashtable();
            hashtable.Add("size",new Size(220,180));
            hashtable.Add("point", new Point(42,435));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "BackgroundPN1");
            pn1=cmm.getPanel(hashtable, pn5);
            pn1.BorderStyle = BorderStyle.FixedSingle;

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(220, 375));
            hashtable.Add("point", new Point(42,55));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "BackgroundPN2");
            pn2 = cmm.getPanel(hashtable, pn5);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1130, 623));
            hashtable.Add("point", new Point(326, 5));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "BackgroundPN3");
            pn3 = cmm.getPanel(hashtable, pn4);
            pn3.BorderStyle = BorderStyle.FixedSingle;

            hashtable = new Hashtable();
            hashtable.Add("width", "80");
            hashtable.Add("point", new Point(42, 10));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "선택");
            hashtable.Add("text", "이름");
            hashtable.Add("value", "이름");
            hashtable.Add("key", "1");
            cb1 = cmm.getComboBox(hashtable, pn5);
            cb_year(cbyear);
            cb1.DropDownStyle = ComboBoxStyle.DropDownList;
            cb1.SelectedIndexChanged += Cb1_SelectedIndexChanged;
            cb1.Font = font1;

            chart1 = new Chart();
            ChartArea chartArea1 = new ChartArea();
            Series series1 = new Series();

            chartArea1.Name = "ChartArea1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = SeriesChartType.Doughnut;
            series1.Name = "Series1";
            
            chart1.Name = "chart1";
            chart1.Dock = DockStyle.Fill;
            chart1.Text = "chart1";
            chart1.ChartAreas.Add(chartArea1);
            chart1.Titles.Add("현 성별 정보");
            chart1.Series.Add(series1);
            chart1.Series["Series1"].IsValueShownAsLabel = false;
            value_search(sql);
            value_search2(sql2);
            pn1.Controls.Add(chart1);
            //===============================================================
            chart2 = new Chart();
            ChartArea chartArea2 = new ChartArea();
            Legend legend2 = new Legend();
            Series series2 = new Series();

            chartArea2.Name = "ChartArea2";
            legend2.Name = "Legend2";
            series2.ChartArea = "ChartArea2";
            series2.ChartType = SeriesChartType.Column;
            series2.Legend = "Legend2";
            series2.Name = "매출액";

            chart2.Name = "chart2";
            chart2.Dock = DockStyle.Fill;
            chart2.Text = "chart2";
            chart2.BackColor = Color.White;
            chart2.ChartAreas.Add(chartArea2);
            chart2.Legends.Add(legend2);
            chart2.Series.Add(series2);

            chart2.Series["매출액"].IsValueShownAsLabel = false;
            month_cost(string.Format("select DATE_FORMAT(mStart, '%Y년 %m월') as '일자',sum(cost) as '월 매출' from member where mstart Like '{0}%' group by DATE_FORMAT(mStart, '%Y%m') order by 1;",cb1.Text));
            pn3.Controls.Add(chart2);
            
            hashtable = new Hashtable();
            hashtable.Add("color", Color.WhiteSmoke);
            hashtable.Add("name", "listView");
            lv = cmm.getListView(hashtable, pn2);
            month_cost2(sql3);
            lv.Columns.Add("월", 120, HorizontalAlignment.Center);
            lv.Columns.Add("매출액", 96, HorizontalAlignment.Center);
            lv.Font = font1;
        }

        private void Cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            month_cost2(string.Format("select DATE_FORMAT(mStart, '%Y년 %m월') as '일자',sum(cost) as '월 매출' from member where mstart Like '{0}%' group by DATE_FORMAT(mStart, '%Y%m') order by 1;", cb1.Text));
            month_cost(string.Format("select DATE_FORMAT(mStart, '%Y년 %m월') as '일자',sum(cost) as '월 매출' from member where mstart Like '{0}%' group by DATE_FORMAT(mStart, '%Y%m') order by 1;", cb1.Text));
        }//콤보박스 클릭시 그래프와 리스트 초기화
        private void cb_year(string cbyear)
        {
            MySqlDataReader sdr = db.Reader(cbyear);
            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                }
                cb1.Items.Add(string.Format("{0}",arr));
            }
            db.ReaderClose(sdr);
        }//콤보박스 년도 자동 생성

        private void month_cost2(string sql3)
        {
            MySqlDataReader sdr = db.Reader(sql3);
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
        }//월별 데이터 리스트뷰

        private void month_cost(string sql3)
        {
            MySqlDataReader sdr = db.Reader(sql3);
            chart2.Series["매출액"].Points.Clear();
            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                }
                chart2.Series["매출액"].Points.AddXY(arr[0],arr[1]);
            }
            db.ReaderClose(sdr);
        }// 월별데이터 그래프
        private void value_search(string sql)
        {
            MySqlDataReader sdr = db.Reader(sql);
            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                    chart1.Series["Series1"].Points.AddXY(string.Format("남자 {0}",arr[i]), string.Format("{0}",arr[i]));
                }
            }
            db.ReaderClose(sdr);
        }//남자
        private void value_search2(string sql2)
        {
            MySqlDataReader sdr = db.Reader(sql2);
            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                    chart1.Series["Series1"].Points.AddXY(string.Format("여자 {0}", arr[i]), string.Format("{0}", arr[i]));
                }
            }
            db.ReaderClose(sdr);
        }//여자

        private void fonts()
        {
            ft1 = new PrivateFontCollection();
            ft2 = new PrivateFontCollection();

            ft1.AddFontFile("Font\\HANYGO230.ttf");
            ft2.AddFontFile("Font\\HANYGO250.ttf");

            font1 = new Font(ft1.Families[0], 13);
            font2 = new Font(ft2.Families[0], 50);
        }
    }
}

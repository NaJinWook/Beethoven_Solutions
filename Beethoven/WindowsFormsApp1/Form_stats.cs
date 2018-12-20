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
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form_stats : Form
    {
        Hashtable hashtable;
        Panel pn1,pn2,pn3,pn4;
        ListView lv;
        ComboBox cb1;
        Chart chart1,chart2;
        ImageList il = new ImageList();
        private MYsql db = new MYsql();
        Commons cmm = new Commons();
        private string sql = "select count(*) from member where sex = '남성';";
        private string sql2 = "select count(*) from member where sex = '여성';";
        private string sql3 = "select DATE_FORMAT(mStart, '%Y년 %m월') as '일자',sum(cost) as '월 매출' from member where mstart Like '2018%' group by DATE_FORMAT(mStart, '%Y%m') order by 1;";
        public Form_stats()
        {
            InitializeComponent();
            Load += Form_stats_Load;
        }
        //1461,633
        private void Form_stats_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("Sky");
            
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1461, 633));
            hashtable.Add("point", new Point(0, 0));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "BackgroundPN1");
            pn4 = cmm.getPanel2(hashtable, this);
            
            hashtable = new Hashtable();
            hashtable.Add("size",new Size(200,200));
            hashtable.Add("point", new Point(1225,430));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "BackgroundPN1");
            pn1=cmm.getPanel(hashtable,pn4);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(200, 350));
            hashtable.Add("point", new Point(1225, 75));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "BackgroundPN2");
            pn2 = cmm.getPanel(hashtable, pn4);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1150, 550));
            hashtable.Add("point", new Point(20, 75));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "BackgroundPN2");
            pn3 = cmm.getPanel(hashtable, pn4);

            chart1 = new Chart();
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();
            Series series1 = new Series();

            chartArea1.Name = "ChartArea1";
            legend1.Name = "Legend1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            
            chart1.Name = "chart1";
            chart1.Dock = DockStyle.Fill;
            chart1.Text = "chart1";
            chart1.ChartAreas.Add(chartArea1);
            chart1.Legends.Add(legend1);
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
            series2.ChartType = SeriesChartType.Bar;
            series2.Legend = "Legend2";
            series2.Name = "매출액";

            chart2.Name = "chart2";
            chart2.Dock = DockStyle.Fill;
            chart2.Text = "chart2";
            chart2.BackColor = Color.Pink;
            chart2.ChartAreas.Add(chartArea2);
            chart2.Legends.Add(legend2);
            chart2.Series.Add(series2);

            chart2.Series["매출액"].IsValueShownAsLabel = false;
            month_cost(sql3);
            pn3.Controls.Add(chart2);
            
            hashtable = new Hashtable();
            hashtable.Add("color", Color.WhiteSmoke);
            hashtable.Add("name", "listView");
            hashtable.Add("click", (MouseEventHandler)listView_click);
            lv = cmm.getListView(hashtable, pn2);
            month_cost2(sql3);
            lv.Columns.Add("월");
            lv.Columns.Add("매출액");
        }

        private void listView_click(object sender, MouseEventArgs e)
        {

        }

        private void month_cost2(string sql3)
        {
            MySqlDataReader sdr = db.Reader(sql3);
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

        private void month_cost(string sql3)
        {
            MySqlDataReader sdr = db.Reader(sql3);
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
        }
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
    }
}

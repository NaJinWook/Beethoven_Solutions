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
        Panel pn1,pn2;
        ListView lv;
        Commons cmm = new Commons();
        public Form_stats()
        {
            InitializeComponent();
            Load += Form_stats_Load;
        }

        private void Form_stats_Load(object sender, EventArgs e)
        {
            hashtable = new Hashtable();
            hashtable.Add("size",new Size(1461,630));
            hashtable.Add("point", new Point(0,0));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "BackgroundPN");
            pn1=cmm.getPanel2(hashtable,this);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(800, 630));
            hashtable.Add("point", new Point(800, 25));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "BackgroundPN");
            pn2 = cmm.getPanel(hashtable, pn1);

            Chart pieChart = new Chart();
            pieChart.ChartAreas.Add(new ChartArea());

            pieChart.Dock = DockStyle.Left;
            
            Series series = new Series();
            series.ChartType = SeriesChartType.Doughnut;
            int[] arrData = { 400, 200};
            for (int i = 0; i < arrData.Length; i++)
            {
                series.Points.Add(arrData[i]);
            }

            pieChart.Series.Add(series);
            pn1.Controls.Add(pieChart);


            hashtable = new Hashtable();
            hashtable.Add("color", Color.WhiteSmoke);
            hashtable.Add("name", "listView");
            hashtable.Add("click", (MouseEventHandler)listView_click);
            lv = cmm.getListView(hashtable, pn2);
            lv.Columns.Add("월");
            lv.Columns.Add("매출액");
            /*
            // 객체 선언 및 생성
            Chart chart1 = new Chart();
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();
            Series series1 = new Series();

            // 기본 설정
            chartArea1.Name = "ChartArea1";
            legend1.Name = "Legend1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Series1";

            // 차트 기본 설정
            chart1.Name = "chart1";
            chart1.Dock = DockStyle.Fill;
            chart1.Text = "chart1";
            chart1.ChartAreas.Add(chartArea1);
            chart1.Legends.Add(legend1);
            chart1.Series.Add(series1);

            // 데이터 부분
            chart1.Series["Series1"].IsValueShownAsLabel = false;
            chart1.Series["Series1"].Points.AddXY("1", "10");
            chart1.Series["Series1"].Points.AddXY("2", "20");
            chart1.Series["Series1"].Points.AddXY("3", "30");
            chart1.Series["Series1"].Points.AddXY("4", "40");
            chart1.Series["Series1"].Points.AddXY("5", "50");
            chart1.Series["Series1"].Points.AddXY("6", "60");

            // 컨트롤 등록
            this.Controls.Add(chart1);
            */

        }

        private void listView_click(object sender, MouseEventArgs e)
        {
        }
    }
}

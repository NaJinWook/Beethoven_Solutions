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
        Panel pn1,pn2,pn3;
        ListView lv;
        Commons cmm = new Commons();
        public Form_stats()
        {
            InitializeComponent();
            Load += Form_stats_Load;
        }

        private void Form_stats_Load(object sender, EventArgs e)
        {

            this.BackgroundImage = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("Sky");
            

            hashtable = new Hashtable();
            hashtable.Add("size",new Size(700,630));
            hashtable.Add("point", new Point(20,25));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "BackgroundPN1");
            pn1=cmm.getPanel2(hashtable,this);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(123, 500));
            hashtable.Add("point", new Point(800, 25));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "BackgroundPN2");
            pn2 = cmm.getPanel(hashtable, this);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(400, 500));
            hashtable.Add("point", new Point(1000, 25));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "BackgroundPN2");
            pn3 = cmm.getPanel(hashtable, this);

            Chart chart1 = new Chart();
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
            chart1.Series["Series1"].Points.AddXY("남자", "10");
            chart1.Series["Series1"].Points.AddXY("여자", "20");
            pn1.Controls.Add(chart1);

            Chart chart2 = new Chart();
            ChartArea chartArea2 = new ChartArea();
            Legend legend2 = new Legend();
            Series series2 = new Series();

            chartArea2.Name = "ChartArea2";
            legend2.Name = "Legend2";
            series2.ChartArea = "ChartArea2";
            series2.ChartType = SeriesChartType.Line;
            series2.Legend = "Legend2";
            series2.Name = "Series2";

            chart2.Name = "chart2";
            chart2.Dock = DockStyle.Fill;
            chart2.Text = "chart2";
            chart2.ChartAreas.Add(chartArea2);
            chart2.Legends.Add(legend2);
            chart2.Series.Add(series2);

            chart2.Series["Series2"].IsValueShownAsLabel = false;
            chart2.Series["Series2"].Points.AddXY("1월", "10");
            chart2.Series["Series2"].Points.AddXY("2월", "20");
            chart2.Series["Series2"].Points.AddXY("3월", "50");
            chart2.Series["Series2"].Points.AddXY("4월", "20");
            chart2.Series["Series2"].Points.AddXY("5월", "70");
            chart2.Series["Series2"].Points.AddXY("6월", "80");
            chart2.Series["Series2"].Points.AddXY("7월", "50");
            chart2.Series["Series2"].Points.AddXY("8월", "10");
            chart2.Series["Series2"].Points.AddXY("9월", "90");
            chart2.Series["Series2"].Points.AddXY("10월", "20");
            chart2.Series["Series2"].Points.AddXY("11월", "10");
            chart2.Series["Series2"].Points.AddXY("12월", "50");
            pn3.Controls.Add(chart2);

            hashtable = new Hashtable();
            hashtable.Add("color", Color.WhiteSmoke);
            hashtable.Add("name", "listView");
            hashtable.Add("click", (MouseEventHandler)listView_click);
            lv = cmm.getListView(hashtable, pn2);
            lv.Columns.Add("월");
            lv.Columns.Add("매출액");
            
        }

        private void listView_click(object sender, MouseEventArgs e)
        {
        }
    }
}

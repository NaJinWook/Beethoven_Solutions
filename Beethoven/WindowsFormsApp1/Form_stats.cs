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
            this.BackgroundImage = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("Sky");

            hashtable = new Hashtable();
            hashtable.Add("size",new Size(1461,630));
            hashtable.Add("point", new Point(20,25));
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
            int[] arrData = { 400, 200, 300, 100 };
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
        }

        private void listView_click(object sender, MouseEventArgs e)
        {
        }
    }
}

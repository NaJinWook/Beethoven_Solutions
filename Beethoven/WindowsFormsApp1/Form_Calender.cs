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
    public partial class Form_Calender : Form
    {
        Commons cmm = new Commons();
        Hashtable hashtable = new Hashtable();
        TextBox tb1;
        Button btn1, btn2, btn3, btn4, btn5;
        Label lb1;
        DateTime startDate;
        Form reg = new Form_register();
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        public Form_Calender()
        {
            InitializeComponent();
            Load += Form_Calender_Load;
            ClientSize = new Size(600, 400);
            this.MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "회원기간 등록창";
            this.BackColor = Color.White;
        }

        private void Form_Calender_Load(object sender, EventArgs e)
        {
            Calender();
            Textbox();
            Label();
            Button();
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
        }

        private void Calender()
        {
            // Create the calendar.
            monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            // Set the calendar location.
            monthCalendar1.Location = new System.Drawing.Point(320, 50);
            
            Controls.Add(this.monthCalendar1);

        }

        private void Textbox()
        {
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(100, 70));
            hashtable.Add("width", "100");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb1");
            hashtable.Add("enabled", true);
            tb1 = cmm.getTextBox(hashtable, this);
        }
        
        private void Label()
        {
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(50, 30));
            hashtable.Add("point", new Point(40, 70));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb1");
            hashtable.Add("text", "시작일");
            lb1 = cmm.getLabel(hashtable, this);
        }


        private void Button()
        {
            
            
            
            
            /*         1개월          */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(80, 50));
            hashtable.Add("point", new Point(20, 100));
            hashtable.Add("color", Color.Silver);
            hashtable.Add("name", "btn1");
            hashtable.Add("text", "1개월");
            //hashtable.Add("click", (EventHandler)btn_calendar);
            btn1 = cmm.getButton(hashtable, this);
            
            
            
            ///*         3개월          */
            //hashtable = new Hashtable();
            //hashtable.Add("size", new Size(80, 50));
            //hashtable.Add("point", new Point(120, 100));
            //hashtable.Add("color", Color.Silver);
            //hashtable.Add("name", "btn2");
            //hashtable.Add("text", "3개월");
            ////hashtable.Add("click", (EventHandler)btn_calendar);
            //btn2 = cmm.getButton(hashtable, this);
            ///*         6개월          */
            //hashtable = new Hashtable();
            //hashtable.Add("size", new Size(80, 50));
            //hashtable.Add("point", new Point(20, 170));
            //hashtable.Add("color", Color.Silver);
            //hashtable.Add("name", "btn3");
            //hashtable.Add("text", "6개월");
            ////hashtable.Add("click", (EventHandler)btn_calendar);
            //btn3 = cmm.getButton(hashtable, this);
            ///*         12개월          */
            //hashtable = new Hashtable();
            //hashtable.Add("size", new Size(80, 50));
            //hashtable.Add("point", new Point(120, 170));
            //hashtable.Add("color", Color.Silver);
            //hashtable.Add("name", "btn4");
            //hashtable.Add("text", "12개월");
            ////hashtable.Add("click", (EventHandler)btn_calendar);
            //btn4 = cmm.getButton(hashtable, this);
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            startDate = (DateTime)monthCalendar1.SelectionRange.Start;
            tb1.Text = startDate.ToShortDateString();
            tb1.ReadOnly = true;
        }
        //private void btn_calendar(object o, EventArgs a)
        //{
        //    this.Visible = false;


        //}
    }
}

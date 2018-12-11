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
    public partial class Form_register : Form
    {
        ob_Set os = new ob_Set();
        ArrayList arr = new ArrayList();
        Panel pnl = new Panel();
        Hashtable hashtable = new Hashtable();
        Label lb1;
        Commons cmm = new Commons();
        TextBox tb1, tb2, tb3, tb4, tb5, tb6;
        Button btn1, btn2, btn3, btn4, btn5;

        public Form_register()
        {
            InitializeComponent();
            Load += Form_register_Load;
        }

        private void Form_register_Load(object sender, EventArgs e)
        {
            // this.BackgroundImage = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("Sky");

            arr.Add(new ob_Pnl(this, "", "", 1461, 633, 20, 24));

            pnl = os.Pnl((ob_Pnl)arr[0]);

            Controls.Add(pnl);
            option();

            Label();
            Textbox();



        }

        private void option()
        {
            pnl.BackColor = Color.White;
        }

        private void Label()
        {
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(50, 50));
            hashtable.Add("point", new Point(130, 50));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb1");
            hashtable.Add("text", "이름");
            lb1 = cmm.getLabel(hashtable, pnl);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(50, 50));
            hashtable.Add("point", new Point(130, 110));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb2");
            hashtable.Add("text", "나이");
            lb1 = cmm.getLabel(hashtable, pnl);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(60, 60));
            hashtable.Add("point", new Point(130, 170));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb3");
            hashtable.Add("text", "전화번호");
            lb1 = cmm.getLabel(hashtable, pnl);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(50, 50));
            hashtable.Add("point", new Point(130, 230));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb4");
            hashtable.Add("text", "주소");
            lb1 = cmm.getLabel(hashtable, pnl);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(50, 50));
            hashtable.Add("point", new Point(130, 290));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb5");
            hashtable.Add("text", "성별");
            lb1 = cmm.getLabel(hashtable, pnl);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(50, 50));
            hashtable.Add("point", new Point(130, 350));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb6");
            hashtable.Add("text", "라커/옷");
            lb1 = cmm.getLabel(hashtable, pnl);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(50, 50));
            hashtable.Add("point", new Point(520, 350));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb7");
            hashtable.Add("text", "기간");
            lb1 = cmm.getLabel(hashtable, pnl);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(30, 30));
            hashtable.Add("point", new Point(760, 350));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "lb7");
            hashtable.Add("text", "~");
            lb1 = cmm.getLabel(hashtable, pnl);
        }

        private void Textbox()
        {
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(200, 50));
            hashtable.Add("width", "300");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb1");
            hashtable.Add("enabled", true);
            tb1 = cmm.getTextBox(hashtable, pnl);


            hashtable = new Hashtable();
            hashtable.Add("point", new Point(200, 110));
            hashtable.Add("width", "300");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb2");
            hashtable.Add("enabled", true);
            tb2 = cmm.getTextBox(hashtable, pnl);

            hashtable = new Hashtable();
            hashtable.Add("point", new Point(200, 170));
            hashtable.Add("width", "300");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb3");
            hashtable.Add("enabled", true);
            tb3 = cmm.getTextBox(hashtable, pnl);

            hashtable = new Hashtable();
            hashtable.Add("point", new Point(200, 230));
            hashtable.Add("width", "300");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb4");
            hashtable.Add("enabled", true);
            tb4 = cmm.getTextBox(hashtable, pnl);


            hashtable = new Hashtable();
            hashtable.Add("point", new Point(640, 350));
            hashtable.Add("width", "100");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb5");
            hashtable.Add("enabled", true);
            tb5 = cmm.getTextBox(hashtable, pnl);

            hashtable = new Hashtable();
            hashtable.Add("point", new Point(800, 350));
            hashtable.Add("width", "100");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb6");
            hashtable.Add("enabled", true);
            tb6 = cmm.getTextBox(hashtable, pnl);
        }

        private void Button()
        {

        }






    }
}

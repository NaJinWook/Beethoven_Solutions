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
    public partial class Form_User : Form
    {
        Hashtable hashtable = new Hashtable();
        Commons cmm = new Commons();
        Label lb1, lb2;
        Button btn1, btn2, btn3, btn4;
        public TextBox tb1, tb2;
        public Form_User()
        {
            InitializeComponent();
            Load += Form_User_Load;
        }

        private void Form_User_Load(object sender, EventArgs e)
        {
            Label();
            Textbox();
            Button();
        }
        private void Label()
        {
            /*       회원번호부분         */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(75, 30));
            hashtable.Add("point", new Point(50, 50));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb1");
            hashtable.Add("text", "회원번호");
            lb1 = cmm.getLabel(hashtable, this);
            lb1.ForeColor = Color.Black;
            lb1.BackColor = Color.Gray;
            lb1.Font = new Font("맑은 고딕", 12, FontStyle.Bold);

            /*       몸무게부분         */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(75, 30));
            hashtable.Add("point", new Point(50, 100));
            hashtable.Add("color", Color.Black);
            hashtable.Add("name", "lb1");
            hashtable.Add("text", "몸무게");
            lb1 = cmm.getLabel(hashtable, this);
            lb1.ForeColor = Color.Black;
            lb1.BackColor = Color.Gray;
            lb1.Font = new Font("맑은 고딕", 15, FontStyle.Bold);
        }

        private void Textbox()
        {
            /*       회원번호검색       */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(130, 50));
            hashtable.Add("width", "50");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb1");
            hashtable.Add("enabled", true);
            tb1 = cmm.getTextBox(hashtable, this);
            tb1.Font = new Font("맑은 고딕", 14, FontStyle.Regular);
            /*       몸무게등록       */
            hashtable = new Hashtable();
            hashtable.Add("point", new Point(130, 100));
            hashtable.Add("width", "50");
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "tb2");
            hashtable.Add("enabled", true);
            tb2 = cmm.getTextBox(hashtable, this);
            tb2.Font = new Font("맑은 고딕", 14, FontStyle.Regular);
        }
        private void Button()
        {
            /*    검색부분     */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(50, 40));
            hashtable.Add("point", new Point(185, 46));
            hashtable.Add("color", Color.Yellow);
            hashtable.Add("name", "btn1");
            hashtable.Add("text", "검색");
            //hashtable.Add("click", (EventHandler)btn_calendar);
            btn1 = cmm.getButton(hashtable, this);

            /*    등록부분     */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(50, 40));
            hashtable.Add("point", new Point(185, 97));
            hashtable.Add("color", Color.Yellow);
            hashtable.Add("name", "btn2");
            hashtable.Add("text", "등록");
            //hashtable.Add("click", (EventHandler)btn_click);
            btn2 = cmm.getButton(hashtable, this);

            /*    그래프부분     */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(50, 40));
            hashtable.Add("point", new Point(235, 97));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn3");
            hashtable.Add("text", "그래프");
            //hashtable.Add("click", (EventHandler)btn_register);
            btn3 = cmm.getButton(hashtable, this);


        }
    }
}

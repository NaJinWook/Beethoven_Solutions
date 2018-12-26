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

namespace WindowsFormsApp1.NewFolder1
{
    public partial class Form_select : Form
    {
        Button btn1, btn2;
        Hashtable hashtable = new Hashtable();
        Commons cmm = new Commons();
        public Form_select()
        {
            InitializeComponent();
            Load += Form_select_Load;
        }

        private void Form_select_Load(object sender, EventArgs e)
        {
            Button();
        }

        private void Button()
        {
            /*    회원부분     */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(80, 80));
            hashtable.Add("point", new Point(30, 50));
            hashtable.Add("color", Color.Yellow);
            hashtable.Add("name", "btn1");
            hashtable.Add("text", "회원");
            hashtable.Add("click", (EventHandler)btn_select);
            btn1 = cmm.getButton(hashtable, this);

            /*    관리자부분     */
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(80, 80));
            hashtable.Add("point", new Point(150, 50));
            hashtable.Add("color", Color.Yellow);
            hashtable.Add("name", "btn2");
            hashtable.Add("text", "관리자");
            hashtable.Add("click", (EventHandler)btn_select);
            btn2 = cmm.getButton(hashtable, this);
        }

        private void btn_select(object o, EventArgs e)
        {
            Button btn = (Button)o;

            switch (btn.Name)
            {
                case"btn1":
                    Form_User user = new Form_User();
                    this.Visible = false;
                    user.Show();
                    break;

                case "btn2":
                    Form_login log = new Form_login();
                    this.Visible = false;
                    log.Show();
                    break;
            }
        }
    }
}
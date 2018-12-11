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
    public partial class Form_main : Form
    {
        ob_Set os = new ob_Set();
        ArrayList arr = new ArrayList();
        Panel menu_pnl = new Panel();
        Panel mdi_pnl = new Panel();
        Panel total_pnl = new Panel();
        Button main_btn = new Button();
        Button view_all = new Button();
        Button register = new Button();
        Button locker = new Button();
        Button money = new Button();
        PictureBox logo = new PictureBox();
        Button logout = new Button();
        Label realtime = new Label();
        Button menu_btn;
        PictureBox bg = new PictureBox();
        Label start = new Label();
        Form close;

        public Form_main()
        {
            InitializeComponent();
            Load += Form_main_Load;
            ClientSize = new Size(1500, 800);
            this.MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Beethoven Management System ver 0.1";
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;

            logo.Image = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("goodee_logo");
            logo.SizeMode = PictureBoxSizeMode.StretchImage;
            logo.Size = new Size(282, 100);
            logo.Location = new Point(1015, 0);

            bg.Image = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("bg2");
            bg.SizeMode = PictureBoxSizeMode.StretchImage;
            bg.Size = new Size(1461, 633);
            bg.Location = new Point(20, 24);

            arr.Add(new ob_Pnl(this, "", "", 1500, 100, 0, 0));
            arr.Add(new ob_Pnl(this, "", "", 1500, 675, 0, 95));
            arr.Add(new ob_Btn(this, "logout", "로그아웃", 200, 100, 1300, 0));
            arr.Add(new ob_Lbl(this, "", "안녕하세요", 300, 300, 20, 24));
            arr.Add(new ob_Pnl(this, "", "", 1500, 30, 0, 770));

            menu_pnl = os.Pnl((ob_Pnl)arr[0]);
            mdi_pnl = os.Pnl((ob_Pnl)arr[1]);
            logout = os.Btn((ob_Btn)arr[2]);
            logout.Click += Logout_Click;
            logout.MouseHover += Logout_MouseHover;
            logout.MouseLeave += Logout_MouseLeave;
            logout.Cursor = Cursors.Hand;
            start = os.Lbl((ob_Lbl)arr[3]);
            total_pnl = os.Pnl((ob_Pnl)arr[4]);

            Controls.Add(menu_pnl);
            Controls.Add(total_pnl);
            mdi_pnl.Controls.Add(bg);
            mdi_pnl.Controls.Add(start);
            menu_pnl.Controls.Add(logo);
            menu_pnl.Controls.Add(logout);
            Controls.Add(mdi_pnl);


            for (int i = 0; i < 5; i++)
            {
                menu_btn = new Button();
                menu_btn.Size = new Size(200, 100);
                menu_btn.Location = new Point((203 * i) + 0, 0);
                menu_btn.BackgroundImage = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("Titanium");
                menu_btn.ForeColor = Color.White;
                menu_btn.Name = string.Format("btn{0}", i + 1);
                menu_btn.TabStop = false; // 탭방지
                menu_btn.FlatStyle = FlatStyle.Flat; // 테두리 제거
                menu_btn.FlatAppearance.BorderSize = 0; // 테두리 제거
                menu_pnl.Controls.Add(menu_btn);
                menu_btn.Click += Menu_btn_Click;
                menu_btn.MouseHover += Menu_btn_MouseHover;
                menu_btn.MouseLeave += Menu_btn_MouseLeave;
                menu_btn.Cursor = Cursors.Hand;

                if (menu_btn.Name == "btn1")
                {
                    menu_btn.Text = "회원 목록";
                }
                else if (menu_btn.Name == "btn2")
                {
                    menu_btn.Text = "회원 등록";
                }
                else if (menu_btn.Name == "btn3")
                {
                    menu_btn.Text = "정보 추가";
                }
                else if (menu_btn.Name == "btn4")
                {
                    menu_btn.Text = "도구 관리";
                }
                else if (menu_btn.Name == "btn5")
                {
                    menu_btn.Text = "통계 정보";
                }
            }
            option();
        }

        private void Logout_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            logout.BackgroundImage = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("VeryBlue");
        }

        private void Logout_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            logout.BackgroundImage = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("Sherbert");
        }

        private void Menu_btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("Titanium");

        }

        private void Menu_btn_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("SolidVault");

        }

        private void option()
        {
            menu_pnl.BackgroundImage = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("Sky");
            mdi_pnl.BackgroundImage = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("Sky");
            total_pnl.BackgroundImage = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("Royal");
            logout.FlatStyle = FlatStyle.Flat; // 테두리 제거
            logout.FlatAppearance.BorderSize = 0; // 테두리 제거
            logout.BackgroundImage = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("VeryBlue");
            logout.ForeColor = Color.White;
            logout.TabStop = false; // 탭방지
            logout.FlatStyle = FlatStyle.Flat; // 테두리 제거
            logout.FlatAppearance.BorderSize = 0; // 테두리 제거
            logout.Font = new Font(FontFamily.GenericSerif, 30, FontStyle.Bold);
            start.ForeColor = Color.White;
            start.Font = new Font(FontFamily.GenericSerif, 30, FontStyle.Bold);
            start.Parent = bg;
            start.BackColor = Color.Transparent;
            total_pnl.BackColor = Color.DarkGray;
        }

        private void Menu_btn_Click(object sender, EventArgs e)
        {
            if (close != null) close.Dispose();

            menu_btn = (Button)sender;
            if (menu_btn.Name == "btn1") close = new Form_member();
            else if (menu_btn.Name == "btn2") close = new Form_register();

            else if (menu_btn.Name == "btn5") close = new Form_stats();

            close.WindowState = FormWindowState.Maximized;
            close.FormBorderStyle = FormBorderStyle.None;
            close.MdiParent = this;
            close.Dock = DockStyle.Fill;
            mdi_pnl.Controls.Add(close);
            close.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Form_login login = new Form_login();
            login.Visible = true;
            this.Close();
        }
    }
}

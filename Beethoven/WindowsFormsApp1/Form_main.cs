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
        Panel time_pnl = new Panel();
        Panel time_pnl2 = new Panel();
        Label date = new Label();
        Label time = new Label();
        Timer mTimer;
        Form close;


        public Form_main()
        {
            InitializeComponent();
            Load += Form_main_Load;
            ClientSize = new Size(1500, 772);
            Control_Init();
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

            
            bg.SizeMode = PictureBoxSizeMode.StretchImage;
            bg.Size = new Size(1461, 633);
            bg.Location = new Point(20, 24);

            arr.Add(new ob_Pnl(this, "", "", 1500, 100, 0, 0));
            arr.Add(new ob_Pnl(this, "", "", 1500, 677, 0, 95));
            arr.Add(new ob_Pnl(this, "", "", 200, 200, 813, 0));
            arr.Add(new ob_Pnl(this, "", "", 190, 90, 5, 5));
            arr.Add(new ob_Lbl(this, "", "", 200, 200, 3, 5));
            arr.Add(new ob_Lbl(this, "", "", 200, 200, -3, 35));
            arr.Add(new ob_Btn(this, "logout", "로그아웃", 200, 100, 1300, 0));
            //arr.Add(new ob_Lbl(this, "", "안녕하세요", 300, 300, 20, 24));

            menu_pnl = os.Pnl((ob_Pnl)arr[0]);
            mdi_pnl = os.Pnl((ob_Pnl)arr[1]);
            time_pnl = os.Pnl((ob_Pnl)arr[2]);
            time_pnl2 = os.Pnl((ob_Pnl)arr[3]);
            time = os.Lbl((ob_Lbl)arr[4]);
            date = os.Lbl((ob_Lbl)arr[5]);
            logout = os.Btn((ob_Btn)arr[6]);
            logout.Click += Logout_Click;
            logout.Cursor = Cursors.Hand;
            //start = os.Lbl((ob_Lbl)arr[7]);

            Controls.Add(menu_pnl);

            mdi_pnl.Controls.Add(bg);
            mdi_pnl.Controls.Add(start);
            menu_pnl.Controls.Add(logo);
            menu_pnl.Controls.Add(time_pnl);
            time_pnl.Controls.Add(time_pnl2);
            time_pnl2.Controls.Add(date);
            time_pnl2.Controls.Add(time);

            menu_pnl.Controls.Add(logout);
            Controls.Add(mdi_pnl);


            for (int i = 0; i < 4; i++)
            {
                menu_btn = new Button();
                menu_btn.Size = new Size(200, 100);
                menu_btn.Location = new Point((203 * i) + 0, 0);
                menu_btn.BackColor = Color.FromArgb(200, 100, 130, 200);
                menu_btn.ForeColor = Color.White;
                menu_btn.Font = new Font("휴먼편지체", 30, FontStyle.Bold);
                menu_btn.Name = string.Format("btn{0}", i + 1);
                menu_btn.TabStop = false; // 탭방지
                menu_btn.FlatStyle = FlatStyle.Flat; // 테두리 제거
                menu_btn.FlatAppearance.BorderSize = 0; // 테두리 제거
                menu_pnl.Controls.Add(menu_btn);
                menu_btn.Click += Menu_btn_Click;
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
                    menu_btn.Text = "기구 관리";
                }
                else if (menu_btn.Name == "btn4")
                {
                    menu_btn.Text = "통계 정보";
                }
            }
            option();
        }

        private void option()
        {
            menu_pnl.BackColor = Color.FromArgb(13, 49, 123);
            mdi_pnl.BackColor = Color.FromArgb(13, 49, 123);
            logout.FlatStyle = FlatStyle.Flat; // 테두리 제거
            logout.FlatAppearance.BorderSize = 0; // 테두리 제거
            logout.BackColor = Color.FromArgb(5, 68, 173);
            logout.ForeColor = Color.White;
            logout.TabStop = false; // 탭방지
            logout.FlatStyle = FlatStyle.Flat; // 테두리 제거
            logout.FlatAppearance.BorderSize = 0; // 테두리 제거
            logout.Font = new Font("휴먼편지체", 30, FontStyle.Bold);
            start.ForeColor = Color.Black;
            start.Font = new Font("휴먼편지체", 30, FontStyle.Bold);
            start.Parent = bg;
            start.BackColor = Color.Transparent;
            time_pnl.BackColor = Color.FromArgb(9, 31, 79);
            time_pnl2.BackColor = Color.FromArgb(30, 100, 130, 20);
        }

        private void Control_Init()
        {
            mTimer = new Timer();
            mTimer.Tick += MTimer_Tick;
            mTimer.Start();
        }

        private void MTimer_Tick(object sender, EventArgs e)
        {
            time.Text = string.Format("{0:yyyy.MM.dd(ddd)}", DateTime.Now);
            time.ForeColor = Color.White;
            time.BackColor = Color.Transparent;
            time.Font = new Font("휴면둥근헤드라인", 19, FontStyle.Bold);
            date.Text = string.Format("{0:HH:mm:ss}", DateTime.Now);
            date.ForeColor = Color.White;
            date.BackColor = Color.Transparent;
            date.Font = new Font("휴면둥근헤드라인", 33, FontStyle.Bold);
        }

        private void Menu_btn_Click(object sender, EventArgs e)
        {
            if (close != null) close.Dispose();

            menu_btn = (Button)sender;
            if (menu_btn.Name == "btn1") close = new Form_member();
            else if (menu_btn.Name == "btn2") close = new Form_register();

            else if (menu_btn.Name == "btn5") close = new Form_stats();

            close.WindowState = FormWindowState.Maximized;
            //close.FormBorderStyle = FormBorderStyle.None;
            close.MdiParent = this;
            close.Dock = DockStyle.Fill;
            mdi_pnl.Controls.Add(close);
            close.Show();
            //    menu_btn = (Button)sender;
            //    switch (menu_btn.Name)
            //    {
            //        case "btn1":
            //            Form_member fm = new Form_member();
            //            fm.MdiParent = this;
            //            fm.WindowState = FormWindowState.Maximized;
            //            fm.FormBorderStyle = FormBorderStyle.None;
            //            mdi_pnl.Controls.Add(fm);
            //            fm.Show();
            //            break;
            //    }
            }

            private void Logout_Click(object sender, EventArgs e)
        {
            Form_login login = new Form_login();
            login.Visible = true;
            this.Close();
        }
    }
}

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

    public partial class Form_login : Form
    {
        private static string pwd = "1234"; // 관리자 로그인 비밀번호
        ob_Set os = new ob_Set();
        ArrayList arr = new ArrayList();
        Label BMS_lbl = new Label();
        PictureBox logo = new PictureBox();
        Label call_lbl = new Label();
        Panel pnl = new Panel();
        Label pw_lbl = new Label();
        TextBox pw_input = new TextBox();
        Button num_btn = new Button();

        public Form_login()
        {
            InitializeComponent();
            Load += Form_login_Load;
            ClientSize = new Size(600, 400);
            this.BackgroundImage = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("bg2");
            this.MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Beethoven Management System ver 0.1";
        }

        private void Form_login_Load(object sender, EventArgs e)
        {
            logo.Image = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("btv_logo");
            logo.SizeMode = PictureBoxSizeMode.StretchImage;
            logo.BackColor = Color.Transparent;
            logo.Size = new Size(250, 250);
            logo.Location = new Point(20, 70);

            arr.Add(new ob_Lbl(this, "", "BMS Solutions", 290, 60, 10, 10));
            arr.Add(new ob_Lbl(this, "", "프로그램 문의 전화) 010-1234-5678", 280, 50, 10, 330));
            arr.Add(new ob_Pnl(this, "", "", 280, 360, 300, 20));
            arr.Add(new ob_Lbl(this, "", "비밀번호를 입력해주세요.", 280, 30, 23, 5));
            arr.Add(new ob_Tbx(this, "", "", 240, 100, 20, 35));

            BMS_lbl = os.Lbl((ob_Lbl)arr[0]);
            call_lbl = os.Lbl((ob_Lbl)arr[1]);
            pnl = os.Pnl((ob_Pnl)arr[2]);
            pw_lbl = os.Lbl((ob_Lbl)arr[3]);
            pw_input = os.Tbx((ob_Tbx)arr[4]);
            // 버튼 이벤트

            Controls.Add(BMS_lbl);
            Controls.Add(logo);
            Controls.Add(call_lbl);
            Controls.Add(pnl);
            pnl.Controls.Add(pw_lbl);
            pnl.Controls.Add(pw_input);

            int count = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button num_btn = new Button();
                    num_btn.Size = new Size(60, 60);
                    num_btn.Location = new Point((70 * j) + 38, (70 * i) + 80);
                    num_btn.Name = string.Format("btn{0}", count++);
                    num_btn.Font = new Font("휴먼옛체", 15, FontStyle.Bold);
                    num_btn.ForeColor = Color.White;
                    num_btn.TabStop = false; // 탭방지
                    num_btn.FlatStyle = FlatStyle.Flat; // 테두리 제거
                    num_btn.FlatAppearance.BorderSize = 0; // 테두리 제거
                    num_btn.BackColor = Color.FromArgb(200, 100, 130, 200);
                    pnl.Controls.Add(num_btn);
                    num_btn.Click += Btn_Click;

                    for (int k = 1; k <= 9; k++)
                    {
                        if (num_btn.Name == string.Format("btn{0}", k))
                        {
                            num_btn.Text = string.Format("{0}", k);
                        }
                    }
                    if (num_btn.Name == "btn10")
                    {
                        num_btn.Text = "확인";
                    }
                    else if (num_btn.Name == "btn11")
                    {
                        num_btn.Text = "0";
                    }
                    else if (num_btn.Name == "btn12")
                    {
                        num_btn.Text = "←";
                    }
                }
            }
            option();
        }

        private void option()
        {
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BMS_lbl.Font = new Font("Sitka Small", 25, FontStyle.Bold);
            BMS_lbl.ForeColor = Color.White;
            BMS_lbl.BackColor = Color.Transparent;
            call_lbl.Font = new Font("나눔 고딕", 15, FontStyle.Bold);
            call_lbl.ForeColor = Color.White;
            call_lbl.BackColor = Color.Transparent;
            pnl.BackColor = Color.FromArgb(220, 9, 29, 81);
            pw_lbl.Font = new Font("나눔 고딕", 18, FontStyle.Bold);
            pw_lbl.ForeColor = Color.White;
            pw_lbl.BackColor = Color.Transparent;
            pw_input.Font = new Font("나눔 고딕", 20, FontStyle.Regular);
            pw_input.PasswordChar = '●';
            pw_input.Enabled = false;
            pw_input.BackColor = Color.White;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            num_btn = (Button)sender;
            Label result = new Label();
            if (num_btn.Name != "btn10" && num_btn.Name != "btn12")
            {
                if (pw_input.TextLength < 4)
                {
                    result.Text = num_btn.Text;
                    pw_input.Text += result.Text;
                }
            }

            else if (num_btn.Name == "btn10" && pw_input.Text == pwd)
            {
                pw_input.Text = "";
                Form_main main = new Form_main();
                this.Visible = false;
                main.Show();
            }
            else if (num_btn.Name == "btn10" && pw_input.Text != pwd) MessageBox.Show("비밀번호를 잘못 입력하셨습니다.", "로그인 실패");

            else if (num_btn.Name == "btn12")
            {
                if (pw_input.Text == "")
                {
                    pw_input.Text = "";
                }
                else
                {
                    pw_input.Text = pw_input.Text.Substring(0, pw_input.Text.Length - 1);
                }
            }
        }

    }
}
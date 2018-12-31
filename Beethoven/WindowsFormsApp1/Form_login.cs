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
using System.Drawing.Text;

namespace WindowsFormsApp1
{

    public partial class Form_login : Form
    {
        private static string pwd = "1234"; // 관리자 로그인 비밀번호
        ob_Set os = new ob_Set();
        ArrayList arr = new ArrayList();
        PictureBox logo = new PictureBox();
        PrivateFontCollection ft1, ft2;
        Font font1, font2;
        Panel pnl;
        Label pw_lbl;
        TextBox pw_input;
        Button num_btn;

        public Form_login()
        {
            InitializeComponent();
            Load += Form_login_Load;
            ClientSize = new Size(685, 748);
            this.BackgroundImage = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("login_background");
            this.MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Beethoven Management System ver 1.04";  
        }

        private void Form_login_Load(object sender, EventArgs e)
        {
            fonts();
            arr.Add(new ob_Pnl(this, "", "", 290, 385, 375, 315));
            arr.Add(new ob_Lbl(this, "", "비밀번호를 입력해주세요.", 280, 30, 23, 5));
            arr.Add(new ob_Tbx(this, "", "", 240, 100, 25, 42));

            pnl = os.Pnl((ob_Pnl)arr[0]);
            pw_lbl = os.Lbl((ob_Lbl)arr[1]);
            pw_input = os.Tbx((ob_Tbx)arr[2]);

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
                    num_btn.Location = new Point((70 * j) + 44, (70 * i) + 95);
                    num_btn.Name = string.Format("btn{0}", count++);
                    num_btn.ForeColor = Color.White;
                    num_btn.TabStop = false; // 탭방지
                    num_btn.FlatStyle = FlatStyle.Flat; // 테두리 제거
                    num_btn.FlatAppearance.BorderSize = 0; // 테두리 제거
                    num_btn.BackColor = Color.Black;
                    pnl.Controls.Add(num_btn);
                    num_btn.Click += Btn_Click;
                    num_btn.Font = font1;

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
            pnl.BackColor = Color.FromArgb(255 ,45, 35, 155);
            pw_lbl.Font = font2;
            pw_lbl.ForeColor = Color.White;
            pw_lbl.BackColor = Color.Transparent;
            pw_input.Font = new Font("나눔 고딕", 20, FontStyle.Bold);
            pw_input.PasswordChar = '●';
            pw_input.Enabled = false;
            pw_input.BackColor = Color.White;

        }

        private void fonts()
        {
            ft1 = new PrivateFontCollection();
            ft2 = new PrivateFontCollection();

            ft1.AddFontFile("Font\\HANYGO250.ttf");
            ft2.AddFontFile("Font\\HANYGO230.ttf");

            font1 = new Font(ft1.Families[0], 15);
            font2 = new Font(ft2.Families[0], 16);

            
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
                Form_main main = new Form_main(this);
                main.StartPosition = FormStartPosition.CenterParent;
                this.Visible = false;
                main.Show();
            }
            else if (num_btn.Name == "btn10" && pw_input.Text != pwd && pw_input.Text != "")
            {
                MessageBox.Show("비밀번호를 잘못 입력하셨습니다.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(num_btn.Name == "btn10" && pw_input.Text == "")
            {
                MessageBox.Show("비밀번호를 입력해주세요.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
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
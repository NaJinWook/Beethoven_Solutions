using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form_member : Form
    {
        private MYsql db = new MYsql();
        ob_Set os = new ob_Set();
        ArrayList arr = new ArrayList();
        Hashtable hashtable = new Hashtable();
        Commons cmm = new Commons();
        ListView lv = new ListView();
        Panel main_pnl, mdi_pnl, pnl1, pnl2;
        PrivateFontCollection ft1, ft2;
        Font font1, font2;
        Button btn1, btn2;
        TextBox tb1;
        ComboBox cb1;
        Form fr;
        Form_main fm;
        private Panel panel;
        private string printAll = "select mNo,mName,Age,Sex,phone,address,locker, case when DATEDIFF(mEnd, now()) < 0 then '기간 만료' else DATEDIFF(mEnd, now()) end from member;";

        public Form_member()
        {
            InitializeComponent();
            Load += Form_member_Load;
        }

        public Form_member(Form_main fm, Panel mdi_pnl)
        {
            InitializeComponent();
            Load += Form_member_Load;
            this.fm = fm;
            this.mdi_pnl = mdi_pnl;
        }

        private void Form_member_Load(object sender, EventArgs e)
        {
            fonts();
            arr.Add(new ob_Pnl(this, "", "", 1441, 613, 10, 10));
            arr.Add(new ob_Pnl(this, "", "", 1441, 562, 0, 54));
            arr.Add(new ob_Pnl(this, "", "", 1441, 50, 0, 0));
            arr.Add(new ob_Tbx(this, "", "", 960, 20, 110, 8));
            arr.Add(new ob_Btn(this, "btn1", "검색", 175, 40, 1080, 5));
            arr.Add(new ob_Btn(this, "btn2", "전체보기", 175, 40, 1260, 5));

            main_pnl = os.Pnl((ob_Pnl)arr[0]);
            pnl1 = os.Pnl((ob_Pnl)arr[1]);
            pnl2 = os.Pnl((ob_Pnl)arr[2]);
            tb1 = os.Tbx((ob_Tbx)arr[3]);
            btn1 = os.Btn((ob_Btn)arr[4]);
            btn2 = os.Btn((ob_Btn)arr[5]);

            Controls.Add(main_pnl);
            main_pnl.Controls.Add(pnl1);
            main_pnl.Controls.Add(pnl2);
            pnl2.Controls.Add(tb1);//검색 텍스트박스
            pnl2.Controls.Add(btn1);//검색 버튼
            pnl2.Controls.Add(btn2);
            btn1.Click += search;
            btn2.Click += All_view;


            option();
            hashtable = new Hashtable();
            hashtable.Add("width", "90");
            hashtable.Add("point", new Point(10, 8));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "선택");
            hashtable.Add("text", "이름");
            hashtable.Add("value", "이름");
            hashtable.Add("key", "1");
            cb1 = cmm.getComboBox(hashtable, pnl2);
            cb1.Items.Add("이름");
            cb1.Items.Add("회원번호");
            cb1.Items.Add("전화번호");

            cb1.Font = font1;
            cb1.DropDownStyle = ComboBoxStyle.DropDownList; // 콤보박스 변경 방지

            hashtable = new Hashtable();
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "listView");
            hashtable.Add("double_click", (MouseEventHandler)listView_click);
            lv.FullRowSelect = true;
            lv.Dock = DockStyle.Fill;
            lv.View = View.Details;
            lv = cmm.getListView2(hashtable, pnl1);
            lv.ColumnClick += Lv_ColumnClick;
            lv.ColumnWidthChanging += Lv_ColumnWidthChanging;
            lv.Font = font1;
            Select(printAll);
        }

        /*               리스트뷰 컬럼 클릭 이벤트                   */
        private void Lv_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (this.lv.Sorting == SortOrder.Ascending || lv.Sorting == SortOrder.None)
            {
                this.lv.ListViewItemSorter = new ListViewItemComparer(e.Column, "desc");
                lv.Sorting = SortOrder.Descending;
            }
            else
            {
                this.lv.ListViewItemSorter = new ListViewItemComparer(e.Column, "asc");
                lv.Sorting = SortOrder.Ascending;

            }
            lv.Sort();
        }

        /*              리스트뷰 컬럼 크기 고정                     */
        private void Lv_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = lv.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void listView_click(object o, EventArgs a) // 리스트뷰 더블클릭 이벤트
        {
            ListView lv = (ListView)o;

            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;
            ListViewItem item = itemGroup[0];

            Member member = new Member();
            member.mNo = item.SubItems[0].Text;
            member.mName = item.SubItems[1].Text;
            member.Age = item.SubItems[2].Text;
            member.Sex = item.SubItems[3].Text;
            member.phone = item.SubItems[4].Text;
            member.address = item.SubItems[5].Text;
            member.locker = item.SubItems[6].Text;

            string sql = string.Format("select delYn from member where mNo = {0};", member.mNo);
            MySqlDataReader sdr = db.Reader(sql);
            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                    if (arr[0] == "Y")
                    {
                        MessageBox.Show("이미 삭제된 컨텐츠입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show(String.Format("{0}님 회원정보를 수정하시겠습니까?", member.mName), "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            this.Visible = false;
                            fr = new Form_register(true, member);
                            fr.WindowState = FormWindowState.Maximized;
                            fr.FormBorderStyle = FormBorderStyle.None;
                            fr.MdiParent = fm;
                            fr.Dock = DockStyle.Fill;
                            mdi_pnl.Controls.Add(fr);
                            fr.FormClosed += fr_FormClosed;
                            fr.Show();
                        }
                    }
                }
            }
            db.ReaderClose(sdr);
            db.ConnectionClose();
        }

        private void fr_FormClosed(object sender, FormClosedEventArgs e) // 레지스터폼이 Close되면 이벤트 발생
        {
            lv.Items.Clear();
            Select(printAll);
            this.Visible = true;
        }

        private void search(object o, EventArgs e)
        {
            if (cb1.Text == "회원번호")
            {
                Select(string.Format("select mNo, mName, Age, Sex, phone, address, locker, case when DATEDIFF(mEnd, now()) < 0 then '기간 만료' else DATEDIFF(mEnd, now()) end from member where mNo like'%{0}%'; ", tb1.Text));
            }
            else if (cb1.Text == "이름")
            {
                Select(string.Format("select mNo, mName, Age, Sex, phone, address, locker, case when DATEDIFF(mEnd, now()) < 0 then '기간 만료' else DATEDIFF(mEnd, now()) end from member where mName like'%{0}%'; ", tb1.Text));
            }
            else if (cb1.Text == "전화번호")
            {
                Select(string.Format("select mNo, mName, Age, Sex, phone, address, locker, case when DATEDIFF(mEnd, now()) < 0 then '기간 만료' else DATEDIFF(mEnd, now()) end from member where phone like'%{0}%'; ", tb1.Text));
            }
            else if (tb1.Text == "")
            {
                lv.Items.Clear();
            }
            else
            {
                Select(string.Format("select mNo, mName, Age, Sex, phone, address, locker, case when DATEDIFF(mEnd, now()) < 0 then '기간 만료' else DATEDIFF(mEnd, now()) end from member where mName like'%{0}%'; ", tb1.Text));
            }
        }

        private void All_view(object o, EventArgs e) // 전체보기 버튼 클릭 이벤트
        {
            Select(printAll);
        }

        private void Select(string sql)
        {
            lv.Clear();
            lv.Columns.Add("번호", 60, HorizontalAlignment.Center);
            lv.Columns.Add("이름", 100, HorizontalAlignment.Center);
            lv.Columns.Add("나이", 80, HorizontalAlignment.Center);
            lv.Columns.Add("성별", 80, HorizontalAlignment.Center);
            lv.Columns.Add("전화번호", 200, HorizontalAlignment.Center);
            lv.Columns.Add("주소", 730, HorizontalAlignment.Center);
            lv.Columns.Add("라커", 80, HorizontalAlignment.Center);
            lv.Columns.Add("잔여일", 107, HorizontalAlignment.Center);

            MySqlDataReader sdr = db.Reader(sql);
            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                }
                lv.Items.Add(new ListViewItem(arr));
            }
            db.ReaderClose(sdr);
        }

        private void locker(string sql)
        {
            MySqlDataReader sdr = db.Reader(sql);
            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                }
            }
            db.ReaderClose(sdr);
            db.ConnectionClose();
        }

        private void fonts()
        {
            ft1 = new PrivateFontCollection();
            ft2 = new PrivateFontCollection();

            ft1.AddFontFile("Font\\HANYGO230.ttf");
            ft2.AddFontFile("Font\\HANYGO250.ttf");

            font1 = new Font(ft1.Families[0], 13);
            font2 = new Font(ft2.Families[0], 50);
        }

        private void option()
        {
            this.BackColor = Color.White;
            main_pnl.BackColor = Color.White;
            pnl2.BackColor = Color.FromArgb(45, 35, 135);
            btn1.BackColor = Color.Black;
            btn1.ForeColor = Color.White;
            btn1.FlatStyle = FlatStyle.Flat; // 테두리 제거
            btn1.FlatAppearance.BorderSize = 0; // 테두리 제거
            btn1.Font = font1;
            btn2.BackColor = Color.Black;
            btn2.ForeColor = Color.White;
            btn2.FlatStyle = FlatStyle.Flat; // 테두리 제거
            btn2.FlatAppearance.BorderSize = 0; // 테두리 제거
            btn2.Font = font1;
            tb1.Font = font1;
        }
    }

    internal class ListViewItemComparer : IComparer // 리스트뷰 컬럼 클릭 정렬 클래스
    {
        private int column;
        private string sort = "asc";

        public ListViewItemComparer()
        {
            column = 0;
        }
        public ListViewItemComparer(int column, string sort)
        {
            this.column = column;
            this.sort = sort;
        }
        public int Compare(object x, object y)
        {
            int chk = 1;
            try
            {
                if (sort == "asc")
                    chk = 1;
                else
                    chk = -1;
                if (Convert.ToInt32(((ListViewItem)x).SubItems[column].Text) > Convert.ToInt32(((ListViewItem)y).SubItems[column].Text))
                    return chk;
                else
                    return -chk;
            }
            catch (Exception)
            {
                if (sort == "asc")
                    return String.Compare(((ListViewItem)x).SubItems[column].Text, ((ListViewItem)y).SubItems[column].Text);
                else
                    return String.Compare(((ListViewItem)y).SubItems[column].Text, ((ListViewItem)x).SubItems[column].Text);
            }
        }
    }
}
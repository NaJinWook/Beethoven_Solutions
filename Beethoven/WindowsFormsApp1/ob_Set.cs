using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class ob_Set
    {
        public Button Btn(ob_Btn oBtn)
        {
            Button btn = new Button();
            btn.DialogResult = DialogResult.OK;
            btn.Name = oBtn.Name;
            btn.Text = oBtn.Text;
            btn.Size = new Size(oBtn.SX,oBtn.SY);
            btn.Location = new Point(oBtn.PX, oBtn.PY);
            return btn;
        }
        public Label Lbl(ob_Lbl oLbl)
        {
            Label lbl = new Label();
            lbl.Name = oLbl.Name;
            lbl.Text = oLbl.Text;
            lbl.Size = new Size(oLbl.SX, oLbl.SY);
            lbl.Location = new Point(oLbl.PX, oLbl.PY);
            return lbl;
        }
        public TextBox Tbx(ob_Tbx oTbx)
        {
            TextBox tbx = new TextBox();
            tbx.Name = oTbx.Name;
            tbx.Text = oTbx.Text;
            tbx.Size = new Size(oTbx.SX, oTbx.SY);
            tbx.Location = new Point(oTbx.PX, oTbx.PY);
            return tbx;
        }
        public ListView Liv(ob_Liv oLiv)
        {
            ListView liv = new ListView();
            liv.Name = oLiv.Name;
            liv.Size = new Size(oLiv.SX, oLiv.SY);
            liv.Location = new Point(oLiv.PX, oLiv.PY);
            return liv;
        }
        public Panel Pnl(ob_Pnl oPnl)
        {
            Panel pnl = new Panel();
            pnl.Name = oPnl.Name;
            pnl.Text = oPnl.Text;
            pnl.Size = new Size(oPnl.SX, oPnl.SY);
            pnl.Location = new Point(oPnl.PX, oPnl.PY);
            return pnl;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class ob_Rdb
    {
        Form form;
        string name, text;
        int sX, sY, pX, pY;

        public ob_Rdb(Form form, string name, string text, int sX, int sY, int pX, int pY)
        {
            this.form = form;
            this.name = name;
            this.text = text;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;

        }
        public Form Form
        {
            get
            {
                return form;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string Text
        {
            get
            {
                return text;
            }
        }
        public int SX
        {
            get
            {
                return sX;
            }
        }
        public int SY
        {
            get
            {
                return sY;
            }
        }
        public int PX
        {
            get
            {
                return pX;
            }
        }
        public int PY
        {
            get
            {
                return pY;
            }
        }
    }
}

﻿using System;
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
    public partial class Form_infoAdd : Form
    {
        ob_Set os = new ob_Set();
        ArrayList arr = new ArrayList();
        Panel pnl = new Panel();

        public Form_infoAdd()
        {
            InitializeComponent();
            Load += Form_infoAdd_Load;
        }

        private void Form_infoAdd_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = (Bitmap)WindowsFormsApp1.Properties.Resources.ResourceManager.GetObject("Sky");
            arr.Add(new ob_Pnl(this, "", "", 1461, 633, 0, 0));

            pnl = os.Pnl((ob_Pnl)arr[0]);

            Controls.Add(pnl);
            option();
        }
        private void option()
        {
            pnl.BackColor = Color.White;
        }
    }
}

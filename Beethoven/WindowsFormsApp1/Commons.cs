using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Commons
    {
        public Form getMdiForm(Form parentForm, Form tagetForm, Control parentDomain)
        {
            tagetForm.MdiParent = parentForm;
            tagetForm.WindowState = FormWindowState.Maximized;
            tagetForm.FormBorderStyle = FormBorderStyle.None;
            tagetForm.Dock = DockStyle.Fill;
            parentDomain.Controls.Add(tagetForm);
            return tagetForm;
        }

        public PictureBox getPictureBox(Hashtable hashtable,Control tergat)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = (Size)hashtable["size"];
            pictureBox.Location = (Point)hashtable["point"];
            pictureBox.SizeMode = (PictureBoxSizeMode)hashtable["pictureboxsizemode"];
            tergat.Controls.Add(pictureBox);
            return pictureBox;
        }

        public Panel getPanel(Hashtable hashtable, Control parentDomain)
        {
            Panel panel = new Panel();
            panel.Size = (Size)hashtable["size"];
            panel.Location = (Point)hashtable["point"];
            panel.BackColor = (Color)hashtable["color"];
            panel.Name = hashtable["name"].ToString();
            parentDomain.Controls.Add(panel);
            return panel;
        }

        public Panel getPanel2(Hashtable hashtable, Form tergat)
        {
            Panel panel = new Panel();
            panel.Size = (Size)hashtable["size"];
            panel.Location = (Point)hashtable["point"];
            panel.BackColor = (Color)hashtable["color"];
            panel.Name = hashtable["name"].ToString();
            tergat.Controls.Add(panel);
            return panel;
        }

        public Label getLabel(Hashtable hashtable, Control parentDomain)
        {
            Label label = new Label();
            label.Size = (Size)hashtable["size"];
            label.Location = (Point)hashtable["point"];
            label.BackColor = (Color)hashtable["color"];
            label.Name = hashtable["name"].ToString();
            label.Text = hashtable["text"].ToString();
            parentDomain.Controls.Add(label);
            return label;
        }

        public Button getButton(Hashtable hashtable, Control parentDomain)
        {
            Button button = new Button();
            button.Size = (Size)hashtable["size"];
            button.Location = (Point)hashtable["point"];
            button.BackColor = (Color)hashtable["color"];
            button.Name = hashtable["name"].ToString();
            button.Text = hashtable["text"].ToString();
            button.Click += (EventHandler)hashtable["click"];
            button.Cursor = Cursors.Hand;
            parentDomain.Controls.Add(button);
            return button;
        }

        public TextBox getTextBox(Hashtable hashtable, Control parentDomain)
        {
            TextBox textBox = new TextBox();
            textBox.Width = Convert.ToInt32(hashtable["width"].ToString());
            textBox.Location = (Point)hashtable["point"];
            textBox.BackColor = (Color)hashtable["color"];
            textBox.Name = hashtable["name"].ToString();
            textBox.Enabled = (bool)hashtable["enabled"];
            parentDomain.Controls.Add(textBox);
            return textBox;
        }

        public ComboBox getComboBox(Hashtable hashtable, Control parentDomain)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Width = Convert.ToInt32(hashtable["width"].ToString());
            comboBox.DropDownWidth = Convert.ToInt32(hashtable["width"].ToString());
            comboBox.Location = (Point)hashtable["point"];
            comboBox.BackColor = (Color)hashtable["color"];
            comboBox.Name = hashtable["name"].ToString();
            comboBox.Text = hashtable["text"].ToString();
            comboBox.DisplayMember = "value";
            comboBox.ValueMember = "Key";
            parentDomain.Controls.Add(comboBox);
            return comboBox;
        }

        public ComboBox getComboBox2(Hashtable hashtable, Form target)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Width = Convert.ToInt32(hashtable["width"].ToString());
            comboBox.DropDownWidth = Convert.ToInt32(hashtable["width"].ToString());
            comboBox.Location = (Point)hashtable["point"];
            comboBox.BackColor = (Color)hashtable["color"];
            comboBox.Name = hashtable["name"].ToString();
            comboBox.DisplayMember = "value";
            comboBox.ValueMember = "Key";
            target.Controls.Add(comboBox);
            return comboBox;
        }

        public ListView getListView(Hashtable hashtable, Control parentDomain)
        {
            ListView listView = new ListView();
            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;
            listView.GridLines = true;
            listView.FullRowSelect = true;
            listView.BackColor = (Color)hashtable["color"];
            listView.Name = hashtable["name"].ToString();
            listView.MouseClick += (MouseEventHandler)hashtable["click"];
            parentDomain.Controls.Add(listView);
            return listView;
        }

        public ListView getListView2(Hashtable hashtable, Control parentDomain)
        {
            ListView listView = new ListView();
            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;
            listView.GridLines = true;
            listView.FullRowSelect = true;
            listView.BackColor = (Color)hashtable["color"];
            listView.Name = hashtable["name"].ToString();
            listView.MouseDoubleClick += (MouseEventHandler)hashtable["double_click"];
            parentDomain.Controls.Add(listView);
            return listView;
        }

        public RadioButton getRadioButton(Hashtable hashtable, Control parentDomain)
        {
            RadioButton RadioButton = new RadioButton();
            RadioButton.Size = (Size)hashtable["size"];
            RadioButton.Location = (Point)hashtable["point"];
            RadioButton.Name = hashtable["name"].ToString();
            RadioButton.Text = hashtable["text"].ToString();
            RadioButton.Click += (EventHandler)hashtable["click"];
            parentDomain.Controls.Add(RadioButton);
            return RadioButton;
        }

    }
}
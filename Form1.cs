using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Image image;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            DialogResult dr = open.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                image = Bitmap.FromFile(open.FileName);
                pictureBox1.Image = image;
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "icon (*.ico)|*.ico|All files (*.*)|*.*";
            DialogResult dr = dialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                Icon myIcon = Icon.FromHandle(((Bitmap)image).GetHicon());
                myIcon.Save(File.Open(dialog.FileName, FileMode.Create));
            }
        }
    }
}

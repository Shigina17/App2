using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App2
{
    public partial class Form2 : Form
    {
        private Form1 f;
        public Form2(Form1 f, bool value) //сопоставить
        {
            InitializeComponent();
            this.f = f;
            rbOn.Checked = value;
            rbOff.Checked = !value;
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            f.Turn(rbOn.Checked);
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

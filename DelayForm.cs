// Author:
//    Evan Olds

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AnimCur
{
    public partial class DelayForm : Form
    {
        public DelayForm()
        {
            InitializeComponent();
        }

        public int DoPrompt()
        {
            if (ShowDialog() != DialogResult.OK)
            {
                return -1;
            }

            return (int)nudANI.Value;
        }

        private void nudANI_ValueChanged(object sender, EventArgs e)
        {
            nudMS.Value = (1000 * nudANI.Value) / 60;
        }

        private void nudMS_ValueChanged(object sender, EventArgs e)
        {
            nudANI.Value = (60 * nudMS.Value) / 1000;
        }
    }
}
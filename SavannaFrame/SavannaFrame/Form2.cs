﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SavannaFrame
{
    public partial class AddFrameFrm : Form
    {
        public AddFrameFrm()
        {
            InitializeComponent();
        }

        public string TextBox
        {
            get { return textBox1.Text; }
        }

        private void btOk_Click(object sender, EventArgs e)
        {

        }
    }
}

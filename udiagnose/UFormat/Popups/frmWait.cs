﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace UDiagnose.Popups
{
    public partial class frmWait : KryptonForm
    {
        public frmWait()
        {
            InitializeComponent();
        }

        private void frmWait_Load(object sender, EventArgs e)
        {
            
        }

        private void lblMessage_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
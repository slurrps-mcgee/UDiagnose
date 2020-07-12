﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;


namespace UDiagnose.Forms
{
    public partial class frmPopup : KryptonForm
    {
        public string VolumeLabel = "";
        public bool quickFormat = false;
        public string fileSystem = "";
        public int allocationSize = 0;
        public frmPopup()
        {
            InitializeComponent();
        }

        private void frmPopup_Load(object sender, EventArgs e)
        {
            txtVolumeLabel.Text = "Untitled";
            cmbFileSystem.SelectedIndex = 0;
            cmbAllocationSize.SelectedIndex = 4;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            int pos = 0;
            string temp;

            //Get Volume Label from user
            VolumeLabel = txtVolumeLabel.Text;

            //Check if quick format is checked
            if(chkQuickFormat.Checked == true)
            {
                quickFormat = true;
            }

            //Get the file system that is selected by the user
            fileSystem = cmbFileSystem.SelectedItem.ToString();

            //Get Allocation size
            //Get the number from the text on the combo box
            temp = cmbAllocationSize.SelectedItem.ToString();
            pos = temp.IndexOf(" ");
            temp = temp.Substring(0, pos);
            //Check to see if the selected item is above the 4th item
            if(cmbAllocationSize.SelectedIndex > 4)
            {
                allocationSize = Convert.ToInt32(temp) * 1000;
            }
            else
            {
                allocationSize = Convert.ToInt32(temp);
            }


            this.Close();
        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

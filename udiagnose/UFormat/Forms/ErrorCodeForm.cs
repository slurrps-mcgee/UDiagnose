﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using ComponentFactory.Krypton.Toolkit;
//Brandons Imports for XML document parsing
using System.Xml;
using System.IO;

namespace UDiagnose.Forms
{
    public partial class ErrorCodeForm : KryptonForm
    {
             
        public DataTable myData;
        
        public ErrorCodeForm()
        {
            InitializeComponent();
        }

        private void ErrorCodeForm_Load(object sender, EventArgs e)
        { 
            loadXmlToDataTable();
        }
       
       public void loadXmlToDataTable()
       {
            //Instantiate the public datatabe myDate and add its columns
            myData = new DataTable();
            myData.Columns.Add("Error");
            myData.Columns.Add("Solution");
            myData.PrimaryKey = new DataColumn[] { myData.Columns["Error"] };
            //Set path to the XML document = the apps runtime directory so its the same for all users
            string xmlDocPath = AppDomain.CurrentDomain.BaseDirectory + "Ref/ErrorCodes.xml";
            //Create new xmldoc object and parse all of the nodes within it
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            xmlnode = xmldoc.GetElementsByTagName("ErrorCodes");
            //Setup filestream that will read out the xmldoc and parse out the needed data
            FileStream fs = new FileStream(xmlDocPath, FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);

            int i;
            //Loop thorugh each ErrorCodes node in the doc and collect the error code, and the solution/meaning of the error
            for (i = 0; i <= xmlnode.Count - 1; i++)
                //Insert the error code and solution/meaning into the global datatable
                myData.Rows.Add(xmlnode[i].ChildNodes.Item(1).InnerText, xmlnode[i].ChildNodes.Item(2).InnerText);
            //Set the datagridview's datasource to the datatable we just populated
            dgDisplay.DataSource = myData;
            //Aaaaand we're done! (fuck office 365)
       }//End loadXmlToDataTable


        private void ErrorCodeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           //Show the main form
           splashScreen.mainForm.Show();
            //Start back up the main forms timer
           splashScreen.mainForm.systemLoadTimer.Start();

        }//End ErrorCodeForm_FormClosing

        //This is some test that might be linked to googling a word or
        //phrase that is in the text box next to the button
        private void btnGoogle_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("http://google.com");

        }//End btnGoogle_Click

        public void SearchOptions()
        {
            //Check of the error radial button is checked
            if(radError.Checked == true)
            {
                //Filter the rows of the data table where bookCode is like any of the text in the textbox txtSpecificBook
                (dgDisplay.DataSource as DataTable).DefaultView.RowFilter = string.Format("Error LIKE '%{0}%'", txtFind.Text);
                
            }
            else
            {
                //Filter the rows of the data table where bookCode is like any of the text in the textbox txtSpecificBook
                (dgDisplay.DataSource as DataTable).DefaultView.RowFilter = string.Format("Solution LIKE '%{0}%'", txtFind.Text);
            }
        }//End SearchOptions

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            //Call the search options method when the text changes in the text box
            SearchOptions();
        }//End txtFind_TextChanged

        private void radError_CheckedChanged(object sender, EventArgs e)
        {
            //clear the text box when error radial button is checked
            txtFind.Clear();
        }//End radError_CheckedChanged

        private void radDesc_CheckedChanged(object sender, EventArgs e)
        {
            //clear the text box when description radial button is checked
            txtFind.Clear();
        }//End radDesc_CheckedChanged


    }
}

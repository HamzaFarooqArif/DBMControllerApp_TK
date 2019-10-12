﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;

namespace DBMControllerApp_TK
{
    public partial class CameraProperties : Form
    {
        private bool camStart0 = false;
        private bool camStart1 = false;

        public CameraProperties()
        {
            InitializeComponent();

            CvInvoke.UseOpenCL = false;
            cb_1.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_1.DataSource = CameraUtility.getInstance(0).getCameraList();
            Application.Idle += processFrame;
        }

        private void processFrame(object sender, EventArgs arg)
        {
            if(camStart0)
            {
                CameraUtility.getInstance(cb_1.SelectedIndex).processFrame();
            }
            if (camStart1)
            {
                CameraUtility.getInstance(1).processFrame();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Preview1_Click(object sender, EventArgs e)
        {
            if(camStart0)
            {
                CameraUtility.getInstance(0).isPreview = !CameraUtility.getInstance(0).isPreview;
            }
            else
            {
                MessageBox.Show("Please Start the device first");
            }
        }

        private void btn_Capture1_Click(object sender, EventArgs e)
        {
            if (cb_1.Items.Count > 0)
            {
                camStart0 = true;
                cb_1.Enabled = false;
                btn_Capture1.Enabled = false;
            }
            else MessageBox.Show("Please Select a valid capture device");
            
        }
    }
}
﻿using DBMControllerApp_TK.Forms;
using DBMControllerApp_TK.Utilities;
using DebugTools.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMControllerApp_TK
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
            initControls();
            initializeForms();
            Inspector inspector = new Inspector();
        }

        private void initializeForms()
        {
            CameraSettings.getInstance(0);
            CameraSettings.getInstance(1);
            FilterSettings.getInstance(0);
            FilterSettings.getInstance(1);
            FilterPreview.getInstance(0);
            FilterPreview.getInstance(1);
            OrientationSettings.getInstance();
        }
        
        private void initControls()
        {
            initSubMenus();
        }
        #region Sidepanel
        private void initSubMenus()
        {
            panelHomeSubmenu.Visible = false;
            panelSettingsSubmenu.Visible = false;
        }

        private void hideHardwareSubmenu()
        {
            panelHardwareInputSubmenu.Visible = false;
        }

        private void showSubmenu(Panel submenu)
        {
            if(submenu.Visible == false)
            {
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            showSubmenu(panelHomeSubmenu);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            showSubmenu(panelSettingsSubmenu);
            hideHardwareSubmenu();
        }
        private void btnHardwareInput_Click(object sender, EventArgs e)
        {
            panelHardwareInputSubmenu.Visible = !panelHardwareInputSubmenu.Visible;
        }
        #endregion
        #region Subforms
        private void appendChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.BringToFront();
            childForm.Show();

            if (panelChildForm.Controls.OfType<TableLayoutPanel>().Count() == 0)
            {
                TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
                tableLayoutPanel.RowCount = 1;
                tableLayoutPanel.ColumnCount = 1;
                tableLayoutPanel.Name = "TLPForms";
                tableLayoutPanel.Margin = new Padding(0);
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent));
                tableLayoutPanel.ColumnStyles[tableLayoutPanel.ColumnStyles.Count - 1].Width = 50;
                tableLayoutPanel.Controls.Add(childForm, tableLayoutPanel.ColumnCount - 1, 0);
                tableLayoutPanel.Dock = DockStyle.Fill;
                panelChildForm.Controls.Add(tableLayoutPanel);
                tableLayoutPanel.BringToFront();
                //tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            }
            else
            {
                TableLayoutPanel tableLayoutPanel = panelChildForm.Controls.OfType<TableLayoutPanel>().FirstOrDefault();
                tableLayoutPanel.ColumnCount += 1;
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent));
                tableLayoutPanel.ColumnStyles[tableLayoutPanel.ColumnStyles.Count - 1].Width = 50;
                tableLayoutPanel.Controls.Add(childForm, tableLayoutPanel.ColumnCount - 1, 0);
                tableLayoutPanel.BringToFront();
            }

        }
        private void closeChildForms()
        {
            panelChildForm.Controls.RemoveByKey("TLPForms");
        }
        private void btnCameraSettings_Click(object sender, EventArgs e)
        {
            closeChildForms();
            appendChildForm(CameraSettings.getInstance(0));
            appendChildForm(CameraSettings.getInstance(1));
        }
        #endregion
        private void form_Index_Load(object sender, EventArgs e)
        {

        }

        private void panelHardwareInputSubmenu_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnPositionSettings_Click(object sender, EventArgs e)
        {
            //closeChildForms();
        }

        private void btnPlayer_Click(object sender, EventArgs e)
        {
            closeChildForms();
        }

        private void btn_Filter_Click(object sender, EventArgs e)
        {
            closeChildForms();
            appendChildForm(FilterSettings.getInstance(0));
            appendChildForm(FilterSettings.getInstance(1));
        }

        private void Index_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = dialog = MessageBox.Show(Utility.errorList[2], "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnOrientationSettings_Click(object sender, EventArgs e)
        {
            closeChildForms();
            appendChildForm(OrientationSettings.getInstance());
        }
    }
}

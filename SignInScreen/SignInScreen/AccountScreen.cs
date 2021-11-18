﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignInScreen
{
    public partial class AccountScreen : Form
    {
        // Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public AccountScreen()
        {
            InitializeComponent();
            random = new Random();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        
        private Color SelectThemeColor()
        {
            int index = random.Next(Themes.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(Themes.ColorList.Count);
            }
            tempIndex = index;
            string color = Themes.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    panelTitleBar.BackColor = color;
                    Themes.PrimaryColor = color;
                    Themes.SecondaryColor = Themes.ChangeColorBrightness(color, -0.3);
                    //btnCloseChildForm.Visible = true;
                    //btnLogo.BackColor = Themes.ChangeColorBrightness(color, -0.3);
                    ///ColorTheme.PrimaryColor = color;
                    //ColorTheme.SecondaryColor = ColorTheme.ChangeColorBrightness(color, -0.3);
                    //btnCloseChildForm.Visible = true;

                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(24, 31, 41);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

                }
            }
        }

        private void AccountScreen_Load(object sender, EventArgs e)
        {

        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //lbTitle.Text = childForm.Text;
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormDashboard(), sender);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormTests(), sender);

        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormCourses(), sender);

        }

        private void btnbooks_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormBooks(), sender);

        }

        private void btnRedeem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormRedeem(), sender);

        }

        private void panelDesktop_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

    }
}
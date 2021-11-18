using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignInScreen.Forms
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
            LoadTheme();
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = Themes.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = Themes.SecondaryColor;

                }
            }
            //label14.ForeColor = Themes.SecondaryColor;
            //label15.ForeColor = Themes.PrimaryColor;
        }
        private void FormDashboard_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            panelExam1.BackColor = Color.FromArgb(74, 104, 148);
            
        }

        private void btnExam1_Click(object sender, EventArgs e)
        {

        }
        /*
        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
        }*/
    }
}

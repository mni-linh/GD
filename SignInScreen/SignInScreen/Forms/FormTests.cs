using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using msword = Microsoft.Office.Interop.Word;
using System.Diagnostics;

namespace SignInScreen.Forms
{
    public partial class FormTests : Form
    {
        public object Application { get; private set; }

        public FormTests()
        {
            InitializeComponent();
        }
        private void FormTest_Load(object sender, EventArgs e)
        {
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

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(74, 104, 148);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
           System.IO.File.Copy("C:/Users/Admin/OneDrive/Documents/templates/Templates1.docx", "C:/Users/Admin/OneDrive/Documents/Templates1_Copy.docx", true);
            //Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
            //Document document = ap.Documents.Open(@"C:/Users/Admin/OneDrive/Documents/templates/Templates1.docx");
            //Console.WriteLine("asfafdsv");
            string a = "C:/Users/Admin/OneDrive/Documents/templates/Templates1.docx";// string a là đường dẫn cụ thể tới cái file word bạn muốn mở ra
            msword.Application word = new msword.Application();
            object miss = System.Reflection.Missing.Value;
            object path = @"C:\Users\Admin\OneDrive\Documents\templates\Templates1.docx";
            object readOnly = false;
            object missing = System.Type.Missing;
            msword.Document doc = word.Documents.Open(ref path,
                    ref miss, ref miss, ref miss, ref miss,
                    ref miss, ref miss, ref miss, ref miss,
                    ref miss, ref miss, ref miss, ref miss,
                    ref miss, ref miss, ref miss);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.IO.File.Copy("C:/Users/Admin/OneDrive/Documents/templates/Templates1.docx", "C:/Users/Admin/OneDrive/Documents/Templates1_Copy.docx", true);
            //Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
            //Document document = ap.Documents.Open(@"C:/Users/Admin/OneDrive/Documents/templates/Templates1_Copy.docx");
        }
    }
}

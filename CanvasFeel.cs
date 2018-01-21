using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dymetric_CS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set window position, width and height
            Rectangle screen_rect = Screen.PrimaryScreen.Bounds;
            this.SetDesktopBounds(0, 0, screen_rect.Width, screen_rect.Height);

            // Set a display text
            this.Text = "useOfMaths.com";

            // Set a background colour
            this.BackColor = System.Drawing.Color.Orange;

            // Set an icon image
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            path = new Uri(path).LocalPath;
            try
            {
                this.Icon = new Icon(path + "\\useOfMaths.ico");
            }
            catch(System.IO.FileNotFoundException ex)
            {
                // Well, just go on and use default pic
            }
            
        }
    }
}

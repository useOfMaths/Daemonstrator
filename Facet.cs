using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dymetric_CS
{
    public partial class Form1 : Form
    {
        private Rectangle screen_rect;
        private Dymetric action_class;
        private bool CLICK_OCCURRED;

        public Form1()
        {
            InitializeComponent();
            screen_rect = Screen.PrimaryScreen.Bounds;
            CLICK_OCCURRED = false;
            action_class = new Dymetric(screen_rect.Width, screen_rect.Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set window position, width and height
            this.SetDesktopBounds(0, 0, screen_rect.Width, screen_rect.Height);

            // Set a display text
            this.Text = "useOfMaths.com";

            // Set a background colour
            this.BackColor = Color.LightGray;

            // Set an icon image
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            path = new Uri(path).LocalPath;
            try
            {
                this.Icon = new Icon(path + "\\useOfMaths.ico");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                // Well, just go on and use default pic
            }

            /*
             * Create a button - response_btn
             */
            Button response_btn = new Button();
            response_btn.BackColor = Color.Magenta;
            response_btn.ForeColor = Color.Blue;
            response_btn.SetBounds(screen_rect.Width / 2 - 50, 5, 100, 40);
            response_btn.Text = "Move";
            response_btn.Click += new EventHandler(response_btn_Click);
            this.Controls.Add(response_btn);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Draw a dotted line
            Pen pencil = new Pen(Color.Black);
            pencil.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            pencil.Width = 5;
            e.Graphics.DrawLine(pencil, 0, 50, this.Width, 50);
            pencil.Dispose();

            // Colour region
            Brush paint_brush = new SolidBrush(Color.Pink);
            e.Graphics.FillRectangle(paint_brush, 0, 0, this.Width, 50);
            paint_brush.Dispose();

            // Call in proper action
            action_class.decideAction(e, CLICK_OCCURRED);
            CLICK_OCCURRED = false; // Reset click variable
        }


        public void response_btn_Click(object sender, EventArgs e)
        {
            // turn this on on every button click
            CLICK_OCCURRED = true;
            this.Refresh();
        }

    }
}

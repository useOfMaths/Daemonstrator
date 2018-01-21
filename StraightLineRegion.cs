using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace Dymetric_CS
{
    class StraightLineRegion
    {
        // ball coordinates
        private int x_ball, y_ball, previous_x, previous_y;
        private const int ballDIAMETER = 80;
        // line variables
        private int x1, y1, x2, y2;
        private double m, c, x_line;

        // we'll be drawing to and from a bitmap image
        private Bitmap offscreen_bitmap;
        Graphics offscreen_g;

        private Brush ball_colour, bg_colour;

        public StraightLineRegion(int screen_width, int screen_height)
        {
            ball_colour = new SolidBrush(Color.Yellow);
            bg_colour = new SolidBrush(Color.LightGray);

            // Create bitmap image
            offscreen_bitmap = new Bitmap(screen_width, screen_height - 55,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            // point graphic object to bitmap image
            offscreen_g = Graphics.FromImage(offscreen_bitmap);

            // Set background of bitmap graphic
            offscreen_g.Clear(Color.LightGray);

            previous_x = x_ball = 10;
            previous_y = y_ball = offscreen_bitmap.Height / 2 - ballDIAMETER / 2;

            x1 = offscreen_bitmap.Width / 2 - 100;
            y1 = 10;
            x2 = offscreen_bitmap.Width / 2 + 100;
            y2 = offscreen_bitmap.Height - 50;

            m = (y2 - y1) / (x2 - x1); // slope
            c = (x2 * y1 - x1 * y2) / (x2 - x1); // y-intercept

            // Point where ball will cross line
            x_line = (y_ball - c) / m;
        }

        // draw first appearance of ball on the screen
        public void clearAndDraw(PaintEventArgs e)
        {
            /*
             * draw to offscreen bitmap
             */
            // draw line
            offscreen_g.DrawLine(Pens.Black, x1, y1, x2, y2);

            // clear previous ball
            offscreen_g.FillEllipse(bg_colour, previous_x, previous_y, ballDIAMETER, ballDIAMETER);
            // draw ball
            offscreen_g.FillEllipse(ball_colour, x_ball, y_ball, ballDIAMETER, ballDIAMETER);
            previous_x = x_ball;
            previous_y = y_ball;

            // draw to screen
            Graphics gr = e.Graphics;
            gr.DrawImage(offscreen_bitmap, 0, 55, offscreen_bitmap.Width, offscreen_bitmap.Height);
        }

        // repetitively clear and draw ball on the screen - Simulate motion
        public void inPlay(PaintEventArgs e)
        {
            // condition for continuing motion
            while (x_ball < offscreen_bitmap.Width - ballDIAMETER)
            {
                // redraw ball
                clearAndDraw(e);

                x_ball += 10;
                // take a time pause
                Thread.Sleep(50);
            }
            x_ball = 10;
            y_ball = offscreen_bitmap.Height / 2 - ballDIAMETER / 2;
        }
    }
}

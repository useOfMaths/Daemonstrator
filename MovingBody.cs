using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace Dymetric_CS
{
    class MovingBody
    {
        private int x, y, previous_x, previous_y;
        private const int ballDIAMETER = 80;

        // we'll be drawing to and from a bitmap image
        private Bitmap offscreen_bitmap;
        Graphics offscreen_g;

        private Brush ball_colour, bg_colour;

        public MovingBody(int screen_width, int screen_height)
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

            previous_x = x = 10;
            previous_y = y = offscreen_bitmap.Height / 2 - ballDIAMETER / 2;
        }

        // draw first appearance of ball on the screen
        public void clearAndDraw(PaintEventArgs e)
        {
            /*
             * draw to offscreen bitmap
             */
            // clear previous ball
            offscreen_g.FillEllipse(bg_colour, previous_x, previous_y, ballDIAMETER, ballDIAMETER);
            // draw ball
            offscreen_g.FillEllipse(ball_colour, x, y, ballDIAMETER, ballDIAMETER);
            previous_x = x;
            previous_y = y;

            // draw to screen
            Graphics gr = e.Graphics;
            gr.DrawImage(offscreen_bitmap, 0, 55, offscreen_bitmap.Width, offscreen_bitmap.Height);
        }

        // repetitively clear and draw ball on the screen - Simulate motion
        public void inPlay(PaintEventArgs e)
        {
            // condition for continuing motion
            while (x < offscreen_bitmap.Width - ballDIAMETER)
            {
                // redraw ball
                clearAndDraw(e);

                x += 10;
                // take a time pause
                Thread.Sleep(50);
            }
            x = 10;
            y = offscreen_bitmap.Height / 2 - ballDIAMETER / 2;
        }
    }
}

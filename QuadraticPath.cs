using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace Dymetric_CS
{
    class QuadraticPath
    {
        private int x_start, y_start, x_max, y_max, x, y;
        private double a, b, c;
        private const int dotDIAMETER = 10;

        // we'll be drawing to and from a bitmap image
        private Bitmap offscreen_bitmap;
        Graphics offscreen_g;

        private Brush dot_colour, bg_colour;

        public QuadraticPath(int screen_width, int screen_height)
        {
            dot_colour = new SolidBrush(Color.Yellow);
            bg_colour = new SolidBrush(Color.LightGray);

            // Create bitmap image
            offscreen_bitmap = new Bitmap(screen_width, screen_height - 55,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            // point graphic object to bitmap image
            offscreen_g = Graphics.FromImage(offscreen_bitmap);

            // Set background of bitmap graphic
            offscreen_g.Clear(Color.LightGray);

            x_start = x = 10;
            y_start = y = offscreen_bitmap.Height - 70;
            x_max = offscreen_bitmap.Width / 2 - 50;
            y_max = 20;

            // constants
            a = (y_start - y_max) / Math.Pow((x_start - x_max), 2);
            b = -2 * a * x_max;
            c = y_max + a*Math.Pow(x_max, 2);
        }

        // draw first appearance of dot on the screen
        public void clearAndDraw(PaintEventArgs e)
        {
            /*
             * draw to offscreen bitmap
             */
            // clear entire bitmap
            offscreen_g.Clear(Color.LightGray);
            // draw dot
            offscreen_g.FillEllipse(dot_colour, x, y, dotDIAMETER, dotDIAMETER);

            // draw to screen
            Graphics gr = e.Graphics;
            gr.DrawImage(offscreen_bitmap, 0, 55, offscreen_bitmap.Width, offscreen_bitmap.Height);
        }

        // repetitively clear and draw dot on the screen - Simulate motion
        public void inPlay(PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            // condition for continuing motion
            while (x < offscreen_bitmap.Width - dotDIAMETER)
            {
                // redraw dot
                offscreen_g.FillEllipse(dot_colour, x, y, dotDIAMETER, dotDIAMETER);
                // draw to screen
                gr.DrawImage(offscreen_bitmap, 0, 55, offscreen_bitmap.Width, offscreen_bitmap.Height);

                x += 20;
                y = (int)Math.Round(a * x * x + b * x + c);
                // take a time pause
                Thread.Sleep(50);
            }
            x = x_start;
            y = y_start;
        }
    }
}

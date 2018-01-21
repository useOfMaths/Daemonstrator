using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace Dymetric_CS
{
    class CubicPath
    {
        private int x_start, x_max, y_max, x_min, y_min, x, y;
        private double a, b, c, d;
        private const int dotDIAMETER = 10;

        // we'll be drawing to and from a bitmap image
        private Bitmap offscreen_bitmap;
        Graphics offscreen_g;

        private Brush dot_colour, bg_colour;

        public CubicPath(int screen_width, int screen_height)
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

            x_start = x = 20;
            x_max = offscreen_bitmap.Width / 4 + 10;
            y_max = 20;
            x_min = 3 * offscreen_bitmap.Width / 4 - 10;
            y_min = offscreen_bitmap.Height - 70;

            // constants
            a = (-2 * (y_max - y_min)) / Math.Pow((x_max - x_min), 3);
            b = -((double)3 / 2) * a * (x_max + x_min);
            c = 3 * a * x_max * x_min;
            d = y_max + (a / 2) * (x_max - 3 * x_min) * Math.Pow(x_max, 2);

            y = (int)Math.Round(a * Math.Pow(x, 3) + b * Math.Pow(x, 2) + c * x + d);
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
            while (x < offscreen_bitmap.Width - dotDIAMETER && y >= y_max)
            {
                // redraw dot
                offscreen_g.FillEllipse(dot_colour, x, y, dotDIAMETER, dotDIAMETER);
                // draw to screen
                gr.DrawImage(offscreen_bitmap, 0, 55, offscreen_bitmap.Width, offscreen_bitmap.Height);

                x += 20;
                y = (int)Math.Round(a * Math.Pow(x, 3) + b * Math.Pow(x, 2) + c * x + d);
                // take a time pause
                Thread.Sleep(50);
            }
            x = x_start;
            y = (int)Math.Round(a * Math.Pow(x, 3) + b * Math.Pow(x, 2) + c * x + d);
        }
    }
}

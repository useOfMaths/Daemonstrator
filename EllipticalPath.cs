using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace Dymetric_CS
{
    class EllipticalPath
    {
        private int h, k, a, b, x, y;
        private const int dotDIAMETER = 10;

        // we'll be drawing to and from a bitmap image
        private Bitmap offscreen_bitmap;
        Graphics offscreen_g;

        private Brush dot_colour, bg_colour;

        public EllipticalPath(int screen_width, int screen_height)
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

            // ellipse centre coordinates
            h = offscreen_bitmap.Width / 2;
            k = offscreen_bitmap.Height / 2;
            // ellipse major and minor semi-axes
            a = offscreen_bitmap.Width / 3;
            b = offscreen_bitmap.Height / 3;
            x = h - a;
            y = k;
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
            while (x <= h + a)
            {
                y = (int)Math.Round(k - ((double)b / a) * Math.Sqrt(Math.Pow(a, 2) - Math.Pow((x - h), 2)));
                // redraw dot
                offscreen_g.FillEllipse(dot_colour, x, y, dotDIAMETER, dotDIAMETER);

                y = (int)Math.Round(k + ((double)b / a) * Math.Sqrt(Math.Pow(a, 2) - Math.Pow((x - h), 2)));
                // redraw dot
                offscreen_g.FillEllipse(dot_colour, x, y, dotDIAMETER, dotDIAMETER);

                // draw to screen
                gr.DrawImage(offscreen_bitmap, 0, 55, offscreen_bitmap.Width, offscreen_bitmap.Height);

                x += 20;
                // take a time pause
                Thread.Sleep(50);
            }
            x = h - a;
            y = k;
        }
    }
}

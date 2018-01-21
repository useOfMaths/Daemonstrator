using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace Dymetric_CS
{
    class PeriodicFunction
    {
        private int theta, a, y, half_vert_screen;
        private const int dotDIAMETER = 10;

        // we'll be drawing to and from a bitmap image
        private Bitmap offscreen_bitmap;
        Graphics offscreen_g;

        private Brush dot_colour, bg_colour;

        public PeriodicFunction(int screen_width, int screen_height)
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

            theta = 0;
            a = offscreen_bitmap.Height / 3; // constant
            // half way down the vertical section of the screen
            half_vert_screen = offscreen_bitmap.Height / 2 - dotDIAMETER / 2;

            y = (int)Math.Round(a * Math.Sin(theta * Math.PI / 180)) + half_vert_screen;
        }

        // draw first appearance of dot on the screen
        public void clearAndDraw(PaintEventArgs e)
        {
            /*
             * draw to offscreen bitmap
             */
            // clear entire bitmap
            offscreen_g.Clear(Color.LightGray);
            // draw x-axis line
            offscreen_g.DrawLine(Pens.Black, 0, half_vert_screen + dotDIAMETER / 2,
                offscreen_bitmap.Width, half_vert_screen + dotDIAMETER / 2);
            // draw dot
            offscreen_g.FillEllipse(dot_colour, theta, y, dotDIAMETER, dotDIAMETER);

            // draw to screen
            Graphics gr = e.Graphics;
            gr.DrawImage(offscreen_bitmap, 0, 55, offscreen_bitmap.Width, offscreen_bitmap.Height);
        }

        // repetitively clear and draw dot on the screen - Simulate motion
        public void inPlay(PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            // condition for continuing motion
            while (theta < offscreen_bitmap.Width - dotDIAMETER)
            {
                // redraw dot
                offscreen_g.FillEllipse(dot_colour, theta, y, dotDIAMETER, dotDIAMETER);
                // draw to screen
                gr.DrawImage(offscreen_bitmap, 0, 55, offscreen_bitmap.Width, offscreen_bitmap.Height);

                theta += 15;
                y = (int)Math.Round(a * Math.Sin(theta * Math.PI / 180)) + half_vert_screen;
                // take a time pause
                Thread.Sleep(50);
            }
            theta = 0;
            y = (int)Math.Round(a * Math.Sin(theta * Math.PI / 180)) + half_vert_screen;
        }
    }
}

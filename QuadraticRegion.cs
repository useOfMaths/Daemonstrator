using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace Dymetric_CS
{
    class QuadraticRegion
    {
        // ball coordinates
        private int x_ball, y_ball, previous_x, previous_y;
        private const int ballDIAMETER = 80;
        // quadratic variables
        private int xq_start, yq_start, xq_min, yq_min, xq_stop, x, y;
        private double xq_lb, xq_ub; // curve lower and upper boundary
        private double a, b, c, discriminant;
        private const int dotDIAMETER = 5;

        // we'll be drawing to and from a bitmap image
        private Bitmap offscreen_bitmap;
        Graphics offscreen_g;

        private Brush ball_colour, dot_colour, bg_colour;

        public QuadraticRegion(int screen_width, int screen_height)
        {
            ball_colour = new SolidBrush(Color.Yellow);
            dot_colour = new SolidBrush(Color.Black);
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

            xq_start = offscreen_bitmap.Width / 2 - 200;
            yq_start = 10;
            xq_min = offscreen_bitmap.Width / 2;
            yq_min = offscreen_bitmap.Height - 70;
            xq_stop = offscreen_bitmap.Width / 2 + 200;

            // constants
            a = (yq_start - yq_min) / Math.Pow((xq_start - xq_min), 2);
            b = -2 * a * xq_min;
            c = yq_min + a*Math.Pow(xq_min, 2);

            discriminant = Math.Sqrt(b*b - 4*a*(c - (y_ball - ballDIAMETER / 2)));
            if (a < 0) // a is negative
            {
                xq_lb = (-b + discriminant) / (2 * a); // lower boundary
                xq_ub = (-b - discriminant) / (2 * a); // upper boundary
            }
            else
            {
                xq_lb = (-b - discriminant) / (2 * a); // lower boundary
                xq_ub = (-b + discriminant) / (2 * a); // upper boundary
            }
        }

        // draw first appearance of ball on the screen
        public void clearAndDraw(PaintEventArgs e)
        {
            /*
             * draw to offscreen bitmap
             */
            // draw quadratic curve
            for (x = xq_start; x <= xq_stop; x++)
            {
                y = (int)Math.Round(a * x * x + b * x + c);
                // redraw dot
                offscreen_g.FillEllipse(dot_colour, x, y, dotDIAMETER, dotDIAMETER);
            }

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
                // yellow outside the quadratic region
                ball_colour = new SolidBrush(Color.Yellow);
                if ((x_ball <= xq_lb && x_ball + ballDIAMETER >= xq_lb)
                    || (x_ball <= xq_ub && x_ball + ballDIAMETER >= xq_ub))
                {
                    // red on the quadratic outline
                    ball_colour = new SolidBrush(Color.Red);
                }
                else if (x_ball >= xq_lb && x_ball + ballDIAMETER <= xq_ub)
                {
                    // green inside the quadratic region
                    ball_colour = new SolidBrush(System.Drawing.Color.Green);
                }

                // redraw ball
                clearAndDraw(e);

                x_ball += 5;
                // take a time pause
                Thread.Sleep(50);
            }
            x_ball = 10;
            y_ball = offscreen_bitmap.Height / 2 - ballDIAMETER / 2;
        }
    }
}

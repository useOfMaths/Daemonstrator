using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace Dymetric_CS
{
    class EllipticalRegion
    {
        // square coordinates
        private int x_square, y_square, previous_x, previous_y;
        private const int squareLENGTH = 80;

        // circle variables
        private int h, k, a, b;
        private const int dotDIAMETER = 10;

        // we'll be drawing to and from a bitmap image
        private Bitmap offscreen_bitmap;
        Graphics offscreen_g;

        private Brush bg_colour;
        private Pen square_pen;

        public EllipticalRegion(int screen_width, int screen_height)
        {
            square_pen = new Pen(Color.Yellow);
            square_pen.Width = 5;
            bg_colour = new SolidBrush(Color.LightGray);

            // Create bitmap image
            offscreen_bitmap = new Bitmap(screen_width, screen_height - 55,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            // point graphic object to bitmap image
            offscreen_g = Graphics.FromImage(offscreen_bitmap);

            // Set background of bitmap graphic
            offscreen_g.Clear(Color.LightGray);

            previous_x = x_square = 10;
            previous_y = y_square = offscreen_bitmap.Height / 2 - squareLENGTH / 2;

            // ellipse centre coordinates
            h = offscreen_bitmap.Width / 2;
            k = offscreen_bitmap.Height / 2;
            // ellipse major and minor semi-axes
            a = offscreen_bitmap.Width / 3;
            b = offscreen_bitmap.Height / 3;
        }

        // draw first appearance of square on the screen
        public void clearAndDraw(PaintEventArgs e)
        {
            /*
             * draw to offscreen bitmap
             */
            // draw an ellipse
            offscreen_g.DrawEllipse(Pens.Black, h - a, k - b, 2 * a, 2 * b);

            // clear previous square
            offscreen_g.FillRectangle(bg_colour, previous_x - 5, previous_y - 5, squareLENGTH + 10, squareLENGTH + 10);
            // draw square
            offscreen_g.DrawRectangle(square_pen, x_square, y_square, squareLENGTH, squareLENGTH);
            previous_x = x_square;
            previous_y = y_square;

            // draw to screen
            Graphics gr = e.Graphics;
            gr.DrawImage(offscreen_bitmap, 0, 55, offscreen_bitmap.Width, offscreen_bitmap.Height);
        }

        // repetitively clear and draw square on the screen - Simulate motion
        public void inPlay(PaintEventArgs e)
        {
            // condition for continuing motion
            while (x_square < offscreen_bitmap.Width - squareLENGTH)
            {
                int square_left = x_square;
                int square_right = x_square + squareLENGTH;
                int square_top = y_square;
                int square_bottom = y_square + squareLENGTH;

                // determinants for each side of the square
                int x_left_det = (int)Math.Round(((double)b / a)
                        * Math.Sqrt(Math.Pow(a, 2) - Math.Pow((square_left - h), 2)));
                int x_right_det = (int)Math.Round(((double)b / a)
                        * Math.Sqrt(Math.Pow(a, 2) - Math.Pow((square_right - h), 2)));
                int y_up_det = (int)Math.Round(((double)a / b)
                        * Math.Sqrt(Math.Pow(b, 2) - Math.Pow((square_top - k), 2)));
                int y_down_det = (int)Math.Round(((double)a / b)
                        * Math.Sqrt(Math.Pow(b, 2) - Math.Pow((square_bottom - k), 2)));

                // check the bounds of the circle
                square_pen.Dispose();
                // yellow outside the circle
                square_pen = new Pen(Color.Yellow);
                if (square_top > k - x_left_det && square_bottom < k + x_left_det
                    && square_top > k - x_right_det && square_bottom < k + x_right_det
                    && square_left > h - y_up_det && square_right < h + y_up_det
                    && square_left > h - y_down_det && square_right < h + y_down_det)
                {
                    // green inside the circle
                    square_pen = new Pen(Color.Green);
                }
                square_pen.Width = 5;

                // redraw square
                clearAndDraw(e);

                x_square += 10;
                // take a time pause
                Thread.Sleep(50);
            }
            x_square = 10;
            y_square = offscreen_bitmap.Height / 2 - squareLENGTH / 2;
        }
    }
}

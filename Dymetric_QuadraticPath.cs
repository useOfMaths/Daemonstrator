using System.Windows.Forms;

namespace Dymetric_CS
{
    class Dymetric
    {
        private QuadraticPath quad_curve;
        private bool do_simulation;

        public Dymetric(int screen_width, int screen_height)
        {
            quad_curve = new QuadraticPath(screen_width, screen_height);
            do_simulation = false;
        }

        // decide what course of action to take
        public void decideAction(PaintEventArgs e, bool click_check)
        {
            if (do_simulation && click_check)
            {
                // do animation
                quad_curve.inPlay(e);
                do_simulation = false;
            }
            else
            {
                // Put ball on screen
                quad_curve.clearAndDraw(e);
                do_simulation = true;
            }
        }
    }
}

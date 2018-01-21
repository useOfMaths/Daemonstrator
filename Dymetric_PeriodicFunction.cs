using System.Windows.Forms;

namespace Dymetric_CS
{
    class Dymetric
    {
        private PeriodicFunction sine_curve;
        private bool do_simulation;

        public Dymetric(int screen_width, int screen_height)
        {
            sine_curve = new PeriodicFunction(screen_width, screen_height);
            do_simulation = false;
        }

        // decide what course of action to take
        public void decideAction(PaintEventArgs e, bool click_check)
        {
            if (do_simulation && click_check)
            {
                // do animation
                sine_curve.inPlay(e);
                do_simulation = false;
            }
            else
            {
                // Put ball on screen
                sine_curve.clearAndDraw(e);
                do_simulation = true;
            }
        }
    }
}

using System.Windows.Forms;

namespace Dymetric_CS
{
    class Dymetric
    {
        private EllipticalPath ellipse_ride;
        private bool do_simulation;

        public Dymetric(int screen_width, int screen_height)
        {
            ellipse_ride = new EllipticalPath(screen_width, screen_height);
            do_simulation = false;
        }

        // decide what course of action to take
        public void decideAction(PaintEventArgs e, bool click_check)
        {
            if (do_simulation && click_check)
            {
                // do animation
                ellipse_ride.inPlay(e);
                do_simulation = false;
            }
            else
            {
                // Put ball on screen
                ellipse_ride.clearAndDraw(e);
                do_simulation = true;
            }
        }
    }
}

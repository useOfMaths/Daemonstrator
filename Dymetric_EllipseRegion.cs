using System.Windows.Forms;

namespace Dymetric_CS
{
    class Dymetric
    {
        private EllipticalRegion ellipse_zone;
        private bool do_simulation;

        public Dymetric(int screen_width, int screen_height)
        {
            ellipse_zone = new EllipticalRegion(screen_width, screen_height);
            do_simulation = false;
        }

        // decide what course of action to take
        public void decideAction(PaintEventArgs e, bool click_check)
        {
            if (do_simulation && click_check)
            {
                // do animation
                ellipse_zone.inPlay(e);
                do_simulation = false;
            }
            else
            {
                // Put ball on screen
                ellipse_zone.clearAndDraw(e);
                do_simulation = true;
            }
        }
    }
}

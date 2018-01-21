using System.Windows.Forms;

namespace Dymetric_CS
{
    class Dymetric
    {
        private QuadraticRegion quad_region;
        private bool do_simulation;

        public Dymetric(int screen_width, int screen_height)
        {
            quad_region = new QuadraticRegion(screen_width, screen_height);
            do_simulation = false;
        }

        // decide what course of action to take
        public void decideAction(PaintEventArgs e, bool click_check)
        {
            if (do_simulation && click_check)
            {
                // do animation
                quad_region.inPlay(e);
                do_simulation = false;
            }
            else
            {
                // Put ball on screen
                quad_region.clearAndDraw(e);
                do_simulation = true;
            }
        }
    }
}

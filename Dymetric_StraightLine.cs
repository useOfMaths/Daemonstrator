using System.Windows.Forms;

namespace Dymetric_CS
{
    class Dymetric
    {
        private StraightLine line_motion;
        private bool do_simulation;

        public Dymetric(int width, int height)
        {
            line_motion = new StraightLine(width, height);
            do_simulation = false;
        }

        // decide what course of action to take
        public void decideAction(PaintEventArgs e, bool click_check)
        {
            if (do_simulation && click_check)
            {
                // do animation
                line_motion.inPlay(e);
                do_simulation = false;
            }
            else
            {
                // Put ball on screen
                line_motion.clearAndDraw(e);
                do_simulation = true;
            }
        }
    }
}

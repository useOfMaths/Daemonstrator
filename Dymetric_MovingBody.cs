using System.Windows.Forms;

namespace Dymetric_CS
{
    class Dymetric
    {
        private MovingBody move_body;
        private bool do_simulation;

        public Dymetric(int width, int height)
        {
            move_body = new MovingBody(width, height);
            do_simulation = false;
        }

        // decide what course of action to take
        public void decideAction(PaintEventArgs e, bool click_check)
        {
            if (do_simulation && click_check)
            {
                // do animation
                move_body.inPlay(e);
                do_simulation = false;
            }
            else
            {
                // Put ball on screen
                move_body.clearAndDraw(e);
                do_simulation = true;
            }
        }
    }
}

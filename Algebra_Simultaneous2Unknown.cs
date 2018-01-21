using System;
using System.Collections.Generic;

namespace Algebra_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our demonstration sequels");
            Console.WriteLine("Hope you enjoy (and follow) the lessons.");
            Console.WriteLine("\r\n");

            /*
                * Simultaneous Equations with 2 unknowns
             */
            char[] operate = new char[] { '+', '+' };
            double[] result2D;
            double[] x_coeff = new double[] { 1, 2 };
            double[] y_coeff = new double[] { 1, 2 };
            double[] equals = new double[] { 2, 4 };

            if (y_coeff[0] < 0)
            {
                operate[0] = '-';
            }
            if (y_coeff[1] < 0)
            {
                operate[1] = '-';
            }

            Console.WriteLine("\r\n    Solving simultaneously the equations:\r\n");
            //Print as an equation
            Console.WriteLine(String.Format("{0,20}x  {1}  {2}y  =  {3}",
                  x_coeff[0], operate[0], Math.Abs(y_coeff[0]), equals[0]
                  )
            );
            Console.WriteLine(String.Format("{0,20}x  {1}  {2}y  =  {3}",
                x_coeff[1], operate[1], Math.Abs(y_coeff[1]), equals[1]
                )
            );
            Console.WriteLine(Environment.NewLine);
            Console.Write(String.Format("{0,15} {1}{2,20}", "Yields:", "\r\n", "(x, y)  =  "));

            try
            {
                Simultaneous2Unknown sim2unk;
                sim2unk = new Simultaneous2Unknown(x_coeff, y_coeff, equals);
                result2D = sim2unk.solveSimultaneous();

                Console.Write(String.Format("({0:0.0000}, {1:0.0000})", result2D[0], result2D[1]));

            }
            catch (Exception)
            {
                Console.Write("(infinity,  infinity)");
            }

        }
    }
}

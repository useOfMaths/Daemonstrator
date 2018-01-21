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
                * Simultaneous Equations with 3 unknowns
             */
            char[, ] operate = new char[3, 2];

            double[] result3D;
            int[] x_coeff = new int[] { 2, 4, 2 };
            int[] y_coeff = new int[] { 1, -1, 3 };
            int[] z_coeff = new int[] { 1, -2, -8 };
            int[] equals = new int[] { 4, 1, -3 };

            for (int i = 0; i < 3; i++)
            {
                operate[i, 0] = '+'; // lazy if..else
                if (y_coeff[i] < 0)
                {
                    operate[i, 0] = '-';
                }
                operate[i, 1] = '+';
                if (z_coeff[i] < 0)
                {
                    operate[i, 1] = '-';
                }
            }

            Console.WriteLine("\r\n    Solving simultaneously the equations:\r\n");
            //Print as an equation
            Console.WriteLine(String.Format("{0,20}x  {1}  {2}y  {3}  {4}z  =  {5}",
                    x_coeff[0], operate[0, 0], Math.Abs(y_coeff[0]),
                    operate[0, 1], Math.Abs(z_coeff[0]), equals[0]
                )
            );
            Console.WriteLine(String.Format("{0,20}x  {1}  {2}y  {3}  {4}z  =  {5}",
                    x_coeff[1], operate[1, 0], Math.Abs(y_coeff[1]),
                    operate[1, 1], Math.Abs(z_coeff[1]), equals[1]
                )
            );
            Console.WriteLine(String.Format("{0,20}x  {1}  {2}y  {3}  {4}z  =  {5}",
                    x_coeff[2], operate[2, 0], Math.Abs(y_coeff[2]),
                    operate[2, 1], Math.Abs(z_coeff[2]), equals[2]
                )
            );
            Console.WriteLine(Environment.NewLine);
            Console.Write(String.Format("{0,15} {1}{2,20}", "Yields:", "\r\n", "(x, y, z)  =  "));

            try
            {
                Simultaneous3Unknown sim3unk;
                sim3unk = new Simultaneous3Unknown(x_coeff, y_coeff, z_coeff, equals);
                result3D = sim3unk.solveSimultaneous();

                Console.Write(String.Format("({0:0.0000}, {1:0.0000}, {2:0.0000})", result3D[0], result3D[1], result3D[2]));

            }
            catch (Exception)
            {
                Console.Write("(infinity,  infinity, infinity)");
            }

        }
    }
}

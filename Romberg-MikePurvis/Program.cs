using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Romberg_MikePurvis
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0;
            double b = Math.PI / 3;

            double h = b - a;

            int n = 6; // iterations

            // trapezoidal extrapolation
            //double[][] R = new double[19][];
            double[,] R = new double [19,19];
            //R[0, 0] = 1.9;

            //R[1][1] = h / 2 * (Math.Sin(a) + Math.Sin(b));
            R[1,1] = (h / 2) * (Math.Tan(a) + Math.Tan(b));
            //Console.WriteLine("R[1][1] is " + R[1][1]+"\n");
            Console.WriteLine("R[1][1] is " + R[1,1] + "\n");

            int powerof2 = 1; // might be wrong
            
            //int powerof4 = 4; // GOT RID OF THIS VARIABLE, DID THE MATH using Math class
            int z = 2;
            double sum = 0;
            for (int i = 2; i <= n; i++)
            {
                sum = 0;
                //powerof2 = 2 ^ (i - 2);
                powerof2 = (int)Math.Pow(2, (i - 2)); // I ADDED THIS
                for (int j = 1; j <= powerof2; j++)
                {
                    sum += Math.Sin(a + (j - 0.5) * h);
                }
                sum *= h;

                powerof2 *= 2;

                //R[2][1] = (R[1][1] + sum) / 2;
                R[2,1] = (R[1,1] + sum) / 2;
                for (int j = 2; j <= i; j++)
                {
                    //R[2,j] = R[2,j - 1] + (R[2,j - 1] - R[1,j - 1]) / (powerof4 - 1);         // HERE'S WHERE THE ERROR IS, the powerof4
                    R[2, j] = R[2, j - 1] + (R[2, j - 1] - R[1, j - 1]) / (Math.Pow(4,j-1) - 1);
                }

                //powerof4 *= 4; // No Need

                for (int j = 1; j <= i; j++)
                {
                    //Console.WriteLine("R[" + z + "][" + j + "] = " + R[2][j]);
                    Console.WriteLine("R[" + z + "][" + j + "] = " + R[2,j]);
                }
                Console.WriteLine();
                h = h / 2;
                for (int j = 1; j <= i; j++)
                {
                    //R[1][j] = R[2][j];
                    R[1,j] = R[2,j];
                }

                z += 1;
            }

            Console.WriteLine("press enter to end ");
            Console.ReadLine();

        }
    }
}

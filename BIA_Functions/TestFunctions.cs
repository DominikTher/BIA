using System;

namespace BIA_Functions
{
    internal class TestFunctions
    {
        [FunctionName("1st De Jong")]
        public double DeJongNo1(double[] x)
        {
            var value = 0.0;

            for (int i = 0; i < x.Length; i++)
            {
                value += Math.Pow(x[i], 2);
            }

            return value;
        }

        [FunctionName("Rosenbrock’s saddle")]
        public double Rosenbrocks(double[] x)
        {
            var value = 0.0;

            for (int i = 0; i < x.Length - 1; i++)
            {
                value += (100 * Math.Pow(Math.Pow(x[i], 2) - x[i + 1], 2) + Math.Pow(1 - x[i], 2));
            }

            return value;
        }

        [FunctionName("3rd De Jong")]
        public double DeJongNo3(double[] x)
        {
            var value = 0.0;

            for (int i = 0; i < x.Length; i++)
            {
                value += Math.Abs(x[i]);
            }

            return value;
        }
    }
}
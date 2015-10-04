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

        //[FunctionName("De jongg")]
        //public double DeJongNo4(double[] x)
        //{
        //    var value = 0.0;

        //    for (int i = 0; i < x.Length; i++)
        //    {
        //        value += (i * Math.Pow(x[i], 4));
        //    }

        //    return value;
        //}

        //[FunctionName("De jofng")]
        //public double Rastrigins(double[] x)
        //{
        //    var value = 0.0;

        //    for (int i = 0; i < x.Length; i++)
        //    {
        //        value += (Math.Pow(x[i], 2) - 10 * Math.Cos(2 * Math.PI * x[i]));
        //    }

        //    value *= (2 * x.Length); // TODO: Test it and test 10cos vs 10 * cos

        //    return value;
        //}

        //[FunctionName("Dffe jong")]
        //public double Schwefels(double[] x)
        //{
        //    var value = 0.0;

        //    for (int i = 0; i < x.Length; i++)
        //    {
        //        value += ((-1 * x[i]) * Math.Sin(Math.Sqrt(Math.Abs(x[i]))));
        //    }

        //    return value;
        //}

        //public double Griewangks(double[] x,)
        //{
        //    var value = 0.0;

        //    for (int i = 0; i < x.Length; i++)
        //    {
        //        value += ((-1 * x[i]) * Math.Sin(Math.Sqrt(Math.Abs(x[i]))));
        //    }

        //    value += 1;

        //    return value;
        //}

        //[FunctionName("De fgjong")]
        //public double SineEnvelopeSineWave(double[] x)
        //{
        //    var value = 0.0;

        //    for (int i = 0; i < x.Length - 1; i++)
        //    {
        //        value += (0.5 + (
        //            (Math.Pow(
        //                Math.Pow(x[i], 2) +
        //                Math.Pow(x[i + 1], 2) -
        //                0.5
        //                , 2))
        //                /
        //                (1 + (
        //                0.001 * Math.Pow(
        //                Math.Pow(x[i], 2) +
        //                Math.Pow(x[i + 1], 2)
        //                , 2)
        //                )))
        //            );
        //    }

        //    value *= -1;

        //    return value;
        //}
    }
}
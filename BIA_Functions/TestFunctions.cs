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

        [FunctionName("4th De Jong")]
        public double DeJongNo4(double[] x)
        {
            var value = 0.0;

            for (int i = 0; i < x.Length; i++)
            {
                value += ((i + 1) * Math.Pow(x[i], 4));
            }

            return value;
        }

        [FunctionName("Rastrigin’s function")]
        public double Rastrigins(double[] x)
        {
            var value = 0.0;

            for (int i = 0; i < x.Length; i++)
            {
                value += (Math.Pow(x[i], 2) - 10 * Math.Cos(2 * Math.PI * x[i]));
            }

            value *= (2 * x.Length); // TODO: Test it and test 10cos vs 10 * cos

            return value;
        }

        [FunctionName("Schwefel’s function")]
        public double Schwefels(double[] x)
        {
            var value = 0.0;

            for (int i = 0; i < x.Length; i++)
            {
                value += ((-1 * x[i]) * Math.Sin(Math.Sqrt(Math.Abs(x[i]))));
            }

            return value;
        }

        [FunctionName("Griewangk’s function")]
        public double Griewangks(double[] x)
        {
            var value1 = 0.0;
            var value2 = 1.0;

            for (int i = 0; i < x.Length; i++)
            {
                value1 += (Math.Pow(x[i], 2) / 4000);
            }

            for (int i = 0; i < x.Length; i++)
            {
                value2 *= Math.Cos(x[i] / Math.Sqrt(i + 1));
            }

            return value1 - value2 + 1;
        }

        [FunctionName("Sine envelope sine wave function")]
        public double SineEnvelopeSineWave(double[] x)
        {
            var value = 0.0;

            for (int i = 0; i < x.Length - 1; i++)
            {
                value += (0.5 + (
                    (Math.Pow(
                        Math.Sin(
                            Math.Pow(x[i], 2) +
                            Math.Pow(x[i + 1], 2) -
                            0.5)
                        , 2))
                        /
                        (1 + (
                        0.001 * Math.Pow(
                        Math.Pow(x[i], 2) +
                        Math.Pow(x[i + 1], 2)
                        , 2)
                        )))
                    );
            }

            value *= -1;

            return value;
        }

        [FunctionName("Stretched V sine wave function")]
        public double StretchedVSineWave(double[] x)
        {
            var value = 0.0;

            for (int i = 0; i < x.Length - 1; i++)
            {
                var tmp = Math.Pow(x[i], 2) + Math.Pow(x[i + 1], 2);
                value += (Math.Pow(tmp, 0.25) *
                            Math.Pow(Math.Sin(50 * Math.Pow(tmp, 0.1)), 2) + 1);
            }

            return value;
        }

        [FunctionName("Ackley’s function I")]
        public double AckleysFunctionI(double[] x)
        {
            var value = 0.0;

            for (int i = 0; i < x.Length - 1; i++)
            {
                value += (Math.Pow(Math.E, -0.2) * Math.Sqrt(Math.Pow(x[i], 2) + Math.Pow(x[i + 1], 2)) +
                            (3 * (Math.Cos(2 * x[i]) + Math.Sin(2 * x[i + 1]))));
            }

            return value;
        }

        [FunctionName("Ackley’s function II")]
        public double AckleysFunction2(double[] x)
        {
            var value = 0.0;

            for (int i = 0; i < x.Length - 1; i++)
            {
                value += (20 + Math.E - (
                        20 / Math.Pow(Math.E, 0.2 * Math.Sqrt((Math.Pow(x[i], 2) + Math.Pow(x[i + 1], 2)) / 2))
                    ) - Math.Pow(Math.E, 0.5 * (Math.Cos(2 * Math.PI * x[i]) + Math.Cos(2 * Math.PI * x[i + 1]))));
            }

            return value;
        }

        [FunctionName("Egg holder")]
        public double EggHolder(double[] x)
        {
            var value = 0.0;

            for (int i = 0; i < x.Length - 1; i++)
            {
                value += ((-1 * x[i]) * Math.Sin(Math.Sqrt(Math.Abs(x[i] - x[i + 1] - 47))) - (
                        (x[i + 1] + 47) * Math.Sin(Math.Sqrt(Math.Abs(x[i + 1] + 47 + (x[i] / 2))))
                    ));
            }

            return value;
        }

        [FunctionName("Rana’s function")]
        public double RanasFunction(double[] x)
        {
            var value = 0.0;

            for (int i = 0; i < x.Length - 1; i++)
            {
                var tmp = Math.Abs(x[i + 1] + 1 - x[i]);
                var tmp2 = Math.Abs(x[i + 1] + 1 + x[i]);

                value += (x[i] * Math.Sin(Math.Sqrt(tmp)) * Math.Cos(Math.Sqrt(tmp2)) + (
                        (x[i + 1] + 1) * Math.Cos(Math.Sqrt(tmp)) * Math.Sin(Math.Sqrt(tmp2))
                    ));
            }

            return value;
        }

        // TODO:
        [FunctionName("Pathological function")]
        public double PathologicalFunction(double[] x)
        {
            var value = 0.0;

            for (int i = 0; i < x.Length - 1; i++)
            {
                value += ((Math.Pow(Math.Sin(Math.Sqrt(100 * Math.Pow(x[i + 1], 2) + Math.Pow(x[i], 2))), 2) - 0.5 / (
                        0.001 * Math.Pow(x[i] - x[i + 1], 4) + 0.50
                    )));
            }

            return value;
        }

        // TODO:
        [FunctionName("Michalewicz’s function")]
        public double MichalewiczsFunction(double[] x)
        {
            var value = 0.0;

            for (int i = 0; i < x.Length; i++)
            {
                // value += (Math.Sin(x[i]) * Math.Pow(Math.Sin(((i + 1) * Math.Pow(x[i], 2)) / Math.PI), 20));

                //value += (-1 * (Math.Sin(x[i]) * Math.Pow(Math.Sin(Math.Pow(x[i], 2) / Math.PI), 20) + (
                //Math.Sin(x[i + 1]) * Math.Pow(Math.Sin(Math.Pow(2 * x[i + 1], 2) / Math.PI), 20)
                //)));

                value += (Math.Sin(x[i]) * Math.Pow(Math.Sin((i * Math.Pow(x[i], 2)) / Math.PI), 20));
            }

            return -1 * value;
        }

        [FunctionName("Master’s cosine wave function")]
        public double MastersCosineWaveFunction(double[] x)
        {
            var value = 0.0;

            for (int i = 0; i < x.Length - 1; i++)
            {
                var term = Math.Pow(x[i], 2) + Math.Pow(x[i + 1], 2) + 0.5 * x[i] * x[i + 1];

                value += (Math.Pow(Math.E, (-1 * (term)) / 8) *
                    (Math.Cos(4 * Math.Sqrt(term))));
            }

            return value;
        }

        // TODO: Tea? :D
        [FunctionName("df")]
        public double deleni(double[] x)
        {
            var g = 1;

            if (10 * x[0] + 6 * x[1] + 5 * 0 <= 2850)
            {
                g = 1;
            }

            if (4 * x[1] + 5 * 0 <= 1380 == false)
            {
                g = -100;
            }

            var value = (-1 * (2 * x[0] + 3 * x[1] + 2 * 0)) * g;

            return value;
        }

        /*
        * Functions for protocol No.3
        **/

        private double f1(double x1)
        {
            return x1;
        }

        private double g(double x2)
        {
            return 10 + x2;
        }

        private double Alpha(double x2)
        {
            var g1 = 11;
            var g2 = 12;

            return 0.25 + (3.75 * ((g(x2) - g2) / (g1 - g2)));
        }

        [FunctionName("Multipurpose optimization problem - parent borderline")]
        public double ParentBorderline(double[] x)
        {
            var value = 0.0;
            var F = 0.5;

            value += (Math.Pow(f1(x[0]) / g(x[1]), Alpha(x[1])) - (
                       (f1(x[0]) / g(x[1])) *
                               Math.Sin(Math.PI * F * f1(x[0]) * g(x[1]))
                       ));

            return value;
        }

        /*
        * END OF Functions for protocol No.3
        **/
    }
}
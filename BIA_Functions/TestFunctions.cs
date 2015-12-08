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

        [FunctionName("Pathological function")]
        public double PathologicalFunction(double[] x)
        {
            double result = 0;

            for (int i = 0; i < x.Length - 1; i++)
            {
                result += (0.5 + ((Math.Pow(Math.Sin(Math.Sqrt(100 * Math.Pow(x[i], 2) - Math.Pow(x[i + 1], 2))), 2) - 0.5) / (1 + 0.001 * Math.Pow(Math.Pow(x[i], 2) - 2 * x[i] * x[i + 1] + Math.Pow(x[i + 1], 2), 2))));
            }

            return result;
        }

        [FunctionName("Michalewicz’s function")]
        public double MichalewiczsFunction(double[] x)
        {
            double result = 0;

            for (int i = 0; i < x.Length - 1; i++)
            {
                result += (-1 * (Math.Sin(x[i]) * Math.Pow(Math.Sin(Math.Pow(x[i], 2) / Math.PI), 20) + Math.Sin(x[i + 1]) * Math.Pow(Math.Sin(2 * Math.Pow(x[i], 2) / Math.PI), 20)));
            }

            return result;
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

        [FunctionName("Problém dělení čaje")]
        public double deleni(double[] x)
        {
            var g = -100;

            if (((10 * x[0]) + (6 * x[1]) + (5 * 0)) <= 2850
                && ((4 * x[1]) + (5 * 0)) <= 1380)
            {
                g = 1;
            }

            var value = (-1 * (2 * x[0] + 3 * x[1] + 2 * 0)) * g;

            return value;
        }

        [FunctionName("Shekel’s foxhole")]
        public double ShekelsFoxhole(double[] x)
        {
            var value = 0.0;
            double[] c = new double[30]
            {
                0.806, 0.517, 0.1, 0.908, 0.965, 0.669, 0.524, 0.902, 0.531, 0.876, 0.462, 0.491, 0.463,
                0.714, 0.352, 0.869, 0.813, 0.811, 0.828, 0.964, 0.789, 0.360, 0.369, 0.992, 0.332,
                0.817, 0.632, 0.883, 0.608, 0.326
            };

            double[,] a = new double[30, 10]
            {
                {9.681, 0.667, 4.783, 9.095, 3.517, 9.325, 6.544, 0.211, 5.122, 2.020},
                {9.400, 2.041, 3.788, 7.931, 2.882, 2.672, 3.568, 1.284, 7.033, 7.374},
                {8.025, 9.152, 5.114, 7.621, 4.564, 4.711, 2.996, 6.126, 0.734, 4.982},
                {2.196, 0.415, 5.649, 6.979, 9.510, 9.166, 6.304, 6.054, 9.377, 1.426},
                {8.074, 8.777, 3.467, 1.863, 6.708, 6.349, 4.534, 0.276, 7.633, 1.567},
                {7.650, 5.658, 0.720, 2.764, 3.278, 5.283, 7.474, 6.274, 1.409, 8.208},
                {1.256, 3.605, 8.623, 6.905, 4.584, 8.133, 6.071, 6.888, 4.187, 5.448},
                {8.314, 2.261, 4.224, 1.781, 4.124, 0.932, 8.129, 8.658, 1.208, 5.762},
                {0.226, 8.858, 1.420, 0.945, 1.622, 4.698, 6.228, 9.096, 0.972, 7.637},
                {7.305, 2.228, 1.242, 5.928, 9.133, 1.826, 4.060, 5.204, 8.713, 8.247},
                {0.652, 7.027, 0.508, 4.876, 8.807, 4.632, 5.808, 6.937, 3.291, 7.016},
                {2.699, 3.516, 5.874, 4.119, 4.461, 7.496, 8.817, 0.690, 6.593, 9.789},
                {8.327, 3.897, 2.017, 9.570, 9.825, 1.150, 1.395, 3.885, 6.354, 0.109},
                {2.132, 7.006, 7.136, 2.641, 1.882, 5.943, 7.273, 7.691, 2.880, 0.564},
                {4.707, 5.579, 4.080, 0.581, 9.698, 8.542, 8.077, 8.515, 9.231, 4.670},
                {8.304, 7.559, 8.567, 0.322, 7.128, 8.392, 1.472, 8.524, 2.277, 7.826},
                {8.632, 4.409, 4.832, 5.768, 7.050, 6.715, 1.711, 4.323, 4.405, 4.591},
                {4.887, 9.112, 0.170, 8.967, 9.693, 9.867, 7.508, 7.770, 8.382, 6.740},
                {2.440, 6.686, 4.299, 1.007, 7.008, 1.427, 9.398, 8.480, 9.950, 1.675},
                {6.306, 8.583, 6.084, 1.138, 4.350, 3.134, 7.853, 6.061, 7.457, 2.258},
                {0.652, 2.343, 1.370, 0.821, 1.310, 1.063, 0.689, 8.819, 8.833, 9.070},
                {5.558, 1.272, 5.756, 9.857, 2.279, 2.764, 1.284, 1.677, 1.244, 1.234},
                {3.352, 7.549, 9.817, 9.437, 8.687, 4.167, 2.570, 6.540, 0.228, 0.027},
                {8.798, 0.880, 2.370, 0.168, 1.701, 3.680, 1.231, 2.390, 2.499, 0.064},
                {1.460, 8.057, 1.336, 7.217, 7.914, 3.615, 9.981, 9.198, 5.292, 1.224},
                {0.432, 8.645, 8.774, 0.249, 8.081, 7.461, 4.416, 0.652, 4.002, 4.644},
                {0.679, 2.800, 5.523, 3.049, 2.968, 7.225, 6.730, 4.199, 9.614, 9.229},
                {4.263, 1.074, 7.286, 5.599, 8.291, 5.200, 9.214, 8.272, 4.398, 4.506},
                {9.496, 4.830, 3.150, 8.270, 5.079, 1.231, 5.731, 9.494, 1.883, 9.732},
                {4.138, 2.562, 2.532, 9.661, 5.611, 5.500, 6.886, 2.341, 9.699, 6.500}
            };

            for (int i = 0; i < 30; i++)
            {
                value += (1 / (c[i] + (
                        Math.Pow(x[0] - a[i, 0], 2) + Math.Pow(x[1] - a[i, 1], 2)
                    )));
            }

            return -1 * value;
        }

        [FunctionName("Pseudo-Dirakova funkce")]
        public double PseudoDirakovaFunkce(double[] x)
        {
            var value = 1.0;
            var s = 3.0;
            var o = new double[2] { 1, 1 };

            for (int i = 0; i < x.Length; i++)
            {
                value *= (Math.Sqrt(s / Math.PI) / Math.Pow(Math.E, s * Math.Pow(x[i] - o[i], 2)));
            }

            return value;
        }

        // TODO:
        [FunctionName("Fraktální funkce")]
        public double FraktálníFunkce()
        {
            var value = 0.0;

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
using System;
using System.Collections.Generic;

namespace BIA_Functions
{
    internal class SimulatedAnnealing
    {
        private float T = 2F;
        private int nt = 0;
        private float Tf = 0.05F;
        private float alpha = 0.95F;
        private float delta = 0.0F;
        private float r = 0.0F;
        private Random rnd = new Random();

        private List<Individual> _individuals;
        private Individual xBest = null;

        public float CurrentMin { get; set; }
        public float CurrentMax { get; set; }

        public float newXmin { get; set; }
        public float newXmax { get; set; }
        public float newYmin { get; set; }
        public float newYmax { get; set; }

        private bool startAlg = true;

        public void Set(List<Individual> individuals, float currentMin, float currentMax)
        {
            nt = individuals.Count;
            _individuals = individuals;

            if (startAlg)
            {
                newXmin = CurrentMin = currentMin;
                newXmax = CurrentMax = currentMax;
                startAlg = false;
            }
        }

        public Individual Step()
        {
            if (xBest == null)
            {
                xBest = _individuals[rnd.Next(nt - 1)];
            }

            var x0 = xBest;

            if (T > Tf)
            {
                for (int i = 0; i < nt; i++)
                {
                    var x = _individuals[rnd.Next(nt - 1)];
                    delta = x.Z - x0.Z;
                    if (delta < 0)
                    {
                        if (x.Z < xBest.Z)
                        {
                            xBest = x;
                        }
                    }
                    else
                    {
                        r = (float)rnd.NextDouble();
                        if (r < Math.Exp(-delta / T))
                        {
                            x0 = x;
                        }
                    }
                }

                T *= alpha;
                Distance();
            }

            return xBest;
        }

        private void Distance()
        {
            newXmin = xBest.X - (Math.Abs(CurrentMin) * T);
            newXmax = xBest.X + (CurrentMax * T);

            newXmin = Math.Abs(newXmin) > Math.Abs(CurrentMin) ? CurrentMin : newXmin;
            newXmax = Math.Abs(newXmax) > CurrentMax ? CurrentMax : newXmax;

            newYmin = xBest.Y - (Math.Abs(CurrentMin) * T);
            newYmax = xBest.Y + (CurrentMax * T);

            newYmin = Math.Abs(newYmin) > Math.Abs(CurrentMin) ? CurrentMin : newYmin;
            newYmax = Math.Abs(newYmax) > CurrentMax ? CurrentMax : newYmax;
        }
    }
}
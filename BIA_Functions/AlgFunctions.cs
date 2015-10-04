using System;

namespace BIA_Functions
{
    internal class AlgFunctions
    {
        public double Fitness(double x, double min, double max)
        {
            return (1 / (min - max) * (((1 - 0.01) * x) + ((min * 0.01) - max)));
        }
    }
}
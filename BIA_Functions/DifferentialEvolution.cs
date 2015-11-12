using System;
using System.Collections.Generic;
using System.Reflection;

namespace BIA_Functions
{
    internal class DifferentialEvolution
    {
        private float F = 0.7F;
        private float CR = 0.6F;
        private int NP;
        private List<int> indexes;
        private List<Individual> individuals;
        private Random random = new Random();
        private TestFunctions testFunction = new TestFunctions();
        private MethodInfo methodInfo;
        private float min;
        private float max;

        public List<Individual> newIndividuals { get; set; }

        public void Step(List<Individual> _individuals, MethodInfo _methodInfo, float _min, float _max)
        {
            min = _min;
            max = _max;
            methodInfo = _methodInfo;
            individuals = _individuals;
            NP = individuals.Count;
            // Index 0 in indexes represent actual individual
            indexes = new List<int>();
            newIndividuals = new List<Individual>();

            var i = 0;
            while (newIndividuals.Count < NP)
            {
                indexes.Clear();
                var individual = individuals[i]; // vyber i-tého jedince
                indexes.Add(individual.Id);
                GetNextThree(); // náhodná selekce tří jedinců z populace
                Vector v = Vectors();
                var newCost = RealizeMethod(new double[] { v.X, v.Y });

                // Test if new individual isnt out of graph range
                if (Math.Abs(v.X) > Math.Abs(max) || Math.Abs(v.X) > Math.Abs(min) ||
                    Math.Abs(v.Y) > Math.Abs(max) || Math.Abs(v.Y) > Math.Abs(min))
                {//||newIndividuals.Exists(m => m.Z == newCost)
                    continue;
                }

                if (newCost < individuals[indexes[0]].Z)
                {
                    var last = individuals[indexes[0]];
                    newIndividuals.Add(new Individual
                    {
                        Id = last.Id,
                        X = v.X,
                        Y = v.Y,
                        Z = newCost
                    });
                }
                else
                {
                    newIndividuals.Add(individuals[indexes[0]]);
                }

                i++;
            }
        }

        private Vector Vectors()
        {
            Vector v1 = new Vector();
            v1.X = individuals[indexes[1]].X - individuals[indexes[2]].X;
            v1.Y = individuals[indexes[1]].Y - individuals[indexes[2]].Y;

            Vector v2 = new Vector();
            v2.X *= F;
            v2.Y *= F;

            Vector v3 = new Vector();
            v3.X = v2.X + individuals[indexes[3]].X;
            v3.Y = v2.Y + individuals[indexes[3]].Y;

            Vector v4 = new Vector();

            var k = random.NextDouble();
            if (k < CR) v4.X = v3.X;
            else v4.X = individuals[indexes[0]].X;

            k = random.NextDouble();
            if (k < CR) v4.Y = v3.Y;
            else v4.Y = individuals[indexes[0]].Y;

            return v4;
        }

        public void GetNextThree()
        {
            while (indexes.Count < 4)
            {
                var index = random.Next(NP - 1);

                if (!indexes.Contains(index))
                {
                    indexes.Add(index);
                }
            }
        }

        private struct Vector
        {
            public float X { get; set; }
            public float Y { get; set; }
        }

        private float RealizeMethod(double[] x)
        {
            return Convert.ToSingle(methodInfo.Invoke(testFunction, new object[] { x }));
        }
    }
}
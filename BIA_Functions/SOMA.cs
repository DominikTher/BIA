using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BIA_Functions
{
    internal class SOMA
    {
        private float pathLength = 3;
        private float step = 0.11F;
        private double PRT = 0.5;
        private int popSize;
        private int migration;
        private float minDev = 0.001F;
        private List<Individual> individuals;
        private MethodInfo methodInfo;
        private Random random = new Random();
        private TestFunctions testFunction = new TestFunctions();

        public List<Individual> newIndividuals { get; set; }

        public SOMA(int migration)
        {
            this.migration = migration;
        }

        public void Step(List<Individual> individuals, MethodInfo methodInfo, float min, float max)
        {
            while (migration-- > 0)
            {
                newIndividuals = new List<Individual>();
                popSize = individuals.Count;
                this.individuals = individuals;
                this.methodInfo = methodInfo;
                var t = 0.01F;

                var bestIndividual = GetBestIndividual();
                //var bestIndividual = individuals[random.Next(0, popSize - 1)];

                for (int i = 0; i < popSize;)
                {
                    var individual = individuals[i];

                    var newBestIndividual = individual;

                    //while (t <= pathLength)
                    //{
                    var rnd = random.NextDouble();
                    var PRTVector = (rnd < PRT) ? 1 : 0;

                    var x = individual.X + (bestIndividual.X - individual.X) * t * PRTVector;
                    var y = individual.Y + (bestIndividual.Y - individual.Y) * t * PRTVector;

                    // Test if new individual isnt out of graph range
                    if (Math.Abs(x) > Math.Abs(max) || Math.Abs(x) > Math.Abs(min) ||
                        Math.Abs(y) > Math.Abs(max) || Math.Abs(y) > Math.Abs(min))
                    {//||newIndividuals.Exists(m => m.Z == newCost)
                        continue;
                    }

                    var newCost = RealizeMethod(new double[] { x, y });

                    if (newCost < newBestIndividual.Z)
                    {
                        newBestIndividual = new Individual
                        {
                            X = x,
                            Y = y,
                            Z = newCost
                        };
                    }

                    t += step;
                    //}

                    newIndividuals.Add(newBestIndividual);
                    i++;
                }

                if (minDev < Math.Abs(GetBestIndividual().Z - GetWorstIndividual().Z))
                {
                    migration = 0; // Stop SOMA
                }
            }
            //else
            //{
            //    newIndividuals = individuals;
            //}
        }

        private Individual GetBestIndividual()
        {
            return individuals.Aggregate((i1, i2) => i1.Z > i2.Z ? i1 : i2);
        }

        private Individual GetWorstIndividual()
        {
            return individuals.Aggregate((i1, i2) => i1.Z < i2.Z ? i1 : i2);
        }

        private float RealizeMethod(double[] x)
        {
            return Convert.ToSingle(methodInfo.Invoke(testFunction, new object[] { x }));
        }
    }
}
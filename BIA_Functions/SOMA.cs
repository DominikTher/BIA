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
        private float minDev = 0.02F;
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
            if (migration-- > 0)
            {
                newIndividuals = new List<Individual>();
                popSize = individuals.Count;
                this.methodInfo = methodInfo;

                var bestIndividual = GetBestIndividual(individuals);
                for (int i = 0; i < popSize; i++)
                {
                    List<Individual> newPositions = new List<Individual>();
                    var individual = individuals[i];

                    var t = 0.01F;
                    while (t <= pathLength)
                    {
                        var x = individual.X + (bestIndividual.X - individual.X) * t * PRTVectorX();
                        var y = individual.Y + (bestIndividual.Y - individual.Y) * t * PRTVectorY();

                        // Test if new individual isnt out of graph range
                        if (Math.Abs(x) > Math.Abs(max) || Math.Abs(x) > Math.Abs(min) ||
                            Math.Abs(y) > Math.Abs(max) || Math.Abs(y) > Math.Abs(min))
                        {//||newIndividuals.Exists(m => m.Z == newCost)
                            continue;
                        }

                        var newCost = RealizeMethod(new double[] { x, y });
                        newPositions.Add(new Individual
                        {
                            X = x,
                            Y = y,
                            Z = newCost
                        });

                        t += step;
                    }

                    var bestPosition = GetBestIndividual(newPositions);

                    if (bestPosition.Z < bestIndividual.Z)
                    {
                        newIndividuals.Add(new Individual
                        {
                            Id = i,
                            X = bestPosition.X,
                            Y = bestPosition.Y,
                            Z = bestPosition.Z
                        });
                    }
                    else
                    {
                        newIndividuals.Add(new Individual
                        {
                            Id = i,
                            X = bestIndividual.X,
                            Y = bestIndividual.Y,
                            Z = bestIndividual.Z
                        });
                    }
                }

                //MessageBox.Show(Math.Abs(GetBestIndividual(newIndividuals).Z - GetWorstIndividual(newIndividuals).Z).ToString());

                if (minDev > Math.Abs(GetBestIndividual(newIndividuals).Z - GetWorstIndividual(newIndividuals).Z))
                {
                    migration = 0; // Stop SOMA
                }
            }
            else
            {
                newIndividuals = new List<Individual>(individuals);
            }
        }

        private int PRTVectorX()
        {
            var rnd = random.NextDouble();
            var PRTVectorX = (rnd < PRT) ? 1 : 0;

            return PRTVectorX;
        }

        private int PRTVectorY()
        {
            var rnd2 = random.NextDouble();
            var PRTVectorY = (rnd2 < PRT) ? 1 : 0;

            return PRTVectorY;
        }

        private Individual GetBestIndividual(List<Individual> _some)
        {
            return _some.Aggregate((i1, i2) => i1.Z < i2.Z ? i1 : i2);
        }

        private Individual GetWorstIndividual(List<Individual> _some)
        {
            return _some.Aggregate((i1, i2) => i1.Z > i2.Z ? i1 : i2);
        }

        private float RealizeMethod(double[] x)
        {
            return Convert.ToSingle(methodInfo.Invoke(testFunction, new object[] { x }));
        }
    }
}
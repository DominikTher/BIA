using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace BIA_Functions
{
    internal enum Algorithms
    {
        None,
        BlindSearch
    }

    internal class Graph
    {
        private float Min { get; set; }

        private float Max { get; set; }

        private MethodInfo MethodInfo { get; set; }

        private int NumberOfIndividuals { get; set; }

        public bool OnlyIntegers { get; set; }

        private TestFunctions testFunctions = new TestFunctions();

        public List<Individual> Individuals { get; private set; }

        public Algorithms Algorithm { get; private set; }

        private ILScene scene;
        private ILPoints points;
        private ILSurface surface;
        private ILPlotCube plotCube;
        private Individual bestIndividual;

        public void Set(float min, float max, int numberOfIndividuals, bool onlyIntegers, Algorithms algorithm, MethodInfo methodInfo)
        {
            Min = min;
            Max = max;
            MethodInfo = methodInfo;
            NumberOfIndividuals = numberOfIndividuals;
            OnlyIntegers = onlyIntegers;
            Algorithm = algorithm;

            if (Individuals != null && Individuals.Any())
            {
                bestIndividual = GetBestIndividual();
            }

            Individuals = new List<Individual>();
        }

        public void SetSurface()
        {
            points = new ILPoints();
            points.Size = 10;
            points.Color = null;

            scene = new ILScene();
            plotCube = new ILPlotCube(twoDMode: false);

            surface = new ILSurface(
                            (x, y) =>
                            {
                                return Calculate(new double[] { x, y });
                            },
                            xmin: Min, xmax: Max, xlen: 100,
                            ymin: Min, ymax: Max, ylen: 100,
                            colormap: Colormaps.ILNumerics
                        );

            plotCube.Add(surface);
        }

        public void SetIndividuals()
        {
            switch (Algorithm)
            {
                case Algorithms.None:
                case Algorithms.BlindSearch:
                    NextIndividuals();
                    break;

                default:
                    break;
            }

            if (Individuals.Any())
            {
                var max = Individuals.Max(m => m.Z);
                var min = Individuals.Min(m => m.Z);

                for (int i = 0; i < Individuals.Count; i++)
                {
                    Individuals[i].Fitness = (float)AlgFunctions.Fitness(Individuals[i].Z, min, max);
                    points.Colors.Update(i, Color.Black);
                }

                plotCube.Add(points);
            }
        }

        public void MarkIndividual(int individualId)
        {
            for (int i = 0; i < Individuals.Count; i++)
            {
                if (i == individualId)
                    points.Colors.Update(i, Color.LightGray);
                else
                    points.Colors.Update(i, Color.Black);
            }

            points.Configure();
        }

        private void NextIndividuals()
        {
            int count = NumberOfIndividuals;

            if (Algorithm == Algorithms.BlindSearch)
            {
                bestIndividual.Id = count - 1;
                Individuals.Add(bestIndividual);
                count = NumberOfIndividuals - 1;
                points.Positions.Update(count, 1, new float[] { bestIndividual.X, bestIndividual.Y, bestIndividual.Z });
            }

            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                var x = (float)NextDouble(random, Min, Max);
                var y = (float)NextDouble(random, Min, Max);

                if (OnlyIntegers)
                {
                    x = (float)Math.Round(x);
                    y = (float)Math.Round(y);
                }

                TestFunctions testFunctions = new TestFunctions();
                var z = RealizeMethod(new double[] { x, y });

                Individual individual = new Individual { Id = i, X = x, Y = y, Z = z };
                Individuals.Add(individual);
                points.Positions.Update(i, 1, new float[] { individual.X, individual.Y, individual.Z });
            }
        }

        private Individual GetBestIndividual()
        {
            return Individuals.Aggregate((i1, i2) => i1.Fitness > i2.Fitness ? i1 : i2);
        }

        public ILScene GetScene()
        {
            scene.Camera.Add(plotCube);

            return scene;
        }

        private float Calculate(double[] x)
        {
            return RealizeMethod(x);
        }

        private double NextDouble(Random rng, double min, double max)
        {
            return min + (rng.NextDouble() * (max - min));
        }

        private float RealizeMethod(double[] x)
        {
            return Convert.ToSingle(MethodInfo.Invoke(testFunctions, new object[] { x }));
        }
    }
}
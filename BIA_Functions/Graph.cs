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
        BlindSearch,
        SimulatedAnnealing,
        DifferentialEvolution,
        SOMA
    }

    internal class Graph
    {
        private float Min { get; set; }
        private float Max { get; set; }

        private float newXmin { get; set; }
        private float newXmax { get; set; }
        private float newYmin { get; set; }
        private float newYmax { get; set; }

        private MethodInfo MethodInfo { get; set; }

        private int NumberOfIndividuals { get; set; }

        public bool OnlyIntegers { get; set; }

        private TestFunctions testFunctions = new TestFunctions();

        public List<Individual> Individuals { get; private set; }

        public Algorithms Algorithm { get; private set; }

        private SimulatedAnnealing simulatedAnnealing;
        private DifferentialEvolution differentialEvolution;
        private SOMA soma;

        private ILScene scene;
        private ILPoints points;
        private ILSurface surface;
        private ILPlotCube plotCube;
        private Individual bestIndividual;

        public Graph()
        {
            Individuals = new List<Individual>();
            bestIndividual = null;
        }

        public void Set(float min, float max, int numberOfIndividuals, bool onlyIntegers, Algorithms algorithm, MethodInfo methodInfo)
        {
            newYmin = newXmin = Min = min;
            newYmax = newXmax = Max = max;
            MethodInfo = methodInfo;
            NumberOfIndividuals = numberOfIndividuals;
            OnlyIntegers = onlyIntegers;
            Algorithm = algorithm;
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
                    bestIndividual = null;
                    Reset();
                    Individuals.Clear();
                    NextIndividuals();
                    break;

                case Algorithms.BlindSearch:
                    bestIndividual = GetBestIndividual();
                    Individuals.Clear();
                    NextIndividuals();
                    break;

                case Algorithms.SimulatedAnnealing:
                    simulatedAnnealing.Set(Individuals, Min, Max);
                    bestIndividual = simulatedAnnealing.Step();
                    newXmin = simulatedAnnealing.newXmin;
                    newXmax = simulatedAnnealing.newXmax;
                    newYmin = simulatedAnnealing.newYmin;
                    newYmax = simulatedAnnealing.newYmax;
                    Individuals.Clear();
                    NextIndividuals();
                    break;

                case Algorithms.DifferentialEvolution:
                    differentialEvolution.Step(Individuals, MethodInfo, Min, Max);
                    Individuals.Clear();
                    Individuals = differentialEvolution.newIndividuals;
                    break;

                case Algorithms.SOMA:
                    soma.Step(Individuals, MethodInfo, Min, Max);
                    Individuals.Clear();
                    Individuals = soma.newIndividuals;
                    break;
            }

            if (Individuals.Any())
            {
                var i = 0;
                foreach (var item in Individuals)
                {
                    UpdatePoints(i++, item);
                }
            }

            ToFitness();
        }

        private void Reset()
        {
            simulatedAnnealing = new SimulatedAnnealing();
            differentialEvolution = new DifferentialEvolution();
            soma = new SOMA(200);
        }

        public void ToFitness()
        {
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

            if (bestIndividual != null)
            {
                count = NumberOfIndividuals - 1;
                bestIndividual.Id = count;
                Individuals.Add(bestIndividual);
                //UpdatePoints(count, bestIndividual);
                //points.Positions.Update(count, 1, new float[] { bestIndividual.X, bestIndividual.Y, bestIndividual.Z });
            }

            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                var x = (float)NextDouble(random, newXmin, newXmax);
                var y = (float)NextDouble(random, newYmin, newYmax);

                if (OnlyIntegers)
                {
                    x = (float)Math.Round(x);
                    y = (float)Math.Round(y);
                }

                TestFunctions testFunctions = new TestFunctions();
                var z = RealizeMethod(new double[] { x, y });

                Individual individual = new Individual { Id = i, X = x, Y = y, Z = z };
                Individuals.Add(individual);
                //UpdatePoints(i, individual);
                //points.Positions.Update(i, 1, new float[] { individual.X, individual.Y, individual.Z });
            }
        }

        private void UpdatePoints(int startColumn, Individual individual)
        {
            points.Positions.Update(startColumn, 1, new float[] { individual.X, individual.Y, individual.Z });
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
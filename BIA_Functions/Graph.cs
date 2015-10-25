﻿using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace BIA_Functions
{
    internal class Graph
    {
        private float Min { get; set; }

        private float Max { get; set; }

        private MethodInfo MethodInfo { get; set; }

        private int NumberOfIndividuals { get; set; }

        public bool OnlyIntegers { get; set; }

        private TestFunctions testFunctions = new TestFunctions();

        public List<Individual> Individuals { get; private set; }

        private ILScene scene;
        private ILPoints points;
        private ILSurface surface;
        private ILPlotCube plotCube;

        public void Set(float min, float max, int numberOfIndividuals, bool onlyIntegers, MethodInfo methodInfo)
        {
            Min = min;
            Max = max;
            MethodInfo = methodInfo;
            NumberOfIndividuals = numberOfIndividuals;
            OnlyIntegers = onlyIntegers;

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
                                if (OnlyIntegers)
                                    //return (float)Math.Round(Calculate(new double[] { x, y }));
                                    //return Calculate(new double[] { Math.Round(x), Math.Round(x) });
                                    return Calculate(new double[] { x, y });
                                else
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
            //GenerateIndividuals(surface);

            Random random = new Random();
            for (int i = 0; i < NumberOfIndividuals; i++)
            {
                var x = (float)NextDouble(random, Min, Max);
                var y = (float)NextDouble(random, Min, Max);

                TestFunctions testFunctions = new TestFunctions();
                var z = RealizeMethod(new double[] { x, y });

                if (OnlyIntegers)
                    Individuals.Add(new Individual { Id = i, X = (float)Math.Round(x), Y = (float)Math.Round(y), Fitness = z });
                else
                    Individuals.Add(new Individual { Id = i, X = x, Y = y, Fitness = z });

                points.Positions.Update(i, 1, new float[] { x, y, z });
            }

            for (int i = 0; i < Individuals.Count; i++)
            {
                points.Colors.Update(i, Color.Black);
            }

            if (Individuals.Any())
            {
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

        //private void GenerateIndividuals(ILSurface surface)
        //{
        //    Random random = new Random();
        //    List<int> randomPointsIndex = new List<int>();

        //    int i = 0;

        //    while (randomPointsIndex.Count != NumberOfIndividuals)
        //    {
        //        var index = random.Next(0, surface.Wireframe.Positions.DataCount - 1);
        //        if (!randomPointsIndex.Contains(index))
        //        {
        //            randomPointsIndex.Add(index);
        //            var vector = surface.Wireframe.Positions.GetPositionAt(index);
        //            var individual = new Individual { Id = i, X = vector.X, Y = vector.Y, Fitness = vector.Z };

        //            if (OnlyIntegers)
        //            {
        //                individual.X = (float)Math.Round(individual.X);
        //                individual.Y = (float)Math.Round(individual.Y);
        //            }

        //            Individuals.Add(individual);
        //            points.Positions.Update(i++, 1, new float[] { individual.X, individual.Y, individual.Fitness });
        //        }
        //    }
        //}
    }
}
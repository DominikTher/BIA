using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using System;
using System.Reflection;

namespace BIA_Functions
{
    internal class Graph
    {
        public float Min { get; private set; }

        public float Max { get; private set; }

        public MethodInfo MethodInfo { get; private set; }

        private TestFunctions testFunctions = new TestFunctions();

        public void Set(float min, float max, MethodInfo methodInfo)
        {
            Min = min;
            Max = max;
            MethodInfo = methodInfo;
        }

        public ILScene Print()
        {
            var scene = new ILScene();
            var plotCube = new ILPlotCube(twoDMode: false);

            var surface = new ILSurface(
                        (x, y) => Calculate(new double[] { x, y }),
                        xmin: Min, xmax: Max, xlen: 80,
                        ymin: Min, ymax: Max, ylen: 80,
                        colormap: Colormaps.ILNumerics
                        );

            plotCube.Add(surface);
            scene.Camera.Add(plotCube);

            return scene;
        }

        private float Calculate(double[] x)
        {
            var returnedValue = MethodInfo.Invoke(testFunctions, new object[] { x });

            return Convert.ToSingle(returnedValue);
        }
    }
}
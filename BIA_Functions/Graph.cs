using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using System;
using System.Reflection;

namespace BIA_Functions
{
    internal class Graph
    {
        public float x_min { get; private set; }

        public float x_max { get; private set; }

        public float y_min { get; private set; }

        public float y_max { get; private set; }

        public MethodInfo MethodInfo { get; private set; }

        private TestFunctions testFunctions = null;

        public Graph()
        {
            // TODO: Check null ??
            testFunctions = Activator.CreateInstance(typeof(TestFunctions)) as TestFunctions;
        }

        public void Set(float xmin, float xmax, float ymin, float ymax, MethodInfo methodInfo)
        {
            x_min = xmin;
            x_max = xmax;
            y_min = ymin;
            y_max = ymax;
            MethodInfo = methodInfo;
        }

        public ILScene Print()
        {
            var scene = new ILScene();
            var plotCube = new ILPlotCube(twoDMode: false);

            var surface = new ILSurface(
                        (x, y) => Calculate(new double[] { x, y }),
                        xmin: x_min, xmax: x_max,
                        ymin: y_min, ymax: y_max,
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
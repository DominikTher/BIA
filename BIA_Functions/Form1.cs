using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace BIA_Functions
{
    public partial class Form1 : Form
    {
        private Dictionary<string, MethodInfo> testFunctionsNames = new Dictionary<string, MethodInfo>();

        private Graph graph = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        /// <summary>
        /// Print graph for specific function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            PrintGraph();
        }

        private void PrintGraph()
        {
            if (graph == null)
            {
                // TODO: Load or check null?
                graph = new Graph();
            }

            graph.Set(
                TextToFloat(textBox1.Text),
                TextToFloat(textBox3.Text),
                TextToFloat(textBox2.Text),
                TextToFloat(textBox4.Text),
                testFunctionsNames[comboBox1.SelectedItem.ToString()]);

            ilPanel1.Scene = graph.Print();
            ilPanel1.Scene.First<ILPlotCube>().Rotation = Matrix4.Rotation(new Vector3(1, 0, 0), Math.PI / 2); // TODO: WTF is this?
            ilPanel1.Refresh();
        }

        private void FillComboBox()
        {
            var methods = typeof(TestFunctions).GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly);

            foreach (var method in methods)
            {
                var attribute = method.GetCustomAttributes(typeof(FunctionNameAttribute), false);

                FunctionNameAttribute functionNameAttribute = attribute[0] as FunctionNameAttribute;

                testFunctionsNames[functionNameAttribute.Name] = method;
                comboBox1.Items.Add(functionNameAttribute.Name);
            }

            comboBox1.SelectedIndex = 0;
        }

        private float TextToFloat(string text)
        {
            return Convert.ToSingle(text);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            PrintGraph();
        }
    }
}
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

        private Graph graph = new Graph();

        private Form1 form = null;

        public Form1()
        {
            InitializeComponent();
            form = this;
            FillComboBox();
        }

        private void ilPanel1_Load(object sender, EventArgs e)
        {
            PrintGraph();
        }

        private void PrintGraph()
        {
            graph.Set(
                TextToFloat(tb_xmin.Text),
                TextToFloat(tb_xmax.Text),
                TextToFloat(tb_ymin.Text),
                TextToFloat(tb_ymax.Text),
                testFunctionsNames[comboBox1.SelectedItem.ToString()]);

            ilPanel1.Scene = graph.Print();
            ilPanel1.Scene.First<ILPlotCube>().Rotation = Matrix4.Rotation(new Vector3(1f, 0.23f, 1), 0.7f);
            ilPanel1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintGraph();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Multipurpose optimization problem - parent borderline")
            {
                BorderLineValues();
            }
            else
            {
                DefaultFunctionValues();
            }

            form.Text = "BIA - " + comboBox1.SelectedItem.ToString();
            PrintGraph();
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

        private void DefaultFunctionValues()
        {
            tb_xmin.Text = "-2";
            tb_xmax.Text = "2";

            tb_ymin.Text = "-2";
            tb_ymax.Text = "2";
        }

        private void BorderLineValues()
        {
            tb_xmin.Text = "0";
            tb_xmax.Text = "1,25";

            tb_ymin.Text = "1";
            tb_ymax.Text = "0,999";
        }
    }
}
﻿using ILNumerics.Drawing;
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

        private Algorithms algorithm = Algorithms.None;

        public Form1()
        {
            InitializeComponent();
            form = this;
            FillComboBox();
        }

        private void ilPanel1_Load(object sender, EventArgs e)
        {
            //PrintGraph();
        }

        private void PrintGraph()
        {
            graph.Set(
                TextToFloat(tb_min.Text),
                TextToFloat(tb_max.Text),
                Convert.ToInt32(individualsNo.Text),
                chbOnlyIntegers.Checked,
                algorithm,
                testFunctionsNames[comboBox1.SelectedItem.ToString()]);

            graph.SetSurface();
            graph.SetIndividuals();
            ilPanel1.Scene = graph.GetScene();
            RefreshGraph();

            dataGridView1.DataSource = graph.Individuals;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintGraph();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
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

            foreach (var alg in Enum.GetValues(typeof(Algorithms)))
            {
                AlgorithmsSelect.Items.Add(alg.ToString());
                AlgorithmsSelect.SelectedIndex = 0;
            }
        }

        private float TextToFloat(string text)
        {
            return Convert.ToSingle(text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;

            if (dataGridView.CurrentRow.Selected)
            {
                int rowindex = dataGridView.CurrentCell.RowIndex;
                var id = dataGridView.Rows[rowindex].Cells[0].Value.ToString();

                graph.MarkIndividual(Convert.ToInt32(id));

                ilPanel1.Refresh();
            }
        }

        private void RefreshGraph()
        {
            ilPanel1.Scene.First<ILPlotCube>().Rotation = Matrix4.Rotation(new Vector3(1f, 0.23f, 1), 0.7f);
            ilPanel1.Refresh();
        }

        private void stepBtn_Click(object sender, EventArgs e)
        {
            PrintGraph();
        }

        private void AlgorithmsSelect_SelectedValueChanged(object sender, EventArgs e)
        {
            algorithm = (Algorithms)Enum.Parse(typeof(Algorithms), AlgorithmsSelect.SelectedItem.ToString());
        }
    }
}
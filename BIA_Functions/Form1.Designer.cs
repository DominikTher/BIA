namespace BIA_Functions
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ilPanel1 = new ILNumerics.Drawing.ILPanel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_min = new System.Windows.Forms.TextBox();
            this.tb_max = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.individualsNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.ilPanel1);
            this.panel1.Location = new System.Drawing.Point(306, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(745, 494);
            this.panel1.TabIndex = 0;
            // 
            // ilPanel1
            // 
            this.ilPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ilPanel1.Driver = ILNumerics.Drawing.RendererTypes.OpenGL;
            this.ilPanel1.Editor = null;
            this.ilPanel1.Location = new System.Drawing.Point(0, 0);
            this.ilPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ilPanel1.Name = "ilPanel1";
            this.ilPanel1.Rectangle = ((System.Drawing.RectangleF)(resources.GetObject("ilPanel1.Rectangle")));
            this.ilPanel1.ShowUIControls = false;
            this.ilPanel1.Size = new System.Drawing.Size(745, 494);
            this.ilPanel1.TabIndex = 0;
            this.ilPanel1.Load += new System.EventHandler(this.ilPanel1_Load);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(99, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(201, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select function:";
            // 
            // tb_min
            // 
            this.tb_min.Location = new System.Drawing.Point(38, 19);
            this.tb_min.Name = "tb_min";
            this.tb_min.Size = new System.Drawing.Size(94, 20);
            this.tb_min.TabIndex = 7;
            this.tb_min.Text = "-2";
            // 
            // tb_max
            // 
            this.tb_max.Location = new System.Drawing.Point(167, 19);
            this.tb_max.Name = "tb_max";
            this.tb_max.Size = new System.Drawing.Size(86, 20);
            this.tb_max.TabIndex = 9;
            this.tb_max.Text = "2";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(214, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 32);
            this.button1.TabIndex = 11;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // individualsNo
            // 
            this.individualsNo.Location = new System.Drawing.Point(126, 39);
            this.individualsNo.Name = "individualsNo";
            this.individualsNo.Size = new System.Drawing.Size(174, 20);
            this.individualsNo.TabIndex = 12;
            this.individualsNo.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Number of individuals";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_min);
            this.groupBox1.Controls.Add(this.tb_max);
            this.groupBox1.Location = new System.Drawing.Point(15, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 56);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Range";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 305);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(285, 201);
            this.dataGridView1.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 518);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.individualsNo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "BIA";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ILNumerics.Drawing.ILPanel ilPanel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_min;
        private System.Windows.Forms.TextBox tb_max;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox individualsNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}


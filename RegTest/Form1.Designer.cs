namespace RegTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            textBoxInput = new TextBox();
            groupBox1 = new GroupBox();
            splitContainerMarkUpBox = new SplitContainer();
            tableLayoutPanel2 = new TableLayoutPanel();
            buttonFullMarkUp = new Button();
            buttonStepMarkUp = new Button();
            splitContainer1 = new SplitContainer();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            buttonRunProccessing = new Button();
            checkBoxIsBuildProccesFlow = new CheckBox();
            labelResultNFA = new Label();
            labelResultMNFA = new Label();
            textBoxInputText = new TextBox();
            groupBoxSettings = new GroupBox();
            buttonRunSimpleMinimization = new Button();
            buttonRunBuildFA = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dataGridViewTableNFA = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            tabPage2 = new TabPage();
            panelGraphFA = new Panel();
            panel1 = new Panel();
            pictureBoxGraphNFA = new PictureBox();
            tabPage3 = new TabPage();
            panel2 = new Panel();
            pictureBoxGraphProcessing = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMarkUpBox).BeginInit();
            splitContainerMarkUpBox.Panel1.SuspendLayout();
            splitContainerMarkUpBox.Panel2.SuspendLayout();
            splitContainerMarkUpBox.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            groupBoxSettings.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTableNFA).BeginInit();
            tabPage2.SuspendLayout();
            panelGraphFA.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGraphNFA).BeginInit();
            tabPage3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGraphProcessing).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1165, 232);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // textBoxInput
            // 
            textBoxInput.Anchor = AnchorStyles.None;
            textBoxInput.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxInput.Location = new Point(234, 8);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.Size = new Size(901, 29);
            textBoxInput.TabIndex = 2;
            textBoxInput.TextChanged += textBoxInput_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(splitContainerMarkUpBox);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1171, 304);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Разметка выражения";
            // 
            // splitContainerMarkUpBox
            // 
            splitContainerMarkUpBox.Dock = DockStyle.Fill;
            splitContainerMarkUpBox.Location = new Point(3, 19);
            splitContainerMarkUpBox.Name = "splitContainerMarkUpBox";
            splitContainerMarkUpBox.Orientation = Orientation.Horizontal;
            // 
            // splitContainerMarkUpBox.Panel1
            // 
            splitContainerMarkUpBox.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainerMarkUpBox.Panel2
            // 
            splitContainerMarkUpBox.Panel2.Controls.Add(tableLayoutPanel2);
            splitContainerMarkUpBox.Size = new Size(1165, 282);
            splitContainerMarkUpBox.SplitterDistance = 232;
            splitContainerMarkUpBox.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 135F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 201F));
            tableLayoutPanel2.Controls.Add(textBoxInput, 2, 0);
            tableLayoutPanel2.Controls.Add(buttonFullMarkUp, 0, 0);
            tableLayoutPanel2.Controls.Add(buttonStepMarkUp, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1165, 46);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // buttonFullMarkUp
            // 
            buttonFullMarkUp.Anchor = AnchorStyles.None;
            buttonFullMarkUp.Location = new Point(3, 8);
            buttonFullMarkUp.Name = "buttonFullMarkUp";
            buttonFullMarkUp.Size = new Size(129, 29);
            buttonFullMarkUp.TabIndex = 3;
            buttonFullMarkUp.Text = "Разметить";
            buttonFullMarkUp.UseVisualStyleBackColor = true;
            buttonFullMarkUp.Click += buttonFullMarkUp_Click;
            // 
            // buttonStepMarkUp
            // 
            buttonStepMarkUp.Anchor = AnchorStyles.None;
            buttonStepMarkUp.Location = new Point(138, 8);
            buttonStepMarkUp.Name = "buttonStepMarkUp";
            buttonStepMarkUp.Size = new Size(64, 29);
            buttonStepMarkUp.TabIndex = 4;
            buttonStepMarkUp.Text = "Шаг";
            buttonStepMarkUp.UseVisualStyleBackColor = true;
            buttonStepMarkUp.Click += buttonRun_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(4, 307);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1.Controls.Add(groupBoxSettings);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabControl1);
            splitContainer1.Size = new Size(1164, 456);
            splitContainer1.SplitterDistance = 279;
            splitContainer1.TabIndex = 6;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(textBoxInputText);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Enabled = false;
            groupBox2.Location = new Point(0, 76);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(279, 380);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Распознание цепочек";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(tableLayoutPanel3);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(3, 170);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(273, 207);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Моделирование";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.6666641F));
            tableLayoutPanel3.Controls.Add(checkBoxIsBuildProccesFlow, 0, 2);
            tableLayoutPanel3.Controls.Add(labelResultNFA, 0, 0);
            tableLayoutPanel3.Controls.Add(labelResultMNFA, 0, 1);
            tableLayoutPanel3.Controls.Add(buttonRunProccessing, 0, 3);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 19);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 54.2857132F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 45.7142868F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel3.Size = new Size(267, 185);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // buttonRunProccessing
            // 
            buttonRunProccessing.Dock = DockStyle.Fill;
            buttonRunProccessing.Location = new Point(3, 142);
            buttonRunProccessing.Name = "buttonRunProccessing";
            buttonRunProccessing.Size = new Size(261, 40);
            buttonRunProccessing.TabIndex = 1;
            buttonRunProccessing.Text = "Обработать текст";
            buttonRunProccessing.UseVisualStyleBackColor = true;
            buttonRunProccessing.Click += buttonRunProccessing_Click;
            // 
            // checkBoxIsBuildProccesFlow
            // 
            checkBoxIsBuildProccesFlow.Anchor = AnchorStyles.Left;
            checkBoxIsBuildProccesFlow.AutoSize = true;
            checkBoxIsBuildProccesFlow.Checked = true;
            checkBoxIsBuildProccesFlow.CheckState = CheckState.Checked;
            checkBoxIsBuildProccesFlow.Location = new Point(3, 111);
            checkBoxIsBuildProccesFlow.Name = "checkBoxIsBuildProccesFlow";
            checkBoxIsBuildProccesFlow.Size = new Size(211, 19);
            checkBoxIsBuildProccesFlow.TabIndex = 2;
            checkBoxIsBuildProccesFlow.Text = "Строить граф потокоа обработки";
            checkBoxIsBuildProccesFlow.UseVisualStyleBackColor = true;
            // 
            // labelResultNFA
            // 
            labelResultNFA.AutoSize = true;
            labelResultNFA.Dock = DockStyle.Fill;
            labelResultNFA.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelResultNFA.Location = new Point(3, 0);
            labelResultNFA.Name = "labelResultNFA";
            labelResultNFA.Size = new Size(261, 55);
            labelResultNFA.TabIndex = 3;
            labelResultNFA.Text = "НКА: ";
            labelResultNFA.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelResultMNFA
            // 
            labelResultMNFA.AutoSize = true;
            labelResultMNFA.Dock = DockStyle.Fill;
            labelResultMNFA.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelResultMNFA.Location = new Point(3, 55);
            labelResultMNFA.Name = "labelResultMNFA";
            labelResultMNFA.Size = new Size(261, 47);
            labelResultMNFA.TabIndex = 4;
            labelResultMNFA.Text = "МНКА:  ";
            labelResultMNFA.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxInputText
            // 
            textBoxInputText.Dock = DockStyle.Top;
            textBoxInputText.Location = new Point(3, 19);
            textBoxInputText.Multiline = true;
            textBoxInputText.Name = "textBoxInputText";
            textBoxInputText.ScrollBars = ScrollBars.Both;
            textBoxInputText.Size = new Size(273, 151);
            textBoxInputText.TabIndex = 0;
            // 
            // groupBoxSettings
            // 
            groupBoxSettings.Controls.Add(buttonRunSimpleMinimization);
            groupBoxSettings.Controls.Add(buttonRunBuildFA);
            groupBoxSettings.Dock = DockStyle.Top;
            groupBoxSettings.Location = new Point(0, 0);
            groupBoxSettings.Name = "groupBoxSettings";
            groupBoxSettings.Size = new Size(279, 76);
            groupBoxSettings.TabIndex = 0;
            groupBoxSettings.TabStop = false;
            groupBoxSettings.Text = "Построение КА";
            // 
            // buttonRunSimpleMinimization
            // 
            buttonRunSimpleMinimization.Enabled = false;
            buttonRunSimpleMinimization.Location = new Point(137, 22);
            buttonRunSimpleMinimization.Name = "buttonRunSimpleMinimization";
            buttonRunSimpleMinimization.Size = new Size(136, 43);
            buttonRunSimpleMinimization.TabIndex = 1;
            buttonRunSimpleMinimization.Text = "Простая минимизация";
            buttonRunSimpleMinimization.UseVisualStyleBackColor = true;
            buttonRunSimpleMinimization.Click += buttonRunSimpleMinimization_Click;
            // 
            // buttonRunBuildFA
            // 
            buttonRunBuildFA.Enabled = false;
            buttonRunBuildFA.Location = new Point(8, 22);
            buttonRunBuildFA.Name = "buttonRunBuildFA";
            buttonRunBuildFA.Size = new Size(128, 43);
            buttonRunBuildFA.TabIndex = 0;
            buttonRunBuildFA.Text = "Построить КА";
            buttonRunBuildFA.UseVisualStyleBackColor = true;
            buttonRunBuildFA.Click += buttonRunBuildFA_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(881, 456);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridViewTableNFA);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(873, 428);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Табличное представление КА";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTableNFA
            // 
            dataGridViewTableNFA.AllowUserToAddRows = false;
            dataGridViewTableNFA.BackgroundColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.DarkOrange;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.InfoText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewTableNFA.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewTableNFA.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTableNFA.Columns.AddRange(new DataGridViewColumn[] { Column1 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewTableNFA.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewTableNFA.Dock = DockStyle.Fill;
            dataGridViewTableNFA.EnableHeadersVisualStyles = false;
            dataGridViewTableNFA.GridColor = SystemColors.GrayText;
            dataGridViewTableNFA.Location = new Point(3, 3);
            dataGridViewTableNFA.Name = "dataGridViewTableNFA";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = Color.DarkOrange;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.InfoText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridViewTableNFA.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewTableNFA.RowHeadersWidth = 100;
            dataGridViewTableNFA.RowTemplate.Height = 25;
            dataGridViewTableNFA.Size = new Size(867, 422);
            dataGridViewTableNFA.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.Name = "Column1";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panelGraphFA);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(873, 428);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Граф переходов КА";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelGraphFA
            // 
            panelGraphFA.AutoScroll = true;
            panelGraphFA.Controls.Add(panel1);
            panelGraphFA.Dock = DockStyle.Fill;
            panelGraphFA.Location = new Point(3, 3);
            panelGraphFA.Name = "panelGraphFA";
            panelGraphFA.Size = new Size(867, 422);
            panelGraphFA.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(pictureBoxGraphNFA);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(867, 422);
            panel1.TabIndex = 0;
            // 
            // pictureBoxGraphNFA
            // 
            pictureBoxGraphNFA.BackColor = Color.Salmon;
            pictureBoxGraphNFA.Location = new Point(3, 3);
            pictureBoxGraphNFA.Name = "pictureBoxGraphNFA";
            pictureBoxGraphNFA.Size = new Size(871, 416);
            pictureBoxGraphNFA.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxGraphNFA.TabIndex = 0;
            pictureBoxGraphNFA.TabStop = false;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(panel2);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(873, 428);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Граф Обработки";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(pictureBoxGraphProcessing);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(873, 428);
            panel2.TabIndex = 0;
            // 
            // pictureBoxGraphProcessing
            // 
            pictureBoxGraphProcessing.Location = new Point(3, 3);
            pictureBoxGraphProcessing.Name = "pictureBoxGraphProcessing";
            pictureBoxGraphProcessing.Size = new Size(877, 422);
            pictureBoxGraphProcessing.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxGraphProcessing.TabIndex = 0;
            pictureBoxGraphProcessing.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1171, 766);
            Controls.Add(splitContainer1);
            Controls.Add(groupBox1);
            MinimumSize = new Size(694, 805);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            splitContainerMarkUpBox.Panel1.ResumeLayout(false);
            splitContainerMarkUpBox.Panel1.PerformLayout();
            splitContainerMarkUpBox.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMarkUpBox).EndInit();
            splitContainerMarkUpBox.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            groupBoxSettings.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewTableNFA).EndInit();
            tabPage2.ResumeLayout(false);
            panelGraphFA.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGraphNFA).EndInit();
            tabPage3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGraphProcessing).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBoxInput;
        private GroupBox groupBox1;
        private SplitContainer splitContainerMarkUpBox;
        private TableLayoutPanel tableLayoutPanel2;
        private Button buttonFullMarkUp;
        private Button buttonStepMarkUp;
        private SplitContainer splitContainer1;
        private GroupBox groupBoxSettings;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dataGridViewTableNFA;
        private DataGridViewTextBoxColumn Column1;
        private TabPage tabPage2;
        private Button buttonRunBuildFA;
        private Button buttonRunSimpleMinimization;
        private Panel panelGraphFA;
        private PictureBox pictureBoxGraphNFA;
        private TabPage tabPage3;
        private GroupBox groupBox2;
        private TextBox textBoxInputText;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBoxGraphProcessing;
        private GroupBox groupBox3;
        private TableLayoutPanel tableLayoutPanel3;
        private Button buttonRunProccessing;
        private CheckBox checkBoxIsBuildProccesFlow;
        private Label labelResultNFA;
        private Label labelResultMNFA;
    }
}
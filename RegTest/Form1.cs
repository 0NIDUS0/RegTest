using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;

using Label = System.Windows.Forms.Label;
using FontStyle = System.Drawing.FontStyle;
using Color = System.Drawing.Color;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace RegTest
{
    public partial class Form1 : Form
    {
        private IEnumerator<List<string>> _steps = null!;
        private ReExpression _expression = null!;
        private NFA _nfa = null!;
        private ThreadsNFA _thNfa = null!;

        public Form1()
        {
            InitializeComponent();
            _steps = ReExpression.StepsAlgoritm(textBoxInput.Text);

        }


        private void CreateMarkUpView(List<string> dataView, TableLayoutPanel table)
        {
            table.Controls.Clear();
            table.ColumnStyles.Clear();
            table.ColumnCount = dataView.Count;

            Label[] labels = new Label[dataView.Count];

            for (var i = 0; i < dataView.Count; i++)
            {
                labels[i] = new Label
                {
                    Dock = DockStyle.Fill,
                    Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point),
                };
                if ((1 & i) == 0)
                {
                    dataView[i] = "↓\n" + dataView[i];
                    labels[i].Text = dataView[i];
                    labels[i].ForeColor = Color.Crimson;
                }
                else
                {
                    labels[i].Text = dataView[i];
                }

                table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
                table.Controls.Add(labels[i]);
            }
        }

        private void CreateTransitionsTableNFA(DataGridView dataGridView)
        {
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            foreach (var symbol in _nfa.InputAlphabet)
            {
                dataGridView.Columns.Add(new DataGridViewColumn()
                {
                    Name = $"{symbol}",
                    HeaderText = $"{symbol}",
                    ReadOnly = true,
                    CellTemplate = new DataGridViewTextBoxCell()
                });
            }

            for (var i = 0; i < _nfa.States.Count(); i++)
            {
                var state = _nfa.States.ElementAt(i);
                dataGridView.Rows.Add();
                dataGridView.Rows[dataGridView.RowCount - 1].HeaderCell.Value = $"S{i}";
                dataGridView.Rows[dataGridView.RowCount - 1].HeaderCell.Style.BackColor = state.IsFinal ? Color.Red : Color.DarkOrange;
                foreach (char symbol in _nfa.InputAlphabet)
                {
                    var transitions = state.Transition(symbol);
                    dataGridView[$"{symbol}", dataGridView.RowCount - 1].Value = transitions is null ? "-" : string.Join(',', transitions);
                }

            }
        }

        private Graph CreateGraphProccessing(string input)
        {
            var states = _nfa.States;
            var graph = new Graph();

            graph.Attr.LayerDirection = LayerDirection.LR;

            int idNext = 0;

            Stack<(Node, int, int)> stack = new();

            var node = new Node(idNext.ToString());

            node.Attr.Shape = Shape.Circle;
            graph.AddNode(node);

            stack.Push((node, 0, 0));

            while (stack.Count > 0)
            {
                var (curent, stateIndex, characterIndex) = stack.Pop();
                var nextIndexsesStates = _nfa.DoTransition(input[characterIndex], stateIndex);

                if (nextIndexsesStates == null)
                {
                    var nextNode = new Node($"{++idNext}");
                    nextNode.LabelText = "X";
                    nextNode.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                    nextNode.Attr.Shape = Shape.Circle;

                    graph.AddNode(nextNode);
                    graph.AddEdge(curent.Id, input[characterIndex].ToString(), nextNode.Id);
                    continue;
                }


                foreach (var nextIndex in nextIndexsesStates)
                {
                    var nextNode = new Node($"{++idNext}");
                    nextNode.LabelText = nextIndex.ToString();
                    nextNode.Attr.Shape = states.ElementAt(nextIndex).IsFinal ? Shape.DoubleCircle : Shape.Circle;

                    graph.AddNode(nextNode);
                    graph.AddEdge(curent.Id, input[characterIndex].ToString(), nextNode.Id);

                    if (characterIndex < input.Length - 1)
                    {
                        stack.Push((nextNode, nextIndex, characterIndex + 1));
                    }
                }

            }

            return graph;
        }
        private Graph CreateGraphNFA(NFA nfa)
        {
            var graph = new Graph();
            graph.Attr.LayerDirection = LayerDirection.LR;


            var statesNFA = nfa.States;

            for (var i = 0; i < nfa.States.Count(); i++)
            {
                var curent = graph.AddNode(i.ToString());
                curent.Attr.Shape = statesNFA.ElementAt(i).IsFinal ? Shape.DoubleCircle : Shape.Circle;
                curent.Label.FontSize = 12;
                curent.Label.FontStyle = Microsoft.Msagl.Drawing.FontStyle.Bold;
                curent.Label.FontName = "Arial";
                curent.Attr.LineWidth = 2;
            }

            for (var i = 0; i < nfa.States.Count(); i++)
            {
                var keys = statesNFA.ElementAt(i).Transitions.Keys;
                foreach (var key in keys)
                {
                    var transitions = statesNFA.ElementAt(i).Transitions[key];
                    foreach (var next in transitions)
                    {
                        var edge = graph.Edges.FirstOrDefault(e => e.SourceNode.Id == i.ToString()
                                                                && e.TargetNode.Id == next.ToString());
                        if (edge != null)
                        {
                            edge.LabelText = edge.LabelText + "," + key.ToString();
                        }
                        else
                        {
                            var newEdge = graph.AddEdge(i.ToString(), key.ToString(), next.ToString());
                            newEdge.Label.FontSize = 12;
                            newEdge.Label.FontStyle = Microsoft.Msagl.Drawing.FontStyle.Bold;
                            newEdge.Label.FontName = "Arial";
                            newEdge.Attr.LineWidth = 2;
                        }
                    }

                }
            }

            return graph;
        }

        public void DrawingGraph(Graph graph, PictureBox pictureBox)
        {
            pictureBox.Image = null;
            pictureBox.Size = new Size(877, 422);

            graph.Attr.MinNodeHeight = 35;
            graph.Attr.MinNodeWidth = 35;

            var renderer = new GraphRenderer(graph);
            renderer.CalculateLayout();

            int graphHeight = (int)graph.Height;
            int graphWidth = (int)graph.Width;

            Bitmap imageGraph = new Bitmap(graphWidth < pictureBox.Width ? pictureBox.Width : graphWidth, graphHeight < pictureBox.Height ? pictureBox.Height : graphHeight);

            using (Graphics graphics = Graphics.FromImage(imageGraph))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                renderer.Render(graphics, 0, 0, imageGraph.Width, imageGraph.Height);
            }

            pictureBox.Image = imageGraph;
        }
        #region Events
        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {
            buttonRunBuildFA.Enabled = false;
            buttonRunSimpleMinimization.Enabled = false;
            groupBox2.Enabled = false;
            _steps = ReExpression.StepsAlgoritm(textBoxInput.Text);
        }

        //Пошаговая разметка
        private void buttonRun_Click(object sender, EventArgs e)
        {
            try
            {
                if (_steps.MoveNext())
                    CreateMarkUpView(_steps.Current, tableLayoutPanel1);
                else
                {
                    MessageBox.Show("Mark up complete!");
                    _expression = new ReExpression(textBoxInput.Text);
                    buttonRunBuildFA.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Полная разметка
        private void buttonFullMarkUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (_steps.MoveNext())
                {
                    while (_steps.MoveNext()) ;
                    CreateMarkUpView(_steps.Current, tableLayoutPanel1);
                }
                else
                {
                    MessageBox.Show("Mark up complete!");
                }
                _expression = new ReExpression(textBoxInput.Text);

                buttonRunBuildFA.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonRunBuildFA_Click(object sender, EventArgs e)
        {
            _nfa = new NFA(_expression.GetFSMConstructionData());
            _thNfa = new ThreadsNFA(_expression.GetFSMConstructionData());

            CreateTransitionsTableNFA(dataGridViewTableNFA);
            buttonRunSimpleMinimization.Enabled = true;
            groupBox2.Enabled = true;
            DrawingGraph(CreateGraphNFA(_nfa), pictureBoxGraphNFA);
        }

        private void buttonRunSimpleMinimization_Click(object sender, EventArgs e)
        {
            _nfa.SimpleMinimization();
            _thNfa.SimpleMinimization();
            CreateTransitionsTableNFA(dataGridViewTableNFA);
            DrawingGraph(CreateGraphNFA(_nfa), pictureBoxGraphNFA);
        }

        #endregion

        private void buttonRunProccessing_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            long avgTicksNFA = 0;
            var resultNFA = false;

            for (var i = 0; i < 10; i++)
            {
                stopwatch = Stopwatch.StartNew();
                resultNFA = _nfa.Accept(textBoxInputText.Text);
                stopwatch.Stop();
                avgTicksNFA += stopwatch.ElapsedTicks;
            }

            labelResultNFA.Text = $"НКА: {resultNFA} - {new TimeSpan(avgTicksNFA / 10)}";


            long avgTicksMNFA = 0;

            for (var i = 0; i < 10; i++)
            {
                stopwatch = Stopwatch.StartNew();
                _thNfa.Accept(textBoxInputText.Text);
                stopwatch.Stop();
                avgTicksMNFA += stopwatch.ElapsedTicks;
            }

            labelResultMNFA.Text = $"МНКА: {_thNfa.finished} - {new TimeSpan(avgTicksMNFA / 10)}";

            if (checkBoxIsBuildProccesFlow.Checked)
                DrawingGraph(CreateGraphProccessing(textBoxInputText.Text), pictureBoxGraphProcessing);
        }


    }
}
using VisualGraphTraversal.Graph;
using VisualGraphTraversal.GraphVisualizer;
namespace VisualGraphTraversal
{
    public partial class Form1 : Form
    {
        Graph<int> graph;
        bool isRunning = false;
        public Form1()
        {
            InitializeComponent();
            // Here i create this graph
            //       1
            //    /     \
            //   2       3
            //  / \     /  \
            // 4   5   6    7
            // You can create your own and test visualizer 
            graph = new Graph<int>(1);
            graph.AddLeftChild(2);
            graph.AddRightChild(3);
            graph?.RootNode.Left?.AddLeftChild(4);
            graph?.RootNode.Left?.AddRightChild(5);
            graph?.RootNode.Right?.AddLeftChild(6);
            graph?.RootNode.Right?.AddRightChild(7);
        }

        private async void NLRMode_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                OutputTextBox.Clear();
                isRunning = true;
                IGraphVisualizer<int> visualizer = new GraphVisualizer.GraphVisualizer<int>(graph, pictureBox1);
                foreach (Node<int> node in graph.GetNLREnumerator())
                {
                    visualizer.Visualize(node);
                    OutputTextBox.Text += $"{node.Value.ToString()} ";
                    await Task.Delay(1000);
                }
                isRunning = false;
            }
        }

        private async void LNRMode_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                OutputTextBox.Clear();
                isRunning = true;
                IGraphVisualizer<int> visualizer = new GraphVisualizer.GraphVisualizer<int>(graph, pictureBox1);
                foreach (Node<int> node in graph.GetLNREnumerator())
                {
                    visualizer.Visualize(node);
                    OutputTextBox.Text += $"{node.Value.ToString()} ";
                    await Task.Delay(1000);
                }
                isRunning = false;
            }
        }

        private async void RLNMode_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                OutputTextBox.Clear();
                isRunning = true;
                IGraphVisualizer<int> visualizer = new GraphVisualizer.GraphVisualizer<int>(graph, pictureBox1);
                foreach (Node<int> node in graph.GetRLNEnumerator())
                {
                    visualizer.Visualize(node);
                    OutputTextBox.Text += $"{node.Value.ToString()} ";
                    await Task.Delay(1000);
                }
                isRunning = false;
            }
        }
    }
}
using VisualGraphTraversal.Graph;
using VisualGraphTraversal.GraphVisualizer;
namespace VisualGraphTraversal
{
    public partial class Form1 : Form
    {
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
            Graph<int> graph = new Graph<int>(1);
            graph.AddLeftChild(2);
            graph.AddRightChild(3);
            if (graph.RootNode.Left != null)
            {

                graph.RootNode.Left.AddLeftChild(4);
                graph.RootNode.Left.AddRightChild(5);
            }
            if (graph.RootNode.Right != null)
            {
                graph.RootNode.Right.AddLeftChild(6);
                graph.RootNode.Right.AddRightChild(8);
                if (graph.RootNode.Right.Left != null)
                {
                    graph.RootNode.Right.Left.AddLeftChild(7);
                    graph.RootNode.Right.Left.Left.AddLeftChild(9);
                }
                
            }
            IGraphVisualizer visualizer = new GraphVisualizer.GraphVisualizer<int>(graph, pictureBox1);
            visualizer.Visualize();
        }

    }
}
using VisualGraphTraversal.Graph;
namespace VisualGraphTraversal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Graph<int> graph = new Graph<int>(1);
            graph.AddChildren(2);
            graph.AddChildren(3);
            graph.Children[0].AddChild(4);
            graph.Children[1].AddChild(5);
            graph.Children[1].AddChild(6);
        }

    }
}
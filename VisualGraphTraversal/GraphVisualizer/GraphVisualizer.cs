using VisualGraphTraversal.Graph;
using System.Windows.Forms;
namespace VisualGraphTraversal.GraphVisualizer
{
    internal class GraphVisualizer<type> : IGraphVisualizer
    {
        Graph<type> _graph;
        PictureBox _pictureBox;
        int _rowHeight;
        int _edgeSize = 5;
        List<Rectangle> _nodeRects;
        public GraphVisualizer(Graph<type> graph, PictureBox picBox)
        {
            _graph = graph;
            _pictureBox = picBox;
            _nodeRects = new List<Rectangle>();
            SetUpSizes();
        }
        private void SetUpSizes()
        {
            _rowHeight = (_pictureBox.Height / GetNumberOfRows()) - 5;
            SetCoordsForAllNodes();
        }

        private int GetNumberOfRows()
        {
            int biggestNum = 0;
            foreach(Node<type> node in _graph.GetNLREnumerator())
            {
                if (node.GetNumberOfRow() > biggestNum)
                {
                    biggestNum = node.GetNumberOfRow();
                }
            }
            return biggestNum;
        }
        private List<Node<type>> GetAllNodesFromRow(int rowNumber)
        {
            List<Node<type>> neighbourNodes = new List<Node<type>>();
            foreach (Node<type> node in _graph.GetNLREnumerator())
            {
                if(node.GetNumberOfRow() == rowNumber)
                {
                    neighbourNodes.Add(node);
                }
            }
            return neighbourNodes;
        }
        private void SetCoordsForAllNodes()
        {
            for(int i = 0; i < GetNumberOfRows(); i++)
            {
                List<Node<type>> currentRowNodes = GetAllNodesFromRow(i);
                for (int j = 0; j < currentRowNodes.Count; j++)
                {
                    _nodeRects.Add(new Rectangle((j+1)*(_pictureBox.Width/(currentRowNodes.Count + 1)),
                       (i - 1) * (_edgeSize + _rowHeight), _rowHeight, _rowHeight));
                }   
            }
        }
        private void SetAllEdgeCoords()
        {

        }
        public void Visualize()
        {
            SolidBrush ellipseBrush = new SolidBrush(Color.Red);
            Bitmap bitmap = new Bitmap(_pictureBox.Width, _pictureBox.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            foreach(Rectangle rect in _nodeRects)
            {
                g.FillEllipse(ellipseBrush, rect);
            }
            _pictureBox.Image = bitmap;
        }
    }
}

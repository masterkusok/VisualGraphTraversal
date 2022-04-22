using System.Collections;

namespace VisualGraphTraversal.Graph
{
    internal class Graph<type> : IEnumerable
    {
        private GraphIterator _iterator;
        Node<type> _rootNode;
        public List<Node<type>> Children { get => _rootNode.Children; }
        public Node<type> RootNode { get => _rootNode; }
        public Graph(type rootValue)
        {
            _rootNode = new Node<type>(null, rootValue);
        }
        public void SetNLRIterator()
        {
            _iterator = new NLRIterator<type>(this);
        }
        public void AddChildren(type value)
        {
            _rootNode.AddChild(value);
        }
        public List<type> GetAllChildrenValues()
        {
            return _rootNode.GetAllChildrenValues();
        }
        public IEnumerator GetEnumerator()
        {
            return _iterator;
        }
    }
}

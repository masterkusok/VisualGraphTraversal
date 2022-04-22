namespace VisualGraphTraversal.Graph
{
    internal class Node<type>
    {
        private List<Node<type>> _children;
        private Node<type> _parent;
        private type _value;
        public type Value { get => _value; }
        public Node<type> Parent { get => _parent; }
        public List<Node<type>> Children { get => _children; }
        public Node(Node<type> parent, type value)
        {
            _parent = parent;
            _value = value;
            _children = new List<Node<type>>();
        }
        public void AddChild(type value)
        {
            _children.Add(new Node<type>(this, value));
        }
        public List<type> GetAllChildrenValues()
        {
            List<type> allChildrenValues = new List<type>();
            allChildrenValues.Add(_value);
            foreach(var child in _children)
            {
                if(child is Node<type>)
                {
                    foreach (var childValue in child.GetAllChildrenValues())
                    {
                        allChildrenValues.Add(childValue);
                    }
                }
            }
            return allChildrenValues;
        }
        
    }
}

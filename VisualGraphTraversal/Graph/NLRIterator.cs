namespace VisualGraphTraversal.Graph
{
    internal class NLRIterator<type> : GraphIterator
    {
        private Graph<type> _graph;
        private object _current;
        protected override object Current
        {
            get => _current;
        }
        public NLRIterator(Graph<type> graph)
        {
            _graph = graph;
            _current = _graph.RootNode;
        }
        public override bool MoveNext()
        {
            return false;
        }

        public override void Reset()
        {
            _current = _graph.RootNode;
        }
    }
}

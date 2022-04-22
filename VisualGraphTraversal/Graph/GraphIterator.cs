using System.Collections;
namespace VisualGraphTraversal.Graph
{
    abstract class GraphIterator : IEnumerator
    {
        object IEnumerator.Current => Current ;
        protected abstract object Current { get;}
        public abstract bool MoveNext();
        public abstract void Reset();
    }
}


namespace RegTest
{
    public abstract class ReElement
    {
        public abstract IEnumerable<int> RightIndex { get; }

        public override string ToString()
        {
            return "[" + string.Join(",", RightIndex) + "]";
        }
    }
}


namespace RegTest
{
    public class Transition : IEquatable<Transition>
    {

        #region Constructors
        public Transition(IEnumerable<int> left, ReSymbol reSymbol)
        {
            LeftIndex = new HashSet<int>(left);
            RightSingleIndex = reSymbol.RightSinglIndex;
            Character = reSymbol.Character;
        }
        public Transition(IEnumerable<int> left, char character, int rightIndex)
        {
            LeftIndex = new HashSet<int>(left);
            RightSingleIndex = rightIndex;
            Character = character;
        }
        #endregion

        #region Methods

        public void ChangeIndexses(List<IGrouping<int, int>> groups)
        {
            RightSingleIndex = groups.FindIndex(g => g.Contains(RightSingleIndex));
            var newLeft = new HashSet<int>();
            foreach (var index in LeftIndex)
            {
                newLeft.Add(groups.FindIndex(g => g.Contains(index)));
            }
            LeftIndex = newLeft;
        }
        public override string ToString()
        {
            return $"[{string.Join(",", LeftIndex)}]{Character}({RightSingleIndex})";
        }
        public bool Equals(Transition? other)
        {
            if (other == null)
                return false;

            if (other.Character == Character &&
                other.RightSingleIndex == RightSingleIndex &&
                other.LeftIndex.SetEquals(LeftIndex))
                return true;
            else
                return false;
        }
        public override bool Equals(object? obj) => Equals(obj as Transition);
        public override int GetHashCode()
        {
            var hashCode = Character.GetHashCode() ^ RightSingleIndex.GetHashCode();
            foreach (var index in LeftIndex)
            {
                hashCode ^= index.GetHashCode();
            }
            return hashCode;
        }
        #endregion

        #region Properties
        public char Character { get; init; }
        public int RightSingleIndex { get; set; }
        public HashSet<int> LeftIndex { get; set; }
        #endregion
    }
}

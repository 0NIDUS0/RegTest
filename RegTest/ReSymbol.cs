
namespace RegTest
{
    public class ReSymbol : ReElement, IIndexable<int>
    {
        //Fields
        private int _index = -1;

        //Constructors
        public ReSymbol(char character, CharacterType type) => (Character, Type) = (character, type);

        //Methods
        public void AddToRightIndex(int index) => _index = index;

        public override string ToString()
        {
            return $"{Character}" + base.ToString();
        }
        //Properties
        public override IEnumerable<int> RightIndex => new[] { _index };
        public int RightSinglIndex => _index;
        public char Character { get; init; }
        public CharacterType Type { get; init; }
    }

    public enum CharacterType
    {
        Literal,
        Bracket,
        Or
    }
}

using System.Text;

namespace RegTest
{
    public class State : IEquatable<State>
    {
        #region Fileds
        private Dictionary<char, HashSet<int>> _transitions = new();
        #endregion

        #region Constructors
        public State(Dictionary<char, HashSet<int>> transitions, bool final = false)
        {
            _transitions = transitions;
            IsFinal = final;
        }

        public State(bool final = false) => IsFinal = final;
        #endregion

        #region Methods
        public HashSet<int>? Transition(char inputSymbol)
        {
            HashSet<int>? states;
            _transitions.TryGetValue(inputSymbol, out states);
            return states;
        }

        public void ChangeTransitions(List<IGrouping<State, int>> groups)
        {
            foreach (var key in _transitions.Keys)
            {
                var newTransitions = new HashSet<int>();
                foreach (var indexState in _transitions[key])
                {
                    newTransitions.Add(groups.FindIndex(g => g.Contains(indexState)));
                }
                _transitions[key] = newTransitions;
            }
        }
        public bool Equals(State? other)
        {
            if (other == null 
               || other._transitions.Count != _transitions.Count 
               || IsFinal != other.IsFinal) return false;
            if (other == this) return true;
            foreach (var key in _transitions.Keys)
            {
                if (!other._transitions.ContainsKey(key) ||
                    !other._transitions[key].SetEquals(_transitions[key])) return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hash = IsFinal.GetHashCode();
            foreach (var key in _transitions.Keys)
            {
                foreach (var transitions in _transitions[key])
                {
                    hash ^= transitions.GetHashCode();
                }
            }
            return hash;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var key in _transitions.Keys)
            {
                stringBuilder.AppendFormat("[{0} :", key);
                stringBuilder.AppendJoin(", ", _transitions[key]);
                stringBuilder.Append(" ]");
            }
            return stringBuilder.ToString();
        }
        #endregion

        #region Properties
        public bool IsFinal { get; init; }
        public Dictionary<char, HashSet<int>> Transitions { get => _transitions; }
        #endregion

    }
}

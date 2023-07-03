

namespace RegTest
{
    public class NFA
    {
        #region Fields
        protected List<State> _states = new();
        protected HashSet<char> _inputAlphabet = new();
        #endregion

        #region Constructors
        public NFA(FSMConstructionData fSMConstructionData)
        {
            int maxStateNumber = fSMConstructionData.Transitions.Last().RightSingleIndex;
            List<Dictionary<char, HashSet<int>>> statesTransitions = new();
            for (var i = 0; i < maxStateNumber + 1; i++) statesTransitions.Add(new());

            foreach (var transition in fSMConstructionData.Transitions)
            {
                _inputAlphabet.Add(transition.Character);
                foreach (var index in transition.LeftIndex)
                {
                    var transitions = statesTransitions[index];
                    if (transitions.ContainsKey(transition.Character))
                    {
                        transitions[transition.Character].Add(transition.RightSingleIndex);
                    }
                    else
                    {
                        transitions.Add(transition.Character, new HashSet<int>() { transition.RightSingleIndex });
                    }
                }
            }

            for (var i = 0; i < statesTransitions.Count; i++)
            {
                _states.Add(new State(statesTransitions[i], fSMConstructionData.FinalStates.Contains(i)));
            }
        }
        #endregion

        #region Methods
        public void SimpleMinimization()
        {
            while (true)
            {
                IEnumerable<State> statesTemp = _states;
                var groups = Enumerable.Range(0, _states.Count()).GroupBy(i => statesTemp.ElementAt(i)).ToList();

                if (groups.Count() == statesTemp.Count()) return;

                _states = statesTemp.Distinct().ToList();

                foreach (var state in _states)
                {
                    state.ChangeTransitions(groups);
                }
            }
            
        }
        public virtual bool Accept(string input)
        {
            Stack<(int, int)> processingParameters = new();
            processingParameters.Push((0, 0));

            while (processingParameters.Count > 0)
            {
                var (curentState, index) = processingParameters.Pop();
                var indexStates = _states[curentState].Transition(input[index]);
                if (indexStates == null) continue;
                if (index != input.Length - 1)
                {
                    //var newIndex = index + 1;
                    foreach (var indexState in indexStates)
                    {
                        processingParameters.Push((indexState, index + 1));
                    }
                }
                else if (index == input.Length - 1)
                {
                    foreach (var indexState in indexStates)
                    {
                        if (_states[indexState].IsFinal) return true;
                    }
                }
            }
            return false;
        }
        public HashSet<int>? DoTransition(char character, int indexState)
        {
            return _states[indexState].Transition(character);
        }
        #endregion

        #region Properties
        public IEnumerable<char> InputAlphabet { get => _inputAlphabet.AsEnumerable(); }
        public IEnumerable<State> States { get => _states.AsEnumerable(); }
        #endregion


    }
}

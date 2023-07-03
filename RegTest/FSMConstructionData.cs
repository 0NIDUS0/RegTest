

namespace RegTest
{
    public class FSMConstructionData
    {
        public FSMConstructionData(List<Transition> transitions
                                  ,IEnumerable<int> finalStates) => (Transitions, FinalStates) = (transitions, finalStates);
        public List<Transition> Transitions { get; init; }
        public IEnumerable<int> FinalStates { get; init; }
    }
}

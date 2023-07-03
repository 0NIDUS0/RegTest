using System.Text.RegularExpressions;

namespace RegTest
{
    public class ReExpression : ReElement, IIndexable<IEnumerable<int>>
    {
        #region Fields
        private HashSet<int> _leftIndex = new();
        private HashSet<int> _rightIndex = new();
        private List<List<ReElement>> _words = new();
        #endregion

        #region Constructors
        public ReExpression(string expression)
        {
            if (!Validation(expression))
                throw new ArgumentException("Invalid expression.");
            else if (expression.Length == 0)
                throw new ArgumentOutOfRangeException("Expression string is empty.");

           
            char[] chars = expression.ToCharArray();
            List<ReElement> elements = new();

            _leftIndex.Add(0);

            elements = GetReElements(chars);
            CreateWordsExpression(elements);

        }
        private ReExpression(IEnumerable<int> left, List<ReElement> elements, bool cloused)
        {
            AddToLefttIndex(left);
            Cloused = cloused;
            CreateWordsExpression(elements);
        }
        #endregion

        #region Methods

        #region MainMethods
        private static bool Validation(string expression)
        {
            Stack<char> brackets = new();
            foreach (char character in expression)
            {
                if (character is '(' or '{')
                {
                    brackets.Push(character);
                }
                else if (character is ')' or '}')
                {
                    char bracket;
                    if (!brackets.TryPop(out bracket))
                    {
                        return false;
                    }
                    if (!((bracket == '(' && character == ')') ||
                       (bracket == '{' && character == '}')))
                    {
                        return false;
                    }
                }
            }

            if (Regex.IsMatch(expression, @"\(\||\|\)|\|\||^\||\|$") || brackets.Count > 0)
                return false;

            return true;
        }
        private static List<ReElement> GetReElements(char[] characters)
        {
            List<ReElement> reElements = new();
            int index = 1;
            foreach (char character in characters)
            {
                ReSymbol reSymbol = new(character, character switch
                {
                    '|' => CharacterType.Or,
                    '(' or ')' or '{' or '}' => CharacterType.Bracket,
                    _ => CharacterType.Literal
                });
                if (reSymbol.Type == CharacterType.Literal) reSymbol.AddToRightIndex(index++);
                reElements.Add(reSymbol);
            }
            return reElements;
        }
        public void AddToRightIndex(IEnumerable<int> indexes)
        {
            _rightIndex.UnionWith(indexes);
            if (Cloused && !_leftIndex.SetEquals(_rightIndex))
                AddToLefttIndex(indexes);
        }
        public void AddToLefttIndex(IEnumerable<int> indexes)
        {
            _leftIndex.UnionWith(indexes);
            if (Cloused && !_leftIndex.SetEquals(_rightIndex))
                _rightIndex.UnionWith(_leftIndex);
            MarkupWords();
        }
        private static ReExpression GetSubExpression(int start, IEnumerable<int> left, List<ReElement> elements)
        {
            int index = start;
            bool cloused = elements[index] is ReSymbol { Character: '{', Type: CharacterType.Bracket };
            Queue<int> brackets = new();
            List<ReElement> elementsForSubExpression = new();

            brackets.Enqueue(index++);

            while (true)
            {
                var reSymbol = (ReSymbol)elements[index];
                if (reSymbol.Type == CharacterType.Bracket)
                {
                    if (reSymbol.Character == '{' || reSymbol.Character == '(')
                        brackets.Enqueue(index);
                    else
                        brackets.Dequeue();
                }
                if (brackets.Count == 0) break;
                elementsForSubExpression.Add(elements[index++]);
            }
            return new ReExpression(left, elementsForSubExpression, cloused);
        }
        private void CreateWordsExpression(List<ReElement> elements)
        {
            Count += elements.Count;
            _words.Clear();
            _words.Add(new());

            for (var i = 0; i < elements.Count; i++)
            {
                var reSymbol = (ReSymbol)elements[i];

                if (reSymbol is ReSymbol
                    {
                        Character: '(' or '{',
                        Type: CharacterType.Bracket
                    })
                {
                    var subExpression = GetSubExpression(i, _words.Last().Count > 0 ?
                                                            _words.Last().Last().RightIndex :
                                                            LeftIndex, elements);
                    i += subExpression.Count + 1;
                    _words.Last().Add(subExpression);
                }
                else if (reSymbol.Type == CharacterType.Literal)
                {
                    _words.Last().Add(reSymbol);
                }
                else if (reSymbol.Type == CharacterType.Or)
                {
                    AddToRightIndex(_words.Last().Last().RightIndex);
                    _words.Add(new());
                }
            }

            AddToRightIndex(_words.Last().Last().RightIndex);
        }
        private void MarkupWords()
        {
            foreach (var word in _words)
            {
                for (var i = 0; i < word.Count; i++)
                {
                    if (word[i] is ReExpression)
                    {
                        var expression = (ReExpression)word[i];
                        HashSet<int> newLeftIndex = i == 0 ? _leftIndex : (HashSet<int>)word[i - 1].RightIndex;

                        if (!newLeftIndex.SetEquals(expression.LeftIndex))
                            expression.AddToLefttIndex(newLeftIndex);
                    }
                    else break;
                }
                AddToRightIndex(word.Last().RightIndex);
            }
        }
        #endregion

        private IEnumerable<int> Minimization(List<Transition> transitions)
        {
            var states = Enumerable.Range(0, transitions.Count + 1).ToList();
            var finalStates = new List<int>(RightIndex);

            bool isChange = false;

            for (var i = 0; i < transitions.Count; i++)
            {
                var transition = transitions[i];
                for (var j = i + 1; j < transitions.Count; j++)
                {
                    if (transition.LeftIndex.SetEquals(transitions[j].LeftIndex) &&
                        transition.Character == transitions[j].Character &&
                        transition.RightSingleIndex != transitions[j].RightSingleIndex)
                    {
                        isChange = true;
                        states[transitions[j].RightSingleIndex] = transition.RightSingleIndex;
                    }
                }
                if (isChange)
                {
                    var indexses = Enumerable.Range(0, states.Count);
                    var groups = indexses.GroupBy(i => states[i]).ToList();
                    for (var k = 0; k < transitions.Count; k++)
                    {
                        transitions[k].ChangeIndexses(groups);
                    }

                    var newFinal = new List<int>();
                    foreach (var finalIndex in finalStates)
                    {
                        newFinal.Add(groups.FindIndex(g => g.Contains(finalIndex)));
                    }
                    finalStates = newFinal;
                    states = Enumerable.Range(0, groups.Count()).ToList();
                    isChange = false;
                }
            }
            return finalStates;
        }
        static private bool TryGetConvertListByTransition(List<Transition> transitions, 
                                                          int indexCurentTransition, 
                                                          List<IGrouping<int, int>> groups)
        {
            var indexRange = Enumerable.Range(0, transitions.Max(t => t.RightSingleIndex) + 1);
            var convertList = indexRange.ToList();
            groups.Clear();

            var transition = transitions[indexCurentTransition];
            var isChange = false;

            for (var j = indexCurentTransition + 1; j < transitions.Count; j++)
            {
                if (transition.LeftIndex.SetEquals(transitions[j].LeftIndex) &&
                    transition.Character == transitions[j].Character &&
                    transition.RightSingleIndex != transitions[j].RightSingleIndex)
                {
                    isChange = true;
                    convertList[transitions[j].RightSingleIndex] = transition.RightSingleIndex;
                }
            }

            if (isChange)
            {
                groups.AddRange(indexRange.GroupBy(i => convertList[i]));
            }
            return isChange;
        }
        public void ConvertIndexsesByList(List<IGrouping<int, int>> convertList)
        {
            HashSet<int> newLeft = new(),
                         newRight = new();

            foreach (var index in _leftIndex)
            {
                newLeft.Add(convertList.FindIndex(g => g.Contains(index)));
            }
            _leftIndex = newLeft;

            foreach (var index in _rightIndex)
            {
                newRight.Add(convertList.FindIndex(g => g.Contains(index)));
            }
            _rightIndex = newRight;

            foreach (var word in _words)
            {
                foreach (var wordItem in word)
                {
                    if (wordItem is ReSymbol)
                    {
                        var reSymbol = (ReSymbol)wordItem;
                        reSymbol.AddToRightIndex(convertList.FindIndex(g => g.Contains(reSymbol.RightSinglIndex)));
                    }
                    else
                    {
                        ((ReExpression)wordItem).ConvertIndexsesByList(convertList);
                    }
                }
            }
        }
        static public IEnumerator<List<string>> StepsAlgoritm(string input)
        {
            if (!Validation(input))
                throw new ArgumentException("Invalid expression.");
            else if (input.Length == 0)
                throw new ArgumentOutOfRangeException("Expression string is empty.");
            
            var reElements = GetReElements(input.ToCharArray());

            List<string> viewData = new List<string>() { "0" };
            foreach(var reElement in reElements)
            {
                var reSymbol = (ReSymbol)reElement;
                viewData.Add(reSymbol.Character.ToString());
                viewData.Add(reSymbol.RightSinglIndex != -1 ? reSymbol.RightSinglIndex.ToString() : "" );
            }
            //first step
            yield return viewData;

            //second step
            var reExpression = new ReExpression(input);
            yield return reExpression.GetViewData();

            //minimization
            var transitions = reExpression.GetTransitions();
            var convertList = new List<IGrouping<int, int>>();

            for(var i = 0; i < transitions.Count; i++)
            {
               if(TryGetConvertListByTransition(transitions, i, convertList))
               {
                    reExpression.ConvertIndexsesByList(convertList);
                    transitions = reExpression.GetTransitions();
                    yield return reExpression.GetViewData();
               }
            }
            yield break;
        }
        public List<Transition> GetTransitions()
        {
            List<Transition> transitions = new();
            foreach (var word in _words)
            {
                for (var i = 0; i < word.Count; i++)
                {
                    if (word[i] is ReExpression)
                    {
                        transitions.AddRange(((ReExpression)word[i]).GetTransitions());
                    }
                    else
                    {
                        transitions.Add(new(i > 0 ? word[i - 1].RightIndex : _leftIndex, (ReSymbol)word[i]));
                    }
                }
            }

            return transitions;
        }
        public List<string> GetViewData(bool withBrackets = false, bool onlyLiterals = false)
        {
            List<string> result = new List<string>();
            if (withBrackets)
            {
                result.Add(Cloused ? "{" : "(");
            }
            for(var i = 0; i < _words.Count; i++)
            { 
                    var sorted = LeftIndex.ToList();
                    sorted.Sort();
                    result.Add(string.Join("\n", sorted));
               

                foreach(var item in _words[i])
                {
                    if(item is ReSymbol)
                    {
                        var symbol = (ReSymbol)item;
                        result.Add(symbol.Character.ToString());
                        result.Add(symbol.RightSinglIndex.ToString());
                    }
                    else
                    {
                        var expression = (ReExpression)item;
                        result.AddRange(expression.GetViewData(true,onlyLiterals));
                    }
                }
                if (i != _words.Count - 1) result.Add("|");  
            }

            if (withBrackets)
            {
                result.Add(Cloused ? "}" : ")");
                var sorted = RightIndex.ToList();
                sorted.Sort();
                result.Add(string.Join("\n", sorted));
            }
           
            return result;
        }
        public FSMConstructionData GetFSMConstructionData(bool minimization = true, bool distinctStates = true)
        {
            var transitions = GetTransitions();
            if (minimization)
            {
                var finalStates = Minimization(transitions);
                return new FSMConstructionData(distinctStates ? transitions.Distinct().ToList() : transitions, finalStates);
            }

            return new(transitions, RightIndex);
        }
        public override string ToString()
        {
            var words = new string[_words.Count];
            for (var i = 0; i < words.Length; i++)
            {
                words[i] = string.Join("", _words[i]);
            }

            (char op, char cl) brackets = !Cloused ? ('(', ')') : ('{', '}');

            return (!Cloused ? "[l:" + string.Join(',', _leftIndex) + "]" : "") +
                   brackets.op + " " + string.Join(" | ", words) + " " +
                   brackets.cl + base.ToString();
        }
        #endregion

        #region Properties
        public override IEnumerable<int> RightIndex => _rightIndex;
        public IEnumerable<int> LeftIndex => _leftIndex;
        public bool Cloused { get; init; } = false;
        public int Count { get; private set; } = 0;
        #endregion
    }
}

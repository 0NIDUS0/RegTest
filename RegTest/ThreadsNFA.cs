using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegTest
{
    public class ThreadsNFA : NFA
    {
        public bool finished = false;
        private string input = string.Empty;
        public CountdownEvent countdownEvent = null!;
        public ThreadsNFA(FSMConstructionData fSMConstructionData) : base(fSMConstructionData)
        {
        }

        public override bool Accept(string input)
        {
            this.input = input;
            finished = false;

            countdownEvent = new CountdownEvent(1);

            AcceptProcces((0, 0));

            countdownEvent.Wait();
            return finished;
        }

        private void AcceptProcces(object context)
        {
            var (curentState, index) = ((int, int))context;
            var intd = index;
            while (!finished)
            {
                var stateIndexses = _states[curentState].Transition(input[index]);
                if (stateIndexses == null || finished)
                {
                    countdownEvent.Signal();
                    return;
                }
                if (index < input.Length - 1)
                {
                    bool first = true;
                    foreach (var stateIndex in stateIndexses)
                    {
                        if (first && !finished)
                        {
                            curentState = stateIndex;
                            first = false;
                        }
                        else if (finished)
                        {
                            countdownEvent.Signal();
                            return;
                        }
                        else
                        {
                            if (!countdownEvent.IsSet)
                            {
                                countdownEvent.AddCount();
                                ThreadPool.QueueUserWorkItem(AcceptProcces!, (stateIndex, index + 1));
                            }
                        }
                    }
                    index++;
                }
                else
                {
                    foreach (var stateIndex in stateIndexses)
                    {
                        if (_states[stateIndex].IsFinal)
                        {
                            finished = true;
                            countdownEvent.Signal();
                            return;
                        }
                    }
                    break;
                }
            }
            countdownEvent.Signal();
            return;
        }
    }
}

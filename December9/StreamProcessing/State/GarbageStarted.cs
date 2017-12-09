using System;

namespace StreamProcessing.State
{
    public class GarbageStarted : BaseState
    {
        protected override IState Process(char nextChar, Context context)
        {
            switch (nextChar)
            {
                case '>':
                    return new None();
                default:
                    return this;
            }
        }
    }
}

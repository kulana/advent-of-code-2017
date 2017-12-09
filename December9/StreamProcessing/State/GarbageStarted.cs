using System;

namespace StreamProcessing.State
{
    //   { => GroupStarted(levelScore+1)
    //  } => GroupEnded
    //< => GarbageStarted
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

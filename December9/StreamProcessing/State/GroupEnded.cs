using System;

namespace StreamProcessing.State
{
    //  , => None
    //} => GroupEnded
    public class GroupEnded : BaseState
    {
        protected override IState Process(char nextChar, Context context)
        {
            switch (nextChar)
            {
                case '}':
                    context.CloseGroup();
                    return new GroupEnded();
                case ',':
                    return new None();
                default:
                    throw new ApplicationException($"Invalid character {nextChar} for state {nameof(this.GetType)}");
            }
        }
    }
}

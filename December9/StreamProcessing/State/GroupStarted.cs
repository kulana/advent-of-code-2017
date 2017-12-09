﻿using System;

namespace StreamProcessing.State
{
    //   { => GroupStarted(levelScore+1)
    //  } => GroupEnded
    //< => GarbageStarted
    public class GroupStarted : BaseState
    {
        protected override IState Process(char nextChar, Context context)
        {
            switch (nextChar)
            {
                case '{':
                    context.OpenGroup();
                    return new GroupStarted();
                case '}':
                    context.CloseGroup();
                    return new GroupEnded();
                case '<':
                    return new GarbageStarted(); 
                default:
                    throw new ApplicationException($"Invalid character {nextChar} for state {nameof(this.GetType)}");
            }
        }
    }
}

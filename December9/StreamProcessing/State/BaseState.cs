namespace StreamProcessing.State
{
    public abstract class BaseState : IState
    {
        private Mode Mode { get; set; } = Mode.Accept;

        public IState Transition(char nextChar, Context context)
        {
            // if we are accepting chars AND the next char sets the mode to ignore
            if (Mode.Equals(Mode.Accept) && nextChar.Equals('!'))
            {
                Mode = Mode.Ignore;
                return this;
            }
            // next char is different than ! and we are accepting, so process it
            else if (Mode.Equals(Mode.Accept))
            {
                return Process(nextChar, context);
            }
            // otherwise we are in ignoring mode, reset to accept but no state chnage
            Mode = Mode.Accept;
            return this;
        }

        protected abstract IState Process(char nextChar, Context context);
    }

    public enum Mode
    {
        Accept,
        Ignore
    }

}

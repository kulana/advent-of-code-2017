namespace StreamProcessing.State
{
    public abstract class BaseState : IState
    {
        private Mode Mode { get; set; } = Mode.Accept;

        public IState Transition(char nextChar, Context context)
        {
            if (Mode.Equals(Mode.Accept) && nextChar.Equals('!'))
            {
                Mode = Mode.Ignore;
                return this;
            }
            else if (Mode.Equals(Mode.Accept))
            {
                return Process(nextChar, context);
            }
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

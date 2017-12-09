namespace StreamProcessing.State
{
    public interface IState
    {
        IState Transition(char nextChar, Context context);
    }
}

namespace Streaming_Video_MVC.Models
{
    public abstract class State
    {
        public string id { get; set; }
        public string name { get; set; }
        public abstract void login(string id,string name);
    }
    public class userLogin : State
    {
        public override void login(string id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
    public class usernotlogin : State
    {
        public override void login(string id, string name)
        {
            this.id = null;
            this.name = null;
        }
    }
    public class Context
    {
        State state;
        // Constructor
        public Context(State state)
        {
            this.State = state;
        }
        public void changeState(State state)
        {
            this.State = state;
        }
        // Gets or sets the state
        public State State
        {
            get { return state; }
            set
            {
                state = value;
                Console.WriteLine("State: " + state.GetType().Name);
            }
        }
    }
}

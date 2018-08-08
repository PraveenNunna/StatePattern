using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTest
{
    public class Context
    {
        private State _state;

        public State State
        {
            get
            {
                return _state;
            }
            set { _state = value; }
        }
        public Context(State state)
        {
            this.State = state;
        }
        public void Request()
        {
            _state.Handle(this);
        }
    }

    public abstract class State
    {
        public abstract void Handle(Context context);
    }

    public class StateA : State
    {
        public override void Handle(Context context)
        {
            Console.WriteLine("This is State A");
            context.State = new StateB();
        }
    }

    public class StateB : State
    {
        public override void Handle(Context context)
        {
            Console.WriteLine("This is State B");
            context.State = new StateA();
        }
    }
}

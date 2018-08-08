using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context(new StateA());
            context.Request();
            context.Request();
            context.Request();
            context.Request();
            context.Request();

            Console.ReadKey();
        }
    }

    public class Account
    {
        public string HolderName { get; set; }

        public AccountState accountState;

        private int Balance { get; set; }
       
        public Account(string holderName)
        {
            this.HolderName = holderName;
            this.accountState = new NotVerifedState();
        }
    }
    public abstract class AccountState
    {
        public int Balance { get; set; }

        public bool IsVerified { get; set; }
        public abstract Account account { get; set; }

        public abstract void Handle(Account account);

        public abstract void UpdateState();
    }

    public class NotVerifedState : AccountState
    {
        public override Account account { get; set; }

        public NotVerifedState()
        {

        }
        public override void UpdateState()
        {
            throw new NotImplementedException();
        }

        public override void Handle(Account account)
        {
            throw new NotImplementedException();
        }
    }

    //public class VerifiedState : AccountState
    //{

    //}

    //public class ClosedState : AccountState
    //{

    //}
}

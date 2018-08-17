using System;
using System.Threading;

namespace Deadlock_Multithreaded
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Started");

            Account accountA = new Account(101, 5000);
            Account accountB = new Account(102, 15000);

            AccountManager accountManagerA = new AccountManager(accountA, accountB, 1000);
            AccountManager accountManagerB = new AccountManager(accountB, accountA, 2000);


            Thread t1 = new Thread(accountManagerA.Transfter);
            t1.Name = "T1";

            Thread t2 = new Thread(accountManagerB.Transfter);
            t2.Name = "T2";

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine(" Main completed");

            Console.ReadKey();

        }
    }

    public class AccountManager
    {
        private Account _fromAccount;
        private Account _toAccount;
        private double _amountToTransfer;

        public AccountManager(Account fromAccount, Account toAccount, double amountToTransfer)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _amountToTransfer = amountToTransfer;
        }

        public void Transfter()
        {

            object _lock1, _lock2;

            //////////////////////////////////THIS IF LOGIC WILL PREVENT DEADLOCK//////////////////////////////////
            if (_fromAccount.ID < _toAccount.ID)
            {
                _lock1 = _fromAccount;
                _lock2 = _toAccount;
            }
            else
            {
                _lock1 = _toAccount;
                _lock2 = _fromAccount;
            }


            Console.WriteLine(Thread.CurrentThread.Name + " trying to acquire lock on " + _fromAccount.ID.ToString());
            lock (_lock1)
            {

                Console.WriteLine(Thread.CurrentThread.Name + " acquired lock on " + _fromAccount.ID.ToString());
                Console.WriteLine(Thread.CurrentThread.Name + " suspended for 1 sec");
                Thread.Sleep(1000);

                Console.WriteLine(Thread.CurrentThread.Name + " trying to acquire lock on " + _fromAccount.ID.ToString());

                lock (_lock2)
                {
                    _fromAccount.Withdraw(_amountToTransfer);
                    _toAccount.Deposit(_amountToTransfer);
                    Console.WriteLine($" {Thread.CurrentThread.Name}  transfered  {_amountToTransfer} from {_fromAccount.ID} to {_toAccount.ID}");

                }
            }
        }
    }

    public class Account
    {
        public double _balance;
        private int _id;

        public Account(int id, double balance)
        {
            this._id = id;
            this._balance = balance;
        }


        public int ID
        {
            get { return _id; }
        }

        public void Withdraw(double amount)
        {
            _balance -= amount;
        }

        public void Deposit(double amount)
        {
            _balance += amount;
        }




    }
}

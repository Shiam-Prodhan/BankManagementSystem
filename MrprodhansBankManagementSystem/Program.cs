using System;
using System.Collections;

namespace Console_Application_02
{
    class DOB
    {
        public string id, Dob;
        public bool Set(int d, int m, int y)
        {
            DateTime dDate;
            Dob = y.ToString() + "-" + m.ToString() + "-" + d.ToString();
            if (DateTime.TryParse(Dob, out dDate))
            {
                return true;

            }
            else
            {
                Console.WriteLine("Invalid Date");
                return false;
            }

        }


    }

    static class IDGenerate
    {
        static int[] Serial = new int[12];

        public static string Generateid()
        {
            DateTime now = DateTime.Now;
            string result = now.Year.ToString("D4") + "-" + now.Month.ToString("D2") + "-" + (Serial[now.Month] + 1).ToString("D5");
            Serial[now.Month]++;
            return result;
        }
    }

    abstract class Account
    {
        public readonly string name, id, nominee;
        public readonly DOB DOB;
        public double balance;
        public string type;

        public abstract bool Deposit(double Amount);
        public abstract bool Withdraw(double Amount);
        public double Get() => this.balance;
        public string Type() => this.type;


        public void PrintAccount()
        {
            Console.WriteLine("\n\n______Accounts Information______\n");

            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Name   : " + this.name);
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("ID     : " + this.id);
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Type   : " + this.type);
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Nominee: " + this.nominee);
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Balance: " + this.balance);
            Console.WriteLine("______________________________________");
        }
        public Account(string name, DOB DOB, string nominee, double balance)
        {
            this.name = name;
            this.id = IDGenerate.Generateid();
            this.DOB = DOB;
            this.nominee = nominee;
            this.balance = balance;
        }

    }
    class Bank
    {
        string input4account;
        public string name, nominee;
        public double balance;
        public int day = 0, month = 0, year = 0;
        public int count = 0;
        DOB Obj = new DOB();
        Program obj = new Program();
        Wait wait = new Wait();

        public ArrayList Array = new ArrayList();

        private Account GetAccount(string name, string id)
        {
            foreach (Account ac in this.Array)
            {

                if (ac.name == name && ac.id == id)
                {
                    return ac;
                }
            }
            throw new ArgumentOutOfRangeException();
        }
        public Account this[string name, string id]
        {
            get
            {
                try
                {
                    return this.GetAccount(name, id);
                }
                catch (ArgumentOutOfRangeException exception)
                {
                    Console.WriteLine("Sorry, There is no such account with this name and id!");
                    return (Account)null;
                }
            }
        }
        public void CreateAccount()
        {
            System.Threading.Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("-____Accounts Criteria____-");
            Console.WriteLine("- 1. Debit Account        -");
            Console.WriteLine("- 2. Credit Accoutn       -");
            Console.WriteLine("- 3. Savings Account      -");
            Console.WriteLine("- 0. Go to Main Menu      -");
            Console.WriteLine("---------------------------");
            Console.WriteLine("");
            DOB DOB = new DOB();
            Console.Write("Choose your option : ");
            input4account = Console.ReadLine();
            if (input4account == "1")
            {
                Console.WriteLine("");
                wait.wait();
                Console.Clear();
                Console.WriteLine("____Debit Account Creation Form____");
                Console.WriteLine("-----------------------------------");
                Console.Write("Name    : ");
                name = Console.ReadLine();
                Console.Write("Nominee : ");
                nominee = Console.ReadLine();
                Console.WriteLine("Date of Birth ");
                Console.Write("Day     : ");
                day = Convert.ToInt32(Console.ReadLine());
                Console.Write("Month   : ");
                month = Convert.ToInt32(Console.ReadLine());
                Console.Write("Year    : ");
                year = Convert.ToInt32(Console.ReadLine());
                Obj.Set(day, month, year);
                Console.Write("Balance : ");
                balance = Double.Parse(Console.ReadLine());
            }
            else if (input4account == "2")
            {
                Console.WriteLine("");
                wait.wait();
                Console.Clear();
                Console.WriteLine("____Credit Account Creation Form____");
                Console.WriteLine("------------------------------------");
                Console.Write("Name    : ");
                name = Console.ReadLine();
                Console.Write("Nominee : ");
                nominee = Console.ReadLine();
                Console.WriteLine("Date of Birth ");
                Console.Write("Day     : ");
                day = Convert.ToInt32(Console.ReadLine());
                Console.Write("Month   : ");
                month = Convert.ToInt32(Console.ReadLine());
                Console.Write("Year    : ");
                year = Convert.ToInt32(Console.ReadLine());
                Obj.Set(day, month, year);
                Console.Write("Balance : ");
                balance = Double.Parse(Console.ReadLine());
            }
            if (input4account == "3")
            {
                Console.WriteLine("");
                wait.wait();
                Console.Clear();
                Console.WriteLine("____Savings Account Creation Form____");
                Console.WriteLine("-------------------------------------");
                Console.Write("Name    : ");
                name = Console.ReadLine();
                Console.Write("Nominee : ");
                nominee = Console.ReadLine();
                Console.WriteLine("Date of Birth ");
                Console.Write("Day     : ");
                day = Convert.ToInt32(Console.ReadLine());
                Console.Write("Month   : ");
                month = Convert.ToInt32(Console.ReadLine());
                Console.Write("Year    : ");
                year = Convert.ToInt32(Console.ReadLine());
                Obj.Set(day, month, year);
                Console.Write("Balance : ");
                balance = Double.Parse(Console.ReadLine());
            }

            int x = Convert.ToInt32(input4account);

            if (x == 1)
            {
                this.Array.Add((object)new DebitAccount(name, DOB, nominee, balance));
                Console.WriteLine("");
                wait.wait();
                Console.WriteLine("");
                Console.WriteLine("Debit Account has been created successfully!");
                Console.Write("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
                count++;
            }

            else if (x == 2)
            {
                this.Array.Add((object)new CreditAccount(name, DOB, nominee, balance));
                Console.WriteLine("");
                wait.wait();
                Console.WriteLine("");
                Console.WriteLine("Credit Account has been created successfully!");
                Console.Write("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
                count++;
            }

            else if (x == 3)
            {
                this.Array.Add((object)new SavingsAccount(name, DOB, nominee, balance));
                Console.WriteLine("");
                wait.wait();
                Console.WriteLine("");
                Console.WriteLine("Savings Account has been created successfully!");
                Console.Write("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
                count++;
            }

            else if (x == 0)
            {
                Console.WriteLine("");
                wait.wait();
                Console.Clear();
                obj.Access();
            }

            else
            {
                Console.WriteLine("Wrong Input! Try Again....");
                System.Threading.Thread.Sleep(300);
                Console.Clear();
                CreateAccount();
            }
        }

        public void Deposit(string id, double amount)
        {
            try
            {
                if (this.GetAccount(name, id).Deposit(amount))
                {
                    Console.WriteLine("Congratulations! \nAccount Debit Successful.");
                }
                else
                {
                    Console.WriteLine("There might be an error!");
                }
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine("Sorry, There is no such account with this name and id!");
            }

        }

        public void Withdraw(string id, double amount)
        {
            try
            {
                if (this.GetAccount(name, id).Withdraw(amount))
                {
                    Console.WriteLine("\nCongratulations! Account Withdrawl Successful.");
                }
                else
                {
                    Console.WriteLine("There might be an error!");
                }
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine("Sorry, There is no such account with this name and id!");
            }

        }

        public void PrintInfo(string name, string id)
        {
            try
            {
                this.GetAccount(name, id).PrintAccount();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine("Sorry, There is no such account with this name and id!");
            }
        }

        public void AllAccount()
        {
            if (this.Array.Count < 1)
            {
                Console.WriteLine("There is no account in the syatem.\nPlease create an account first");
            }
            else
            {
                Console.WriteLine("ID\t\t\tName\t\t\tBalance\t\tAccountType");
                foreach (Account account in this.Array)
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}", new object[4]
                    {
                        (object) account.id,
                        (object) account.name,
                        (object) account.Get(),
                        (object) account.Type()
                    });

            }

        }
        class CreditAccount : Account
        {
            double MinimumBalance = -100000;
            double Limit = 20000;
            DateTime old = new DateTime(2005, 04, 12);
            DateTime current;
            double withdraw = 0;

            public CreditAccount(string name, DOB DOB, string nominee, double balance)
          : base(name, DOB, nominee, balance)
            {
                this.type = nameof(CreditAccount);
            }

            bool overlimit(double amount)
            {
                this.current = DateTime.Now.Date;
                if (amount > 0 && (uint)this.current.CompareTo(this.old) > 0U)
                {
                    this.withdraw = 0;
                    this.withdraw = this.withdraw + amount;
                    this.old = this.current;
                }
                else
                {
                    this.withdraw = this.withdraw + amount;
                }

                return this.withdraw > this.Limit || this.balance - amount <= this.MinimumBalance;
            }

            public override bool Deposit(double Amount)
            {
                if (Amount <= 0)
                {
                    return false;
                }
                this.balance = this.balance + Amount;
                return true;
            }
            public override bool Withdraw(double Amount)
            {
                if (Amount <= 0) //this.overlimit(Amount)
                    return false;

                this.balance = this.balance - Amount;
                return true;
            }
        }

        class DebitAccount : Account
        {
            double MaximumBalance = -100000;
            double Limit = 20000;
            DateTime old = new DateTime(2005, 04, 12);
            DateTime current;
            double withdraw = 0;

            public DebitAccount(string name, DOB DOB, string nominee, double balance)
          : base(name, DOB, nominee, balance)
            {
                this.type = nameof(DebitAccount);
            }

            bool overlimit(double amount)
            {
                this.current = DateTime.Now.Date;
                if (amount > 0 && (uint)this.current.CompareTo(this.old) > 0U)
                {
                    this.withdraw = 0;
                    this.withdraw = this.withdraw + amount;
                    this.old = this.current;
                }
                else
                {
                    this.withdraw = this.withdraw + amount;
                }

                return this.withdraw > this.Limit || this.balance - amount <= this.MaximumBalance;
            }

            public override bool Deposit(double Amount)
            {
                if (Amount <= 0)
                {
                    return false;
                }
                this.balance = this.balance + Amount;
                return true;
            }
            public override bool Withdraw(double Amount)
            {
                if (Amount <= 0) //this.overlimit(Amount)
                {
                    return false;
                }
                this.balance = this.balance - Amount;
                return true;
            }
        }

        class SavingsAccount : Account
        {

            public SavingsAccount(string name, DOB DOB, string nominee, double balance)
          : base(name, DOB, nominee, balance)
            {
                this.type = nameof(SavingsAccount);
            }

            public override bool Deposit(double Amount)
            {
                if (Amount <= 0)
                {
                    return false;
                }
                this.balance = this.balance + Amount;
                return true;
            }
            public override bool Withdraw(double Amount)
            {
                if (Amount <= 0) //this.balance(Amount)
                {
                    return false;
                }
                this.balance = this.balance - Amount;
                return true;
            }
        }
        class Wait
        {
            public void wait()
            {
                Console.Write("Please wait");
                for (int i = 0; i < 3; i++)
                {
                    System.Threading.Thread.Sleep(300);
                    Console.Write(".");
                }
                System.Threading.Thread.Sleep(500);
            }

        }

        class Program
        {
            static Bank obj = new Bank();
            static string input4menu;
            static Program access = new Program();
            Wait wait = new Wait();
            public static void Main(string[] args)
            {
                Console.Title = "M r . P r o d h a n ' s Bank Management System";
                access.Access();

            }
            public void Access()
            {
                DOB DOB = new DOB();
                Console.WriteLine("---------------------------");
                Console.WriteLine("- M r . P r o d h a n ' s -");
                Console.WriteLine("- Bank Management System  -");
                Console.WriteLine("-________Main Menu________-");
                Console.WriteLine("- 1. Create New Account   -");
                Console.WriteLine("- 2. Account Details      -");
                Console.WriteLine("- 3. Transaction (Dr/Cr)  -");
                Console.WriteLine("- 4. All Information      -");
                Console.WriteLine("- 5. Clear Screen         -");
                Console.WriteLine("- 0. Exit from the System -");
                Console.WriteLine("---------------------------");

                if (obj.count < 1)
                {
                    System.Threading.Thread.Sleep(300);
                    Console.WriteLine("------------------------------------");
                    System.Threading.Thread.Sleep(300);
                    obj.AllAccount();
                    System.Threading.Thread.Sleep(300);
                    Console.WriteLine("------------------------------------");
                }
                System.Threading.Thread.Sleep(300);
                Console.WriteLine("");
                Console.Write("Choose your option : ");
                input4menu = Console.ReadLine();

                if (input4menu == "1")
                {
                    wait.wait();
                    obj.CreateAccount();
                    Main(null);
                }
                else if (input4menu == "2")
                {
                    wait.wait();
                    Console.Clear();
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("-________Accounts Information________-");
                    Console.WriteLine("-Please provide the valid information-");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("");
                    System.Threading.Thread.Sleep(300);
                    Console.Write("Your Name : ");
                    string Name = Console.ReadLine();
                    Console.Write("Your ID   : ");
                    string ID = Console.ReadLine();
                    obj.PrintInfo(Name, ID);
                    Console.Write("\n\nPress any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    Main(null);
                }
                else if (input4menu == "3")
                {
                Label1:
                    wait.wait();
                    Console.Clear();
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("-____Transaction Method___-");
                    Console.WriteLine("- 1. Debit Acoount        -");
                    Console.WriteLine("- 2. Credit Account       -");
                    Console.WriteLine("---------------------------");

                    Console.Write("Choose your option : ");
                    int p = Convert.ToInt32(Console.ReadLine());

                    if (p == 1)
                    {

                        Console.Write("Your Name        : ");
                        string Name_1 = Console.ReadLine();
                        Console.Write("Enter account ID : ");
                        string ID_1 = Console.ReadLine();
                        Console.Write("Enter Amount     : ");
                        double amount = Convert.ToDouble(Console.ReadLine());
                        wait.wait();
                        Console.WriteLine("");
                        obj.Deposit(ID_1, amount);
                        obj.PrintInfo(Name_1, ID_1);
                        Console.Write("\n\nPress any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        Main(null);

                    }

                    else if (p == 2)
                    {
                        Console.Write("Your Name        : ");
                        string Name_2 = Console.ReadLine();
                        Console.Write("Enter account ID : ");
                        string ID_2 = Console.ReadLine();
                        Console.Write("Enter Amount     : ");
                        double amount = Convert.ToDouble(Console.ReadLine());
                        wait.wait();
                        Console.WriteLine("");
                        obj.Withdraw(ID_2, amount);
                        obj.PrintInfo(Name_2, ID_2);
                        Console.Write("\n\nPress any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        Main(null);
                    }
                    else
                    {
                        Console.WriteLine("Wrong Input! Try Again....");
                        System.Threading.Thread.Sleep(300);
                        Console.Clear();
                        goto Label1;
                    }

                }
                else if (input4menu == "4")
                {
                    wait.wait();
                    Console.WriteLine("");
                    Console.Clear();
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("-______All Accounts Information______-");
                    Console.WriteLine("--------------------------------------");
                    obj.AllAccount();
                    Console.Write("\n\nPress any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    Main(null);

                }

                else if (input4menu == "5")
                {
                    wait.wait();
                    Console.Clear();
                    Main(null);
                }

                else if (input4menu == "0")
                {
                label:
                    Console.WriteLine("");
                    Console.Write("\nAre you sure you want to exit? (y/n) : ");
                    string x = Console.ReadLine();
                    if (x == "y" || x == "Y")
                    {
                        wait.wait();
                        Console.WriteLine();
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("-Thank you for using the software!-");
                        Console.WriteLine("-----------------------------------");
                        System.Threading.Thread.Sleep(1000);
                        Environment.Exit(0);
                        Console.ReadKey();
                    }
                    else if (x == "n" || x == "N")
                    {
                        System.Threading.Thread.Sleep(500);
                        Console.Clear();
                        Main(null);
                    }
                    else
                    {
                        Console.Write("Wrong Input! Try Again");
                        for (int i = 0; i < 3; i++)
                        {
                            System.Threading.Thread.Sleep(300);
                            Console.Write("");
                        }
                        goto label;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong Input! Try Again");
                    for (int i = 0; i < 3; i++)
                    {
                        System.Threading.Thread.Sleep(300);
                        Console.Write("");
                    }
                    System.Threading.Thread.Sleep(500);
                    Console.Clear();
                    Main(null);
                }
            }
        }
    }
}

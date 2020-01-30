using System;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            UserManager man = new UserManager();
            User1 usr1 = new User1
            {
                id = 444,
                user1code = "djslnfs",
            };
            man.adduser(usr1);

            User2 usr2 = new User2
            {
                id = 258,
                user2code = "ndsjf",
            };
            man.adduser(usr2);

            try
            {
                TestErr();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            HandleException(() =>
            {
                TestErr();
            });

        }

        private static void HandleException(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void TestErr()
        {
            int a = 7;
            int b = 0;
            int rs = a / b;
        }

        interface IUser
        {
            int id { get; set; }
        }

        class User1 : IUser
        {
            public int id { get; set; }
            public string user1code { get; set; }
        }

        class User2 : IUser
        {
            public int id { get; set; }
            public string user2code { get; set; }
        }

        class UserManager
        {
            public void adduser(IUser user)
            {
                Console.WriteLine(user.id);
            }

        }
    }
}

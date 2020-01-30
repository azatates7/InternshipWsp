using System;

namespace Inheritance
{
    public class Program
    {
        static void Main(string[] args)
        {
            Tester tester = new Tester();
            Console.WriteLine(tester.id);
        }

        public class User
        {
            public int id { get; set; }
            public string name { get; set; }
            public string userkey { get; set; }
        }

        public class Student : User
        {
            public int studentdepid { get; set; }
        }

        public class Tester : User
        { 

            public int testerdepid { get; set; }
        }

    }
}

using System;

namespace Virtual_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
             Mssql mssql =  new Mssql();
             mssql.Add();
             
             Console.ReadLine();
        }
    }

    class Database
    {
        public virtual void Add()
        {
            Console.WriteLine("Added");
        }
        public void Deleted()
        {
            Console.WriteLine("Deleted");
        }
         
    }

    class MySql : Database
    {
        public void Update()
        {
            Console.WriteLine("Updated");
        }
           
        public void Listed()
        {
            Console.WriteLine("Listed");
        }
    }

    class Mssql : Database
    {
        public void Selected()
        {
            Console.WriteLine("Selected");
        }

        public void Add()
        {
            Console.WriteLine("Deleted by mssql");
        }
        public void Listed()
        {
            Console.WriteLine("Listed");
        }
    }
}

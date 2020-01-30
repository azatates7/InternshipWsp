using System;

namespace Abstract_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Mssql ms = new Mssql();
            ms.Add();                    
        }
    }
    abstract class Database
    {
        public virtual void Add()
        {
            Console.WriteLine("Added");
        }
        public void Deleted()
        {
            Console.WriteLine("Deleted");
        }

        public abstract void Generated(); // in every class changed method

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

        public override void Generated()
        {
            throw new NotImplementedException();
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

        public override void Generated()
        {
            throw new NotImplementedException();
        }
    }
} 
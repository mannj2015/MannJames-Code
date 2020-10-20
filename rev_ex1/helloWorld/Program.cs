//dotnet new console -o helloWorld
//1.0 prefefined namespace
using System;

//delete bin and obj then run dotnet builds

//1.1 custom defined namespace
namespace helloWorld
{
    class Program
    {
        //start execution
            //commandline arguments
        static void Main(string[] args)
        {
            string fname, lname;
            //Console.WriteLine("Hello World!");
            Console.WriteLine("please enter fname");
            fname = Console.ReadLine();
            Console.WriteLine("please enter lname");
            lname = Console.ReadLine();
            //interpolation
            Console.WriteLine($"welcome {fname} {lname} !");

            //add date time
            //sql datetime?

            //adding weather?

            //connocation - less efficient
            //System.Console.WriteLine("w " + fname + " " + lname);
        }
    }
}

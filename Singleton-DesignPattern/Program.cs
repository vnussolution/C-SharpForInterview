using System;
using System.Threading.Tasks;

namespace Singleton_DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            // Purposely call these 2 methods at the same time , trying to instanciate 2 instaces of Singleton
            Parallel.Invoke(() => CreateS1(),()=>CreateS2());


            Console.ReadLine();
        }

        private static void CreateS2()
        {
            Singleton s2 = Singleton.GetInstance;
            s2.PrintDetails(" message from s2");
        }

        private static void CreateS1()
        {
            Singleton s1 = Singleton.GetInstance;
            s1.PrintDetails(" message from s1");
        }
    }


    // sealed restricts the inheritance
    public sealed class Singleton{

        //
        private static int counter = 0;

        //
        private static Singleton instance = null;


        // create dummy obj 
        private static readonly object obj = new object();


        // private constructor ensures that objects is not instanciated from outside of this class
        private Singleton()
        {
            counter++;
            Console.WriteLine($" Counter value = {counter}");
        }


        // return single instance 
        public static Singleton GetInstance{
            get{

                // because lock consumes lots of resources, use this check to skip it if possible
                if (instance == null)

                    // in case of multi-threading, it will let only 1 thread execute this
                    lock(obj){
                        // conditionally instantiate the object 
                        // this check again is not redundant 
                        if (instance == null)
                            instance = new Singleton();
                    }
                return instance;
            }
        }

        // public method can be invoked via the singleton instance
        public void PrintDetails(string message){
            Console.WriteLine(message);
        }
    }
}

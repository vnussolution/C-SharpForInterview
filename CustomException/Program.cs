using System;
using System.Runtime.Serialization;

namespace CustomException
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                throw new MyOwnException(" hello there ....");
            }
            catch (MyOwnException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.ReadKey();
            }


        }
    }

    // [Serializable]
    public class MyOwnException : Exception
    {
        public MyOwnException() : base()
        {

        }
        public MyOwnException(string message) : base(message)
        {

        }


        public MyOwnException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public MyOwnException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}

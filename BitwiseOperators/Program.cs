using System;

namespace BitwiseOperators
{

    //[Flags]
    [Flags]
    public enum Colors
    {
        Red = 1,
        Blue = 2,
        Green = 4,
        Pink = 8,
        Violet = 16,
        White = 32,
        Orange = 64,
        Purple = 128
    }
    class Program
    {


        static void Main(string[] args)
        {

            // Binary //https://www.youtube.com/watch?v=tNO05yKSQcU

            ////////////////Bitwise operators////////////////

            // And      & (Both)
            const byte a = 36;
            const byte b = 37;
            var c1 = (byte)a & (byte)b;
            PrintBitwise("And", a, b, c1);


            // Or       | (Either)
            var c2 = (byte)a | (byte)b;
            PrintBitwise("Or", a, b, c2);

            // Xor      ^ (Exclusive or, different)
            var c3 = (byte)a ^ (byte)b;
            PrintBitwise("XOr", a, b, c3);

            // Not      ~ (Invert)
            byte c4 = unchecked((byte)~a);
            PrintBitwise("Not", a, null, c4);


            ////////////////// Bitwise Shifting ////////////////
            // Left     <<   (move left 1 means multiply it by 2)
            byte c5 = (byte)(a << 1);
            PrintBitwise($" << 1", a, null, c5);

            // Right    >> (move right 1 means divide it by 2)
            byte c6 = (byte)(a >> 1);
            PrintBitwise($" >> 1", a, null, c6);


            ////////////////// Usage////////////////
            // Toggling boolean
            var d = true;
            d ^= true;
            Console.WriteLine($" toggling boolean d = {d}");


            // Enum flags
            var colors = (byte)(Colors.Blue | Colors.Orange);
            PrintColors(colors);

            // Masking
            //
            //

            Console.ReadLine();


        }


        public static void PrintBitwise(string type, int a, int? b, int c)
        {
            Console.WriteLine($"  First = {Convert.ToString(a, 2).PadLeft(8, '0')} - int value: {a} {type} {b} = {c}");

            if (b != null)
                Console.WriteLine($" Second = {Convert.ToString(b ?? 1, 2).PadLeft(8, '0')}");

            Console.WriteLine($" -----------------");
            Console.WriteLine($" Result = {Convert.ToString(c, 2).PadLeft(8, '0')} ");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


        }

        public static void PrintColors(byte colors)
        {
            byte next = 0;

            if (colors > 0)
            {

                foreach (var color in Enum.GetValues(typeof(Colors)))
                {
                    if (((Colors)colors & (Colors)color) == (Colors)color)
                    {
                        Console.WriteLine($" color is {(Colors)color}");
                    }
                }

            }

        }


    }
}

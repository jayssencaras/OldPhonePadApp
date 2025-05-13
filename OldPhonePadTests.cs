using System;

namespace OldPhonePadApp
{
    public static class OldPhonePadTests
    {
        public static void RunAll()
        {
            Run("33#", "E");
            Run("227*#", "B");
            Run("4433555 555666#", "HELLO");
            Run("8 88777444666*664#", "TURING");
            Run("5 2 999 7777 7777 33 66#", "JAYSSEN");
        }

        private static void Run(string input, string expected)
        {
            string actual = OldPhonePad.Decode(input);
            Console.WriteLine($"Input:    {input}");
            Console.WriteLine($"Expected: {expected}");
            Console.WriteLine($"Output:   {actual}");
            Console.WriteLine(actual == expected ? "✅ PASS\n" : "❌ FAIL\n");
        }
    }
}

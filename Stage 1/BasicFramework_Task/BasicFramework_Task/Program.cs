using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter decimal number:");
        string decimalNumberInput = Console.ReadLine();

        // Parse the decimal number input into an integer
        int decimalNumber;
        if (!int.TryParse(decimalNumberInput, out decimalNumber))
        {
            Console.WriteLine("Invalid decimal number.");
            return;
        }

        Console.WriteLine("Enter the base of the number system (from 2 to 20):");
        string baseInput = Console.ReadLine();

        // Parse the base input into an integer and validate it
        int newBase;
        if (!int.TryParse(baseInput, out newBase) || newBase < 2 || newBase > 20)
        {
            Console.WriteLine("Incorrect base of the number system. The base must be between 2 and 20.");
            return;
        }

        string result = ConvertToBase(decimalNumber, newBase);
        Console.WriteLine($"Decimal number {decimalNumber} in base number system {newBase}: {result}");
    }

    // Converts the decimal number to the specified base
    static string ConvertToBase(int decimalNumber, int newBase)
    {
        string digits = "0123456789ABCDEFGHIJ";
        string result = "";

        while (decimalNumber > 0)
        {
            int remainder = decimalNumber % newBase;
            result = digits[remainder] + result;
            decimalNumber /= newBase;
        }

        return result;
    }
}

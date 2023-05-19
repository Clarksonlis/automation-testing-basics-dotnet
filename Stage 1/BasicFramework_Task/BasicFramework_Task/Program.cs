using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите десятичное число:");
        string decimalNumberInput = Console.ReadLine();

        int decimalNumber;
        if (!int.TryParse(decimalNumberInput, out decimalNumber))
        {
            Console.WriteLine("Некорректное десятичное число.");
            return;
        }

        Console.WriteLine("Введите основание системы счисления (от 2 до 20):");
        string baseInput = Console.ReadLine();

        int newBase;
        if (!int.TryParse(baseInput, out newBase) || newBase < 2 || newBase > 20)
        {
            Console.WriteLine("Некорректное основание системы счисления. Основание должно быть от 2 до 20.");
            return;
        }

        string result = ConvertToBase(decimalNumber, newBase);
        Console.WriteLine($"Десятичное число {decimalNumber} в системе счисления с основанием {newBase}: {result}");
    }

    static string ConvertToBase(int decimalNumber, int newBase)
    {
        string digits = "0123456789ABCDEFGHIJ"; // Цифры для оснований до 20
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

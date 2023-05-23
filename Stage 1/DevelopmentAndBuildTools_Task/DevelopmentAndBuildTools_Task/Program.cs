namespace DevelopmentAndBuildTools
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input symbols: \n"); // Prompt the user to input symbols
            string input = Console.ReadLine(); // Read the input from the user

            string maxConsecutiveUnequalChars = GetMaxConsecutiveUnequalChars(input); // Call the method to calculate the maximum number of unequal consecutive characters

            Console.WriteLine($"The maximum number of unequal consecutive characters is: {maxConsecutiveUnequalChars.Length}."); // Display the result to the console
            Console.WriteLine($"The characters are: {maxConsecutiveUnequalChars}."); // Display the result to the console
        }

        // Method to calculate the maximum number of consecutive unequal characters
        public static string GetMaxConsecutiveUnequalChars(string input)
        {
            char[] inputArray = input.ToCharArray(); // Convert the input string to a character array

            if (inputArray.Length == 0)
            {
                return string.Empty; // If the input string is empty, there are no consecutive characters, so return 0
            }

            int currentNumber = 1; // Initialize the current count to 1
            string currentSequence = inputArray[0].ToString();
            string maxSequence = inputArray[0].ToString();
            int startIndex = 0; // Initialize the starting index to 0

            for (int i = 1; i < inputArray.Length; i++) // Iterate through the character array
            {
                for (int j = i - 1; j >= startIndex; j--) // Iterate through the previous characters in the array
                {
                    // If a repeating character is found, update the maximum count and reset the current count
                    if (inputArray[j] == inputArray[i])
                    {
                        maxSequence = maxSequence.Length > currentSequence.Length ? maxSequence : currentSequence;
                        currentSequence = string.Empty;
                        currentNumber = 0;
                        startIndex = i;
                        break;
                    }
                }

                currentSequence += inputArray[i].ToString();
                maxSequence = maxSequence.Length > currentSequence.Length ? maxSequence : currentSequence;
                currentNumber++; // Increment the current count for consecutive unequal characters
            }

            return maxSequence; // Return the maximum count of consecutive unequal characters
        }
    }
}
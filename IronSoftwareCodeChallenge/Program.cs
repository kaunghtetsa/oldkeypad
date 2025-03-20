using System;
using System.Text;

public class OldPhoneTyping
{
    private static readonly string[] keypadChars = new string[]
    {
        " ",      // 0 (I will consider space)
        "&'(",   // 1
        "ABC",   // 2
        "DEF",   // 3
        "GHI",   // 4
        "JKL",   // 5
        "MNO",   // 6
        "PQRS",  // 7
        "TUV",   // 8
        "WXYZ"   // 9
    };

    public static void Main(string[] args)
    {
        Console.WriteLine(OldPhonePad("33#"));                // Output: E
        Console.WriteLine(OldPhonePad("227*#"));              // Output: B
        Console.WriteLine(OldPhonePad("4433555 555666#"));    // Output: HELLO
        Console.WriteLine(OldPhonePad("8 88777444666*664#")); // Output: TURING
        Console.WriteLine(OldPhonePad("222 2 22#"));          // Output: CAB
        Console.WriteLine(OldPhonePad("2#"));                 // Output: A
        Console.WriteLine(OldPhonePad("22#"));                // Output: B
        Console.WriteLine(OldPhonePad("222#"));               // Output: C
        Console.WriteLine(OldPhonePad("22222#"));
        Console.WriteLine(OldPhonePad("222 22#"));
        Console.WriteLine(OldPhonePad("22*22#"));
        Console.WriteLine(OldPhonePad("1#"));
        Console.WriteLine(OldPhonePad("11#"));
        Console.WriteLine(OldPhonePad("111#"));
        Console.WriteLine(OldPhonePad("1111#"));
        Console.WriteLine(OldPhonePad("0#"));
        Console.WriteLine(OldPhonePad("00#"));
        Console.WriteLine(OldPhonePad("0 0#"));
        Console.WriteLine(OldPhonePad("20#"));
        Console.WriteLine(OldPhonePad("220#"));
        Console.WriteLine(OldPhonePad("4433***555666#"));
        Console.WriteLine(OldPhonePad("**#"));
    }

    public static string OldPhonePad(string input)
    {
        try
        {
            // Check for invalid input
            if (string.IsNullOrEmpty(input) || !input.EndsWith("#") || string.IsNullOrWhiteSpace(input))
            {
                return "Invalid input.";
            }

            // Remove '#' at end of my input
            input = input.Remove(input.Length - 1);

            // My main operation
            #region my main operation updated on 20-march-2025
            StringBuilder result = new StringBuilder();
            StringBuilder temp = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                // Handle invalid characters (non-digit and non-special characters) 08:24pm
                if (!char.IsDigit(currentChar) && currentChar != '*' && currentChar != ' ')
                {
                    return "Invalid input.";
                }

                // Handle backspace ('*') 
                if (currentChar == '*')
                {
                    if (result.Length > 0)
                    {
                        result.Remove(result.Length - 1, 1); // Remove the last character
                    }
                    continue;
                }

                // Handle space (' ')
                if (currentChar == ' ')
                {
                    if (temp.Length > 0)
                    {
                        string letter = GetLetterFromKeys(temp.ToString());//divide op method here
                        if (letter == "Invalid input.")
                        {
                            return "Invalid input.";
                        }
                        result.Append(letter);
                        temp.Clear();
                    }
                    continue;
                }

                temp.Append(currentChar);

                // If the next character is different or this is the last character,clear temp & add char to the res
                if (i == input.Length - 1 || currentChar != input[i + 1])
                {
                    string letter = GetLetterFromKeys(temp.ToString());
                    if (letter == "Invalid input.")
                    {
                        return "Invalid input.";
                    }
                    result.Append(letter);
                    temp.Clear();
                }
            }

            #endregion
            return result.ToString();
        }
        catch { return "Invalid input."; }
    }

    private static string GetLetterFromKeys(string presses)
    {
        try
        {
            if (string.IsNullOrEmpty(presses))
            {
                return "Invalid input.";
            }

            int keyIndex;
            if (!int.TryParse(presses[0].ToString(), out keyIndex))
            {
                return "Invalid input.";
            }

            int pressCount = presses.Length; // presses count

            // invalid case
            if (keyIndex < 0 || keyIndex >= keypadChars.Length || string.IsNullOrEmpty(keypadChars[keyIndex]))
            {
                return "Invalid input.";
            }

            // If press count exceeds the number of letters, return "Invalid input." add on 9:44pm
            if (pressCount > keypadChars[keyIndex].Length)
            {
                return "Invalid input.";
            }

            // modified on 9:44pm
            int letterIndex = pressCount - 1;

            return keypadChars[keyIndex][letterIndex].ToString();
        }
        catch { return "Invalid input."; }
    }
}
using System.Text;

public class OldPhoneTyping
{
    public static void Main(string[] args)
    {
        OldPhonePad("33#");                // Output: E
        OldPhonePad("227*#");              // Output: B
        OldPhonePad("4433555 555666#");    // Output: HELLO
        OldPhonePad("8 88777444666*664#"); // Output: TURING
        OldPhonePad("222 2 22#");          // Output: CAB
        OldPhonePad("2#");                 // Output: A
        OldPhonePad("22#");                // Output: B
        OldPhonePad("222#");               // Output: C
        OldPhonePad("22222#");             // Output: Invalid input
    }

    private static readonly string[] keypadChars = new string[]
    {
        "",
        "&'(",
        "ABC",
        "DEF",
        "GHI",
        "JKL",
        "MNO",
        "PQRS",
        "TUV",
        "WXYZ"
    };

    private static void OldPhonePad(string input)
    {
        try
        {
            if (string.IsNullOrEmpty(input) || !input.EndsWith("#"))
            {
                Console.WriteLine("Invalid input.");
            }

            StringBuilder result = new StringBuilder();
            StringBuilder temp = new StringBuilder();
            input = input.Remove(input.Length - 1); // Remove char '#' at the end

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '*')
                {
                    if (result.Length > 0)
                    {
                        result.Remove(result.Length - 1, 1); // Remove last char(backspace) find by *
                    }
                    continue;
                }

                if (input[i] == ' ')
                {
                    if (temp.Length > 0)
                    {
                        result.Append(keypadChars[int.Parse(temp[0].ToString())][temp.Length - 1]);
                        temp.Clear();
                    }
                    continue;
                }

                if (i < input.Length - 1 && input[i] == input[i + 1])
                {
                    temp.Append(input[i]);
                }
                else
                {
                    temp.Append(input[i]);
                    result.Append(keypadChars[int.Parse(temp[0].ToString())][temp.Length - 1]);
                    temp.Clear();
                }
            }

            Console.WriteLine(result.ToString());
        }

        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }
}
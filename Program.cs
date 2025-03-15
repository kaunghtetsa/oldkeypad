using System.Linq;
using System.Text;

public class OldPhoneTyping
{
    public static void Main(string[] args)
    {
        OldPhonePad("33#"); //=> output: E 
        OldPhonePad("227*#"); //=> output: B 
        OldPhonePad("4433555 555666#"); //=> output: HELLO 
        OldPhonePad("8 88777444666*664#"); //=> output: ????
    }
    static readonly string[] keypadChars = new string[]
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
    static void OldPhonePad(string input)
    {
        try
        {
            if (!string.IsNullOrEmpty(input) && input.EndsWith("#") && input.Length > 1)
            {
                StringBuilder result = new StringBuilder();
                StringBuilder temp = new StringBuilder();
                input=input.Remove(input.Length - 1, 1);
                temp.Append(input.ElementAt(0));
                    
                for (int i = 0; i < input.Length-1; i++)
                {
                    if (i == input.Length - 2)
                    {
                        result.Append(keypadChars[int.Parse(temp[0].ToString())][temp.Length]);
                        continue;
                    }
                    if (input[i] == '*')
                    {
                        if (result.Length > 0)
                        {
                            result.Remove(result.Length - 1, 1); // Remove the last character
                        }
                        continue;
                    }
                    if (input[i] == input[i+1] && input[i+1]!=' ')
                    {
                        temp.Append(input[i + 1]);
                    }
                    else
                    {
                        result.Append(keypadChars[int.Parse(temp[0].ToString())][temp.Length]);
                        i++;
                        temp.Clear();
                    }
                   
                }

                Console.WriteLine(result); return;
            }
        }
        catch { }
        Console.WriteLine("Invalid input.");


    }
}
using Xunit;

public class OldPhoneTypingTests
{
    /// <summary>
    /// Testing normal input HELLO
    /// </summary>
    [Fact]
    public void Test_HELLO()
    {
        string output = OldPhoneTyping.OldPhonePad("4433555 555666#");
        Assert.Equal("HELLO", output);
    }

    /// <summary>
    /// Testing normal input TURING
    /// </summary>
    [Fact]
    public void Test_TURING()
    {
        string output = OldPhoneTyping.OldPhonePad("8 88777444666*664#");
        Assert.Equal("TURING", output);
    }

    /// <summary>
    /// Testing backspace
    /// </summary>
    [Fact]
    public void Test_Backspace()
    {
        string output = OldPhoneTyping.OldPhonePad("227*#");
        Assert.Equal("B", output);
    }

    /// <summary>
    /// Testing single character input
    /// </summary>
    [Fact]
    public void Test_SingleChar()
    {
        string output = OldPhoneTyping.OldPhonePad("2#");
        Assert.Equal("A", output);
    }

    /// <summary>
    /// Testing invalid input (too many presses 2)
    /// </summary>
    [Fact]
    public void Test_InvalidInput()
    {
        string output = OldPhoneTyping.OldPhonePad("22222#");
        Assert.Equal("Invalid input.", output);
    }

    /// <summary>
    /// Testing empty input
    /// </summary>
    [Fact]
    public void Test_Empty()
    {
        string output = OldPhoneTyping.OldPhonePad("");
        Assert.Equal("Invalid input.", output);
    }

    /// <summary>
    /// Testing multiple spaces in input
    /// </summary>
    [Fact]
    public void Test_MultipleSpaces()
    {
        string output = OldPhoneTyping.OldPhonePad("44 33   555   555666#");
        Assert.Equal("HELLO", output);
    }

    /// <summary>
    /// Testing input with only special characters
    /// </summary>
    [Fact]
    public void Test_OnlySpecialCharacters()
    {
        string output = OldPhoneTyping.OldPhonePad("**#");
        Assert.Equal("", output);
    }

    /// <summary>
    /// Testing mixed characters and backspace
    /// </summary>
    [Fact]
    public void Test_MixedCharacters()
    {
        string output = OldPhoneTyping.OldPhonePad("22 777 444#*");
        Assert.Equal("Invalid input.", output);
    }

    /// <summary>
    /// Testing rare case with all letters from the keypad
    /// </summary>
    [Fact]
    public void Test_RareCase()
    {
        string input = "222 333 444 555 666 777 888 999#";
        string output = OldPhoneTyping.OldPhonePad(input);
        Assert.Equal("CFILORVY", output);
    }

    /// <summary>
    /// Testing input with spaces and backspaces
    /// </summary>
    [Fact]
    public void Test_AbnormalSpaceAndBackspaces()
    {
        string output = OldPhoneTyping.OldPhonePad("44 33**555 6 6 *6#");
        Assert.Equal("LMM", output);
    }

    /// <summary>
    /// Testing input with no letter keys ('1' and '0' have no letters)
    /// </summary>
    [Fact]
    public void Test_NumbersWithoutLetters()
    {
        string output = OldPhoneTyping.OldPhonePad("1111 0000 99999#");
        Assert.Equal("Invalid input.", output);
    }

    /// <summary>
    /// Testing long backspace sequence
    /// </summary>
    [Fact]
    public void Test_LongBackspace()
    {
        string output = OldPhoneTyping.OldPhonePad("222**#");
        Assert.Equal("", output);
    }

    /// <summary>
    /// Testing input with repeated numbers
    /// </summary>
    [Fact]
    public void Test_Repetition()
    {
        string output = OldPhoneTyping.OldPhonePad("2222222222#");
        Assert.Equal("Invalid input.", output);
    }

    /// <summary>
    /// Testing input with multiple backspaces in sequence add on 11:20pm
    /// </summary>
    [Fact]
    public void Test_ContinuousBackspaces()
    {
        string output = OldPhoneTyping.OldPhonePad("4433***555666#");
        Assert.Equal("LO", output);
    }

    /// <summary>
    /// Testing input that does not end with '#'
    /// </summary>
    [Fact]
    public void Test_InputDoesNotEndWithHash()
    {
        string output = OldPhoneTyping.OldPhonePad("4433555 555666");
        Assert.Equal("Invalid input.", output);
    }

    /// <summary>
    /// Testing input with invalid characters
    /// </summary>
    [Fact]
    public void Test_InvalidCharacters()
    {
        string output = OldPhoneTyping.OldPhonePad("44a33#");
        Assert.Equal("Invalid input.", output);
    }
}
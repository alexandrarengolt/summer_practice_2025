namespace task01;
public static class StringExtensions
{
    public static bool IsPalindrome(this string input)
    {
         if (string.IsNullOrEmpty(input))
            return false;
            
        List<char> formatted = new List<char>();

        string lowerInput = input.ToLower();
        
        foreach (var a in lowerInput)
        {
            if (!Char.IsWhiteSpace(a) && !Char.IsPunctuation(a)) formatted.Add(a);
        }

        List<char> reverseOrder = new List<char>(formatted);
        reverseOrder.Reverse();

        return formatted.SequenceEqual(reverseOrder);
    }
}
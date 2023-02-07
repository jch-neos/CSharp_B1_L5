using System.Text;

public class RomanNumeralConverter : INumberConverter<int>
{
    // Stryker disable once string
    readonly string[] romanLetters = {
        "CM","M","CD","D","XC","C","XL","L","IX","X","IV","V","I"
    };
    readonly int[] numbers = {
        900,1000,400,500,90,100,40,50,9,10,4,5,1
    };
    // Stryker disable once string
    readonly string[] romanLettersTo = {
        "M","CM","D","CD","C","XC","L","XL","X","IX","V","IV","I"
    };
    readonly int[] numbersTo = {
        1000,900,500,400,100,90,50,40,10,9,5,4,1
    };

    public int Parse(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value);
        return Parse(value.AsSpan());
    }
    int Parse(ReadOnlySpan<char> value)
    {
        if (value.SequenceEqual("N".AsSpan()))
        {
            return 0;
        }
        int i = 0;
        int result = 0;
        while (!value.IsEmpty)
        {
            ThrowIfIndexTooHigh(i);
            if (!value.StartsWith(romanLetters[i]))
            {
                i++;
                continue;
            }

            // add value for matching group 
            result += numbers[i];
            // move to next group in source
            value = value.Slice(romanLetters[i].Length);

            if (romanLetters[i].Length > 1)
            {
                ThrowIfDoubleGroup(value, romanLetters[i]);
                // forbid "X" folloing "IX", jump to "V" 
                i += 3;
            }
        }
        return result;
    }

    private void ThrowIfDoubleGroup(ReadOnlySpan<char> value, string group)
    {
        if (!value.IsEmpty && value.StartsWith(group))
            throw new FormatException($"Cannot have 2 groups of {group}");
    }

    private void ThrowIfIndexTooHigh(int i)
    {
        if (i >= romanLetters.Length)
            throw new FormatException($"Invalid roman numeral");
    }

    public string Stringify(int value)
    {
        ThrowIfNegative(value);
        if (value == 0) return "N";
        int i = 0;
        var romanResult = new StringBuilder();
        while (value != 0)
        {
            if (value >= numbersTo[i])
            {
                value -= numbersTo[i];
                romanResult.Append(romanLettersTo[i]);
            }
            else
            {
                i++;
            }
        }
        return romanResult.ToString();
    }

    private static void ThrowIfNegative(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException(nameof(value), "value must be positive");
        }
    }
}
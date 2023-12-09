namespace AdventOfCode2023.Utilities;
public static class StringExtensions
{
	public static string StringReverse(this string input)
	{
		var reversedArray = input.Reverse().ToArray();
		return new string(reversedArray);
	}

	public static string[] StringReverse(this string[] input)
	{
		var d = input.Select(i => i.StringReverse());
		return d.ToArray();
	}
}

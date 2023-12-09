using System.Text.RegularExpressions;

namespace AdventOfCode2023.Utilities;
public static class RegexUtilities
{
	public static Regex RegexMatchAnyInstanceOf(ICollection<string> strings)
	{
		var allOptions = strings.ToList();
		var matchString = string.Join("|", allOptions);
		return new Regex($"({matchString})");
	}

	public static Regex Integers() => new(@"\d");
}

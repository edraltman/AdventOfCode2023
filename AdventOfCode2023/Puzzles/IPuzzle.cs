namespace AdventOfCode2023.Puzzles;

public interface IPuzzle
{
    public string FileName();
    public string[] PuzzleInput();
    public string Solution();
}
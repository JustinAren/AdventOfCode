namespace AdventOfCode2020;

public class Day02 : Day<string[]>
{
    protected override string[] ParseInput(string inputString) => inputString.SplitNewLine();

    public override string Perform1(string inputString)
    {
        var inputArray = ParseInput(inputString);

        var count = (from line in inputArray
                     select line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     into lineSplitted
                     let limits = lineSplitted[0].Split('-', StringSplitOptions.RemoveEmptyEntries)
                     let lowerLimit = int.Parse(limits[0])
                     let upperLimit = int.Parse(limits[1])
                     let matchingCharacter = lineSplitted[1][0]
                     let occurrences = lineSplitted[2].Count(occurrence => occurrence == matchingCharacter)
                     where occurrences >= lowerLimit && occurrences <= upperLimit
                     select lowerLimit).Count();

        return count.ToString();
    }

    public override string Perform2(string inputString)
    {
        var inputArray = ParseInput(inputString);

        var count = (from line in inputArray
                     select line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     into lineSplitted
                     let positions = lineSplitted[0].Split('-', StringSplitOptions.RemoveEmptyEntries)
                     let firstPosition = int.Parse(positions[0])
                     let secondPosition = int.Parse(positions[1])
                     let matchingCharacter = lineSplitted[1][0]
                     let firstCharacter = lineSplitted[2][firstPosition - 1]
                     let secondCharacter = lineSplitted[2][secondPosition - 1]
                     where (firstCharacter == matchingCharacter && secondCharacter != matchingCharacter) ||
                         (firstCharacter != matchingCharacter && secondCharacter == matchingCharacter)
                     select matchingCharacter).Count();

        return count.ToString();
    }
}
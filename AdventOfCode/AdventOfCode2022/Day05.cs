using System.Text;

namespace AdventOfCode2022;

public class Day05 : Day<StackingPlan>
{
	protected override StackingPlan ParseInput(string inputString) => StackingPlan.Parse(inputString);

	public override string Perform1(string inputString)
	{
		var plan = ParseInput(inputString);
		plan.ProcessInstructions9000();
		var resultBuilder = new StringBuilder();
		foreach (var stack in plan.Stacks) resultBuilder.Append(stack.Pop());
		return resultBuilder.ToString();
	}

	public override string Perform2(string inputString)
	{
		var plan = ParseInput(inputString);
		plan.ProcessInstructions9001();
		var resultBuilder = new StringBuilder();
		foreach (var stack in plan.Stacks) resultBuilder.Append(stack.Pop());
		return resultBuilder.ToString();
	}
}

public record struct Instruction(int Count, int From, int To)
{
	public static Instruction Parse(string inputString)
	{
		var words = inputString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
		return new Instruction(int.Parse(words[1]), int.Parse(words[3]), int.Parse(words[5]));
	}
}

public record class StackingPlan(List<Stack<char>> Stacks, List<Instruction> Instructions)
{
	public static StackingPlan Parse(string inputString)
	{
		var parts = inputString.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);
		var stackLines = parts[0].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();
		var stacks = new List<Stack<char>>();
		for (var i = 0; i < stackLines[0].Length / 4 + 1; i++) stacks.Add(new Stack<char>());

		foreach (var line in stackLines)
			for (var i = 0; i < line.Length; i++)
				if (line[i] >= 'A' && line[i] <= 'Z')
					stacks[i / 4].Push(line[i]);

		var instructions = parts[1].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(Instruction.Parse).ToList();

		return new StackingPlan(stacks, instructions);
	}

	public void ProcessInstructions9000()
	{
		foreach (var instruction in Instructions)
			for (var i = 0; i < instruction.Count; i++)
				Stacks[instruction.To - 1].Push(Stacks[instruction.From - 1].Pop());
	}

	public void ProcessInstructions9001()
	{
		foreach (var instruction in Instructions)
		{
			var tempStack = new Stack<char>();
			for (var i = 0; i < instruction.Count; i++)
				tempStack.Push(Stacks[instruction.From - 1].Pop());
			while (tempStack.Count > 0)
				Stacks[instruction.To - 1].Push(tempStack.Pop());
		}
	}
}
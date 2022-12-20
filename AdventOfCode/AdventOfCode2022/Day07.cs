using System.Text;

namespace AdventOfCode2022;

public class Day07 : Day<Directory>
{
	protected override Directory ParseInput(string inputString)
	{
		var root = new Directory("/", null);
		var currentDirectory = root;
		var commands = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
		foreach (var command in commands)
		{
			var words = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			switch (words[0])
			{
				case "$":
					switch (words[1])
					{ 
						case "cd":
							switch (words[2])
							{
								case "..": currentDirectory = currentDirectory!.Parent; break;
								case "/": currentDirectory = root; break;
								default: currentDirectory = currentDirectory!.Directories.Single(d => d.Name== words[2]); break;
							}
							break;
						default: continue;
					}
					break;
				case "dir": currentDirectory!.Directories.Add(new Directory(words[1], currentDirectory)); break;
				default: currentDirectory!.Files.Add(new File(words[1], long.Parse(words[0]))); break;
			}
		}
		return root;
	}

	public override string Perform1(string inputString)
	{
		var root = this.ParseInput(inputString);
		var foundDirectories = GetDirectoriesWithMaxSize(100000, root);
		return foundDirectories.Sum(d => d.Size).ToString();
	}

	private static List<Directory> GetDirectoriesWithMaxSize(int maxSize, Directory inputDirectory)
	{
		var result = new List<Directory>();
		foreach (var directory in inputDirectory.Directories)
		{
			if (directory.Size <= maxSize) result.Add(directory);
			result.AddRange(GetDirectoriesWithMaxSize(maxSize, directory));
		}
		return result;
	}

	public override string Perform2(string inputString)
	{
		var root = this.ParseInput(inputString);
		return inputString;
	}
}

public readonly record struct File(string Name, long Size);

public class Directory
{
	public string Name { get; }
	public List<Directory> Directories { get; } = new();
	public List<File> Files { get; } = new();
	public long Size => Files.Sum(f => f.Size) + Directories.Sum(d => d.Size);
	public Directory? Parent { get; }

	public Directory(string name, Directory? parent)
	{
		Name = name;
		this.Parent = parent;
	}
}
﻿namespace AdventOfCode2022;

public class Day07 : Day<Directory>
{
    private static IEnumerable<Directory> GetDirectoriesWithMaxSize(int maxSize, Directory inputDirectory)
    {
        var result = new List<Directory>();
        foreach (var directory in inputDirectory.Directories)
        {
            if (directory.Size <= maxSize) result.Add(directory);
            result.AddRange(GetDirectoriesWithMaxSize(maxSize, directory));
        }

        return result;
    }

    private static long? GetDirectorySizeToRemove(long toBeRemoved, Directory directory)
    {
        if (directory.Directories.Count == 0 && directory.Size >= toBeRemoved) return directory.Size;
        if (directory.Directories.Count == 0 || directory.Size < toBeRemoved) return null;

        var sizesToRemove = new List<long> { directory.Size };

        foreach (var subDirectory in directory.Directories)
        {
            var sizeToRemove = GetDirectorySizeToRemove(toBeRemoved, subDirectory);
            if (sizeToRemove is null) continue;
            sizesToRemove.Add(sizeToRemove.Value);
        }

        return sizesToRemove.MinBy(size => size);
    }

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
                            currentDirectory = words[2] switch
                            {
                                ".." => currentDirectory!.Parent,
                                "/" => root,
                                _ => currentDirectory!.Directories.Single(d => d.Name == words[2])
                            };
                            break;
                        default: continue;
                    }

                    break;
                case "dir":
                    currentDirectory!.Directories.Add(new Directory(words[1], currentDirectory));
                    break;
                default:
                    currentDirectory!.Files.Add(new File(words[1], long.Parse(words[0])));
                    break;
            }
        }

        return root;
    }

    public override string Perform1(string inputString)
    {
        var root = ParseInput(inputString);
        var foundDirectories = GetDirectoriesWithMaxSize(100000, root);
        return foundDirectories.Sum(d => d.Size).ToString();
    }

    public override string Perform2(string inputString)
    {
        var root = ParseInput(inputString);
        var unused = 70_000_000L - root.Size;
        var toBeRemoved = 30_000_000L - unused;
        return (GetDirectorySizeToRemove(toBeRemoved, root) ?? 0).ToString();
    }
}

public readonly record struct File(string Name, long Size);

public class Directory
{
    public Directory(string name, Directory? parent)
    {
        Name = name;
        Parent = parent;
    }

    public List<Directory> Directories { get; } = new();

    public List<File> Files { get; } = new();

    public string Name { get; }

    public Directory? Parent { get; }

    public long Size => Files.Sum(f => f.Size) + Directories.Sum(d => d.Size);
}
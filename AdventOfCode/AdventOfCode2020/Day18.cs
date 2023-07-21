using System.Text.RegularExpressions;

namespace AdventOfCode2020;

public partial class Day18 : Day<IExpression[]>
{
    [GeneratedRegex("\\s")]
    private static partial Regex ExpressionRegex();

    private static IExpression ParseExpression(string expressionString)
    {
        expressionString = ExpressionRegex().Replace(expressionString, "");
        return ParseExpression(expressionString, 0, expressionString.Length);
    }

    private static IExpression ParseExpression(string expressionString, int start, int end)
    {
        if (end - start == 1) return new Constant(long.Parse(expressionString[start].ToString()));

        var parenthesisCount = 0;

        for (var i = end - 1; i >= start; i--)
        {
            var currentChar = expressionString[i];

            switch (currentChar)
            {
                case '(':
                    parenthesisCount++;
                    break;

                case ')':
                    parenthesisCount--;
                    break;

                default:
                {
                    if (parenthesisCount == 0)
                        switch (currentChar)
                        {
                            case '+':
                                return new Sum(ParseExpression(expressionString, start, i),
                                    ParseExpression(expressionString, i + 1, end));

                            case '*':
                                return new Product(ParseExpression(expressionString, start, i),
                                    ParseExpression(expressionString, i + 1, end));
                        }

                    break;
                }
            }
        }

        return new Parenthesis(ParseExpression(expressionString, start + 1, end - 1));
    }

    protected override IExpression[] ParseInput(string inputString)
    {
        var expressions = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        return expressions.Select(ParseExpression).ToArray();
    }

    public override string Perform1(string inputString)
    {
        var input = ParseInput(inputString);
        return input.Aggregate<IExpression, long>(0, (sum, expression) => sum + expression.Calculate())
            .ToString();
    }

    public override string Perform2(string inputString)
    {
        var input = ParseInput(inputString);
        for (var i = 0; i < 100; i++) input = input.Select(expression => expression.Rewrite()).ToArray();
        return input.Aggregate<IExpression, long>(0, (sum, expression) => sum + expression.Calculate())
            .ToString();
    }
}

public interface IExpression
{
    long Calculate();

    IExpression Rewrite();
}

public class Constant : IExpression
{
    public Constant(long value) => Value = value;

    #region Implementation of IExpression

    public long Calculate() => Value;

    public IExpression Rewrite() => this;

    #endregion

    private long Value { get; }
}

public class Sum : IExpression
{
    public Sum(IExpression leftSide, IExpression rightSide)
    {
        LeftSide = leftSide;
        RightSide = rightSide;
    }

    #region Implementation of IExpression

    public long Calculate() => LeftSide.Calculate() + RightSide.Calculate();

    public IExpression Rewrite()
    {
        if (LeftSide is Product product)
            return new Product(product.LeftSide.Rewrite(),
                new Sum(product.RightSide.Rewrite(), RightSide.Rewrite()));

        return new Sum(LeftSide.Rewrite(), RightSide.Rewrite());
    }

    #endregion

    private IExpression LeftSide { get; }

    private IExpression RightSide { get; }
}

public class Product : IExpression
{
    public Product(IExpression leftSide, IExpression rightSide)
    {
        LeftSide = leftSide;
        RightSide = rightSide;
    }

    #region Implementation of IExpression

    public long Calculate() => LeftSide.Calculate() * RightSide.Calculate();

    public IExpression Rewrite() => new Product(LeftSide.Rewrite(), RightSide.Rewrite());

    #endregion

    public IExpression LeftSide { get; }

    public IExpression RightSide { get; }
}

public class Parenthesis : IExpression
{
    public Parenthesis(IExpression innerExpression) => InnerExpression = innerExpression;

    #region Implementation of IExpression

    public long Calculate() => InnerExpression.Calculate();

    public IExpression Rewrite() => new Parenthesis(InnerExpression.Rewrite());

    #endregion

    private IExpression InnerExpression { get; }
}
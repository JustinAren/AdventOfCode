using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
	public class Day18 : Day<IExpression[]>
	{
		public override ulong Perform1(string inputString)
		{
			var input = this.ParseInput(inputString);
			return input.Aggregate<IExpression, ulong>(0, (sum, expression) => sum + expression.Calculate());
		}

		public override ulong Perform2(string inputString)
		{
			var input = this.ParseInput(inputString);
			throw new NotImplementedException();
		}

		protected override IExpression[] ParseInput(string inputString)
		{
			var expressions = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
			return expressions.Select(ParseExpression).ToArray();
		}

		private static IExpression ParseExpression(string expressionString)
		{
			expressionString = Regex.Replace(expressionString, @"\s", "");
			return ParseExpression(expressionString, 0, expressionString.Length);
		}

		private static IExpression ParseExpression(string expressionString, int start, int end)
		{
			if (end - start == 1) return new Constant(UInt64.Parse(expressionString[start].ToString()));

			var parenthesisCount = 0;

			for (var i = end - 1; i >= start; i--)
			{
				var currentChar = expressionString[i];

				switch (currentChar)
				{
					case '(': parenthesisCount++; break;
					case ')': parenthesisCount--; break;
					default:
					{
						if (parenthesisCount == 0)
							switch (currentChar)
							{
								case '+': return new Sum(ParseExpression(expressionString, start, i), ParseExpression(expressionString, i + 1, end));
								case '*': return new Product(ParseExpression(expressionString, start, i), ParseExpression(expressionString, i + 1, end));
							}

						break;
					}
				}
			}

			return new Parenthesis(ParseExpression(expressionString, start + 1, end - 1));
		}
	}

	public interface IExpression
	{
		ulong Calculate();
	}

	public class Constant : IExpression
	{
		public ulong Value { get; }

		public Constant(ulong value)
		{
			this.Value = value;
		}

		public ulong Calculate()
		{
			return this.Value;
		}
	}

	public class Sum : IExpression
	{
		public IExpression LeftSide { get; }
		public IExpression RightSide { get; }

		public Sum(IExpression leftSide, IExpression rightSide)
		{
			this.LeftSide = leftSide;
			this.RightSide = rightSide;
		}

		public ulong Calculate()
		{
			return this.LeftSide.Calculate() + this.RightSide.Calculate();
		}
	}

	public class Product : IExpression
	{
		public IExpression LeftSide { get; }
		public IExpression RightSide { get; }

		public Product(IExpression leftSide, IExpression rightSide)
		{
			this.LeftSide = leftSide;
			this.RightSide = rightSide;
		}

		public ulong Calculate()
		{
			return this.LeftSide.Calculate() * this.RightSide.Calculate();
		}
	}

	public class Parenthesis : IExpression
	{
		public IExpression InnerExpression { get; }

		public Parenthesis(IExpression innerExpression)
		{
			this.InnerExpression = innerExpression;
		}

		public ulong Calculate()
		{
			return this.InnerExpression.Calculate();
		}
	}
}

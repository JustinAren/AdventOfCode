﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCodeBase;

namespace AdventOfCode2020
{
	public class Day18 : Day<IExpression[]>
	{
		public override long Perform1(string inputString)
		{
			var input = this.ParseInput(inputString);
			return input.Aggregate<IExpression, long>(0, (sum, expression) => sum + expression.Calculate());
		}

		public override long Perform2(string inputString)
		{
			var input = this.ParseInput(inputString);
			for (var i = 0; i < 100; i++) input = input.Select(expression => expression.Rewrite()).ToArray();
			return input.Aggregate<IExpression, long>(0, (sum, expression) => sum + expression.Calculate());
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
			if (end - start == 1) return new Constant(Int64.Parse(expressionString[start].ToString()));

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
		long Calculate();
		IExpression Rewrite();
	}

	public class Constant : IExpression
	{
		public long Value { get; }

		public Constant(long value)
		{
			this.Value = value;
		}

		public long Calculate()
		{
			return this.Value;
		}

		public IExpression Rewrite()
		{
			return this;
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

		public long Calculate()
		{
			return this.LeftSide.Calculate() + this.RightSide.Calculate();
		}

		public IExpression Rewrite()
		{
			if (this.LeftSide is Product product) return new Product(product.LeftSide.Rewrite(), new Sum(product.RightSide.Rewrite(), this.RightSide.Rewrite()));
			return new Sum(this.LeftSide.Rewrite(), this.RightSide.Rewrite());
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

		public long Calculate()
		{
			return this.LeftSide.Calculate() * this.RightSide.Calculate();
		}

		public IExpression Rewrite()
		{
			return new Product(this.LeftSide.Rewrite(), this.RightSide.Rewrite());
		}
	}

	public class Parenthesis : IExpression
	{
		public IExpression InnerExpression { get; }

		public Parenthesis(IExpression innerExpression)
		{
			this.InnerExpression = innerExpression;
		}

		public long Calculate()
		{
			return this.InnerExpression.Calculate();
		}

		public IExpression Rewrite()
		{
			return new Parenthesis(this.InnerExpression.Rewrite());
		}
	}
}
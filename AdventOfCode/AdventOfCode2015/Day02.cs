using System;
using System.Linq;
using AdventOfCodeBase;

namespace AdventOfCode2015
{
    public class Day02 : Day<Rectangle[]>
    {
        public override long Perform1(string inputString)
        {
            var inputRectangles = this.ParseInput(inputString);
            var result = inputRectangles.Select(r => r.CalculateWrappingPaperSurface()).Sum();
            return result;
        }

        public override long Perform2(string inputString)
        {
            throw new NotImplementedException();
        }

        protected override Rectangle[] ParseInput(string inputString)
        {
            var strings = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = new Rectangle[strings.Length];
            for (var i = 0; i < strings.Length; i++)
            {
                var splits = strings[i].Split('x', StringSplitOptions.RemoveEmptyEntries);
                result[i] = new Rectangle(Int32.Parse(splits[0]), Int32.Parse(splits[1]), Int32.Parse(splits[2]));
            }

            return result;
        }
    }

    public readonly record struct Rectangle(int Length, int Width, int Height)
    {
        public int CalculateWrappingPaperSurface()
        {
            var lwSurface = this.Length * this.Width;
            var whSurface = this.Width * this.Height;
            var lhSurface = this.Length * this.Height;

            var minSurface = Math.Min(Math.Min(lwSurface, whSurface), lhSurface);
            return 2 * lwSurface + 2 * whSurface + 2 * lhSurface + minSurface;
        }
    }
}

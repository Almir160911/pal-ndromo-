namespace Palindrome
{
    using System;

    class Range
    {
        public int Start { get; }

        public int End { get; }

        public Range(int start, int end)
        {
            Start = start;
            End = end;
        }

        public bool ContainsRangeOf(int start, int end)
        {
            return Start <= start && End >= end;
        }
    }
}

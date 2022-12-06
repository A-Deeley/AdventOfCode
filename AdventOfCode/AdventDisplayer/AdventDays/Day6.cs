namespace AdventDisplayer.AdventDays
{
    internal class Day6 : Day<string>
    {
        public Day6(Task<string> input)
            : base(input)
        {
            Part1Description = "Number of characters processed before start-of-packet marker detected";
        }

        public override async Task Start()
        {
            ExecTimer.Start();
            string transmission = await _input;





            Part1Answer = CharsProcessed(transmission, 4);
            Part2Answer = CharsProcessed(transmission, 14);

            ExecTimer.Stop();
        }

        int CharsProcessed(string input, int qtyUniqueChars)
        {
            bool isStartOfSignal = false;
            int charsProcessed = 0;

            while (!isStartOfSignal)
            {
                char[] fourChars = input[charsProcessed..(charsProcessed + qtyUniqueChars)].ToArray();
                isStartOfSignal = fourChars.Distinct().Count() == qtyUniqueChars;

                charsProcessed++;
            }

            return charsProcessed + qtyUniqueChars - 1;
        }
    }
}

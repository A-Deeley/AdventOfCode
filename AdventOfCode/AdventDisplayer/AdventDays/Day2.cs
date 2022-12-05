namespace AdventDisplayer.AdventDays
{
    internal class Day2 : Day<string>
    {
        const int ABCAdjust = 65;
        const int XYZAdjust = 88;
        struct RPSPair
        {
            public RPSPair(string p1, string p2)
            {
                P1 = p1[0];
                P2 = p2[0];
            }

            public int P1 { get; set; }
            public int P2 { get; set; }
        }

        public Day2(Task<string> task)
            : base(task)
        {
            Part1Description = "Total score of assumed guide";
            Part2Description = "Total score of actual guide";
        }

        public override async Task Start()
        {
            ExecTimer.Start();
            var data = await _input;
            List<string> rockPaperScissorPairs = new(data.Split('\n'));

            List<RPSPair> RPSPairs = new(rockPaperScissorPairs.Select(pair =>
            {
                var splitPair = pair.Split(' ');
                return new RPSPair(splitPair[0], splitPair[1]);
            }));


            int totalScore = 0;

            foreach (var pair in RPSPairs)
            {
                // P2 wins (nous)
                if ((pair.P1 - ABCAdjust + 1) % 3 == pair.P2 - XYZAdjust)
                    totalScore += pair.P2 - XYZAdjust + 6;
                // draw
                else if (pair.P1 - ABCAdjust == pair.P2 - XYZAdjust)
                    totalScore += pair.P2 - XYZAdjust + 3;
                // P1 wins
                else
                    totalScore += pair.P2 - XYZAdjust;
            }

            totalScore += RPSPairs.Count;
            Part1Answer = totalScore;

            totalScore = 0;

            foreach (var pair in RPSPairs)
            {
                int value = 0;
                if (pair.P2 == 'Z')
                    totalScore += 6 + (pair.P1 - ABCAdjust + 1) % 3; // Win (6 + jet choisi)
                else if (pair.P2 == 'Y')
                    totalScore += 3 + (pair.P1 - ABCAdjust); // Draw (3 + jet chosi)
                else
                    totalScore += (pair.P1 - ABCAdjust + 2) % 3; // Lose (0 + jet choisi)

            }

            totalScore += RPSPairs.Count;
            Part2Answer = totalScore;


            ExecTimer.Stop();
        }
    }
}

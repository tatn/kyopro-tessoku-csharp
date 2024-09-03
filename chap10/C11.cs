namespace KyoproTessokuCsharp.chap10
{
    internal class C11
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            List<int> A = ReadIntArray().ToList();
            A.Insert(0, 0);


            long GetSheetNumber(double border)
            {
                long sheetNumber = 0;
                for (int i = 1; i <= N; i++)
                {
                    sheetNumber += (long)(A[i] / border);
                }

                return sheetNumber;
            }

            double left = 1;
            double right = 1_000_000_000;
            double mid = 0;
            double border = 0;
            for (int i = 0; i <= 50; i++)
            {
                mid = (left + right) / 2;

                long sheatNumber = GetSheetNumber(mid);

                if (K <= sheatNumber)
                {
                    left = mid;
                    border = Math.Max(border, mid);
                }
                else
                {
                    right = mid;
                }
            }

            List<int> answer = new List<int>();
            for (int i = 1; i <= N; i++)
            {
                answer.Add((int)(A[i] / border));
            }

            Console.WriteLine(string.Join(" ", answer));
        }

        public static void MainTLE(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            List<int> A = ReadIntArray().ToList();
            A.Insert(0, 0);

            int[] seats = new int[N + 1];
            PriorityQueue<int, double> priorityQueue = new PriorityQueue<int, double>();

            for (int i = 1; i <= N; i++)
            {
                priorityQueue.Enqueue(i, -A[i]);
            }

            int totalSeats = 0;
            while (0 < priorityQueue.Count)
            {
                int electedParty = priorityQueue.Dequeue();

                seats[electedParty]++;
                totalSeats++;

                priorityQueue.Enqueue(electedParty, -(double)A[electedParty] / ((double)seats[electedParty] + 1d));

                if (K <= totalSeats)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join(" ", seats.Skip(1)));
        }
    }
}

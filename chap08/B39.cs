namespace KyoproTessokuCsharp.chap08
{
    internal class B39
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] ND = ReadIntArray();
            int N = ND[0];
            int D = ND[1];

            List<int>[] worksByDay = new List<int>[D + 1];
            for (int i = 0; i < worksByDay.Length; i++)
            {
                worksByDay[i] = new List<int>();            
            }

            for (int i = 0; i < N; i++)
            {
                int[] XY = ReadIntArray();
                worksByDay[XY[0]].Add(XY[1]);
            }

            PriorityQueue<int,int> priorityQueue = new PriorityQueue<int,int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));

            int answer = 0;
            for (int day = 1; day <= D; day++)
            {
                foreach (int works in worksByDay[day])
                {
                    priorityQueue.Enqueue(works, works);
                }

                if(0 < priorityQueue.Count)
                {
                    answer += priorityQueue.Dequeue();
                }
            }

            Console.WriteLine(answer);


        }
    }
}

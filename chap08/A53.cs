namespace KyoproTessokuCsharp.chap08
{
    internal class A53
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int Q = ReadInt();
            List<int[]> Query = new List<int[]>();

            for (int i = 0; i < Q; i++)
            {
                Query.Add(ReadIntArray());
            }

            PriorityQueue<int,int> priorityQueue = new PriorityQueue<int,int>();

            foreach (int[] q in Query)
            {
                switch (q[0])
                {
                    case 1:
                        priorityQueue.Enqueue(q[1], q[1]);
                        break;
                    case 2:
                        Console.WriteLine(priorityQueue.Peek());
                        break;
                    case 3:
                        priorityQueue.Dequeue();
                        break;
                }
            }
        }
    }
}

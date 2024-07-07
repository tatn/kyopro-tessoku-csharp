namespace KyoproTessokuCsharp.chap08
{
    internal class A55
    {
        public static void Main(string[] args)
        {
            //TODO 
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int Q = ReadInt();
            List<int[]> Query = new List<int[]>();

            for (int i = 0; i < Q; i++)
            {
                Query.Add(ReadIntArray());
            }

            SortedSet<int> desk = new SortedSet<int>();

            foreach (int[] q in Query)
            {
                switch (q[0])
                {
                    case 1:
                        desk.Add(q[1]);
                        break;
                    case 2:
                        desk.Remove(q[1]);
                        break;
                    case 3:
                        if (desk.Count == 0)
                        {
                            Console.WriteLine(-1);
                        }
                        else
                        {
                            int min = desk.Min();
                            if (q[1] <= min)
                            {
                                Console.WriteLine(min);
                            }
                            else
                            {
                                Console.WriteLine(-1);
                            }
                        }
                        break;
                }
            }
        }
    }
}

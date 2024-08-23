namespace KyoproTessokuCsharp.chap08
{
    internal class B55
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

            List<int> desk = new List<int>();

            foreach (int[] q in Query)
            {
                switch (q[0])
                {
                    case 1:
                        int insertIndex = desk.BinarySearch(q[1]);
                        if (insertIndex <= 0)
                        {
                            desk.Insert(~insertIndex, q[1]);
                        }

                        break;
                    case 2:
                        if (desk.Count == 0)
                        {
                            Console.WriteLine(-1);
                        }
                        else
                        {
                            int index = desk.BinarySearch(q[1]);

                            if (0 <= index)
                            {
                                Console.WriteLine(0);
                            }
                            else
                            {
                                int findIndex = ~index;

                                int index1 = findIndex - 1;
                                int index2 = findIndex;

                                int diff = 1_000_000_000;
                                if(0 <= index1)
                                {
                                    diff = Math.Abs(desk[index1] - q[1]);
                                }

                                if(index2 <= desk.Count - 1)
                                {
                                    diff = Math.Min(diff, Math.Abs(desk[index2] - q[1]));
                                }


                                Console.WriteLine(diff);

                            }

                        }
                        break;
                }
            }
            }
    }
}

namespace KyoproTessokuCsharp.chap08
{
    internal class A55
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
                            desk.Insert(~insertIndex,q[1]);
                        }
                
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
                            int index = desk.BinarySearch(q[1]);

                            if (0 <= index)
                            {
                                Console.WriteLine(desk[index]);
                            }
                            else
                            {
                                int findIndex = ~index;
                                Console.WriteLine(findIndex < desk.Count ? desk[findIndex] : -1);
                            }
                        }
                        break;
                }
            }
        }
    }
}

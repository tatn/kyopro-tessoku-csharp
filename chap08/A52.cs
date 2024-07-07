namespace KyoproTessokuCsharp.chap08
{
    internal class A52
    {
        public static void Main(string[] args)
        {
            string[] ReadStringArray() => Console.ReadLine()!.Split();
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int Q = ReadInt();
            List<string[]> Query = new List<string[]>();

            for (int i = 0; i < Q; i++)
            {
                Query.Add(ReadStringArray());
            }

            Queue<string> list = new Queue<string>();

            foreach (string[] q in Query)
            {
                switch (q[0])
                {
                    case "1":
                        list.Enqueue(q[1]);
                        break;
                    case "2":
                        Console.WriteLine(list.Peek());
                        break;
                    case "3":
                        list.Dequeue();
                        break;
                }
            }
        }
    }
}

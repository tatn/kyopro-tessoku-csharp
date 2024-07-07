namespace KyoproTessokuCsharp.chap08
{
    internal class A51
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

            Stack<string> books = new Stack<string>();

            foreach (string[] q in Query)
            {
                switch (q[0])
                {
                    case "1":
                        books.Push(q[1]);
                        break;
                    case "2":
                        Console.WriteLine(books.Peek());
                        break;
                    case "3":
                        books.Pop();
                        break;
                }
            }
        }
    }
}

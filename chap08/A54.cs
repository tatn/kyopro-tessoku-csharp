namespace KyoproTessokuCsharp.chap08
{
    internal class A54
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

            Dictionary<string, int> scores = new Dictionary<string, int>();

            foreach (string[] q in Query)
            {
                switch (q[0])
                {
                    case "1":
                        scores.Add(q[1], int.Parse(q[2]));
                        break;
                    case "2":
                        Console.WriteLine(scores[q[1]]);
                        break;
                }
            }
        }
    }
}

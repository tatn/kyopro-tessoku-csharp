namespace KyoproTessokuCsharp.chap10
{
    internal class C17
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            string[] ReadStringArray() => Console.ReadLine()!.Split();

            int Q = ReadInt();
            string[,] Query = new string[Q,2];

            for (int i = 0; i < Q; i++)
            {
                string[] query = ReadStringArray();
                Query[i,0] = query[0];
                if(query[0] == "A" || query[0] == "B")
                {
                    Query[i,1] = query[1];
                }
            }

            LinkedList<string> before = new LinkedList<string>();
            LinkedList<string> after = new LinkedList<string>();

            int beforeCount = 0;
            int afterCount = 0;

            for (int i = 0; i < Q; i++)
            {
                switch (Query[i, 0])
                {
                    case "A":
                        after.AddLast(Query[i, 1]);
                        afterCount++;

                        if(beforeCount < afterCount)
                        {
                            before.AddLast(after.First());
                            after.RemoveFirst();
                            beforeCount++;
                            afterCount--;
                        }
                        break;
                    case "B":
                        if(beforeCount == afterCount)
                        {
                            before.AddLast(Query[i, 1]);
                            beforeCount++;
                        }
                        else
                        {
                            after.AddFirst(Query[i, 1]);
                            afterCount++;
                        }
                        break;
                    case "C":
                        before.RemoveFirst();
                        beforeCount--;
                        if (beforeCount < afterCount)
                        {
                            before.AddLast(after.First());
                            after.RemoveFirst();
                            beforeCount++;
                            afterCount--;
                        }
                        break;
                    case "D":
                        string name = before.First();
                        Console.WriteLine(name);
                        break;
                }
            }
        }
    }
}

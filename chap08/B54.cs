namespace KyoproTessokuCsharp.chap08
{
    internal class B54
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();

            Dictionary<int,int> sameValues = new Dictionary<int,int>();

            for (int i = 0; i < N; i++)
            {
                int n = ReadInt();

                if(sameValues.TryGetValue(n, out int value))
                {
                    sameValues[n] = value + 1;
                }
                else
                {
                    sameValues.Add(n, 1);
                }                
            }

            long answer = 0L;

            foreach (int count in sameValues.Values)
            {
                if(count <= 1)
                {
                    continue;
                }

                answer += (long)count * ((long)count - 1L) / (long)2;
            }

            Console.WriteLine(answer);

        }
    }
}

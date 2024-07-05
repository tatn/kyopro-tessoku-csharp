namespace KyoproTessokuCsharp.chap06
{
    internal class B44
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();

            int[,] A = new int[N+1,N+1];

            for (int i = 1; i <= N; i++)
            {
                int[] aInput = ReadIntArray();
                for (int j = 1; j <= N; j++)
                {
                    A[i,j] = aInput[j-1];
                }
            }

            int[] indexes = new int[N+1];
            for (int i = 1; i <= N; i++)
            {
                indexes[i] = i;
            }


            int Q = ReadInt();

            List<string> answer = new List<string>();

            for (int i = 0; i < Q; i++)
            {
                int[] Query = ReadIntArray();

                switch (Query[0])
                {
                    case 1:
                        int rowIndex1 = Query[1];
                        int rowIndex2 = Query[2];

                        int swapRow = indexes[rowIndex2];
                        indexes[rowIndex2] = indexes[rowIndex1];
                        indexes[rowIndex1] = swapRow;
                        break;
                    case 2:
                        int targetIndex = Query[1];
                        targetIndex = indexes[targetIndex];
                        answer.Add(A[targetIndex,Query[2]].ToString());
                        break;
                }
            }

            foreach (string s in answer)
            {
                Console.WriteLine(s);
            }
        }
    }
}

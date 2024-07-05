namespace KyoproTessokuCsharp.chap06
{
    internal class A44
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NQ = ReadIntArray();
            int N = NQ[0];
            int Q = NQ[1];

            int[] A = new int[N];
            for (int i = 0; i < N; i++)
            {
                A[i] = i + 1;
            }

            bool isReverse = false;

            List<string> answer = new List<string>();

            for (int i = 0; i < Q; i++)
            {
                int[] Query = ReadIntArray();

                switch (Query[0])
                {
                    case 1:
                        int index = Query[1] - 1;
                        if (isReverse)
                        {
                            index = N - 1 - index;
                        }
                        A[index] = Query[2];
                        break;
                    case 2:
                        isReverse = !isReverse;
                        break;
                    case 3:
                        int targetIndex = Query[1] - 1;
                        if (isReverse)
                        {
                            targetIndex = N - 1 - targetIndex;
                        }
                        answer.Add(A[targetIndex].ToString());
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

namespace KyoproTessokuCsharp.chap06
{
    internal class A43
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            string[] ReadStringArray() => Console.ReadLine()!.Split();

            int[] NL = ReadIntArray();
            int N = NL[0];
            int L = NL[1];

            int[] A = new int[N];
            bool[] isEast = new bool[N];

            for (int i = 0; i < N; i++)
            {
                string[] AB = ReadStringArray();
                A[i] = int.Parse(AB[0]);
                isEast[i] = AB[1] == "E";
            }

            int answer = 0;
            for (int i = 0; i < N; i++)
            {
                int exitDistance = A[i];
                if (isEast[i])
                {
                    exitDistance = L - exitDistance;
                }

                if(answer < exitDistance)
                {
                    answer = exitDistance;
                }
            }

            Console.WriteLine(answer);
        }
    }
}

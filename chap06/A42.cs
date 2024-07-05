namespace KyoproTessokuCsharp.chap06
{
    internal class A42
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            int[] A = new int[N];
            int[] B = new int[N];

            for (int i = 0; i < N; i++)
            {
                int[] AB = ReadIntArray();
                A[i] = AB[0];
                B[i] = AB[1];
            }

            Func<int,int,int> getInRangeNumber =  (a,b) =>  {

                int result = 0;

                for (int i = 0; i < N; i++)
                {
                    if (a <= A[i] && A[i] <= a + K && b <= B[i] && B[i] <= b + K)
                    {
                        result++;
                    }

                }

                return result;
            };


            int answer = 0;
            for (int a = 1; a <= 100 ; a++)
            {
                for (int b = 1; b <= 100 ; b++)
                {

                    int rangeNumbner = getInRangeNumber(a, b);
                    if(answer < rangeNumbner)
                    {
                        answer = rangeNumbner;
                    }
                }
            }

            Console.WriteLine(answer);
        }
    }
}

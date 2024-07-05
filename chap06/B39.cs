namespace KyoproTessokuCsharp.chap06
{
    internal class B39
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] ND = ReadIntArray();
            int N = ND[0];
            int D = ND[1];

            List<int[]> xyList = new List<int[]>();
            for (int i = 0; i < N; i++)
            {
                int[] XY = ReadIntArray();
                xyList.Add(XY);
            }

            xyList.Sort((a,b) => a[1].CompareTo(b[1]) == 0 ? a[0].CompareTo(b[0]) : -1 * a[1].CompareTo(b[1]));

            int answer = 0;
            for (int day = 1; day <= D; day++)
            {
                for (int i = 0; i < N; i++)                
                {
                    if(xyList[i][0] <= day && 0 < xyList[i][1])
                    {
                        answer += xyList[i][1];
                        xyList[i][1] = 0;
                        break;
                    }
                }

            }

            Console.WriteLine(answer);
        }
    }
}

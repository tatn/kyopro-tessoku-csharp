namespace KyoproTessokuCsharp.chap06
{
    internal class A39
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();
            List<Tuple<int,int>> lrList = new List<Tuple<int,int>>();

            for (int i = 0; i < N; i++)
            {
                int[] LR = ReadIntArray();
                lrList.Add(new Tuple<int,int>(LR[0],LR[1]));
            }

            lrList.Sort((a,b) => a.Item2.CompareTo(b.Item2));

            int answer = 0;
            int time = 0;
            for (int i = 0; i < N; i++)
            {
                if(time <= lrList[i].Item1)
                {
                    answer++;
                    time = lrList[i].Item2;
                }

            }

            Console.WriteLine(answer);
        }
    }
}

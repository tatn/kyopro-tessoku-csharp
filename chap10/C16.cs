namespace KyoproTessokuCsharp.chap10
{
    internal class C16
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NMK = ReadIntArray();
            int N = NMK[0];
            int M = NMK[1];
            int K = NMK[2];

            int[] A = new int[M+1];
            int[] B = new int[M+1];
            int[] S = new int[M+1];
            int[] T = new int[M+1];

            int limitTime = 2 * 1_000_000_000 + 1;

            // time(0-2*10^9+1),index(1-M,1-N),type (0:開始・終了、1:BT到着、2:AS出発)
            List<(int, int, int)> list = new List<(int, int, int)>();

            for (int i = 1; i <= M; i++)
            {
                int[] ASBT = ReadIntArray();
                A[i] = ASBT[0];
                S[i] = ASBT[1];
                B[i] = ASBT[2];
                T[i] = ASBT[3] + K;

                list.Add((T[i], i, 1));
                list.Add((S[i], i, 2));
            }

            for (int i = 1; i <= N; i++)
            {
                list.Add((-1, i, 0));
                list.Add((limitTime, i, 0));
            }

            list.Sort((a, b) => a.Item1 - b.Item1 == 0 ? (a.Item3 - b.Item3 == 0 ? a.Item2 - b.Item2 : a.Item3 - b.Item3) : a.Item1 - b.Item1);

            // フライトの番号をノード番号(listのインデックス+1)に変換
            int[] flightToNodeA = new int[M + 1];
            int[] flightToNodeB = new int[M + 1];
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i].Item3 == 1)
                {
                    flightToNodeB[list[i].Item2] = i + 1;
                }
                if (list[i].Item3 == 2)
                {
                    flightToNodeA[list[i].Item2] = i + 1;
                }
            }

            // 空港に待機する場合の空港番号をノード番号(listのインデックス+1)に変換
            List<int>[] waiting = new List<int>[N+1];
            for (int i = 0; i < N+1; i++)
            {
                waiting[i] = new List<int>();
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Item3 == 0)
                {
                    waiting[list[i].Item2].Add(i + 1);
                }
                if (list[i].Item3 == 1)
                {
                    waiting[B[list[i].Item2]].Add(i + 1);
                }
                if (list[i].Item3 == 2)
                {
                    waiting[A[list[i].Item2]].Add(i + 1);
                }
            }

            // グラフの作成
            List<(int,int)>[] G = new List<(int, int)>[list.Count+ 2];
            for (int i = 0; i < list.Count + 2; i++)
            {
                G[i] = new List<(int, int)>();
            }

            //フライトの設定
            for (int i = 1; i <= M; i++)
            {
                G[flightToNodeB[i]].Add((flightToNodeA[i],1));
            }
            // 空港待ちの設定
            for (int i = 1; i <= N; i++)
            {
                List<int> nodeIndexes = waiting[i];
                for (int j = 0; j < nodeIndexes.Count -1; j++)
                {
                    int fromIndex = nodeIndexes[j];
                    int toIndex = nodeIndexes[j+1];
                    G[toIndex].Add((fromIndex, 0));
                }
            }

            //開始と終了のノード
            for (int i = 1; i <= N; i++)
            {
                G[waiting[i][0]].Add((0, 0));
                G[list.Count + 1].Add((waiting[i][waiting[i].Count -1], 0));
            }

            int[] dp = new int[list.Count()+2];
            dp[0] = 0;
            for (int i = 1;i <= list.Count + 1; i++)
            {
                foreach ( (int j,int t) in G[i])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + t );
                }

            }

            Console.WriteLine(dp[list.Count+1]);
        }
    }
}

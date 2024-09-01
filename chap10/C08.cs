namespace KyoproTessokuCsharp.chap10
{
    internal class C08
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            string[] ReadStringArray() => Console.ReadLine()!.Split().ToArray();

            int N = ReadInt();

            string[] S = new string[N + 1];
            int[] T = new int[N + 1];
            for (int i = 1; i <= N; i++)
            {
                string[] st = ReadStringArray();
                S[i] = st[0];
                T[i] = int.Parse(st[1]);
            }

            bool IsConsist(string s)
            {
                for (int i = 1; i <= N; i++)
                {
                    switch (T[i])
                    {
                        case 1:
                            if(s != S[i])
                            {
                                return false;
                            }
                            break;
                        case 2:
                            int sameCount = 0;
                            sameCount += s[0] == S[i][0] ? 1 : 0;
                            sameCount += s[1] == S[i][1] ? 1 : 0;
                            sameCount += s[2] == S[i][2] ? 1 : 0;
                            sameCount += s[3] == S[i][3] ? 1 : 0;

                            if(sameCount != 3)
                            {
                                return false;
                            }

                            break;
                        case 3:
                            int sameCount2 = 0;
                            sameCount2 += s[0] == S[i][0] ? 1 : 0;
                            sameCount2 += s[1] == S[i][1] ? 1 : 0;
                            sameCount2 += s[2] == S[i][2] ? 1 : 0;
                            sameCount2 += s[3] == S[i][3] ? 1 : 0;

                            if (sameCount2 == 4 || sameCount2 == 3)
                            {
                                return false;
                            }
                            break;

                    }
                }

                return true;
            }

            string answer = "";

            for (int i = 0; i <= 9999; i++)
            {
                string s = i.ToString().PadLeft(4, '0');
                bool isConsist = IsConsist(s);

                if (isConsist)
                {
                    if (String.IsNullOrEmpty(answer))
                    {
                        answer = s;
                    }
                    else
                    {

                        answer = "Can't Solve";
                        break;
                    }
                }
            }

            Console.WriteLine(answer);
        }
    }
}

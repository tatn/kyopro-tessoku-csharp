using System.Net.Security;
using System.Numerics;

namespace KyoproTessokuCsharp.chap10
{
    internal class C13
    {
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] NP = ReadLongArray();
            long N = NP[0];
            long P = NP[1];

            long mod = 1000000007;

            List<long> A = ReadLongArray().Select(x => x % mod).ToList();
            A.Sort();

            if(P == 0)
            {
                long zeroCount = A.Where(x => x == 0L).Count();
                long nonZeroCount = N - zeroCount;

                long a = zeroCount * nonZeroCount;
                a += zeroCount * (zeroCount - 1) / 2;
                Console.WriteLine(a);

                return;
            }

            A.RemoveAll(x => x == 0);

            long[] modCount = new long[P + 1];

            long answer = 0;
            foreach (long x in A)
            {
                // ÷x <=> ×x^(M-2)
                // P ÷ x  <=> P × x^(M-2)

                long needNumber = P * GetPower(x, mod - 2, mod);
                needNumber %= mod;
                answer += modCount[needNumber];

                modCount[x]++;
            }

            Console.WriteLine(answer);

            long GetPower(long x , long p,long mod)
            {
                long answer = 1L;
                long mul = x;
                while(0 < p)
                {
                    if(p % 2 == 1)
                    {
                        answer *= mul;
                        answer %= mod;
                    }

                    mul *= mul;
                    mul %= mod;
                    p /= 2;
                }

                return answer;
            }


        }
    }
}

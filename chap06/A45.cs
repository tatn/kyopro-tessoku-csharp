namespace KyoproTessokuCsharp.chap06
{
    internal class A45
    {
        public static void Main(string[] args)
        {
            string[] ReadStringArray() => Console.ReadLine()!.Split();
            string ReadString() => Console.ReadLine()!;

            string[] NC = ReadStringArray();
            int N = int.Parse(NC[0]);
            string C = NC[1];
            string A = ReadString();

            int number = A.Select(a => a == 'W' ? 0 : (a == 'B' ? 1 : 2)).Sum() % 3;
            int targetNumber = C == "W" ? 0 : (C == "B" ? 1 : 2);

            Console.WriteLine(number == targetNumber ? "Yes":"No");
        }
    }
}

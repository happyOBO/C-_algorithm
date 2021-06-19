using System;

namespace BruteForce
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] answers = { 1, 2, 3, 4, 5 };
            int[] answer = solution.solution(answers);

            for(int idx = 0; idx < answer.Length; idx++)
            {
                Console.WriteLine(answer[idx]);
            }
        }
    }


}

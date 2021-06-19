using System;
using System.Collections.Generic;

namespace Easy
{
    class Program
    {
        static int FindCandidateCard(int curr_num, ref List<int> card_storage)
        {
            int candidate_card = int.MaxValue; // 최대값으로 초기화

            for(int idx = 0; idx < card_storage.Count ; idx++)
            {
                if (card_storage[idx] > curr_num && candidate_card > card_storage[idx])
                    candidate_card = card_storage[idx];
            }

            if (candidate_card != int.MaxValue)
            {
                card_storage.Remove(candidate_card);
                return candidate_card;
            }
            else
                return int.MinValue; // 해당 자리수보다 큰 숫자 찾는 것 실패
        }

        static List<int> ParseInput(string input)
        {
            const int UNICODE_0 = (int)'0';
            List<int> result = new List<int>();

            for (int idx = 0; idx < input.Length; idx++)
            {
                result.Add((int)input[idx] - UNICODE_0);
            }

            return result;
        }



        static void Main(string[] args)
        {

            List<int> input = ParseInput(Console.ReadLine());
            List<int> answer = new List<int>();

            // 첫째자리 수부터 비교해서, 적합하지 않으면
            // card_storage 에 쌓아놓자.
            List<int> card_storage = new List<int>();

            for(int idx = input.Count - 1; idx >= 0; idx--)
            {
                if (card_storage.Count == 0)
                    card_storage.Add(input[idx]);

                else
                {
                    int candidate_card = FindCandidateCard(input[idx] , ref card_storage);
                    if (input[idx] < candidate_card)
                    {
                        card_storage.Add(input[idx]);
                        card_storage.Sort();

                        // 결과값 정리

                        answer.AddRange(input.GetRange(0, idx));
                        answer.Add(candidate_card);
                        answer.AddRange(card_storage);

                        for (int j = 0; j < answer.Count; j++)
                            Console.Write(answer[j]);
                        return ;

                    }
                    else
                        card_storage.Add(input[idx]);
                }

            }

            Console.WriteLine(0);
        }
    }
}

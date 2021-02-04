using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PriorityQueueGeneric
{
    // T는 T인데 비교가능한 T 타입만 올 수 있다.
    class PriorityQueue<T> where T : IComparable<T>
    {
        List<T> _heap = new List<T>();
        public void Push(T data)
        {
            // 힙의 맨 끝에 새로운 데이터를 삽입한다.
            _heap.Add(data);

            int now = _heap.Count - 1;

            // 도장깨기를 시작

            while (now > 0)
            {
                // 도장 깨기 시도
                int next = (now - 1) / 2;
                if (_heap[now].CompareTo(_heap[next]) < 0)
                    break;
                // 두 값을 교체
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                // 검사 위치를 이동한다.
                now = next;
            }
        }

        public T Pop()
        {
            // 반환할 데이터를 따로 저장
            T ret = _heap[0];

            // 마지막 데이터를 루트로 이동
            int lastIndex = _heap.Count - 1;

            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            // 역으로 내려가는 도장깨기 시작
            int now = 0;
            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;

                int next = now;

                // 왼쪽 값이 현재 값보다 크면 왼쪽으로 이동

                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                    next = left;

                // 오른 값이 현재 값보다 크면 오른쪽으로 이동
                // 왼쪽 값이 현재 값보다 크지만, 오른 값보다 작았다면 여기서 교체가 된다.
                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                    next = right;

                // 왼쪽 오른쪽 모두 현재 값보다 작음
                if (next == now)
                    break;

                // 두 값을 교체
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                // 검사 위치를 이동한다.
                now = next;

            }

            return ret;
        }

        public int Count()
        {
            return _heap.Count;
        }
    }

    class Knight : IComparable<Knight>
    {
        public int Id { get; set; }

        public int CompareTo([AllowNull] Knight other)
        {
            if (Id == other.Id)
                return 0;
            return Id > other.Id ? 1 : -1;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int> q = new PriorityQueue<int>();
            q.Push(20);
            q.Push(10);
            q.Push(30);
            q.Push(90);
            q.Push(40);

            while (q.Count() > 0)
            {
                Console.WriteLine(q.Pop());
            }

            PriorityQueue<Knight> q2 = new PriorityQueue<Knight>();
            q2.Push(new Knight() { Id = 20 });
            q2.Push(new Knight() { Id = 15 });
            q2.Push(new Knight() { Id = 50 });
            q2.Push(new Knight() { Id = 30 });
            q2.Push(new Knight() { Id = 10 });

            while (q2.Count() > 0)
            {
                Console.WriteLine(q2.Pop().Id);
            }
        }
    }
}

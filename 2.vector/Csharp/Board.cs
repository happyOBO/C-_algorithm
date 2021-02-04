using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp
{
    class MyList<T>
    {
        const int DEFAULT_SIZE = 1;
        T[] _data = new T[DEFAULT_SIZE];
        public int Count = 0; // 실제로 사용 중인 데이터 개수
        public int Capacity { get { return _data.Length;  } } // 예약된 데이터 개수

        // O(1) , 이사 비용은 특이 케이스 이므로 무시한다.
        public void Add(T item)
        {
            // 1. 공간이 충분히 남아 있는지 확인한다.
            if(Count >= Capacity)
            {
                //공간을 다시 확보한다.
                T[] newArray = new T[Count * 2];
                for (int i = 0; i < Count; i++)
                    newArray[i] = _data[i];
                _data = newArray;
            }

            // 2. 공간에다 데이터를 넣어준다.

            _data[Count] = item;
            Count++;
        }

        // O(1)
        public T this[int index]
        {
            // T temp = _data[3];
            get { return _data[index];  }
            // _data[3] = value
            set { _data[index] = value;  }
        }

        // O(N)
        public void RemoveAt(int index)
        {
            // 중간에 하나 삭제했으니 뒤에 있는거 앞으로 당기자

            for (int i = index; i < Count - 1; i++)
                _data[i] = _data[i + 1];
            _data[Count - 1] = default(T); // 끝에 남은거 초기화 정수라면 0으로 초기화 그외는 null
            Count--;
        }
    }
    class Board
    {

        // 배열 vs 동적 배열 vs 연결 리스트
        /*
         * 배열
         *      사용할 방 개수를 고정해서 계약하고, 절대 변경 불가
         *      연속된 방으로 배정 받아 사용가능
         *      장점 : 연속된 방
         *      단점 : 방을 축소 / 추가 불가
         * 
         * 동적 배열
         *      사용할 방 개수를 유동적으로 계약
         *      연속된 방으로 배정 받아 사용
         *      예를 들어서, 101, 102,103호를 쓰고 있는데 1명더 추가할 예정,,
         *      허나 104호는 이미 사용중 이기 때문에 201, 202,203, 204호로 이동해서 사용하시오
         *      그러면 이사 비용이 발생한다.
         *      이를 해결하기 위해
         *      정책 
         *          실제로 사용할 방보다 많이, 여유분을 두고 예약
         *          이사 횟수를 최소화
         *      장점 : 유동적인 계약
         *      단점 : 중간 삽입/ 삭제 불가
         * 
         * 연결 리스트
         *      연속되지 않은 방을 사용
         *      장접 : 중간 추가/ 삭제 가능
         *      단점 : N 번째 방을 바로 찾을 수가 없음 (임의 접근 불가)
         */

        public int[] _data = new int[25]; // 배열
        public MyList<int> _data2 = new MyList<int>(); // 동적 배열
        public LinkedList<int> _data3 = new LinkedList<int>(); // 연결 리스트

        /* 맵은 대부분 사라졌다가 생기지 않는다. 그렇다면 배열이 제일 적당하겠네!*/

        /* 디버깅 방법
         * 중단점을 만들고, F5를 누른다. 그 후에 조사식에 알아보고싶은 변수 명을 적은 뒤,
         * F10 을 눌러 한줄한 줄 어떻게 채워지는지 확인한다.
         */

        public void initialize()
        {
            _data2.Add(101);
            _data2.Add(102);
            _data2.Add(103);
            _data2.Add(104);
            _data2.Add(105);

            int temp = _data2[2];

            _data2.RemoveAt(2);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp
{
    class MyLinkedListNode<T>
    {
        public T Data;
        public MyLinkedListNode<T> Next;
        public MyLinkedListNode<T> Prev;

    }

    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Head = null; // 첫번째 방
        public MyLinkedListNode<T> Tail = null; // 마지막 방
        public int Count = 0;
        
        // O(1)
        public MyLinkedListNode<T> AddLast(T data)
        {
            MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
            newRoom.Data = data;

            // 방 리스트에 방이 없었다면

            if (Head == null)
                Head = newRoom;

            // 기존의 마지막 방에 새로 추가된 방을 연결해준다.
            if(Tail != null)
            {
                Tail.Next = newRoom;
                newRoom.Prev = Tail;


            }

            Tail = newRoom;
            Count++;
            return newRoom;
        }
        // O(1)
        public void Remove(MyLinkedListNode<T> room)
        {
            // 방리스트에서 첫번째 방을 제거해야하면, 두번째 방을 첫째 방으로 바꿔준다.
            if (Head == room)
                Head = Head.Next;
            // 기존의 마지막 방의 이전 방을 마지막 방으로 인정한다.
            if (Tail == room)
                Tail = Tail.Prev;
            if (room.Prev != null)
                room.Prev.Next = room.Next;
            if (room.Next != null)
                room.Next.Prev = room.Prev;

            Count--;
        }
    }
    class Board
    {

        public MyLinkedList<int> _data3 = new MyLinkedList<int>(); // 연결 리스트

        /* 디버깅 방법
         * 중단점을 만들고, F5를 누른다. 그 후에 조사식에 알아보고싶은 변수 명을 적은 뒤,
         * F10 을 눌러 한줄한 줄 어떻게 채워지는지 확인한다.
         */

        public void initialize()
        {
            _data3.AddLast(101);
            _data3.AddLast(102);
            MyLinkedListNode<int> node = _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);

            _data3.Remove(node);


        }
    }
}

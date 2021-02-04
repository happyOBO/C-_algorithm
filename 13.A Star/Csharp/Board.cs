using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp
{

    class Board
    {
        const char CIRCLE = '\u25cf';
        public TileType[,] Tile { get; private set; }// 2차원 배열
        public int Size { get; private set; }

        public int DestY { get; private set; }
        public int DestX { get; private set; }
        Player _player;

        public enum TileType
        {
            Empty,
            Wall,

        }

        public void initialize(int size, Player player)
        {
            if (size % 2 == 0)
                return;

            _player = player;
            Tile = new TileType[size, size];
            Size = size;

            DestY = Size - 2;
            DestX = Size - 2;
            
            GenerateBySideWinder();
        }

        void GenerateBySideWinder()
        {

            // 일단, 길을 다 막아버리는 작업
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        Tile[y, x] = TileType.Wall;
                    else
                        Tile[y, x] = TileType.Empty;

                }
            }

            // 
            // 초록색 점에 대해서 랜덤으로 우측 혹은 아래로 길을 뚫는 작업
            Random rand = new Random();
            for (int y = 0; y < Size; y++)
            {
                int count = 1;
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;
                    if (y == Size - 2 && x == Size - 2)
                        continue;
                    if(y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }
                    if(x == Size -2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (rand.Next(0, 2) == 0) // 0 혹은 1 두개중 하나가 나온다. 1/2 확률 생성
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        count++;
                    }
                    else
                    {
                        int randomindex = rand.Next(0, count);
                        Tile[y + 1, x - randomindex * 2] = TileType.Empty;
                        count = 1;
                    }
                }
            }
        }

        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    // 플레이어 좌표를 갖고 와서 현재 좌표와 일치하면 플레이어 전용 색상으로 표시
                    if (y == _player.PosY && x == _player.PosX)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else if (y == DestY && x == DestX)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = GetTileColor(Tile[y, x]); // 콘솔에 써지는 색상 변경
                    Console.Write(CIRCLE); // 동그라미 그리기
                }
                Console.WriteLine(); // 개행
            }
            Console.ForegroundColor = prevColor;
        }


        ConsoleColor GetTileColor(TileType type)
        {
            switch(type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Green;
            }
        }
    }
}

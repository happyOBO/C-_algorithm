using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp
{
    class Player
    {
        public int PosY { get; private set; } // 외부에서는 값을 불러올수만 있고 변경은 불가능
        public int PosX { get; private set; }
        Random _random = new Random();

        Board _board;
        public void initialize(int posY, int posX, int destY, int destX , Board board)
        {
            PosX = posX;
            PosY = posY;

            _board = board;
        }

        const int MOVE_TICK = 100;
        int _sumTick = 0;
        public void Update(int deltaTick)
        {
            _sumTick += deltaTick;
            if(_sumTick >= MOVE_TICK)
            {
                _sumTick = 0;
                // 여기에 0.1초마다 실행될 로직을 넣어준다.
                int randValue = _random.Next(0, 5);
                switch(randValue)
                {
                    case 0: // 상
                        if (PosY - 1 >= 0 &&  _board.Tile[PosY - 1, PosX] == Board.TileType.Empty)
                            PosY -= 1;
                        break;
                    case 1: // 하
                        if (PosY + 1 < _board.Size && _board.Tile[PosY + 1, PosX] == Board.TileType.Empty)
                            PosY += 1;
                        break;
                    case 2: // 좌
                        if (PosX - 1 >= 0 && _board.Tile[PosY, PosX -1] == Board.TileType.Empty)
                            PosX -= 1;
                        break;
                    case 3: // 우
                        if (PosX + 1 < _board.Size && _board.Tile[PosY, PosX+1] == Board.TileType.Empty)
                            PosX += 1;
                        break;
                }
            }
        }
    }
}

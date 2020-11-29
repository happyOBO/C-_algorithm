using System;

namespace Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Player player = new Player();
            board.initialize(25 , player);
            player.initialize(1, 1, board.Size - 2, board.Size -2 , board);
            Console.CursorVisible = false; // 커서 깜빡이기 제거

            const int WAIT_TICK = 1000 / 30;


            int lastTick = 0;
            while (true)
            {
                // #region을 쓰면 에디터 상에서 접었다 폈다 사용가능
                #region 프레임 관리
                int currentTick = System.Environment.TickCount; // 특정 시스템이 시작된 이후 경과된 밀리 세컨을 뱉어준다.
                // 만약에 경과한 시간이 1/30초 보다 작다면
                if (currentTick - lastTick < WAIT_TICK)
                    continue;
                int deltaTick = currentTick - lastTick;
                lastTick = currentTick;
                #endregion

                // FPS 프레임 (60 프레임 OK 30 프레임 이하로 NO) -> 이 루프가 1초에 몇번 실행되고 있느냐!
                // 게임에서는 크게 세가지로 나뉜다.

                // 입력단계
                // 키보드, 마우스 인풋

                // 로직 단계
                // 게임 몬스터의 AI 또는 로직
                player.Update(deltaTick);

                // 렌더링 단게
                // Direct X, OpenGL 이용

                Console.SetCursorPosition(0, 0); // 출력 시작점 0,0 고정
                board.Render();

            }
        }
    }
}

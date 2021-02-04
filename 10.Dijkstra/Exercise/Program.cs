using System;
using System.Collections.Generic;


namespace Exercise
{

    class Graph
    {
        int[,] adj = new int[6, 6]
        {
            { -1, 15, -1, 35, -1, -1 },
            { 15, -1, 05, 10, -1, -1 },
            { -1, 05, -1, -1, -1, -1 },
            { 35, 10, -1, -1, 05, -1 },
            { -1, -1, -1, 05, -1, 05 },
            { -1, -1, -1, -1, 05, -1 },
        };

        bool[] visited = new bool[6];
        
        // 현재까지 탐색한 노드들 중 방문하지 않은 (시작점부터 해당 노드까지의 최소거리를 알고 있는)
        // 그런 노드들 중에서도 제일 작은 값을 갖고 있는것부터 탐방 시작
        // 해서 방문 노드로 교체하고 ~ ,주변 노드 탐색 시작해서 거기까지의 최소거리 알아냄
        public void Dijikstra(int start)
        {
            bool[] visited = new bool[6];
            int[] distance = new int[6]; // 그 당시의 최단거리 기입
            int[] parent = new int[6];

            // 타입이 넣을수 있는 가장 큰 값으로 초기화
            Array.Fill(distance, Int32.MaxValue);

            distance[start] = 0;
            parent[start] = start;

            while(true)
            {
                // 제일 좋은 후보를 찾는다. (가장 가까이 있는)
                // 가장 유력한 후보의 거리와 번호를 저장한다.
                // 방문하지 않은 노드중에서 제일 최솟값인 노드를 찾아라
                int closest = Int32.MaxValue;
                int now = -1;

                for(int i = 0; i < 6; i++)
                {
                    // 이미 방문한 정점은 스킵
                    if (visited[i])
                        continue;
                    // 아직 발견된 적이 없거나, 기존 후보보다 멀리 있으면 스킵
                    if (distance[i] == Int32.MaxValue || distance[i] >= closest)
                        continue;
                    // 여태껏 발견한 가장 좋은 후보로 정보 갱신

                    closest = distance[i];
                    now = i;
                }

                // 다음 후보가 하나도 없다. -> 종료
                if (now == -1)
                    break;
                // 제일 좋은 후보를 찾았으니까 방문한다.
                visited[now] = true;

                // 방문한 정점과 인접한 정점들을 조사해서
                // 상황에 따라 최단 거리를 갱신한다.
                // 방문한 노드와 인접한 노드들의 최소 거리를 구하라.
                for (int next = 0; next < 6; next++)
                {
                    // 연결되지 않은 정점 스킵
                    if (adj[now, next] == -1)
                        continue;
                    // 이미 방문한 정점은 스킵

                    if (visited[next])
                        continue;

                    // 새로 조사된 정점의 최단거리를 계산한다.

                    int nextDist = distance[now] + adj[now, next];

                    // 만약에 기존에 발견된 최단거리가 새로 조사된 최단거리보다 크면, 정보를 갱신
                    if(nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                        parent[next] = now;
                    }
 

                }

            }
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 그래프 순회 방법
            // DFS (Depth First Search 깊이 우선 탐색)
            // BFS (Breath First Search 너비 우선 탐색)

            Graph graph = new Graph();
            // graph.DFS(0);
            // graph.SearchAllDFS();
            graph.Dijikstra(0);



        }
    }
}

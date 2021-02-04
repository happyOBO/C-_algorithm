using System;
using System.Collections.Generic;


namespace Exercise
{

    class Graph
    {
        int[,] adj = new int[6, 6]
        {
            { 0, 1, 0, 1, 0, 0 },
            { 1, 0, 1, 1, 0, 0 },
            { 0, 1, 0, 0, 0, 0 },
            { 1, 1, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0, 1 },
            { 0, 0, 0, 0, 1, 0 },
        };

        List<int>[] adj2 = new List<int>[]
        {
            new List<int>() { 1, 3 },
            new List<int>() { 0, 2, 3 },
            new List<int>() { 1},
            new List<int>() { 0, 1, 4 },
            new List<int>() { 3, 5 },
            new List<int>() { 4 },
        };

        bool[] visited = new bool[6];
        // 1) 우선 now부터 방문하고
        // 2) now와 연결된 정점들을 하나씩 확인해서, [아직 미방문 상태라면] 방문한다.
        public void DFS(int now)
        {
            Console.WriteLine(now);
            visited[now] = true;

            for (int next = 0; next <6; next++)
            {
                if (adj[now, next] == 0) // 연결되어있지 않으면 skip
                    continue;
                if (visited[next]) // 이미 방문 했으면 skip
                    continue;
                DFS(next);
            }
        }
        public void DFS2(int now)
        {
            Console.WriteLine(now);
            visited[now] = true;

            foreach(int next in adj2[now])
            {
                if (visited[next]) // 이미 방문 했으면 skip
                    continue;
                DFS2(next);
            }
        }

        public void SearchAllDFS()
        {
            visited = new bool[6];
            for (int now = 0; now < 6; now++)
                if (visited[now] == false)
                    DFS(now);
        }
        

        public void BFS(int start)
        {
            bool[] found = new bool[6];

            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            found[start] = true;
            while(q.Count > 0)
            {
                int now = q.Dequeue();
                Console.WriteLine(now);
                for (int next = 0; next < 6; next++)
                {
                    if (adj[now, next] == 0)
                        continue;
                    if (found[next])
                        continue;
                    q.Enqueue(next);
                    found[next] = true;

                }

            }
        }

        public void BFS2(int start)
        {
            bool[] found = new bool[6];

            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            found[start] = true;
            while (q.Count > 0)
            {
                int now = q.Dequeue();
                Console.WriteLine(now);
                foreach (int next in adj2[now])
                {
                    if (found[next])
                        continue;
                    q.Enqueue(next);
                    found[next] = true;

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
            graph.BFS2(0);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 创建邻接矩阵无向图
/// </summary>
public class Table {
    char[] vexs = {'A', 'B', 'C', 'D', 'E', 'F', 'G','H'};

    private char[,] edges = {
        {'A', 'C'}, 
        {'A', 'D'}, 
        {'A', 'F'}, 
        {'B', 'C'}, 
        {'C', 'D'}, 
        {'D', 'H'}, 
        {'E', 'G'}, 
        {'F', 'G'},
    };

    public void Create() {
        var materixUDG = new MatrixUDG(vexs,edges);
        materixUDG.Print();
        materixUDG.DFS();
        materixUDG.BFS();
    }
}

/// <summary>
/// 邻接矩阵无向图
/// </summary>
public class MatrixUDG {
    public char[] vexs; // 顶点集合
    public int vexNum; // 顶点数
    public int edgNum; // 边数
    public int[,] matrix; // 邻接矩阵

    StringBuilder str = new StringBuilder();
    public MatrixUDG(char[] vexs, char[,] edges) {
        edgNum = edges.Length / edges.Rank;
        vexNum = vexs.Length;
        this.vexs = new char[vexNum];
        for (int i = 0; i < vexNum; i++) {
            this.vexs[i] = vexs[i];
        }

        edgNum = edgNum;
        matrix = new int[edgNum, edgNum];
        for (int i = 0; i < edgNum; i++) {
            var p1 = GetPosition(edges[i,0]);
            var p2 = GetPosition(edges[i,1]);
            matrix[p1, p2] = 1;
            matrix[p2, p1] = 1;
        }
    }

    public void Print() {
        str.Clear();
        Console.WriteLine($"当前顶点数:{vexNum}");
        foreach (var ch in vexs) {
            str.Append(ch);
            str.Append(" ");
        }

        Console.WriteLine($"顶点:{str}");
        Console.WriteLine($"当前边数:{edgNum}");
        for (int i = 0; i < edgNum; i++) {
            str.Clear();
            for (int j = 0; j < edgNum; j++) {
                str.Append(matrix[i,j]);
                str.Append(" ");
            }
            Console.WriteLine(str);
        }
    }

    /// <summary>
    /// 深度优先遍历
    /// </summary>
    public void DFS() {
        str.Clear();
        var i = 0;
        var visited = new int[vexNum];
        
        for (int j = 0; j < vexNum; j++) {
            if (visited[j] == 0) {
                DFS(j, visited);
            }
        }
        Console.WriteLine($"DFS: {str}");
    }

    private void DFS(int i, int[] visited) {
        visited[i] = 1;
        str.Append(vexs[i]);
        str.Append("->");
        for (int j = GetFirstVertex(i); j >= 0; j = GetNextVertex(i, j)) {
            if (visited[j] == 0) {
                DFS(j, visited);
            }
        }
    }

    /// <summary>
    /// 返回首个接触点
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    private int GetFirstVertex(int v) {
        if (v < 0 || v > (vexNum - 1)) {
            return -1;
        }

        for (int i = 0; i < vexNum; i++) {
            if (matrix[v,i] == 1) {
                return i;
            }
        }

        return -1;
    }

    /// <summary>
    /// 返回顶点 v 相对于 w 的下一个临界顶点的索引
    /// </summary>
    /// <param name="v"></param>
    /// <param name="w"></param>
    /// <returns></returns>
    private int GetNextVertex(int v, int w) {
        if (v < 0 || v > (vexNum - 1)) {
            return -1;
        }

        if (w < 0 || w > (vexNum - 1)) {
            return -1;
        }

        for (int i = w + 1; i < vexNum; i++) {
            if (matrix[v, i] == 1) {
                return i;
            }
        }

        return -1;
    }

    /// <summary>
    /// 广度优先遍历
    /// </summary>
    public void BFS() {
        str.Clear();
        str.Append("BFS: ");
        var visited = new int[vexNum];
        BFS(0, visited);
        Console.WriteLine(str);
    }

    private void BFS(int vex, int[] visited) {
        if (visited[vex] == 0) {
            visited[vex] = 1;
            str.Append(vexs[vex]);
            str.Append("->");
        }
        var allPoint = GetAllPoint(vex, visited);
        var num = allPoint.Length;
        if (num <= 0) {
            return;
        }

        var list = new List<int>();
        for (int i = 0; i < num; i++) {
            var count = allPoint[i];
            visited[count] = 1;
            list.Add(count);
            str.Append(vexs[count]);
            str.Append("->");
        }

        if (list.Count > 0) {
            for (int i = 0; i < list.Count; i++) {
                BFS(list[i], visited);
            }
        }
    }

    /// <summary>
    /// 获取当前顶点所有接触点
    /// </summary>
    /// <param name="vex"></param>
    /// <returns></returns>
    private int[] GetAllPoint(int vex, int[] visited) {
        var list = new List<int>();
        for (int i = 0; i < vexNum; i++) {
            if (matrix[vex, i] == 1 && visited[i] == 0) {
                list.Add(i);
            }
        }
        return list.ToArray();
    }

    private int GetPosition(char ch) {
        for (int i = 0; i < vexNum; i++) {
            if (vexs[i] == ch) {
                return i;
            }
        }

        return -1;
    }
}

/// <summary>
/// 邻接表无向图
/// </summary>
public class ListUDG {
    public int vexNum; // 顶点数
    public int[] vexs; // 顶点数组
    public ListUDGNode[] listArrays; // 链表地址

    public class ListUDGNode {
        public List<int> list { private set; get; }
        public int count => list.Count;

        public void AddNode(int vex) {
            if (!list.Contains(vex)) {
                list.Add(vex);
            }
        }
        
        
    }
}
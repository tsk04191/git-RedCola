using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sysAStar
{
    private Node[,] gridMap;
    private bool[,] gridBarricade;

    public void Set(int x, int y)
    {
        gridMap = new Node[x, y];
        gridBarricade = new bool[x, y];

        for(int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                gridMap[i, j] = new Node();

                gridMap[i, j].x = i;
                gridMap[i, j].y = j;
            }
        }
    }

    public void AddBarricade(int x, int y)
    {
        gridBarricade[x, y] = true;
    }

    public bool GetBarricade(int x, int y)
    {
        return gridBarricade[x, y];
    }
}

public class Node
{
    public int x;
    public int y;
    public int gCost;
    public int hCost;
    public int FCost { get { return gCost + hCost; } }

    public Node parent;
}
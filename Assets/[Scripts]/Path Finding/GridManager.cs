using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Vector2Int gridSize;
    private Dictionary<Vector2Int, Node> _grid = new Dictionary<Vector2Int, Node>();

    private void Awake()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                Vector2Int coordinates = new Vector2Int(i, j);
                _grid.Add(coordinates, new Node(coordinates, true));
                print($"{_grid[coordinates].coordinates} {_grid[coordinates].isWalkable}");
            }
        }
    }
}
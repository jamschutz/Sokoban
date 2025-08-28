using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
[RequireComponent(typeof(TilemapCollider2D))]
[RequireComponent(typeof(Grid))]
public class GridController : MonoBehaviour
{
    private Tilemap tilemap;
    private Grid grid;


    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
        grid = GetComponent<Grid>();
    }


    public Vector3 GridToWorldPos(int x, int y)
    {
        return grid.CellToWorld(new Vector3Int(x, y, 0));
    }
}

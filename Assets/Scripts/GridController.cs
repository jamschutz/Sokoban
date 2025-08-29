using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes.Test;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Grid))]
public class GridController : MonoBehaviour
{
    // singleton instance
    public static GridController instance;

    private Grid _grid;
    private Tilemap _boxesTilemap;

    private TileBase[] _blocks;


    private void Awake()
    {
        // instance already exists -- can only be one singleton!
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        GridController.instance = this;
        _grid = GetComponent<Grid>();
        _boxesTilemap = transform.Find("Blocks").GetComponent<Tilemap>();
        _blocks = _boxesTilemap.GetTilesBlock(_boxesTilemap.cellBounds);
    }


    public Vector3 GridToWorldPos(int x, int y)
    {
        return _grid.CellToWorld(new Vector3Int(x, y, 0));
    }


    public ObjectType GetObjectInCell(int x, int y)
    {
        var tile = _boxesTilemap.GetTile(new Vector3Int(x, y, 0));
        if(tile == null) {
            return ObjectType.Empty;
        }
        if(tile.name == "Box") {
            Debug.Log("hit box");
            return ObjectType.Box;
        }
        if(tile.name == "Wall") {
            Debug.Log("hit wall");
            return ObjectType.Wall;
        }
        return ObjectType.Empty;
    }
}


public enum ObjectType { Player, Box, Wall, Empty }

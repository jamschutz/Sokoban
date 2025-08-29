using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes.Test;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Grid))]
public class GridController : MonoBehaviour
{
    public TileSprite[] _tiles;

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
            return ObjectType.Box;
        }
        if(tile.name == "Wall") {
            return ObjectType.Wall;
        }
        return ObjectType.Empty;
    }


    public bool CanPushBlock(int x, int y)
    {
        return true;
    }


    public void PushBlock(Vector3Int start, Vector3Int dest)
    {
        // if there's a block in our destination, push it!
        if(GetObjectInCell(dest.x, dest.y) != ObjectType.Empty) {
            var dir = dest - start;
            PushBlock(dest, dest + dir);
        }

        // set starting position empty
        _boxesTilemap.SetTile(start, GetTile(ObjectType.Empty));
        // and set destination to the box
        _boxesTilemap.SetTile(dest, GetTile(ObjectType.Box));
    }


    private Tile GetTile(ObjectType type)
    {
        foreach(var t in _tiles) {
            if(t.type == type)
                return t.tile;
        }

        Debug.Log($"couldn't find tile for {type.ToString()} -- did you forget to update the GridController?");
        return _tiles[0].tile;
    }
}


public enum ObjectType { Player, Box, Wall, Empty }

[System.Serializable]
public class TileSprite
{
    public ObjectType type;
    public Tile tile;
}
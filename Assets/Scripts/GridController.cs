using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Grid))]
public class GridController : MonoBehaviour
{
    // singleton instance
    public static GridController instance;

    private Grid _grid;


    private void Start()
    {
        // instance already exists -- can only be one singleton!
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        GridController.instance = this;
        _grid = GetComponent<Grid>();
    }


    public Vector3 GridToWorldPos(int x, int y)
    {
        return _grid.CellToWorld(new Vector3Int(x, y, 0));
    }
}

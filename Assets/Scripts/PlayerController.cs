using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int _x;
    private int _y;

    private void Start() {
        _x = 0;
        _y = 0;
        Move(0, 0);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            Move(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            Move(0, -1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Move(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Move(1, 0);
        }

    }


    private void Move(int x, int y)
    {
        _x += x;
        _y += y;
        transform.position = GridController.instance.GridToWorldPos(_x, _y);
    }
}

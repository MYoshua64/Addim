using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    const int moveLimit = 2;
    Vector2 initialPos;
    Board board;

    private void Start()
    {
        board = FindObjectOfType<Board>();
        board.SetTileEmptyState(transform.position, false);
    }

    private void OnMouseDown()
    {
        initialPos = transform.position;
        board.DisplaySurroundingTiles(initialPos);
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
    }

    private void OnMouseUp()
    {
        FindObjectOfType<Board>().ResetTileColors();
        Vector2 newPos;
        newPos.x = Mathf.RoundToInt(transform.position.x);
        newPos.y = Mathf.RoundToInt(transform.position.y);
        if (TileIsValid(newPos))
        {
            if (newPos.x == 0)
            {
                newPos.x = 6;
            }
            else if (newPos.x == 7)
            {
                newPos.x = 1;
            }
            board.SetTileEmptyState(initialPos, true);
            board.SetTileEmptyState(newPos, false);
            transform.position = newPos;
        }
        else
        {
            transform.position = initialPos;
        }
    }

    private bool TileInRange(Vector2 tilePos)
    {
        Vector2 directionVector = tilePos - initialPos;
        return Mathf.Abs(directionVector.magnitude) <= Mathf.Sqrt(2);
    }

    private bool TileIsValid(Vector2 position)
    {
        return TileInRange(position) && board.ReturnTileEmptyState(position);
    }
}

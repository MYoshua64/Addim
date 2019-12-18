using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    const int moveLimit = 2;
    Vector2 initialPos;

    private void OnMouseDown()
    {
        initialPos = transform.position;
        FindObjectOfType<Board>().DisplaySurroundingTiles(initialPos);
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
    }

    private void OnMouseUp()
    {
        Vector2 newPos;
        newPos.x = Mathf.RoundToInt(transform.position.x);
        newPos.y = Mathf.RoundToInt(transform.position.y);
        transform.position = newPos;
    }
}

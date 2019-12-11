using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField] Text tileNumberUpper;
    [SerializeField] Text tileNumberLower;
    public int x { get; set; }
    public int y { get; set; }
    Color tileColor;
    public Color color
    {
        get
        {
            return tileColor;
        }
        set
        {
            tileColor = value;
            GetComponent<SpriteRenderer>().color = value;
        }
    }
    int number;
    public int Number
    {
        get
        {
            return number;
        }
        set
        {
            number = value;
            tileNumberUpper.text = tileNumberLower.text = value.ToString();
        }
    }

    private void Awake()
    {
        x = Mathf.FloorToInt(transform.position.x);
        y = Mathf.FloorToInt(transform.position.y);
    }
}

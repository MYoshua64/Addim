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
    Color initialColor;
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
            if (initialColor == new Color32(0,0,0,0))
            {
                initialColor = tileColor;
            }
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

    public void ResetColor()
    {
        if (color != initialColor)
        {
            color = initialColor;
        }
    }
}

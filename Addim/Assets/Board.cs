using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Tile[] tiles;
    Tile[,] boardTiles = new Tile[4, 6];
    int[] numberLimit = new int[5];
    int[] colorLimit = new int[2];
    Color[] possibleColors = new Color[2] { Color.red, new Color32(0, 166, 0, 255) };

    void Start()
    {
        foreach (Tile tile in tiles)
        {
            boardTiles[tile.y - 2, tile.x - 1] = tile;
        }
        RandomizeBoard();
    }

    void RandomizeBoard()
    {
        foreach (Tile tile in tiles)
        {
            tile.Number = RandomizeNumber();
        }
        for (int y = 0; y < boardTiles.GetLength(0); y++)
        {
            for (int x = 0; x < boardTiles.GetLength(1); x++)
            {
                RandomizeColor(boardTiles[y, x]);
            }
        }
    }

    private void RandomizeColor(Tile tile)
    {
        int randomNum = 0;
        bool valid = false;
        do
        {
            randomNum = UnityEngine.Random.Range(0, 2);
            if (IsValid(randomNum, tile))
            {
                valid = true;
                colorLimit[randomNum]++;
            }

        } while (!valid);
        tile.color = possibleColors[randomNum];
    }

    private bool IsValid(int randomNum, Tile tile)
    {
        return colorLimit[randomNum] < 12 && GetColorInRow(possibleColors[randomNum], tile.y) < 4 &&
            GetColorInColumn(possibleColors[randomNum], tile.x) < 2;
    }

    private int RandomizeNumber()
    {
        int randomNum = 0;
        bool valid = false;
        do
        {
            randomNum = UnityEngine.Random.Range(1, 6);
            if (numberLimit[randomNum - 1] < 5)
            {
                valid = true;
                numberLimit[randomNum - 1]++;
            }
        } while (!valid);
        return randomNum;
    }

    int GetColorInRow(Color color, int y)
    {
        int counter = 0;
        for (int x = 0; x < boardTiles.GetLength(1); x++)
        {
            if (boardTiles[y - 2, x].color == color)
            {
                counter++;
            }
        }
        return counter;
    }

    int GetColorInColumn(Color color, int x)
    {
        int counter = 0;
        for (int y = 0; y < boardTiles.GetLength(0); y++)
        {
            if (boardTiles[y, x - 1].color == color)
            {
                counter++;
            }
        }
        return counter;
    }
}

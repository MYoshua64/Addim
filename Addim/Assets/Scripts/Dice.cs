using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public GameObject [] Numbers = new GameObject [4];
    public int [] DiceNumbers = new  int [4];
    public GameObject buttonRoll;
    public GameObject ButtonPlay;


    // Update is called once per frame
    void Start()
    {
        dice();
    }

    public void ButtonRollAgain()
    {
        dice();
        buttonRoll.SetActive(false);
        ButtonPlay.SetActive(false);
    }

    void dice()
    {
        for (int i = 0; i < DiceNumbers.Length; i++)
        {
            DiceNumbers[i] = UnityEngine.Random.Range(49, 55);
            if (DiceNumbers[i] == 54)
            {
                DiceNumbers[i] = 88;
            }
            Numbers[i].GetComponent<Text>().text = Convert.ToChar(DiceNumbers[i]).ToString();
        }
    }
}

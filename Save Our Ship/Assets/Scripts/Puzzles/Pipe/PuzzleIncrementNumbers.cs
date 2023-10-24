using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzleIncrementNumbers : MonoBehaviour, ISelectable
{
    [SerializeField] TextMeshProUGUI text;
    int num = 0;

    public void Select()
    { 
        if (num < 9)
        {
            num++;
        } 
        else
        {
            num = 0;
        }
        text.SetText(num.ToString());
    }
}

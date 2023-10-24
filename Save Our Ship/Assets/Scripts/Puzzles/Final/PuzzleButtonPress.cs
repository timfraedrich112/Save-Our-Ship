using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButtonPress : MonoBehaviour, ISelectable
{
    [SerializeField] int row, num;

    Renderer ren;

    void Start()
    {
        ren = GetComponent<Renderer>();
    }

    public void Select()
    {
        FinalPuzzle.instance.ButtonPress(row, num, ren);
    }
}
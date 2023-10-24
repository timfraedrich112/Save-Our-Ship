using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : MonoBehaviour, ISelectable
{
    [SerializeField] int num;

    public void Select()
    {
        PaperPuzzle.instance.Input(num);
    }
}

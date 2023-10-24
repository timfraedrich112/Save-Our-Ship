using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleKeypadEnter : MonoBehaviour, ISelectable
{
    public void Select()
    {
        DecodePuzzle.instance.Check();
    }
}

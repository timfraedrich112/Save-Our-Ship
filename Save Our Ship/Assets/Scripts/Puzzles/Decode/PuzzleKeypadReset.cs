using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleKeypadReset : MonoBehaviour, ISelectable
{
    public void Select()
    {
        DecodePuzzle.instance.ResetKeypad();
    }
}

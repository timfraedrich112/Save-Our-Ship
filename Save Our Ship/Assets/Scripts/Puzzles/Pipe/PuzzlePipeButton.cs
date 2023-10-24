using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePipeButton : MonoBehaviour, ISelectable
{
    public void Select()
    {
        PipePuzzle.instance.Check();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLightInput : MonoBehaviour, ISelectable
{
    [SerializeField] int num;

    public void Select()
    {
        KeyPuzzle.instance.Input(num);
    }
}

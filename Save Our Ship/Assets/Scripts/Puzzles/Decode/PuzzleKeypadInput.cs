using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleKeypadInput : MonoBehaviour, ISelectable
{
    [SerializeField] char num;

    public void Select()
    {
        DecodePuzzle.instance.EnterNum(num);
    }
}

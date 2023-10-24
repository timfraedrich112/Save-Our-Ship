using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStartSimonSays : MonoBehaviour, ISelectable
{
    public void Select()
    {
        KeyPuzzle.instance.StartGame();
    }
}

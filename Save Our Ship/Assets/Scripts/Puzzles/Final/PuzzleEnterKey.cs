using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEnterKey : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Keyhole"))
        {
            FinalPuzzle.instance.Check();
        }
    }
}

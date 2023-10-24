using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalPuzzle : MonoBehaviour
{
    public static FinalPuzzle instance;

    public static Action gameSuccess;

    [SerializeField] Light completeLight;
    [SerializeField] AudioSource buttonSound;
    [SerializeField] AudioSource completeSound;

    [SerializeField] Material pressedMat, unpressedMat;
    int[] currentSelectionNums = new int[4];
    Renderer[] currentSelectionRens = new Renderer[4];
 
    void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this);
    }

    public void ButtonPress(int row, int newInput, Renderer newSelection) 
    {
        buttonSound.Play();
        if (currentSelectionRens[row] != null)
        {
            currentSelectionRens[row].material = unpressedMat;
        }
        currentSelectionNums[row] = newInput;
        currentSelectionRens[row] = newSelection;
        currentSelectionRens[row].material = pressedMat;
    }

    public void Check()
    {
        if (currentSelectionNums[1] == 7 &&
            currentSelectionNums[2] == 4 &&
            currentSelectionNums[3] == 6)
        {
            Complete();
        }
    }

    void Complete()
    {
        completeLight.color = Color.green;
        completeSound.Play();

        gameSuccess?.Invoke();
    }
}

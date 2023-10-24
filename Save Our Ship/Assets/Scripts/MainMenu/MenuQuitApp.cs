using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuQuitApp : MonoBehaviour, ISelectable
{
    public void Select()
    {
        Application.Quit();
    }
}

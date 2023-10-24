using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlayGame : MonoBehaviour, ISelectable
{
    public void Select()
    {
        SceneManager.LoadScene("Main");
    }
}

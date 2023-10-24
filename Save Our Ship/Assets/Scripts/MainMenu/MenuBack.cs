using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBack : MonoBehaviour, ISelectable
{
    [SerializeField] Canvas mainMenu;

    public void Select()
    {
        mainMenu.gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}

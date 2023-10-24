using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAskQuit : MonoBehaviour, ISelectable
{
    [SerializeField] Canvas quitMenu;

    public void Select()
    {
        quitMenu.gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}

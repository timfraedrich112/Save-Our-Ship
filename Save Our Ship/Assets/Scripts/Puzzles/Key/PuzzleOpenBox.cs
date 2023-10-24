using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOpenBox : MonoBehaviour
{
    [SerializeField] string animString;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenBox()
    {
        animator.SetTrigger(animString);
    }
}

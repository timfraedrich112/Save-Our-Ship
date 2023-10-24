using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRevealDecoder : MonoBehaviour
{
    [SerializeField] Canvas image;
    void Start()
    {
        image.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Decoder"))
        {
            image.gameObject.SetActive(true);
        }
    }
}

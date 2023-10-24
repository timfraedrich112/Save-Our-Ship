using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PipePuzzle : MonoBehaviour
{
    public static PipePuzzle instance;

    [SerializeField] Light completeLight;
    [SerializeField] AudioSource buttonSound;
    [SerializeField] AudioSource completeSound;

    [SerializeField] TextMeshProUGUI red, yellow, blue, reward;

    void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this);
    }

    void Start()
    {
        reward.gameObject.SetActive(false);
    }

    public void Check()
    {
        buttonSound.Play();
        if (red.text == "7" && 
            yellow.text == "2" && 
            blue.text == "5")
        {
            Complete();
        }
    }

    void Complete()
    {
        red.color = Color.green;
        red.gameObject.GetComponent<Collider>().enabled = false;
        yellow.color = Color.green;
        yellow.gameObject.GetComponent<Collider>().enabled = false;
        blue.color = Color.green;
        blue.gameObject.GetComponent<Collider>().enabled = false;

        completeLight.color = Color.green;
        completeSound.Play();
        reward.gameObject.SetActive(true);
    }
}

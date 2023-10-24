using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PaperPuzzle : MonoBehaviour
{
    public static PaperPuzzle instance;

    [SerializeField] Light completeLight;
    [SerializeField] AudioSource buttonSound;
    [SerializeField] AudioSource completeSound;

    [SerializeField] TextMeshProUGUI reward;

    public List<int> inputs;

    void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this);
    }

    void Start()
    {
        reward.gameObject.SetActive(false);
        inputs = new List<int>();
    }

    public void Input(int num)
    {
        buttonSound.Play();
        inputs.Add(num);
        if (inputs.Count > 6)
        {
            inputs.Remove(inputs[0]);
        }
        else if (inputs.Count > 5)
        {
            Check();
        }
    }

    void Check()
    {
        if (inputs[0] == 2 &&
            inputs[1] == 9 &&
            inputs[2] == 7 &&
            inputs[3] == 6 &&
            inputs[4] == 4 &&
            inputs[5] == 3)
        {
            Complete();
        }
    }

    void Complete()
    {
        completeLight.color = Color.green;
        completeSound.Play();
        reward.gameObject.SetActive(true);
    }
}

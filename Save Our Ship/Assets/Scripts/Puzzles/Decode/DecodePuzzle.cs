using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DecodePuzzle : MonoBehaviour
{
    public static DecodePuzzle instance;

    [SerializeField] Light completeLight;
    [SerializeField] AudioSource buttonSound;
    [SerializeField] AudioSource completeSound;

    [SerializeField] TextMeshProUGUI keypad, reward;

    char[] inputs;
    int current = 0;

    void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this);
    }

    void Start()
    {
        reward.gameObject.SetActive(false);
        inputs = new char[5];
        ResetKeypad();
        keypad.SetText(inputs);
    }

    public void EnterNum(char num)
    {
        if (current < inputs.Length)
        {
            buttonSound.Play();
            inputs[current] = num;
            current++;
        }
        keypad.SetText(inputs);
    }

    public void ResetKeypad()
    {
        current = 0;
        for (int i = 0; i < inputs.Length; i++)
        {
            inputs[i] = '_';
        }
        keypad.SetText(inputs);
        buttonSound.Play();
    }

    public void Check()
    {
        if (inputs[0] == '5' &&
            inputs[1] == '6' &&
            inputs[2] == '2' &&
            inputs[3] == '3' &&
            inputs[4] == '9')
        {
            Complete();
        }
        ResetKeypad();
    }

    void Complete()
    {
        keypad.gameObject.SetActive(false);

        completeLight.color = Color.green;
        completeSound.Play();
        reward.gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class KeyPuzzle : MonoBehaviour
{
    public static KeyPuzzle instance;

    [SerializeField] AudioSource failSound;
    [SerializeField] AudioSource completeSound;

    [SerializeField] PuzzleOpenBox reward;
    [SerializeField] Collider onSwitch;
    [SerializeField] public GameObject[] lights = new GameObject[3];
    [SerializeField] float flashSpeed;
    [SerializeField] float waitSpeed;
    [SerializeField] int[] flashOrder = new int[8];

    int rounds;
    bool correct = false;
    List<int> inputList = new List<int>();
    int inputCount = 0;
    int currentRound = 0;

    void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this);
    }

    void Start()
    {
        //reward.gameObject.SetActive(false);
        rounds = flashOrder.Length;
        foreach (GameObject light in lights)
        {
            light.GetComponentInParent<Collider>().enabled = false;
        }
    }

    public void StartGame()
    {
        onSwitch.enabled = false;
        foreach (GameObject light in lights)
        {
            light.SetActive(false);
        }
        StartCoroutine(nameof(SimonSays));
    }

    IEnumerator SimonSays() 
    {
        for (int i = 0; i < rounds; i++)
        {
            yield return new WaitForSeconds(waitSpeed * 2);
            currentRound = i;
            for (int j = 0; j <= i; j++) //flash lights
            {
                lights[flashOrder[j]].SetActive(true);
                yield return new WaitForSeconds(flashSpeed);
                lights[flashOrder[j]].SetActive(false);
                yield return new WaitForSeconds(waitSpeed);
            }
            foreach (GameObject light in lights)
            {
                light.GetComponentInParent<Collider>().enabled = true;
            }
            while (!correct) //wait for inputs
            {
                yield return null;
            }
            correct = false;
            foreach (GameObject light in lights)
            {
                light.GetComponentInParent<Collider>().enabled = false;
            }
        }
        Complete();
    }

    public void Input(int num)
    {
        inputList.Add(num);
        StartCoroutine(nameof(Check));
    }

    IEnumerator Check()
    {
        if (flashOrder[inputCount] == inputList[inputCount])
        {
            lights[flashOrder[inputCount]].SetActive(true);
            yield return new WaitForSeconds(flashSpeed / 2f);
            lights[flashOrder[inputCount]].SetActive(false);
            yield return new WaitForSeconds(waitSpeed / 2f);

            if (inputCount == currentRound)
            {
                inputList.Clear();
                inputCount = 0;
                correct = true;
            }
            else
            {
                inputCount++;
            }
        }
        else
        {
            EndGame();
        }
    }
    
    void EndGame()
    {
        StopCoroutine(nameof(SimonSays));
        inputList.Clear();
        inputCount = 0;
        currentRound = 0;
        onSwitch.enabled = true;
        foreach (GameObject light in lights)
        {
            light.GetComponentInParent<Collider>().enabled = false;
        }
        foreach (GameObject light in lights)
        {
            light.SetActive(true);
        }
        failSound.Play();
    }

    void Complete()
    {
        foreach (GameObject light in lights)
        {
            light.GetComponentInParent<Collider>().enabled = false;
        }
        foreach (GameObject light in lights)
        {
            light.SetActive(true);
        }

        completeSound.Play();
        reward.OpenBox();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float startTime;
    [SerializeField] AudioSource loseSound;
    [SerializeField] float waitTime = 4f;

    float currentTime;
    string min;
    string sec;
   
    bool gameState = false;

    void Start()
    {
        currentTime = startTime;
        gameState = true;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        SetTimerText();
        if (currentTime < 0 && gameState == true) 
        {
            gameState = false;
            StartCoroutine(nameof(LoseSequence));
        }
    }

    void SetTimerText()
    {
        if (currentTime > 0)
        {
            min = ((int)currentTime / 60).ToString("00");
            sec = (currentTime % 60).ToString("00.00");
            timerText.text = min + ":" + sec;
        }
        else
        {
            timerText.text = "00:00.00";
        }
    }

    IEnumerator LoseSequence()
    {
        loseSound.Play();
        foreach (GameObject light in KeyPuzzle.instance.lights)
        {
            light.SetActive(false);
        }
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Lose");
    }

    IEnumerator WinSequence()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Win");
    }

    void OnEnable()
    {
        FinalPuzzle.gameSuccess += Complete;
    }

    void Complete()
    {
        StartCoroutine(nameof(WinSequence));
    }

    void OnDisable()
    {
        FinalPuzzle.gameSuccess -= Complete;
    }
}
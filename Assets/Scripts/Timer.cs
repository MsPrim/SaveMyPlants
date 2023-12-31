using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public bool isGameActive;

    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {                 
        //Make the countdown. If countdown is true, then time.deltaTime. If false then..
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;


        if(hasLimit && (countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
            if(currentTime == 0)
            {
                GameWon();
            }
        }

        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0");
    }
    public void GameWon()
    {
        //gameOverText.gameObject.SetActive(true);
        CancelInvoke();
        isGameActive = false;
        SceneManager.LoadScene("YouWinScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI timeText;
    // public TextMeshProUGUI gameOverText;
    // public GameObject titleScreen;
    // public Button restartButton;

    private float timeLeft = 120;
    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        UpdateTimer(timeLeft);
    }

    // Update is called once per frame
    void Update()
    {
        // Countdown seconds while the time left is greater than 0 second(s), and game is active
        if (isGameActive)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                timeLeft = 0;
                GameOver();
            }
        }
    }

    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
        // gameOverText.gameObject.SetActive(true);
        // restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void UpdateTimer(float timeLeft)
    {
        int minutesLeft = Mathf.FloorToInt(timeLeft / 60);
        float secondsLeft = Mathf.Round(timeLeft % 60);

        timeText.text = string.Format("{0:00} : {1:00}", minutesLeft, secondsLeft);
    }
}

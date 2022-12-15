using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI timeText, gameOverText, levelCompletedText;
    // public GameObject titleScreen;
    public Button restartButton;

    private float timeLeft = 120;
    public static bool isGameActive, levelCompleted, gameOver;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        levelCompleted = gameOver = false;
        Time.timeScale = 1;
        levelCompletedText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        UpdateTimer(timeLeft);
    }

    // Update is called once per frame
    void Update()
    {
        // Start a level; disable UI components irrelevant to gameplay
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && !isGameActive)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;

            isGameActive = true;
            levelCompletedText.gameObject.SetActive(false);
            gameOverText.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(false);
        }

        if (levelCompleted)
        {
            Debug.Log("Level completed!");
            LevelComplete();
        }
        
        if (gameOver)
        {
            Debug.Log("Game Over!");
            GameOver();
        }

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
    private void GameOver()
    {
        Time.timeScale = 0;
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    // Restart Level 0
    private void LevelComplete()
    {
        Time.timeScale = 0;
        isGameActive = false;
        levelCompletedText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void UpdateTimer(float timeLeft)
    {
        int minutesLeft = Mathf.FloorToInt(timeLeft / 60);
        float secondsLeft = Mathf.Round(timeLeft % 60);

        timeText.text = string.Format("{0:00} : {1:00}", minutesLeft, secondsLeft);
    }
}

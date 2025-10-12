using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // public
    public bool gameRunning = true;
    public GameObject pauseButton;
    public GameObject gamePausedPanel;

    // SerializeField

    // private

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GamePaused()
    {
        Time.timeScale = 0;
        pauseButton.gameObject.SetActive(false);
        gamePausedPanel.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        gamePausedPanel.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gameRunning = false;
    }

    public void GameWinning()
    {
        gameRunning = false;
    }
}

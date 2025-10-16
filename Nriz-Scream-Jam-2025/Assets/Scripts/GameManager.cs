using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // public
    public bool gameRunning = true;
    public bool gamePaused = false;

    // SerializeField
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject gamePausedPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject gameWinPanel;
    [SerializeField] AudioSource gameAudio;
    [SerializeField] AudioSource buttonsAudio;
    [SerializeField] AudioSource gameOverAudio;
    [SerializeField] AudioSource gameWinningAudio;
    
    // private 
    private float audioDelay = 0.2f;

    public void GamePaused()
    {
        buttonsAudio.PlayOneShot(buttonsAudio.clip, 1f);
        Time.timeScale = 0;
        pauseButton.gameObject.SetActive(false);
        gamePausedPanel.gameObject.SetActive(true);
        gamePaused = true;
        gameAudio.Stop();
    }

    public void ResumeGame()
    {
        buttonsAudio.PlayOneShot(buttonsAudio.clip, 1f);
        gamePausedPanel.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        Time.timeScale = 1;
        gamePaused = false;
        gameAudio.Play();
    }

    public void GameOver()
    {
        gameAudio.Stop();
        gameOverAudio.PlayOneShot(gameOverAudio.clip, 1f);
        gameRunning = false;
        gameOverPanel.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    public void GameWinning()
    {
        gameAudio.Stop();
        gameWinningAudio.PlayOneShot(gameWinningAudio.clip, 1f);
        gameRunning = false;
        gameWinPanel.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    public void GoBackToMenu()
    {
        buttonsAudio.PlayOneShot(buttonsAudio.clip, 1f);
        StartCoroutine(BackToMenuAudio());
    }

    private IEnumerator BackToMenuAudio()
    {
        yield return new WaitForSeconds(audioDelay);
        SceneManager.LoadScene("Menu Scene");
    }
}
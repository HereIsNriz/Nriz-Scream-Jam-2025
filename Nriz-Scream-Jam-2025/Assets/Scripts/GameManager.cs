using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // public
    public bool gameRunning = true;

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

    private void GamePaused()
    {
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
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

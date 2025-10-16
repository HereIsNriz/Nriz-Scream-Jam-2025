using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] AudioSource buttonAudio;

    private float audioDelay = 0.2f;

    public void PlayButton()
    {
        buttonAudio.PlayOneShot(buttonAudio.clip, 1f);
        StartCoroutine(PlayButtonCouroutine());
    }

    public void ExitButton()
    {
        buttonAudio.PlayOneShot(buttonAudio.clip, 1f);
        StartCoroutine(ExitButtonCouroutine());
    }

    private IEnumerator PlayButtonCouroutine()
    {
        yield return new WaitForSeconds(audioDelay);
        SceneManager.LoadScene("Game Scene");
    }

    private IEnumerator ExitButtonCouroutine()
    {
        yield return new WaitForSeconds(audioDelay);
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
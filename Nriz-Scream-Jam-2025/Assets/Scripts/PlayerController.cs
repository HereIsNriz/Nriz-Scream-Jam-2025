using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // public
    public bool visibleByEnemy;

    // SerializeField
    [SerializeField] float playerSpeed;
    [SerializeField] int keyCollected;
    [SerializeField] TextMeshProUGUI keysCollectedText;
    [SerializeField] AudioSource keysCollectedAudio;

    // private
    private GameManager gameManager;
    private Rigidbody2D playerRb;
    private int totalKeys = 20;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();   
        playerRb = GetComponent<Rigidbody2D>();

        visibleByEnemy = true;
        keyCollected = 0;
        keysCollectedText.text = string.Format("Keys Collected: {0:00} / {1}", keyCollected, totalKeys);
    }

    private void FixedUpdate()
    {
        if (gameManager.gameRunning)
        {
            MovePlayer();
            if (gameManager.gamePaused)
            {
                keysCollectedText.gameObject.SetActive(false);
            }
            else
            {
                keysCollectedText.gameObject.SetActive(true);
            }
        }
        else
        {
            playerRb.velocity = Vector3.zero;
            keysCollectedText.gameObject.SetActive(false);
        }
    }

    private void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 playerMoving = new Vector2(horizontalInput, verticalInput).normalized;

        playerRb.velocity = playerMoving * playerSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            keysCollectedAudio.PlayOneShot(keysCollectedAudio.clip, 1f);
            keyCollected++;
            Destroy(collision.gameObject);
            keysCollectedText.text = string.Format("Keys Collected: {0:00} / {1}", keyCollected, totalKeys);
        }

        if (collision.gameObject.CompareTag("Bush"))
        {
            visibleByEnemy = false;
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            gameManager.GameWinning();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bush"))
        {
            visibleByEnemy = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();
        }

        if (collision.gameObject.CompareTag("Door") && keyCollected == totalKeys)
        {
            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public
    public bool visibleByEnemy;

    // SerializeField
    [SerializeField] float playerSpeed;

    // private
    private GameManager gameManager;
    private Rigidbody2D playerRb;
    private int keyCollected;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();   
        playerRb = GetComponent<Rigidbody2D>();

        visibleByEnemy = true;
        keyCollected = 0;
    }

    private void FixedUpdate()
    {
        if (gameManager.gameRunning)
        {
            MovePlayer();
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
        
    }
}

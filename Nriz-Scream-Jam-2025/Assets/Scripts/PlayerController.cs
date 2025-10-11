using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public

    // SerializeField
    [SerializeField] float playerSpeed;

    // private
    private GameManager gameManager;
    private Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();   
        playerRb = GetComponent<Rigidbody2D>();
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

        Vector2 playerMoving = new Vector2(horizontalInput, verticalInput);

        playerRb.velocity = playerMoving * playerSpeed * Time.deltaTime;
    }
}

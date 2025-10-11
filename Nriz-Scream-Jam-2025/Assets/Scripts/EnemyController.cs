using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // public
    public GameObject player;

    // SerializeField
    [SerializeField] float enemySpeed;

    // private
    private GameManager gameManager;
    private PlayerController playerController;
    private Rigidbody2D enemyRb;
    private float boundary = 14.3f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        enemyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (gameManager.gameRunning)
        {
            if (playerController.visibleByEnemy)
            {
                EnemyChasingPlayer();
            }
            else
            {
                EnemyPatrolling();
            }
        }
    }

    private float RandomPosition()
    {
        return Random.Range(-boundary, boundary);
    }

    private void EnemyPatrolling()
    {
        Vector2 enemyPatrolling = new Vector2(RandomPosition(), RandomPosition()).normalized;

        enemyRb.velocity = enemyPatrolling * enemySpeed * Time.deltaTime;
    }

    private void EnemyChasingPlayer()
    {
        Vector2 enemyChasing = (player.transform.position - enemyRb.transform.position).normalized;

        enemyRb.velocity = enemyChasing * enemySpeed * Time.deltaTime;
    }
}

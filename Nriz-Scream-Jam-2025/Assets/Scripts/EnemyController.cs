using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // public
    public GameObject player;

    // SerializeField
    [SerializeField] float enemySpeed;
    [SerializeField] Vector2 enemyDestination;

    // private
    private GameManager gameManager;
    private PlayerController playerController;
    private Rigidbody2D enemyRb;
    private float boundary = 13f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        enemyRb = GetComponent<Rigidbody2D>();
        enemyDestination = SetEnemyPosition();
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
                int enemyPositionX = (int)enemyRb.transform.position.x;
                int enemyDestinationX = (int)enemyDestination.x;
                if (enemyPositionX == enemyDestinationX)
                {
                    enemyDestination = SetEnemyPosition();
                }
            }
        }
        else
        {
            enemyRb.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bush"))
        {
            enemyDestination = SetEnemyPosition();
        }
    }

    private float RandomPosition()
    {
        return Random.Range(-boundary, boundary);
    }

    private Vector2 SetEnemyPosition()
    {
        return new Vector2(RandomPosition(), RandomPosition());
    }

    private void EnemyPatrolling()
    {
        Vector2 enemyTargetPosition = (enemyDestination - (Vector2)enemyRb.transform.position).normalized;

        enemyRb.velocity = enemyTargetPosition * enemySpeed * Time.deltaTime;
    }

    private void EnemyChasingPlayer()
    {
        Vector2 enemyChasing = (player.transform.position - enemyRb.transform.position).normalized;

        enemyRb.velocity = enemyChasing * enemySpeed * Time.deltaTime;
    }
}

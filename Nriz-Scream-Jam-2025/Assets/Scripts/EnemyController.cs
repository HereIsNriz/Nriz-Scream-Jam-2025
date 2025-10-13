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
    private Vector2 enemyDestination;
    private float boundary = 14.3f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        enemyRb = GetComponent<Rigidbody2D>();
        enemyDestination = SetEnemyPosition().normalized;
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
        else
        {
            enemyRb.velocity = Vector3.zero;
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
        enemyRb.velocity = enemyDestination * enemySpeed * Time.deltaTime;
    }

    private void EnemyChasingPlayer()
    {
        Vector2 enemyChasing = (player.transform.position - enemyRb.transform.position).normalized;

        enemyRb.velocity = enemyChasing * enemySpeed * Time.deltaTime;
    }
}

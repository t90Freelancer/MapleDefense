using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask heroLayer;
    private Transform MapleTower;
    private Rigidbody2D rb;
    private EnemyState enemyState;
    public enum EnemyState
    {
        moving,
        attack,
    }

    private void OnEnable()
    {
        enemyState = EnemyState.moving; 
    }
    private void Start()
    {
        MapleTower = GameObject.Find("House").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void moveToTower()
    {
        if (enemyState == EnemyState.moving)
        {
            Vector3 direction = (MapleTower.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }      
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            moveToTower();
        }
    }

    private void Update()
    {
    //    checkMove();
    }
    private void checkMove()
    {
        Vector3 direction = MapleTower.position - transform.position;
        Vector2 checkDir = new Vector2(direction.x,direction.y).normalized;
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position,checkDir,heroLayer);
        if(hit.Length > 0 )
        {
            enemyState = EnemyState.attack;
        }
        else
        {
            enemyState = EnemyState.moving;
        }
    }

 

}

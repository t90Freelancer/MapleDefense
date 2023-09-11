using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform EnemyTower;
    private Rigidbody2D rb;    

    void Start()
    {
        EnemyTower = GameObject.Find("EnemyTower").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            SetAnim.HeroState state = GetComponent<SetAnim>().state;
            if(state == SetAnim.HeroState.moving)
            MoveToEnemyTower();
        }
    }

    private void MoveToEnemyTower()
    {
        Vector3 direction = (EnemyTower.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }
}
